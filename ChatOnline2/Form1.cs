using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ChatOnline2
{
    public partial class Form1 : Form
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private Thread _receiveThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _client = new TcpClient();
            _client.Connect(IPAddress.Parse("127.0.0.1"), 5000);
            _stream = _client.GetStream();
            AppendText("\nПодключено к серверу.\n");

            _receiveThread = new Thread(ReceiveData);
            _receiveThread.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_client != null && _stream != null)
            {
                string message = txtMessage.Text;
                byte[] data = Encoding.ASCII.GetBytes(message);
                _stream.Write(data, 0, data.Length);

                AppendText($"\nВы: {message}");
                txtMessage.Clear();
            }
        }

        private void ReceiveData()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int byteCount = _stream.Read(buffer, 0, buffer.Length);
                    if (byteCount == 0)
                        break;

                    string message = Encoding.ASCII.GetString(buffer, 0, byteCount);
                    AppendText(message);
                }
                catch
                {
                    AppendText("\nОтключено от сервера.");
                    break;
                }
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
                if (!string.IsNullOrEmpty(text))
                {
                    txtChat.AppendText(text + Environment.NewLine);
                }
                
            }
        }
        
        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_client != null)
            {
                _stream.Close();
                _client.Close();
            }
        }
    }
}

