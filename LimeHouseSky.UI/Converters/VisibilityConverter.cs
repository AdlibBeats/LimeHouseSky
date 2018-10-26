using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace LimeHouseSky.UI.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is bool boolValue)) return value;
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (!(value is Visibility visibilityValue)) return value;
            return visibilityValue == Visibility.Visible;
        }
    }
}
