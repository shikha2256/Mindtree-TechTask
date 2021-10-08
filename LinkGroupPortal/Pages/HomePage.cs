using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace LinkGroup.DemoTests.Pages
{
   public class HomePage
    {
        public IWebDriver WebDriver { get; }
        public HomePage(IWebDriver webdriver)
        {
            WebDriver = webdriver;
        }

        //UI Elements
        public IWebElement AcceptCookiesBtn => WebDriver.FindElement(By.Id("btnAccept"));
        public IWebElement SearchIconTxt => WebDriver.FindElement(By.Id("navbardrop"));
        public IWebElement SearchTxt => WebDriver.FindElement(By.XPath("//input[@name='searchTerm']"));
        public IWebElement SearchBtn => WebDriver.FindElement(By.XPath("//button[contains(text(),'Search')]"));
        public IWebElement LeedsLbl => WebDriver.FindElement(By.XPath("//h3/em[contains(text(),'Leeds')]"));



        public void ClickAcceptCookies() => AcceptCookiesBtn.Click();

        public void OpenURL()
        {
            WebDriver.Navigate().GoToUrl("https://www.linkgroup.eu/");
            WebDriver.Manage().Window.Maximize();
        }

        public void HoverSearchIcon()
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(SearchIconTxt).Build().Perform();
        }

        public void PerformSearch(String txt)
        {
            SearchTxt.SendKeys(txt); 
        }
        public void ClickSearchBtn() => SearchBtn.Click();

        public bool VerifySearchResponse()
        {
            bool flag = false;
            if (LeedsLbl.Displayed)
            {
                flag = true;
            }
            return flag;
        }
    }
}
