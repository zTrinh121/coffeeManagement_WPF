using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

public class ImagePathToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string path = value as string;
        if (!string.IsNullOrEmpty(path))
        {
            try
            {
                if (!Uri.IsWellFormedUriString(path, UriKind.Absolute))
                {
                    // Điều chỉnh đường dẫn gốc của ứng dụng hoặc một vị trí cụ thể
                    path = System.IO.Path.Combine(Environment.CurrentDirectory, path);
                }
                return new BitmapImage(new Uri(path, UriKind.Absolute));
            }
            catch
            {
                // Log error or return a default image
                return new BitmapImage(new Uri("pack://application:,,,/Images/default.png"));
            }
        }
        return null;
    }


    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
