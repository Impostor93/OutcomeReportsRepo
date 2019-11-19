namespace OutcomeReports.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using OutcomeReports.Domain.ViewModels;
    using OutcomeReports.ViewModels;
    using Xamarin.Forms;

    public class ConvertCategorIdToName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (ReferenceEquals(value, null))
                return string.Empty;

            var listView = parameter as ListView;
            if (ReferenceEquals(listView, null))
                return value;

            var context = listView.BindingContext as PeriodLinesViewModel;
            if (ReferenceEquals(context, null))
                return value;

            var categoryId = int.Parse(value.ToString());
            var allCategories = context.Categories;

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
