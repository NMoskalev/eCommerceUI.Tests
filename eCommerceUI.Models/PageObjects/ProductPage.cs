using eCommerceUI.Core;

namespace eCommerceUI.Models.PageObjects
{
    public class ProductPage : PageBase
    {
        public ProductPage(IWebDriverFacade driver, PageBase mPreviousPage, string xPath) : base(driver, mPreviousPage)
        {
            GoTo(xPath);
        }

        public ShoppingCartPage AddToCart()
        {
            driver.FindElement(Repository.Product.AddToCardButton).Click();

            return new ShoppingCartPage(driver, this);
        }
    }
}
