using eCommerceUI.Core;

namespace eCommerceUI.Models.PageObjects
{
    public abstract class PageBase
    {
        protected IWebDriverFacade driver;
        private PageBase m_previousPage;

        public PageBase(IWebDriverFacade driver, PageBase mPreviousPage)
        {
           this.driver = driver;
           this.m_previousPage = mPreviousPage;
        }

        public virtual T Back<T>() where T: PageBase
        {
            driver.NavigateBack();
            return m_previousPage as T;
        }

        protected void GoTo(string xPath)
        {
            driver.MoveAndClickToElement(xPath);
        }
    }
}
