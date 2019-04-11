using eCommerceUI.Core;

namespace eCommerceUI.Models.PageObjects
{
    public class CategoryPage : PageBase
    {
        public string Name { get; private set; }

        public CategoryPage(IWebDriverFacade driver, PageBase mPreviousPage, string name) : base(driver, mPreviousPage)
        {
            Name = name;
            GoTo(string.Format(Repository.Catalog.Link, name));
        }

        public SubCategory GoToSubCategory(string name)
        {
            var subCategory = new SubCategory(driver, this, name);
            return subCategory;
        }
    }
}
