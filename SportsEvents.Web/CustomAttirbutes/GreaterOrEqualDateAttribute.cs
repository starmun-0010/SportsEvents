using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

namespace SportsEvents.Web.CustomAttirbutes
{
    public class GreaterOrEqualDateAttribute : ValidationAttribute
    {
        public GreaterOrEqualDateAttribute(string otherProperty, string errorMessage)
        {
            OtherProperty = otherProperty;
            ErrorMessage = errorMessage;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo ohterProperty = validationContext.ObjectType.GetProperty(this.OtherProperty);
            var otherValue = (DateTime)ohterProperty.GetValue(validationContext.ObjectInstance);
            DateTime thisValue = (DateTime)value;

            if (thisValue.Date >= otherValue.Date)
            {
                return (ValidationResult)null;
            }
            return new ValidationResult(ErrorMessage);
        }

        public string OtherProperty { get; set; }

    }
}