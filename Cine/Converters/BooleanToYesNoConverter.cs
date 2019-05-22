namespace Cine.ValueConverters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;


    public class BooleanToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value) return "Yes";

            return "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value ==  "Yes") return true;

            return false;
        }
    }
}