using System.Diagnostics;

namespace ACoreX.Extensions.Base.Core
{
    public static class StringExtensions
    {
        public static bool IsValidJson(this string s)
        {
            try
            {
                JToken.Parse(s);
                return true;
            }
            catch (JsonReaderException ex)
            {
                Trace.WriteLine(ex);
                return false;
            }
        }
    }
}
