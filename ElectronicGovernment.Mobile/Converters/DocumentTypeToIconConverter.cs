using System.Globalization;
using ElectronicGovernment.Mobile.Resources.Fonts;

namespace ElectronicGovernment.Mobile.Converters;

public class DocumentTypeToIconConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null) return MaterialIcons.ProgressCheck;
        var va = (int)value;
        return va switch
        {
            0 => MaterialIcons.ProgressCheck,
            1 => MaterialIcons.Check,
            2 => MaterialIcons.Cancel,
            _ => MaterialIcons.ProgressCheck
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}