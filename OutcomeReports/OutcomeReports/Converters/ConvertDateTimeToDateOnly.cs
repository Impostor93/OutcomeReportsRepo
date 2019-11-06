using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace OutcomeReports.Converters
{
    public class ConvertDateTimeToDateOnly : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(DateTime))
                throw new ArgumentException("Invalid value");

            if (ReferenceEquals(value, null))
                return string.Empty;

            var date = value as DateTime?;
            if (date.HasValue == false)
                return string.Empty;

            return date.Value.Date.ToString(culture.DateTimeFormat.ShortDatePattern);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (ReferenceEquals(value, null))
                return DateTime.MinValue;

            var date = DateTime.Parse(value.ToString(), culture.DateTimeFormat);

            return date;
        }
    }
}
