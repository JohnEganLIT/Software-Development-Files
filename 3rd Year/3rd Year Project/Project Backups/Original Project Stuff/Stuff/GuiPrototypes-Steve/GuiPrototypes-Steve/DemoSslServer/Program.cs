// ************************************************************************* //
// Michael Collins - 11 November 2016                                        //
//                                                                           //
// This Library is heavily based on the Berkley Sockets interface.           //
// An SslServer is multithreaded. The main thread lies idle waiting for the  //
// user to type "Shutdown" into the console. This will terminate all running //
// threads and close all open tunnels.                                       //
//                                                                           //
// The other thread listens to the socket and waits for clients to connect.  //
// This thread will use an SslFactory (which you define). This Factory will  //
// instantiate your SslWorkers.                                              //
//                                                                           //
// The SslWorkers are the ones that communicate with the client through the  //
// tunnel. Each SslWorker is launched in its own thread so please be careful //
// with shared state and lock accordingly.                                   //
// ************************************************************************* //
using Security;
using System;
using System.Threading;

namespace DemoSslServer {
    class Program {
        public static Logger logger;

        static void Main(string[] args) {
            logger = new Logger();
            logger.Open("server.log");

            // load the servers configuration
            SslServer socket = new SslServer();
            if (socket.SetUp("server.json")) {

                // Open a socket and listen for clients
                // the listener runs in a seperate thread
                // main thread returns here to allow for manual shutdown
                if (socket.Listen(new MySslFactory())) {

                    // this main thread waits for users to signal shutdown
                    Thread.Sleep(5000);
                    for (;;) {
                        logger.Info("Enter 'Shutdown' to terminate...");
                        string cmd = Console.ReadLine();
                        if (cmd.ToLower() == "shutdown") {
                            socket.ShutDown();
                            break;
                        }
                    }
                }
            }

            // and then exits
            Console.Write("Press enter to finish...");
            Console.ReadLine();
            logger.Close();
        }
    }

    // ********************************************************************* //
    // This Factory produces your SslWorkers, the workers define             //
    // the protocol used during you TCP session.                             //
    // ********************************************************************* //
    public class MySslFactory : SslFactory {
        public override SslWorker Produce() {
            return new MyWorker();
        }
    }

    // ********************************************************************* //
    // Here is where your server talks to your client                        //
    // ********************************************************************* //
    public class MyWorker : SslWorker {
        public MyWorker() {
        }

        public override void EntryPoint() {
            logger.Echo = false;

            // Read a message from the client.   
            logger.Info("Waiting for client message...");
            string messageData = Recv();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Received: {0}", messageData);
            Console.ResetColor();

            // Write a message to the client.
            Send("Hello from the server");

            // Now just echo back everything we receive
            for (;;) {
                try {
                    string request = Recv();
                    if (request == "") continue; // handle timeouts gracefully

                    // echo to console
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Client says: " + request);
                    Console.ResetColor();

                    // process the request
                    if (request == "<EOF>") break; // recognize end of transmission

                    Console.WriteLine("Server says: " + request);
                    if (!Send(request)) break; // recognize failure
                } catch (Exception e) {
                    logger.Fail("Lost connection! " + e.Message);
                    break;
                }
            }

            try {
                logger.Echo = true;
                Disconnect();
            } catch { }
        }
    }
}
