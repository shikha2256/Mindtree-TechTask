using LinkGroup.DemoTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            //this will check if t there is an active Investment Managers link 
            bool status =fundSolutionsPage.getDynamicElement(Jurisdiction.ToLower()).Displayed;
            Assert.AreEqual(true, status);

            //to check if link is working fine, we can also check if the link is giving 200 status code
            
            /*****  this code is not working for THESE 3 URL's   ******/
          
            /*
            var statusCode=fundSolutionsPage.TestHttpStatusCodeAsync($"https://www.linkfundsolutions.co.uk/investment-managers-for-{Jurisdiction.ToLower()}-investors/");
            Assert.AreEqual(true, statusCode);
           */ 
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

    }
}
