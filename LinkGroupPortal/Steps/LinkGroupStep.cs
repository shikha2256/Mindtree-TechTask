using LinkGroup.DemoTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace LinkGroup.DemoTests.Steps
{
    [Binding]
    public sealed class LinkGroupStep
    {
        IWebDriver driver = new ChromeDriver();
        HomePage homePage = null;

        public LinkGroupStep()
        {
            homePage = new HomePage(driver);
        }

        //Step Definitions
        [When(@"I open the home page")]
        public void WhenIOpenTheHomePage()
        {
            homePage.OpenURL();
        }

        [Then(@"the page is displayed")]
        public void ThenThePageIsDisplayed()
        {
            string expectedTitle = "Home";
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Given(@"I have opened the home page")]
        public void GivenIHaveOpenedTheHomePage()
        {
            if (driver.Title != "Home")
            {
                homePage.OpenURL();
            }
        }

        [Given(@"I have agreed to the cookie policy")]
        public void GivenIHaveAgreedToTheCookiePolicy()
        {
            homePage.ClickAcceptCookies();
        }

        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string p0)
        {
            homePage.HoverSearchIcon();
            homePage.PerformSearch(p0);
            homePage.ClickSearchBtn();
        }

        [Then(@"the search results are displayed")]
        public void ThenTheSearchResultsAreDisplaye()
        {
            bool resp=homePage.VerifySearchResponse();
            Assert.AreEqual(true, resp);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
