using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            //Values that will replace placeholdesr
            string[] details = { "Shite Road", "Yeah Boi", "Shite City", "Shite County", "Your Man", "3289472398", "B93284903", "Back arse of nowhere",  "131-CE-3745", "11"};
            printDocument("offence", details);
        }

        static void printDocument(string template, string[] details) {
            //Creates the file path 
            template = String.Format("{0}{1}{2}", "templates/", template, "Template.rtf");

            List<string> lines = new List<string>();

            //Reads in selected template
            using (System.IO.StreamReader reader = new System.IO.StreamReader(template)) {
                while (!reader.EndOfStream) {
                    lines.Add(reader.ReadLine());
                }
            }

            int index=0;
            var regex = new Regex(Regex.Escape("%"));
            string printLine="";

            //Uses the selected template file to create notify.rtf 
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("notify.rtf")) {
                foreach (string line in lines) {
                    int occurances = line.Count(f => f == '%');
                    printLine = line;

                    for (int i = 0; i<occurances; i++) {
                        printLine = regex.Replace(printLine, details[index], 1);
                        index++;
                    }

                    file.WriteLine(printLine);
                }

            }
        }
    }
}
