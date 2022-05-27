using QSANN.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QSANN.Core.ValidationRules
{
    public class RequiredNumericRule : ValidationRule
    {
        public string InitialMessage { get; set; }
        public string ErrorMessage { get; set; }

        public RequiredNumericRule()
        {

        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueAsString = value?.ToString();

            if (string.IsNullOrEmpty(valueAsString))
            {
                return new ValidationResult(false, InitialMessage);
            }

            if (valueAsString.StripAndParseAsDecimal() <= 0)
            {
                return new ValidationResult(false, ErrorMessage);
            }


            return ValidationResult.ValidResult;
        }
    }
}
