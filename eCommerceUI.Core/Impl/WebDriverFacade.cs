using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace eCommerceUI.Core.Impl
{
    public class WebDriverFacade : IWebDriverFacade, IDisposable
    {
        private bool m_disposed;
        private IWebDriver m_webDriver;
        private string m_url;

        public ILogger Logger { get; private set; }


        public WebDriverFacade(string url, string[] args)
        {
            m_url = url;
            m_webDriver = new WebDriverFactory().CreateInstance(args);
            Logger = new ConsoleLogger();
        }

        public void Dispose()
        {
            if (m_webDriver != null && !m_disposed)
            {
                m_webDriver.Quit();
                m_disposed = true;
                Logger.Log("Close browser.");
            }
        }

        public IWebElement FindElement(string elementXpath, int timeout = 10)
        {
            var element = WaitForElementLoad(elementXpath, timeout);
            Logger.Log(string.Format("Found the elementXPath by XPath {0}", elementXpath));
            return element;
        }

        public void MoveAndClickToElement(string elementXPath)
        {
            var element = FindElement(elementXPath);
            (m_webDriver as IJavaScriptExecutor).ExecuteScript("arguments[0].scrollIntoView(true);", element);

            Thread.Sleep(2000);

            element.Click();
            Logger.Log(string.Format("Move and Click to XPath {0}", elementXPath));
        }

        public void NavigateBack()
        {
            (m_webDriver as IJavaScriptExecutor).ExecuteScript("window.history.go(-1)");
            Logger.Log("Navigate to previous page");
        }

        private IWebElement WaitForElementLoad(string elementXpath, int timeout)
        {
            var wait = new WebDriverWait(m_webDriver, TimeSpan.FromSeconds(timeout));

            var attempts = 3;
            while (attempts > 0)
            {
                try
                {
                    return wait.Until<IWebElement>(d => d.FindElement(By.XPath(elementXpath)));
                }
                catch (StaleElementReferenceException)
                {
                    Logger.Log("StaleElementException is occured, may be page is refreshed?", LoggerLevel.Error);
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    wait.Until<IWebElement>(d => d.FindElement(By.XPath(elementXpath)));
                    attempts--;
                }
                catch (NoSuchElementException)
                {
                    Logger.Log($"Element was not found (NoSuchElementException). xPath: {elementXpath}", LoggerLevel.Error);
                    attempts = 0;
                }
                catch (WebDriverTimeoutException)
                {
                    Logger.Log($"Element was not found for {timeout} seconds, attempts: {attempts}, xPath: {elementXpath}", LoggerLevel.Error);
                    attempts--;
                }
            }

            return null;
        }

        public void Quit()
        {
            Dispose();
        }

        public void Start()
        {
            m_webDriver.Url = m_url;
            m_webDriver.Navigate();
            Logger.Log(string.Format("Navigate to '{0}'", m_url));
        }
    }
}