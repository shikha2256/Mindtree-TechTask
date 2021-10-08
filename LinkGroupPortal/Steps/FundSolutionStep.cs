using LinkGroup.DemoTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LinkGroup.DemoTests.Steps
{
    [Binding]
    public sealed class FundSolutionStep
    {
        IWebDriver driver = new ChromeDriver();
        FundSolutionsPage fundSolutionsPage = null;

        [Given(@"I have opened the Found Solutions page")]
        public void GivenIHaveOpenedTheFoundSolutionsPage()
        {
            fundSolutionsPage = new FundSolutionsPage(driver);
            fundSolutionsPage.OpenURL();
        }

        [When(@"I view Funds")]
        public void WhenIViewFunds()
        {
            fundSolutionsPage.ShowFunds();
        }

        [Then(@"I can select the investment managers for (.*) investors")]
        public void ThenICanSelectTheInvestmentManagersForUKInvestors(string Jurisdiction)
        {

            bool status=fundSolutionsPage.getDynamicEmement(Jurisdiction.ToLower()).Displayed;
            Assert.AreEqual(true, status);

            //to check if link is working fine we can check if the link is giving 200 status code
            fundSolutionsPage.TestHttpStatusCodeAsync($"https://www.linkfundsolutions.co.uk/investment-managers-for-{Jurisdiction.ToLower()}-investors/");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

    }
}
