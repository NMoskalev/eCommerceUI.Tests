using System.Collections.Generic;
using eCommerceUI.Core;
using eCommerceUI.Models.PageObjects;

namespace eCommerceUI.Tests.TestCases.DataDriven
{
    public class AddItemsToCartTest: ITest
    {
        private IWebDriverFacade m_driver;
        private List<AddItemsToCartDataModel> m_dataModels;
        public AddItemsToCartTest(IWebDriverFacade mDriver, IStepMapper<AddItemsToCartDataModel> mapper, string filePath)
        {
            this.m_driver = mDriver;

            m_dataModels = GetData(mapper, filePath);
        }

        public void Run()
        {
            foreach (var model in m_dataModels)
            {
                m_driver.Start();

                new CategoryPage(m_driver, null, model.Category)
                    .GoToSubCategory(model.SubCategory)
                    .SortBy(model.SortBy)
                    .GetProductByOrder(0)
                    .AddToCart()
                    .Back<ProductPage>()
                    .Back<SubCategory>()
                    .GetProductByOrder(1)
                    .AddToCart();
            }         
        }

        private List<AddItemsToCartDataModel> GetData(IStepMapper<AddItemsToCartDataModel> mapper, string filePath)
        {
            var lines = Utils.LoadCsvFile(filePath);
            return mapper.Map(lines);
        }
    }
}
