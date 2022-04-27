using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NavigationRabbit
{
    public class PagesStringConverter : IValueConverter
    {
        private readonly PageStringConverter _pageConverter;

        public PagesStringConverter(PageStringConverter pageConverter)
        {
            _pageConverter = pageConverter;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<Page> pages && targetType == typeof(string))
            {
                return pages.Aggregate(
                    (0, new StringBuilder()),
                    ((int index, StringBuilder builder) acc, Page page) => (++acc.index, acc.builder.AppendFormat("{0}. {1}", acc.index, _pageConverter.Convert(page, targetType, null, culture))),
                    ((int index, StringBuilder builder) acc) => acc.index == 0 ? "None" : acc.builder.ToString());
            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
