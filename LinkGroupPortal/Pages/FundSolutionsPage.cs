using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LinkGroup.DemoTests.Pages
{
    public class FundSolutionsPage
    {
        public IWebDriver WebDriver { get; }
        HttpClient _httpClient;
        public FundSolutionsPage(IWebDriver webdriver)
        {
            WebDriver = webdriver;
        }

        //UI Elements
        public IWebElement AcceptCookiesBtn => WebDriver.FindElement(By.Id("btnAccept"));
        public IWebElement FundsLnk => WebDriver.FindElement(By.Id("navbarDropdown"));

        public IWebElement getDynamicEmement(String Jurisdiction)
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

        public async Task<HttpStatusCode> TestHttpStatusCodeAsync(string urlLink)
        {
           /* var request = (HttpWebRequest)WebRequest.Create(urlLink);
            request.Method = "HEAD";
            var response = (HttpWebResponse)request.GetResponse();

            // status code...
            return response.StatusCode;*/

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://www.google.com/");
            return response.StatusCode;
        }
    }
}