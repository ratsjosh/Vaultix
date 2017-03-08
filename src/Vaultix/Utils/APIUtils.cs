using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Vaultix.Utils
{
    public class APIUtils
    {
        public static string ConvertToURL(string result)
        {
            result = result.Replace(" ", "%20"); // Replaces any spaces with %20
            result = HtmlEncoder.Default.Encode(result); // Encode the resultant string
            return result;
        }
    }
}
