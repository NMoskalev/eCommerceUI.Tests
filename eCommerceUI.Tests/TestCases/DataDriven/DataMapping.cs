using System.Collections.Generic;
using System.Linq;
using eCommerceUI.Core;

namespace eCommerceUI.Tests.TestCases.DataDriven
{
    public class DataMapping : IStepMapper<AddItemsToCartDataModel>
    {
        /// <summary>
        /// |Category|SubCategory|SortBy
        /// </summary>
        public List<AddItemsToCartDataModel> Map(List<string> lines)
        {
            return lines
                .Skip(1)
                .Select(l => l.Split(';'))
                .Select(m => new AddItemsToCartDataModel { Category = m[0], SubCategory = m[1], SortBy = m[2]}).ToList();
        }
    }
}