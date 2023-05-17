using System.Windows.Data;
using System;

namespace MovieRental.View.Converters;

public class InverseAndBooleansToBooleanConverter : IMultiValueConverter {
    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
        if (values.LongLength > 0) {
            foreach (var value in values) {
                if (value is bool boolean && boolean) {
                    return false;
                }
            }
        }
        return true;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) {
        throw new NotImplementedException();
    }
}
