namespace OutcomeReports.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using OutcomeReports.Domain.ViewModels;
    using Xamarin.Forms;

    public class ConvertCategorIdToName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (ReferenceEquals(value, null))
                return string.Empty;

            if (ReferenceEquals(parameter, null))
                return value;

            var categoryId = int.Parse(value.ToString());
            var allCategories = (parameter as IEnumerable<CategoryViewModel>);

            if (ReferenceEquals(allCategories, null))
                return categoryId;

            var category = allCategories.FirstOrDefault(e => e.Id == categoryId);
            if (ReferenceEquals(category, null))
                return categoryId;

            return category.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
