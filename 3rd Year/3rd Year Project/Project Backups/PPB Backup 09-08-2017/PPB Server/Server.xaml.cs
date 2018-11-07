using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace PPB_Server
{
    //Allows the TcpListener Active property to be accessed
    public class TcpListenerEx : TcpListener
    {
        public TcpListenerEx(IPEndPoint localEP) : base(localEP)
        {
        }
        public TcpListenerEx(IPAddress localaddr, int port) : base(localaddr, port)
        {
        }

        public new bool Active
        {
            get { return base.Active; }
        }
    }

    public partial class Server : Window
    {
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        int port = 2000;
        public volatile bool running = false;

        public Server()
        {
            InitializeComponent();
        }

        //Listen to incoming connections.
        private void Listen()
        {
            TcpListenerEx server = new TcpListenerEx(ip, port);

            server.Start();

            while(running == true)
            {
                TcpClient newClient = server.AcceptTcpClient();

                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                clientThread.IsBackground = true;
                clientThread.Start(newClient);
            }

            server.Stop();
        }

        private void HandleClient(object newClient)
        {
            TcpClient client = (TcpClient)newClient;
            NetworkStream stream = client.GetStream();

            while (running == true && client.Connected == true)
            {



                try
                {
                    

                    //stream.ReadTimeout = 10000;

                    MessageBox.Show(((IPEndPoint)client.Client.RemoteEndPoint).Port.ToString());
                    if (stream != null)
                    {
                        int i;
                        Byte[] bytes = new Byte[256];
                        String data = null;

                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            MessageBox.Show("From Client: " + data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }       
        }

        private void StartServer_Click(object sender, RoutedEventArgs e)
        {
            //Disables StartServerBtn & enables StopServerBtn
            StartServerBtn.IsEnabled = false;
            StopServerBtn.IsEnabled = true;

            //Sets server status and colour
            ServerStatusLabel.Content = "Server Online";
            ServerStatusLabel.Foreground = new SolidColorBrush(Colors.Green);

            running = true;

            Thread listenThread = new Thread(Listen);
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void StopServer_Click(object sender, RoutedEventArgs e)
        {
            //Enables StartServerBtn & disables StopServerBtn
            this.StartServerBtn.IsEnabled = true;
            this.StopServerBtn.IsEnabled = false;

            //Sets server status and colour
            this.ServerStatusLabel.Content = "Server Offline";
            this.ServerStatusLabel.Foreground = new SolidColorBrush(Colors.Red);

            running = false;
        }
    }
}
