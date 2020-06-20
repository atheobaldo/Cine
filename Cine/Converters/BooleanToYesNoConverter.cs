namespace Cine.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;


    public class BooleanToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool booleano) return booleano ? "Yes" : "No";

            return "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value ==  "Yes") return true;

            return false;
        }
    }
}