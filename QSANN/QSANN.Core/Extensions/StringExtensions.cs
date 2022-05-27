using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSANN.Core.Extensions
{
    public static class StringExtensions
    {
        public static decimal StripAndParseAsDecimal(this string input) 
        {
            if (decimal.TryParse(new string(input.Where(c => char.IsDigit(c) || char.IsPunctuation(c)).ToArray()).Trim(), out decimal result))
            {
                return result;
            }


            return 0;
        }

        public static string AppendIfNotExists(this string input, string toAppend)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return input.Contains(toAppend.Trim()) ? input : $"{input}{toAppend}";
            }
            return input;
        }
    }
}
