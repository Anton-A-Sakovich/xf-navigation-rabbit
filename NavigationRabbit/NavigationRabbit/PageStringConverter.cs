using System;
using System.Globalization;
using Xamarin.Forms;

namespace NavigationRabbit
{
    public class PageStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null && targetType == typeof(string))
            {
                return null;
            }

            if (value is Page page && targetType == typeof(string))
            {
                return String.Format("{0} ({1})\n", page.GetType().Name, page.GetHashCode());
            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
