using System.Globalization;

namespace ElectronicGovernment.Mobile.Converters;

public class DocumentTypeToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null) return Color.Parse("Blue");
        var va = (int)value;
        return va switch
        {
            0 => Color.Parse("Blue"),
            1 => Color.Parse("Green"),
            2 => Color.Parse("Red"),
            _ => Color.Parse("Blue")
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}