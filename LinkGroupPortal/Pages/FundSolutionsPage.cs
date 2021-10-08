using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Net;
using System.Net.Http;


namespace LinkGroup.DemoTests.Pages
{
    public class FundSolutionsPage
    {
        public IWebDriver WebDriver { get; }
        public FundSolutionsPage(IWebDriver webdriver)
        {
            WebDriver = webdriver;
        }

        //UI Elements
        public IWebElement AcceptCookiesBtn => WebDriver.FindElement(By.Id("btnAccept"));
        public IWebElement FundsLnk => WebDriver.FindElement(By.Id("navbarDropdown"));

        public IWebElement getDynamicElement(String Jurisdiction)
        {
            return WebDriver.FindElement(By.XPath($"//a[@href='/investment-managers-for-{Jurisdiction}-investors/']"));
        }

        public void OpenURL()
        {
            WebDriver.Navigate().GoToUrl("https://www.linkfundsolutions.co.uk/");
            WebDriver.Manage().Window.Maximize();
        }

        public void ShowFunds()
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(FundsLnk).Build().Perform();
        }

        public bool TestHttpStatusCodeAsync(string urlLink)
        {
            // HttpWebRequest request = WebRequest.Create("https://www.google.com/") as HttpWebRequest;
            HttpWebRequest request = WebRequest.Create(urlLink) as HttpWebRequest;
            request.Method = "HEAD";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return (response.StatusCode==HttpStatusCode.OK);
        }
    }
}