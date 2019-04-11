
using OpenQA.Selenium;

namespace eCommerceUI.Core
{
    public interface IWebDriverFacade
    {
        ILogger Logger { get; }

        void Quit();

        void Start();

        IWebElement FindElement(string elementXpath, int timeout = 10);

        void MoveAndClickToElement(string elementXPath);

        void NavigateBack();
    }
}
