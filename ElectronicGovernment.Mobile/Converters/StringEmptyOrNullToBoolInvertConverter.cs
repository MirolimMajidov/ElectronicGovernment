using System.Globalization;

namespace ElectronicGovernment.Mobile.Converters;

public class StringEmptyOrNullToBoolInvertConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !string.IsNullOrEmpty((value as string)?.Trim());
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}