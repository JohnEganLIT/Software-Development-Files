using Newtonsoft.Json;
using Security;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Server {
    // ********************************************************************* //
    // Here is where your server talks to your client                        //
    // ********************************************************************* //
    public class Worker : SslWorker {
        //Dictionary<string, string> procs;

        public Worker() {
            //procs = new Dictionary<string, string>();
            //procs.Add("Login", "CALL LoginUser(@UserName, @Cipher);");
            //procs.Add("AddUser", "CALL AddUser(@UserName, @OrganizationID, @Position, @Email, @DateAdded);");

        }

        public override void EntryPoint() {
            //logger.Echo = false;

            // Write a message to the client.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Server says: {0}", this.GetHost() + ":" + this.GetPort());
            Console.ResetColor();
            Send(this.GetHost());
            Send(this.GetPort());
            logger.SetUser(this.host+":"+this.port);

            // Now just echo back everything we receive
            for (;;) {
                try {
                    // receive client requests
                    string request = Recv();
                    if (request == "") continue; // handle timeouts gracefully
                    if (request == "<EOF>") break; // recognize end of transmission

                    // sanitize the request
                    request = Regex.Replace(request, ";", "");

                    // split the procedure name from the json object
                    int index = request.IndexOf('{', 0);
                    if (index < 1) {
                        Send("{\"Error\":\"Bad Request\"}");
                        continue;
                    }
                    string strip = request.Substring(0, index-1);
                    strip = Regex.Replace(strip, "\"", "");
                    string proc = Regex.Replace(strip, ":", "");
                    //if (!procs.ContainsKey(proc)) {
                    //    Send("{\"Error\":\"Bad Request\"}");
                    //    continue;
                    //}

                    string req = request.Substring(index);
                    //Dictionary<string, object>[] reply = Program.dao.Call(proc, req);
                    //if (reply == null) {
                    //    Send("{\"Error\":\"Bad Request\"}");
                    //    continue;
                    //}

                    Dictionary<string, object>[] reply = Program.dao.Call(proc, req);
                    if (reply == null) {
                        Send("{\"Error\":\"Bad Request\"}");
                        continue;
                    }

                    string json = JsonConvert.SerializeObject(reply);
                    if (!Send(json)) break; // recognize failure
                } catch (Exception e) {
                    logger.Fail("Lost connection! {0}", e.Message);
                    break;
                }
            }

            try {
                //logger.Echo = true;
                Disconnect();
            } catch { }
        }
    }
}
