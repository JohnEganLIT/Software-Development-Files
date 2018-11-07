using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Security {
    public class SslClient : SslSocket {
        protected X509Certificate2Collection certificates;

        public SslClient() {
            logger = new Logger();
            logger.Open("server.log");
        }

        public SslClient(Logger log) {
            logger = log;
        }

        ~SslClient() {
            logger.Close();
        }

        // ********************************************************************
        // Connect to the Server.
        // ********************************************************************
        public bool Connect() {
            if (config == null) {
                logger.Fail("You must load a configuration file first!");
                return false;
            }

            // SSL TCP Connection Configuration
            string host = config["host"];
            int    port = int.Parse(config["port"]);
            string cert = config["cert"];
            string pass = config["pass"];
            try {
                localCert = new X509Certificate2(cert, pass);
                certificates = new X509Certificate2Collection(localCert);
            } catch (Exception e) {
                logger.Fail("The clients Certificate is invalid", e.Message);
                return false;
            }

            // Create a TCP/IP client socket (host is the server domain or IP)
            logger.Info("Connecting to {0}:{1}", host, port);
            try {
                client = new TcpClient(host, port);
                logger.Pass("Connected to {0}:{1}", host, port);
            } catch (Exception e) {
                logger.Fail("Failed to Connect to {0}:{1}! {2}",
                    host, port, e.Message);
                return false;
            }

            // Create an SSL stream that will close the client's stream.
            stream = new SslStream(client.GetStream(),
                false, ValidateCertificate);

            return ClientValidate();
        }

        // ********************************************************************
        // Validate the Certificates and Record to Log
        // ********************************************************************
        protected bool ClientValidate() {
            // The server name must match the name on the server certificate.
            try {
                string host = config["host"];
                stream.AuthenticateAsClient(host, certificates,
                    SslProtocols.Default, true);
            } catch (AuthenticationException e) {
                logger.Fail("Failed to authenticate certificate: "+e.Message);
                if (e.InnerException != null) {
                    logger.Fail("Failed to authenticate certificate: {0}",
                        e.InnerException.Message);
                }
                Disconnect();
                return false;
            }
            LogCerificateCredentials(stream);
            return true;
        }
    }
}
