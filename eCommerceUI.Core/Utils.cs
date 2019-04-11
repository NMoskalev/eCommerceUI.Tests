using System.Collections.Generic;
using System.IO;

namespace eCommerceUI.Core
{
    public class Utils
    {
        public static List<string> LoadCsvFile(string filePath)
        {
            using (var reader = new StreamReader(File.OpenRead(filePath)))
            {
                List<string> searchList = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    searchList.Add(line);
                }

                return searchList;
            }
        }
    }
}
