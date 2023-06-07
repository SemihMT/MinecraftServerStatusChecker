using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MinecraftServerStatusChecker.View.Converters
{
     public class PlayerNameToImageUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string playerName)
            {
                // Modify the URL based on the player name
                string modifiedUrl = "https://mc-heads.net/avatar/" + playerName + "/32.png";
                return modifiedUrl;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
