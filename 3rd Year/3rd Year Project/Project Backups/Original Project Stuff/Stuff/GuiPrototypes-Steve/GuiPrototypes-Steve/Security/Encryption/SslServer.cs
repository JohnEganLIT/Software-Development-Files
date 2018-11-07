using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Security {
    public class SslServer : SslSocket {
        protected Dictionary<string, TcpClient> clients;
        protected Dictionary<string, SslStream> streams;
        protected Dictionary<string, Thread> threads;
        protected SslFactory Factory;
        protected TcpListener server;
        protected Thread listener;
        protected long count;

        public SslServer() {
            logger = new Logger();
            logger.Open("server.log");
            clients = new Dictionary<string, TcpClient>();
            streams = new Dictionary<string, SslStream>();
            threads = new Dictionary<string, Thread>();
            count = 0;
        }

        public SslServer(Logger log) {
            logger = log;
            clients = new Dictionary<string, TcpClient>();
            streams = new Dictionary<string, SslStream>();
            threads = new Dictionary<string, Thread>();
            count = 0;
        }

        ~SslServer() {
            logger.Close();
        }

        // ********************************************************************
        // Listen to the Port for Client Connections
        // ********************************************************************
        public bool Listen(SslFactory WorkerFactory) {
            Factory = WorkerFactory;

            // SSL TCP Connection Configuration
            string host = config["host"];
            int    port = int.Parse(config["port"]);
            string cert = config["cert"];
            string pass = config["pass"];
            try {
                localCert = new X509Certificate2(cert, pass);
                ServicePointManager.ServerCertificateValidationCallback +=
                    new RemoteCertificateValidationCallback(ValidateCertificate);
            } catch (Exception e) {
                logger.Fail("Server Certificate is invalid\n"+e.Message);
                return false;
            }

            // Create a TCP/IP (IPv4) socket and listen for incoming connections.
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            listener = new Thread(new ThreadStart(this.Listener));
            listener.Start();
            return true;
        }

        private void Listener() {
            int timeout = int.Parse(config["timeout"]);
            Thread.Sleep(1000);
            while (true) {
                // Application blocks while waiting for an incoming connection.
                // Type CNTL-C to terminate the server.
                logger.Info("Waiting for a client to connect...");
                try {
                    client = server.AcceptTcpClient();
                } catch (SocketException e) {
                    if (e.SocketErrorCode == SocketError.Interrupted) break;
                }

                stream = new SslStream(client.GetStream(), false);
                if (!ServerValidate(localCert)) continue;

                if (timeout > 0) {
                    stream.ReadTimeout = timeout;
                    stream.WriteTimeout = timeout;
                }

                count++;
                host = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                port = ((IPEndPoint)client.Client.RemoteEndPoint).Port.ToString();
                this.userid = host + ":" + port + "("+count.ToString()+")";
                clients.Add(this.userid, client);
                streams.Add(this.userid, stream);
                logger.SetUser(this.userid);
                logger.Pass("Client Connected! " + this.userid);

                // create the worker thread
                SslWorker worker = Factory.Produce();
                worker.logger = new Logger();
                worker.logger.log = this.logger.log;
                worker.SetClient(client);
                worker.SetStream(stream);
                worker.SetHost(host);
                worker.SetPort(port);
                Thread thread = new Thread(new ThreadStart(worker.EntryPoint));
                threads.Add(this.userid, thread);
                thread.Start();
            }
        }

        // ********************************************************************
        // Shutdown the Server.
        // ********************************************************************
        public bool ShutDown() {
            string host = config["host"];
            int    port = int.Parse(config["port"]);

            logger.Info("Shutting Down Host {0}:{1}", host, port);
            server.Stop();

            foreach (SslStream s in streams.Values) {
                try {
                    s.Close();
                } catch (Exception e) {
                    logger.Pass("Failed to disconnect! {0}", e.Message);
                }
            }

            foreach (TcpClient c in clients.Values) {
                try {
                    c.Close();
                    logger.Pass("Disconnected from Host succeeded.");
                } catch (Exception e) {
                    logger.Pass("Failed to disconnect! {0}", e.Message);
                }
            }
            return Disconnect();
        }

        // ********************************************************************
        // Validate the Certificates and Record to Log
        // ********************************************************************
        protected bool ServerValidate(X509Certificate certificate) {
            // The server name must match the name on the server certificate.
            try {
                // Mutual SSL authentication (requires client certificate)
                stream.AuthenticateAsServer(certificate, true,
                    SslProtocols.Default, true);
                // SSL authentication only (do not require client certificate)
                //sslStream.AuthenticateAsServer(certificate, false,
                //    SslProtocols.Default, true);
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

