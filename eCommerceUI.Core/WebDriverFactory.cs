using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace eCommerceUI.Core
{
    internal class WebDriverFactory
    {
        private const string DefaultBrowser = "chrome";

        private static readonly Dictionary<string, Func<IWebDriver>> m_supportedBrowser = new Dictionary<string, Func<IWebDriver>>
        {
            {DefaultBrowser, () => new ChromeDriver()},
            {"firefox", () => new FirefoxDriver()}
        };

        public IWebDriver CreateInstance(string[] args)
        {
            if (args != null && args.Length > 0 && m_supportedBrowser.ContainsKey(args[0]))
            {
                return m_supportedBrowser[args[0]]();
            }

            return m_supportedBrowser[DefaultBrowser]();
        } 
    }
}
