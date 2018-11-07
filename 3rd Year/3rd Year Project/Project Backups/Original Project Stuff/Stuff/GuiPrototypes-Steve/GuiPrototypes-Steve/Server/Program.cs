using Newtonsoft.Json;
using Security;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Threading;

namespace Server {
    class Program {
        public static DataAccess dao;

        static void Main(string[] args) {
            Logger logger = new Logger();
            logger.Open("server.log");

            dao = new DataAccess(logger);
            dao.Connect();

            // load the servers configuration
            SslServer socket = new SslServer(logger);
            if (socket.SetUp("server.json")) {

                // Open a socket and listen for clients
                // the listener runs in a seperate thread
                // main thread returns here to allow for manual shutdown
                if (socket.Listen(new Factory())) {

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
    public class Factory : SslFactory {
        public override SslWorker Produce() {
            return new Worker();
        }
    }
}
