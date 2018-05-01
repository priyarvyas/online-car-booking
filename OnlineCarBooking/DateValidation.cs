using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OnlineCarBooking
{
    class DateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            DateTime pickupDate = (DateTime)value;
            if (pickupDate < DateTime.Now)
            {
                result = new ValidationResult(false, "Please select future date");
            }
            return result;
        }

    }
}
