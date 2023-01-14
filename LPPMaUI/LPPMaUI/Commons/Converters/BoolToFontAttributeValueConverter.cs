using System.Globalization;
namespace LPPMaUI.Commons.Converters
{
     public class BoolToFontConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                if (booleanValue)
                    return "Gravity-Book";
            }
            return "Gravity-Bold";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }


}
