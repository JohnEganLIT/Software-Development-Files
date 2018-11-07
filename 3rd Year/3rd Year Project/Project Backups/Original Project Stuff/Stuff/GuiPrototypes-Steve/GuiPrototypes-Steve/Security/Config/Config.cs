using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Security {
    // ************************************************************************
    // Configuration Manager Class
    // All configuration settings are stored internally as an associative array
    // they are saved to file as a JSON encoded text file.
    // ************************************************************************
    public class Config {
        private string path;
        private SortedList<string, string> config;
        private Logger logger;

        // ********************************************************************
        // This method loads an associative array from a JSON encoded text file
        // ********************************************************************
        public Config(string path) {
            logger = new Logger();
            logger.Open("config.log");
            this.path = path;
            config = new SortedList<string, string>();
        }

        public Config(string path, Logger log) {
            logger = log;
            logger.Open("config.log");
            this.path = path;
            config = new SortedList<string, string>();
        }

        // ********************************************************************
        // Reset settings to previous save
        // ********************************************************************
        public bool Load() {
            SortedList<string, string> temp;
            try {
                string json = File.ReadAllText(@path);
                temp = JsonConvert.DeserializeObject
                    <SortedList<string, string>>(json);
                logger.Pass("File '{0}' opened successfully!", path);
            } catch (Exception e) {
                if (path == null) path = "";
                logger.Fail("File '{0}' not opened! {1}", path, e.Message);
                return false;
            }
            config = temp;
            return true;
        }

        // ********************************************************************
        // This method commits an associative array to a JSON encoded text file
        // ********************************************************************
        public bool Save() {
            try {
                string json = JsonConvert.SerializeObject(config);
                File.WriteAllText(@path, json);
                logger.Pass("File '{0}' saved successfully!", path);
            } catch (Exception e) {
                if (path == null) path = "";
                logger.Fail("File '{0}' not saved! {1}", path, e.Message);
                return false;
            }
            return true;
        }

        // ********************************************************************
        // Retrieve a value from the configuration file
        // ********************************************************************
        public string this[string name] {
            get {
                if (name == null) return null;
                return (config.ContainsKey(name)) ? config[name] : null;
            }
            set {
                // ignore null named values
                if (name == null) return;

                // remove name if value is set to null
                if (value == null) {
                    if (config.ContainsKey(name)) config.Remove(name);
                    return;
                }

                // if the value doesn't exist, then create it
                if (!config.ContainsKey(name)) config.Add(name, value);

                // otherwise update the existing value
                config[name] = value.ToString();
            }
        }
    }
}
