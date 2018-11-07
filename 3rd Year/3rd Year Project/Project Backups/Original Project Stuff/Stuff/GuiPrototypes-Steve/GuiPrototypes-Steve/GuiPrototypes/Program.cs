using System;
using Security;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiPrototypes {
    static class Program {
        public static string host;
        public static string port;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            //Logger.Hide();
            Logger logger = new Logger();
            logger.Open(@"client.log");

            // Load the clients configuration
            SslClient socket = new SslClient();
            if (socket.SetUp(@"client.json")) {

                // Connect to the server
                if (socket.Connect()) {
                    //SSL Tunnel Established 
                    host = socket.Recv();
                    port = socket.Recv();

                    logger.Echo = false;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Frame(socket));


                    // SSL Tunnel Established#
                    /*
                    socket.Send("Hello from the client");
                    string response = socket.Recv();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Server says: {0}", response);
                    Console.ResetColor();
                    

                    // now just continue to pass secure messages
                    for (;;) {
                        // send confidential message to the server...
                        Console.Write("Enter text (null string to exit): ");
                        string plainText = Console.ReadLine();
                        if (plainText == "") break;
                        socket.Send(plainText);

                        // receive confidential message from server...
                        try {
                            string reply = socket.Recv();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Server says: {0}", reply);
                            Console.ResetColor();
                        } catch (Exception e) {
                            Logger.Fail("Lost connection! {0}", e.Message);
                            break;
                        }

                    }
                    */
                    // disconnect from the server...
                    try {
                        socket.Send("<EOF>");
                        socket.Disconnect();
                    } catch { }
                }
            }

            logger.Echo = true;
            logger.Close();
            //Logger.Show();
        }
    }
}
