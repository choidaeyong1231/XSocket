using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace XSocket
{
    public partial class XSocketServerCtrl : UserControl
    {
        public class AsyncObject
        {
            public byte[] _byteBuffers;
            public Socket _socketWorking;
            public IPEndPoint _endPointClient = null;
            public readonly int _nBufferSize;
            public AsyncObject(int nBufferSize)
            {
                _nBufferSize = nBufferSize;
                _byteBuffers = new byte[(long)_nBufferSize];
            }

            public void ClearBuffer()
            {
                Array.Clear(_byteBuffers, 0, _nBufferSize);
            }
        }

        public bool _bSendAll = true;
        public int _nSocketBufferSize { get; set; } = 1024;

        public Socket _socketServer = null;
        public List<Socket> _listSocketClient = new List<Socket>();
        public List<List<string>> _listMsgHistory = new List<List<string>>();

        public Action<bool> _actionSize = null;
        public Action<string, AsyncObject> _actionDataReceived = null;

        public string IPAddressText
        {
            get { return toolStripTextBoxIPAddress.Text; }
            set { toolStripTextBoxIPAddress.Text = value; }
        }

        public string PortText
        {
            get { return toolStripTextBoxPort.Text; }
            set { toolStripTextBoxPort.Text = value; }
        }
        
        public XSocketServerCtrl()
        {
            InitializeComponent();
        }

        private void XControlSocketServer_Load(object sender, EventArgs e)
        {
            toolStripLabelBufSize.Text = _nSocketBufferSize.ToString();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            Stop();
        }

        public void Close()
        {
            Stop();

            _listSocketClient.Clear();
            listBoxClient.Items.Clear();

            listBoxMsg.Items.Clear();
            textBoxSendMsg.Clear();

            toolStripButtonStart.BackColor = Color.Red;
        }

        public void Start()
        {
            timerConnectCheck.Start();

            IPAddress iPAddress = IPAddress.Parse(toolStripTextBoxIPAddress.Text);
            int nPort = int.Parse(toolStripTextBoxPort.Text);

            if (_socketServer == null)
            {
                _socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint serverEP = new IPEndPoint(iPAddress, nPort);

                _socketServer.Bind(serverEP);
                _socketServer.Listen(10);
                _socketServer.BeginAccept(AcceptCallback, null);

                labelStatus.Text = "The server has been created.";
            }
            else
            {
                labelStatus.Text = "The server has already been created.";
            }
        }

        public void Stop()
        {
            // 클라이언트 상태 확인 타이머 정지
            timerConnectCheck.Stop();

            for (int i = 0; i < _listSocketClient.Count; i++)
            {
                if (_listSocketClient[i].Connected)
                    _listSocketClient[i].Shutdown(SocketShutdown.Both);

                _listSocketClient[i].Close();
                _listSocketClient[i].Dispose();
                _listSocketClient[i] = null;
            }
        }

        void DataReceived(IAsyncResult asyncResult)
        {
            AsyncObject asyncObject = (AsyncObject)asyncResult.AsyncState;

            try
            {
                int nReceived = asyncObject._socketWorking.EndReceive(asyncResult, out SocketError socketError);
                if (socketError == SocketError.Success && nReceived > 0) // 정상적인 상태
                {
                    byte[] byteDatas = new byte[nReceived];
                    Array.Copy(asyncObject._byteBuffers, 0, byteDatas, 0, nReceived);

                    string szEncodingData = Encoding.UTF8.GetString(byteDatas, 0, nReceived);
                    if (_actionDataReceived != null)
                        _actionDataReceived(szEncodingData, asyncObject);

                    string szData = "R : " + szEncodingData;

                    this.Invoke(new EventHandler(delegate
                    {
                        int nIndex = -1;
                        for (int i = 0; i < _listSocketClient.Count; i++)
                        {
                            if (_listSocketClient[i] == asyncObject._socketWorking)
                            {
                                nIndex = i;
                                break;
                            }
                        }

                        if (listBoxClient.SelectedIndex != nIndex)
                            listBoxClient.SelectedIndex = nIndex;

                        listBoxMsg.Items.Add(szData);
                        labelStatus.Text = szData;
                        _listMsgHistory[nIndex].Add(szData);
                    }));

                    asyncObject._socketWorking.BeginReceive(asyncObject._byteBuffers, 0, _nSocketBufferSize, 0, DataReceived, asyncObject);
                }
                else // 비정상 적인 상태
                {
                    for (int i = 0; i < _listSocketClient.Count; i++)
                    {
                        if (_listSocketClient[i] == asyncObject._socketWorking)
                        {
                            _listSocketClient[i].Dispose();
                            _listSocketClient[i].Close();
                            break;
                        }
                    }
                }
            }
            catch
            {
                for (int i = 0; i < _listSocketClient.Count; i++)
                {
                    if (_listSocketClient[i] == asyncObject._socketWorking)
                    {
                        _listSocketClient[i].Dispose();
                        _listSocketClient[i].Close();
                        break;
                    }
                }
            }
        }

        public void Send(string szSend, bool bOnlyData = false)
        {
            if (_bSendAll)
            {
                for (int i = 0; i < _listSocketClient.Count; i++)
                {
                    byte[] byteDatas = null;
                    byteDatas = Encoding.UTF8.GetBytes(szSend);

                    _listSocketClient[i].Send(byteDatas);

                    if (bOnlyData == false)
                    {
                        string szMsg = "S : " + szSend + "(" + _listSocketClient[i].RemoteEndPoint.ToString() + ")";
                        listBoxMsg.Items.Add(szMsg);
                        _listMsgHistory[listBoxClient.SelectedIndex].Add(szMsg);
                    }
                }
            }
            else
            {
                if (listBoxClient.SelectedIndex != -1)
                {
                    byte[] byteDatas = null;
                    byteDatas = Encoding.UTF8.GetBytes(szSend);

                    _listSocketClient[listBoxClient.SelectedIndex].Send(byteDatas);

                    if (bOnlyData == false)
                    {
                        string szMsg = "S : " + szSend + "(" + _listSocketClient[listBoxClient.SelectedIndex].RemoteEndPoint.ToString() + ")";
                        listBoxMsg.Items.Add(szMsg);
                        _listMsgHistory[listBoxClient.SelectedIndex].Add(szMsg);
                    }
                }
            }
        }

        void AcceptCallback(IAsyncResult asyncResult)
        {
            Socket socketClient = null;
            IPEndPoint clientEndPoint = null;
            try
            {
                socketClient = _socketServer.EndAccept(asyncResult);
                clientEndPoint = (IPEndPoint)socketClient.RemoteEndPoint;
                AsyncObject asyncObject = new AsyncObject(_nSocketBufferSize)
                {
                    _socketWorking = socketClient,
                    _endPointClient = clientEndPoint
                };

                socketClient.BeginReceive(asyncObject._byteBuffers, 0, _nSocketBufferSize, 0, DataReceived, asyncObject);

            }
            catch (Exception ex)
            {
                this.Invoke(new EventHandler(delegate
                {
                    labelStatus.Text = ex.Message;
                }));
            }
                
            if (socketClient != null)
            {
                string szData = clientEndPoint.ToString() + " Connect !!";

                _listSocketClient.Add(socketClient);
                _listMsgHistory.Add(new List<string>());

                this.Invoke(new EventHandler(delegate
                {
                    listBoxClient.Items.Add(clientEndPoint.ToString());
                    listBoxClient.SelectedIndex = listBoxClient.Items.Count - 1;

                    listBoxMsg.Items.Clear();
                    listBoxMsg.Items.Add(szData);
                    _listMsgHistory[listBoxClient.SelectedIndex].Add(szData);

                    labelStatus.Text = szData;
                }));

                _socketServer?.BeginAccept(AcceptCallback, null);
            }
        }
        
        private void listBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIndex = listBoxClient.SelectedIndex;

            if (nIndex == -1)
                return;

            listBoxMsg.Items.Clear();
            foreach (string szValue in _listMsgHistory[nIndex])
                listBoxMsg.Items.Add(szValue);
        }

        private void timerConnectCheck_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < _listSocketClient.Count; i++)
            {
                bool bIsConnected = false;
                try
                {
                    bIsConnected = !((_listSocketClient[i].Poll(1000, SelectMode.SelectRead) &&
                    (_listSocketClient[i].Available == 0)) || !_listSocketClient[i].Connected);

                    if (!bIsConnected)
                    {
                        _listSocketClient.Remove(_listSocketClient[i]);

                        if (listBoxClient.SelectedIndex == i)
                        {
                            listBoxMsg.Items.Clear();
                            textBoxSendMsg.Clear();
                        }

                        _listMsgHistory.RemoveAt(i);
                        listBoxClient.Items.RemoveAt(i);

                        i--;
                    }
                }
                catch(Exception ex)
                {
                    labelStatus.Text = ex.Message;

                    if (!bIsConnected)
                    {
                        _listSocketClient.Remove(_listSocketClient[i]);

                        if (listBoxClient.SelectedIndex == i)
                        {
                            listBoxMsg.Items.Clear();
                            textBoxSendMsg.Clear();
                        }

                        _listMsgHistory.RemoveAt(i);
                        listBoxClient.Items.RemoveAt(i);

                        i--;
                    }
                }
            }
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            if (toolStripButtonStart.Checked)
            {
                Start();
                toolStripButtonStart.Text = "Start";
            }
            else
            {
                Close();
                toolStripButtonStart.Text = "Stop";
            }
        }

        private void toolStripButtonSend_Click(object sender, EventArgs e)
        {
            if (_bSendAll)
            {
                for (int i = 0; i < _listSocketClient.Count; i++)
                {
                    byte[] bytes = null;
                    string szData = null;

                    szData = textBoxSendMsg.Text;
                    bytes = Encoding.UTF8.GetBytes(szData);

                    _listSocketClient[i].Send(bytes);

                    string szMsg = "S : " + szData + "(" + _listSocketClient[i].RemoteEndPoint.ToString() + ")";
                    listBoxMsg.Items.Add(szMsg);
                    _listMsgHistory[listBoxClient.SelectedIndex].Add(szMsg);
                }
            }
            else
            {
                if (listBoxClient.SelectedIndex != -1)
                {
                    byte[] bytes = null;
                    string szData = null;

                    szData = textBoxSendMsg.Text;
                    bytes = Encoding.UTF8.GetBytes(szData);

                    _listSocketClient[listBoxClient.SelectedIndex].Send(bytes);

                    string szMsg = "S : " + szData + "(" + _listSocketClient[listBoxClient.SelectedIndex].RemoteEndPoint.ToString() + ")";
                    listBoxMsg.Items.Add(szMsg);
                    _listMsgHistory[listBoxClient.SelectedIndex].Add(szMsg);
                }
            }
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            if (listBoxClient.SelectedIndex == -1)
            {
                labelStatus.Text = "Please select a client !";
                return;
            }

            listBoxMsg.Items.Clear();
            _listMsgHistory[listBoxClient.SelectedIndex].Clear();
        }

        private void toolStripButtonSize_CheckedChanged(object sender, EventArgs e)
        {
            if(toolStripButtonSize.Checked)
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

        private void toolStripButtonStart_MouseEnter(object sender, EventArgs e)
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

        private void toolStripButtonSendAll_Click(object sender, EventArgs e)
        {
            if (toolStripButtonSendAll.Checked)
            {
                _bSendAll = true;
                toolStripButtonSendAll.Text = "All";
            }
            else
            {
                _bSendAll = false;
                toolStripButtonSendAll.Text = listBoxClient.SelectedIndex.ToString();
            }
        }

        private void toolStripButtonSendAll_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}
