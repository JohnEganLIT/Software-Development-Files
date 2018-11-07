using System.Collections.Generic;

namespace Security {
    public class BlackList {
        private Dictionary<string, bool> list;
        private string[] identity;

        // ********************************************************************
        // Load the black list with the set of rules
        // ********************************************************************
        public BlackList(Dictionary<string, bool> rules) {
            list = rules;
        }

        // ********************************************************************
        // Load the black list with currently logged in user's credentials
        // ********************************************************************
        public void SetUser(string Organization, string[] Groups,
                            string UserClass, string UserID) {
            identity = new string[6*(Groups.Length+1)];
            int i = 0;
            // we begin with a specific identity, then generalize
            for (int group = Groups.Length; group >= 0; group--) {
                for (int type = 1; type >= 0; type--) {
                    for (int uid = 2; uid >= 0; uid--) {
                        string key = Organization;
                        key += (group == 0) ? "" : "/" + Groups[group-1];
                        key += (type == 0) ? "" : "/" + UserClass;
                        key += (uid == 0) ? "" :
                               (uid == 1) ? "/" + UserID : "/self";
                        identity[i++] = key;
                    }
                }
            }
        }

        // ********************************************************************
        // Check if the black list forbids (or allows) the operation
        // ********************************************************************
        public bool this[string action] {
            get {
                // we begin with a specific operation, then generalize
                string[] parts = action.Split(new char[] { '/'});
                for (int j = parts.Length; j > 0; j--) {
                    string op = parts[0];
                    for (int i = 1; i < j; i++) {
                        op += "/" + parts[i];
                    }
                    foreach (string key in identity) {
                        string rule = key+":"+action;
                        if (list.ContainsKey(rule)) return list[rule];
                    }
                }
                return false;
            }
            set {
                // do not allow setting rules
            }
        }
    }
}
