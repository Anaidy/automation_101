using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace automation_101
{
    public class WebPage
    {
        public static IWebDriver TestWebDriver;

        public static void OpenChromeBrowser()
        {
            TestWebDriver = new ChromeDriver();
        }


        public static void NavigateToThisPage(string url)
        {
            TestWebDriver.Navigate().GoToUrl(url);
        }


        public static void MaximizeBrowser()
        {
            TestWebDriver.Manage().Window.Maximize();
        }

        public static void CloseBrowser()
        {
            TestWebDriver.Quit();
        }

        public static void SetPageTimeOutSeconds(int i)
        {
            TestWebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(i);
        }

        public static void SetImplicitWait(int i)
        {
            TestWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(i);
        }

    }
}
