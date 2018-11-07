using System.Net.Security;
using System.Net.Sockets;

namespace Security {
    public class SslFactory {
        public virtual SslWorker Produce() {
            return new SslWorker();
        }
    }

    public class SslWorker : SslSocket {
        public SslWorker() {
            this.logger = new Logger();
        }

        public void SetClient(TcpClient c) {
            client = c;
        }

        public void SetStream(SslStream s) {
            stream = s;
        }

        public void SetHost(string host) {
            this.host = host;
        }
        public void SetPort(string port) {
            this.port = port;
        }
        public string GetHost() {
            return this.host;
        }
        public string GetPort() {
            return this.port;
        }

        // ********************************************************************
        // Server Side Thread for processing Clients.
        // ********************************************************************
        public virtual void EntryPoint() {
            logger.SetUser(this.host.ToString()+":"+this.port.ToString());
        }
    }
}
