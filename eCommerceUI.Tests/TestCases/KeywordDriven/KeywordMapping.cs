using System.Collections.Generic;
using System.Linq;
using eCommerceUI.Core;

namespace eCommerceUI.Tests.TestCases.KeywordDriven
{
    /// <summary>
    /// |Step|Selector|Action|Params(| separated)
    /// </summary>
    public class KeywordMapping : IStepMapper<KeywordModel>
    {
        public List<KeywordModel> Map(List<string> lines)
        {
            return lines.Skip(1).Select(m => Map(m)).Where(m => m != null).ToList();
        }

        private static KeywordModel Map(string line, char separator = ';')
        {
            if (string.IsNullOrEmpty(line))
            {
                return null;
            }

            var rawProperties = line.Split(separator);

            if (rawProperties.Length != 4)
            {
                return null;
            }

            var model = new KeywordModel
            {
                Step = rawProperties[0],
                Selector = rawProperties[1],
                Action = rawProperties[2]
            };

            model.Params.AddRange(rawProperties[3].Split('|'));

            return model;
        }
    }
}
