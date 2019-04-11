namespace eCommerceUI.Models
{
    internal static class Repository
    {
        private const string mainContentId = ".//div[@id='mainContent']";
        public static class Catalog
        {
            public const string Link = mainContentId + "//div[@class='hl-cat-nav']//ul[@class='hl-cat-nav__container']//li//a[text()='{0}']";
        }

        public static class SubCatalog
        {
            private const string sortUniqueAttribute = "substring(@data-w-onclick, string-length(@data-w-onclick) - 5) = '-w0-w1'";
            private const string sortUniqueId = "substring(@id, string-length(@id) - 5) = '-w0-w1'";
            private const string sortedProductId = "substring(@id, string-length(@id) - 8) = '-items[{0}]'";

            public const string Link = mainContentId +
                                       "//section[contains(@class,'b-module')]//div[@class='b-visualnav__grid']//a[contains(@class,'b-visualnav__tile')]//div[text()='{0}']";

            public const string SortDropdown = "//button["+ sortUniqueAttribute + "]";

            public const string NotExpandedSortDropdown = "//button[" + sortUniqueAttribute + " and @aria-expanded='false']";

            public const string SortDropdownItem = ".//div[" + sortUniqueId + "]//div[contains(@class, 'flyout-notice--information')]//div[@class='srp-sort']//ul//li[@class='btn']//a[span/text()='{0}']";

            public const string SortedProductLink =
                ".//li["+ sortedProductId + "]//div[contains(@class, 's-item__wrapper')]//div[@class='s-item__image-section']//div[@class='s-item__image']//a";
        }

        public static class Product
        {
            public const string AddToCardButton = ".//a[@id='isCartBtn_btn']";
        }
    }
}
