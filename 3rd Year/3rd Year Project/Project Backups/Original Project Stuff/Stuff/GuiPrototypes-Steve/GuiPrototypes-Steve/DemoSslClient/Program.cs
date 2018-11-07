// ************************************************************************* //
// Michael Collins - 11 November 2016                                        //
//                                                                           //
// This Library is heavily based on the Berkley Sockets interface.           //
// Setting up an SSL Client is as easy as:                                   //
//     SetUp(config file) // pass your configuration into the server         //
//     Connect()          // try to connect to the server                    //
//     Send(plain text)   // send plain text to the server                   //
//     plaintext = Recv() // receive plain text from the server              //
//     Disconnect()       // disconnect from the server                      //
//                                                                           //
// During the connection the following steps take place:                     //
//     1. The Client connects over a TCP socket to the Server.               //
//     2. The Server sends its certificate to the Client.                    //
//     3. The Client verifies that the Servers Certificate has been signed   //
//        by the Trusted Certificate Authority.                              //
//     4. The Client sends its certificate to the Server.                    //
//     5. The Server verifies that the Clients Certificate has been signed   //
//        by the Trusted Certificate Authority.                              //
//     6. The Server verifies that the Client has not been revoked.          //
//     7. The Server creates an SSL TCP Tunnel and informs the Client.       //
//     8. The Server creates a thread to communicate with the Client.        //
//     9. The SslFactory instantiates an instance of an SslWorker and        //
//        execution is passed to that instance.                              //
//     10. The Client sends an encrypted "hello" message.                    //
//     11. The Server sends an encrypted "hello" message.                    //
//     12. Communication proceeds.                                           //
//                                                                           //
// Once a Connection has been established, then the messages you send are    //
// encrypted in transit. You will only see plain text at each end point.     //
//                                                                           //
// a typical configutation file looks like this:                             //
//     {                                                                     //
//     "host":"127.0.0.1",                                                   //
//     "port":"443",                                                         //
//     "cert":"path/to/my/cert.pfx";                                         //
//     "pass":"myCertificatesPassword";                                      //
//     "timeout":"5000",                                                     //
//     "IsSelfSigned":"true"                                                 //
//     }                                                                     //
//                                                                           //
// The timeout is in milliseconds, use 0 for no timeouts.                    //
// The cer files are public keys and must be installed to Windows Store.     //
// The pfx files are private keys and must not be distributed.               //
// Don't worry, the pfx files contain all the information needed to generate //
// public keys, the client/server only send the public parts to each other.  //
//                                                                           //
// Don't forget to use the cerficates provided with this binary.             //
// ************************************************************************* //
using Security;
using System;

namespace DemoSslClient {
    class Program {
        public static Logger logger;

        static void Main(string[] args) {
            logger = new Logger();
            //logger.Hide();
            logger.Open(@"client.log");

            // Load the clients configuration
            SslClient socket = new SslClient();
            if (socket.SetUp(@"client.json")) {

                // Connect to the server
                if (socket.Connect()) {
                    logger.Echo = false;

                    // SSL Tunnel Established
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
                            logger.Fail("Lost connection! {0}", e.Message);
                            break;
                        }
                    }

                    // disconnect from the server...
                    try {
                        socket.Send("<EOF>");
                        socket.Disconnect();
                    } catch { }
                }
            }

            logger.Echo = true;
            logger.Close();
            //logger.Show();
        }
    }
}
