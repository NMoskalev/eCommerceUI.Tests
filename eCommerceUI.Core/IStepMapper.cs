using System.Collections.Generic;

namespace eCommerceUI.Core
{
    public interface IStepMapper<T> where T: class
    {
        List<T> Map(List<string> lines);
    }
}
