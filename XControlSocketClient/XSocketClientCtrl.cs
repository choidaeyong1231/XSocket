using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace XSocket
{
    public partial class XSocketClientCtrl : UserControl
    {
        public class AsyncObject
        {
            public byte[] byteBuffers;
            public readonly int nBufferSize;
            public IPEndPoint _endPointLocal = null;
            public Socket SocketWorking;

            public AsyncObject(int bufferSize)
            {
                nBufferSize = bufferSize;
                byteBuffers = new byte[(long)nBufferSize];
            }

            public void ClearBuffer()
            {
                Array.Clear(byteBuffers, 0, nBufferSize);
            }
        }

        public bool _bConnected { get; set; } = false;
        public Socket _socket = null;
        public int _nSocketBufferSize { get; set; } = 1024;
        
        public Action<bool> _actionSize = null;
        public Action<string, AsyncObject> _actionDataReceived = null;

        public string IPAddressText
        {
            get { return toolStripTextBoxServerIPAddress.Text; }
            set { toolStripTextBoxServerIPAddress.Text = value; }
        }

        public string PortText
        {
            get { return toolStripTextBoxPort.Text; }
            set { toolStripTextBoxPort.Text = value; }
        }

        public XSocketClientCtrl()
        {
            InitializeComponent();
        }

        private void XControlSoketClient_Load(object sender, EventArgs e)
        {
            toolStripLabelBufSize.Text = _nSocketBufferSize.ToString();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            Disconnect();
        }

        public void Connect()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress iPAddressServer = IPAddress.Parse(toolStripTextBoxServerIPAddress.Text);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddressServer, int.Parse(toolStripTextBoxPort.Text));

            _socket.BeginConnect(iPEndPoint, new AsyncCallback(ConnectCallback), _socket);
        }

        public void Disconnect()
        {
            if (_socket != null)
            {
                timerConnectCheck.Stop();

                if (_socket.Connected)
                    _socket.Shutdown(SocketShutdown.Both);

                _socket.Close();
                _socket.Dispose();
                _socket = null;
            }
        }

        public void Close()
        {
            Disconnect();

            toolStripButtonConnect.BackColor = Color.Red;
            toolStripLabelBufSize.Text = _nSocketBufferSize.ToString();
        }

        void ConnectCallback(IAsyncResult asyncResult)
        {
            try
            {
                Socket socketClient = (Socket)asyncResult.AsyncState;
                socketClient.EndConnect(asyncResult);

                AsyncObject asyncObject = new AsyncObject(_nSocketBufferSize)
                {
                    _endPointLocal = (IPEndPoint)socketClient.LocalEndPoint,
                    SocketWorking = _socket
                };

                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        toolStripLabelBufSize.Text = socketClient.LocalEndPoint.ToString();
                    }));
                }
                else
                {
                    toolStripLabelBufSize.Text = socketClient.LocalEndPoint.ToString();
                }

                _socket.BeginReceive(asyncObject.byteBuffers, 0, asyncObject.nBufferSize, 0, DataReceived, asyncObject);

                timerConnectCheck.Start();
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate 
                    {
                        toolStripButtonConnect.Checked = false;
                        labelStatus.Text = ex.Message;
                    }));
                }
                else
                {
                    toolStripButtonConnect.Checked = false;
                    labelStatus.Text = ex.Message;
                }
            }
        }

        void DataReceived(IAsyncResult asyncResult)
        {
            AsyncObject asyncObject = (AsyncObject)asyncResult.AsyncState;

            try
            {
                int nReceived = asyncObject.SocketWorking.EndReceive(asyncResult, out SocketError socketError);
                if (socketError == SocketError.Success && nReceived > 0) // 정상적인 상태
                {
                    byte[] byteBuffers = new byte[nReceived];

                    Array.Copy(asyncObject.byteBuffers, 0, byteBuffers, 0, nReceived);

                    string szEncodingData = Encoding.UTF8.GetString(byteBuffers, 0, nReceived);
                    if (_actionDataReceived != null)
                        _actionDataReceived(szEncodingData, asyncObject);

                    string szData = "R : " + szEncodingData;

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            labelStatus.Text = szData;
                            listBoxMsg.Items.Add(szData);
                        }));
                    }
                    else
                    {
                        labelStatus.Text = szData;
                        listBoxMsg.Items.Add(szData);
                    }

                    if (asyncObject.SocketWorking.Connected)
                        asyncObject.SocketWorking.BeginReceive(asyncObject.byteBuffers, 0, _nSocketBufferSize, 0, DataReceived, asyncObject);

                    asyncObject.ClearBuffer();
                }
            }
            catch(Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        labelStatus.Text = ex.Message;
                    }));
                }
                else
                {
                    labelStatus.Text = ex.Message;
                }
            }
        }

        public void Send(string szMessage)
        {
            byte[] byteMessages = Encoding.UTF8.GetBytes(szMessage);

            _socket?.Send(byteMessages);
        }

        public void ReceivedAdd(byte[] byteDatas)
        {
            string szData = Encoding.Default.GetString(byteDatas);

            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate 
                {
                    labelStatus.Text = szData;
                    listBoxMsg.Items.Add(szData);
                }));
            }
            else
            {
                labelStatus.Text = szData;
                listBoxMsg.Items.Add(szData);
            }
        }

        private void timerConnectCheck_Tick(object sender, EventArgs e)
        {
            if ((_socket.Poll(1000, SelectMode.SelectRead) && (_socket.Available == 0)))
            {
                if (!_socket.Connected)
                {
                    toolStripButtonConnect.Checked = false;
                    timerConnectCheck.Stop();
                    _bConnected = false;
                }
                else
                    _bConnected = true;
            }
        }

        private void toolStripButtonConnect_Click(object sender, EventArgs e)
        {
            if (toolStripButtonConnect.Checked)
                Connect();
            else
                Close();
        }

        private void toolStripButtonSend_Click(object sender, EventArgs e)
        {
            Send(textBoxSend.Text);
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            listBoxMsg.Items.Clear();
        }

        private void toolStripButtonSize_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripButtonSize.Checked)
            {
                toolStripButtonSize.Text = "S";
                _actionSize?.Invoke(true);
            }
            else
            {
                toolStripButtonSize.Text = "L";
                _actionSize?.Invoke(false);
            }
        }

        private void toolStripButtonConnect_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void toolStripButtonSend_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void toolStripButtonClear_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}
