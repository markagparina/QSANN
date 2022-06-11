using QSANN.Core.Extensions;
using System.Globalization;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;

namespace QSANN.Core.ValidationRules
{
    public class RequiredNumericRule : ValidationRule
    {
        public string InitialMessage { get; set; }
        public string ErrorMessage { get; set; }

        public RequiredNumericRule()
        {
            ValidationStep = ValidationStep.UpdatedValue;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Get and convert the value
            string valueAsString = GetBoundValue(value) as string;

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

        private object GetBoundValue(object value)
        {
            if (value is BindingExpression)
            {
                // ValidationStep was UpdatedValue or CommittedValue (validate after setting)
                // Need to pull the value out of the BindingExpression.
                BindingExpression binding = (BindingExpression)value;

                // Get the bound object and name of the property
                string resolvedPropertyName = binding.GetType().GetProperty("ResolvedSourcePropertyName", BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance).GetValue(binding, null).ToString();
                object resolvedSource = binding.GetType().GetProperty("ResolvedSource", BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance).GetValue(binding, null);

                // Extract the value of the property
                object propertyValue = resolvedSource.GetType().GetProperty(resolvedPropertyName).GetValue(resolvedSource, null);

                return propertyValue;
            }
            else
            {
                return value;
            }
        }
    }
}