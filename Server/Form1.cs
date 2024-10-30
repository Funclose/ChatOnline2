using System.Net.Sockets;
using System.Net;
using System.Text;


namespace Server
{
    public partial class Form1 : Form
    {
        private TcpListener _serverSocket;
        private static readonly object _lock = new object();
        private static readonly Dictionary<int, TcpClient> _clients = new Dictionary<int, TcpClient>();
        private int _clientCount = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            _serverSocket = new TcpListener(IPAddress.Any, 5000);
            _serverSocket.Start();
            AppendText("Сервер запущен...");

            Thread acceptThread = new Thread(AcceptClients);
            acceptThread.Start();
        }

        private void AcceptClients()
        {
            while (true)
            {
                TcpClient client = _serverSocket.AcceptTcpClient();
                lock (_lock) _clients.Add(_clientCount, client);
                AppendText($"\nКлиент {_clientCount} подключился.");

                Thread clientThread = new Thread(HandleClient);
                clientThread.Start(_clientCount);
                _clientCount++;
            }
        }

        private void HandleClient(object obj)
        {
            int clientId = (int)obj;
            TcpClient client;
            lock (_lock) client = _clients[clientId];

            while (true)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int byteCount = stream.Read(buffer, 0, buffer.Length);

                    if (byteCount == 0)
                    {
                        break;
                    }

                    string message = Encoding.ASCII.GetString(buffer, 0, byteCount);
                    AppendText($"\nСообщение от клиента {clientId}: {message}\n");

                    Broadcast(message, clientId);
                }
                catch
                {
                    break;
                }
            }

            lock (_lock) _clients.Remove(clientId);
            client.Close();
            AppendText($"\nКлиент {clientId} отключился.\n");
        }

        private void Broadcast(string message, int senderCLientId)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message + Environment.NewLine);
            lock (_lock)
            {
                foreach (var clientEntry in _clients)
                {
                    if (clientEntry.Key != senderCLientId)
                    { 
                    NetworkStream stream = clientEntry.Value.GetStream();
                    stream.Write(buffer , 0 , buffer.Length);
                    }
                }
            }
        }

        public void StopServer()
        {
            if (_serverSocket != null)
            {
                _serverSocket.Stop();
                Console.WriteLine("server stoped");

            }
        }

        private void AppendText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendText), text);
            }
            else
            {
                txtLog.AppendText(text + Environment.NewLine);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _serverSocket?.Stop();
        }
    }

}

