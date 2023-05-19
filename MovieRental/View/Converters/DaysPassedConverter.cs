using System;
using System.Globalization;
using System.Windows.Data;

namespace MovieRental.View.Converters;

public class DaysPassedConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is DateTime issuedDate) {
            TimeSpan daysPassed = DateTime.Now - issuedDate;
            return $"{daysPassed.Days} days ago";
        }

        return "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
