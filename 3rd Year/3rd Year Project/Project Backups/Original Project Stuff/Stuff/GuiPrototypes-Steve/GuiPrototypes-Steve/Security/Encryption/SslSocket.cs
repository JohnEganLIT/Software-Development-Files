using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Security {
    public abstract class SslSocket {
        public Logger logger;
        protected Config config;
        protected TcpClient client;
        protected SslStream stream;
        protected X509Certificate2 localCert;
        protected string host;
        protected string port;
        protected string userid;

        // ********************************************************************
        // Configuration Settings are imported from a JSON file.
        // ********************************************************************
        public bool SetUp(string path) {
            userid = "null";
            config = new Config(@path, logger);
            if (!config.Load()) return false;
            logger.SetUser(config["host"]+":"+config["port"]);
            return true;
        }

        // ********************************************************************
        // Disconnect from the Server.
        // ********************************************************************
        public bool Disconnect() {
            try {
                stream.Close();
                client.Close();
                logger.Pass("Disconnected from Host succeeded.");
            } catch (Exception e) {
                logger.Pass("Failed to disconnect! {0}", e.Message);
                return false;
            }
            config.Save();
            return true;
        }

        // ********************************************************************
        // Send a message to the server.
        // ********************************************************************
        public bool Send(string text) {
            if (stream == null) {
                logger.Debug("Send Failed - No connection established!");
                return false;
            }

            // The UTF-8 character for "end of text" is 0x03
            byte[] plainText = Encoding.UTF8.GetBytes(text + "\x03");
            stream.Write(plainText);
            stream.Flush();
            logger.Send("{0}", text);
            return true;
        }

        // ********************************************************************
        // Read a message sent by the server.
        // ********************************************************************
        public string Recv() {
            if (stream == null) {
                logger.Debug("Recv Failed - No connection established!");
                return null;
            }

            byte[] data = new byte[2048];
            StringBuilder builder = new StringBuilder();
            for (int bytes = 1; bytes > 0;) {
                try {
                    bytes = stream.Read(data, 0, 2048);
                } catch {
                    continue;
                }
                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(data, 0, bytes)];
                decoder.GetChars(data, 0, bytes, chars, 0);
                builder.Append(chars);

                // The UTF-8 character for "end of text" is 0x03
                if (builder.ToString().IndexOf("\x03") != -1) break;
            }
            string recv = Regex.Replace(builder.ToString(), @"\x03", "");
            logger.Recv("{0}", recv);
            return recv;
        }

        // ********************************************************************
        // Validate the Certificate (which is Self Signed During Development).
        // ********************************************************************
        protected bool ValidateCertificate(object sender,
            X509Certificate certificate,
            X509Chain chain, SslPolicyErrors sslPolicyErrors) {

            // During development we allow self signed certificates to be used.
            if (config["isSelfSigned"] == "true") {
                logger.Warn("Certificate is Self Signed");
                return true;

                // Outside of production all certificates to be signed by a
                // Trusted Certificate Authority recognized by Windows
            } else if (sslPolicyErrors == SslPolicyErrors.None) {
                logger.Fail("Certificate NOT Signed by a Trusted Authority");
                return false;
            } else {
                logger.Pass("Certificate is Signed by a Trusted Authority");
                return true;
            }
        }

        // ********************************************************************
        // Creates a log entry of the Established Connection and Certificates
        // ********************************************************************
        protected void LogCerificateCredentials(SslStream stream) {
            // ****************************************************************
            // SSL TCP Session Info
            // ****************************************************************
            logger.Pass("SSL Cipher: {0} strength {1}",
                stream.CipherAlgorithm, stream.CipherStrength);
            logger.Pass("SSL Hash: {0} strength {1}",
                stream.HashAlgorithm, stream.HashStrength);
            logger.Pass("SSL Key exchange: {0} strength {1}",
                stream.KeyExchangeAlgorithm, stream.KeyExchangeStrength);
            logger.Pass("SSL Protocol: {0}", stream.SslProtocol);
            logger.Pass("SSL Is Authenticated? {0}", stream.IsAuthenticated);
            logger.Pass("SSL Authenticated as Server? {0}", stream.IsServer);
            logger.Pass("SSL Is Signed? {0}", stream.IsSigned);
            logger.Pass("SSL Is Encrypted? {0}", stream.IsEncrypted);
            logger.Pass("SSL Certificate Revocation List Checked? {0}",
                stream.CheckCertRevocationStatus);
            logger.Pass("SSL Can Read? {0}", stream.CanRead);
            logger.Pass("SSL Can Write? {0}", stream.CanWrite);
            logger.Pass("SSL Can Timeout? {0}", stream.CanTimeout);

            // ****************************************************************
            // local Certificate
            // ****************************************************************
            X509Certificate localCertificate = stream.LocalCertificate;
            if (stream.LocalCertificate != null) {
                logger.Pass("Local Certificate Authority {0}",
                    localCertificate.Subject);
                logger.Pass("Local Certificate is valid from {0}",
                    localCertificate.GetEffectiveDateString());
                logger.Pass("Local Certificate is valid until {0}",
                    localCertificate.GetExpirationDateString());
            } else {
                logger.Fail("Local Certificate is null.");
            }

            // ****************************************************************
            // Remote Certificate
            // ****************************************************************
            X509Certificate remoteCertificate = stream.RemoteCertificate;
            if (remoteCertificate != null) {
                logger.Pass("Remote Certificate Authority {0}",
                    remoteCertificate.Subject);
                logger.Pass("Remote Certificate is valid from {0}",
                    remoteCertificate.GetEffectiveDateString());
                logger.Pass("Remote Certificate is valid until {0}",
                    remoteCertificate.GetExpirationDateString());
            } else {
                logger.Fail("Remote certificate is null.");
            }
        }
    }
}
