using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Linq;

namespace MyOrganizer.WPF
{
    public struct ColorScheme
    {
        public string FontFamily;
        public string Name;
        public float FontSize;

    }
    public static class ConfigurationHandler
    {
        public static ColorScheme CurrentColorScheme { get; set; }
        public async static Task<List<ColorScheme>> GetColorSchemes()
        {
            using (FileStream filestream   = File.OpenRead(Environment.CurrentDirectory+"//Assets//ColorsBase.json") )
            {
                var scheme = new byte[] { };
               await filestream.ReadAsync(scheme);

                return JsonConvert.DeserializeObject<List<ColorScheme>>(Encoding.ASCII.GetString(scheme));
            }

           
        }
        public static async Task<bool> ChangeColorScheme(string name)
       {
            var schemes= await GetColorSchemes();
            CurrentColorScheme = schemes.FirstOrDefault(x => x.Name == name);

            return true;
            
       }
    }
}
