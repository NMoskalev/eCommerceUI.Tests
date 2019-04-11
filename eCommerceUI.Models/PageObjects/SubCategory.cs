using eCommerceUI.Core;

namespace eCommerceUI.Models.PageObjects
{
    public class SubCategory: PageBase
    {
        public string Name { get; private set; }

        public SubCategory(IWebDriverFacade driver, PageBase mPreviousPage, string name) : base(driver, mPreviousPage)
        {
            Name = name;
            GoTo(string.Format(Repository.SubCatalog.Link, name));
        }

        public SubCategory SortBy(string name)
        {
            driver.MoveAndClickToElement(Repository.SubCatalog.SortDropdown);
            var dropdown = driver.FindElement(Repository.SubCatalog.NotExpandedSortDropdown);
            if (dropdown != null)
            {
                dropdown.Click();
            }

            driver.FindElement(string.Format(Repository.SubCatalog.SortDropdownItem, name)).Click();

            return this;
        }

        public ProductPage GetProductByOrder(int order)
        {
            var xPath = string.Format(Repository.SubCatalog.SortedProductLink, order);
            var product = new ProductPage(driver, this, xPath);

            return product;
        }
    }
}
