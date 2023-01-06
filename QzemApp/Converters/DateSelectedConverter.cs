using System;
using System.Globalization;

namespace QzemApp.Converters;

public class DateSelectedConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateChangedEventArgs eventArgs)
            return eventArgs.NewDate;

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}