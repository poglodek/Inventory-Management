using Inventory_Management.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;

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
            catch (Exception ex)
            {
                MessageBox.Show("Cannot read data conifg", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                App.Current.Shutdown();
            }
            return null;
        }
    }
}
