using System;
using eCommerceUI.Core.Impl;
using eCommerceUI.Tests.TestCases;
using eCommerceUI.Tests.TestCases.DataDriven;
using eCommerceUI.Tests.TestCases.KeywordDriven;

namespace eCommerceUI.Tests
{
    /// <summary>
    /// use following parameters: chrome or firefox. Default is chrome
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver = new WebDriverFacade("https://www.ebay.com/", args))
            {
                // NOTE: two type of tests which do the same actions
                //  ITest test = new TestCases.KeywordDriven.AddItemsToCartTest(driver, new KeywordMapping(), driver.Logger, @"Data/eCommerceKeywords.csv");
                ITest test = new TestCases.DataDriven.AddItemsToCartTest(driver, new DataMapping(), @"Data/addItemsToCartData.csv");

                test.Run();
                Console.Write("\nPress any key to finish test... ");
                Console.ReadLine();
            }
        }
    }
}
