using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MR6100Demo
{
    public class Config
    {
        // DataBase setting
        public string DatabaseIP { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // TCP parameter setting
        public string IP { get; set; }
        public string SubnetMask { get; set; }
        public string GateWay { get; set; }

        // readers properties
        public string R1IP { get; set; }
        public string R1Port { get; set; }

        public string R2IP { get; set; }
        public string R2Port { get; set; }


        //Frequency setting
        public string FrequencyType { get; set; }
        public string FrequencyPoints { get; set; }

        //power setting
        public string Ante1 { get; set; }
        public string Ante2 { get; set; }



        //WorkingMode
        public string WorkingMode { get; set; }

        //BuzerStatus
        public string BuzzerStatus { get; set; }

    }

    public static class ConfigManager
    {
        private static string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

        public static Config Load()
        {
            if (!File.Exists(configPath))
                return null;

            try
            {

                string json = File.ReadAllText(configPath);
               
              //  MessageBox.Show("Config path: " + configPath);  

                return JsonConvert.DeserializeObject<Config>(json);

            }
            catch
            {
                return null;
            }
        }

        public static bool Save(Config config)
        {
            try
            {
                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(configPath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
