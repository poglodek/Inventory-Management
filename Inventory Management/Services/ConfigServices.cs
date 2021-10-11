using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Inventory_Management.Model;
using Newtonsoft.Json;

namespace Inventory_Management.Services
{
    public class ConfigServices : IConfigServices
    {
        public Config GetConfig()
        {
            try
            {
                var json = File.ReadAllText("Data.json");
                return JsonConvert.DeserializeObject<Config>(json);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot read data conifg", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                App.Current.Shutdown();
            }
            return null;
        }
    }
}
