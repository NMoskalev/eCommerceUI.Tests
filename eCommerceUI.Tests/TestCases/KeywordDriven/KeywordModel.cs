using System.Collections.Generic;

namespace eCommerceUI.Tests.TestCases.KeywordDriven
{
    public class KeywordModel
    {
        public KeywordModel()
        {
            Params = new List<string>();
        }

        public string Step { get; set; }

        public string Selector { get; set; }

        public string Action { get; set; }

        public List<string> Params { get; set; }
    }
}