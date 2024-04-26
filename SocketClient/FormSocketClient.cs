using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using XSocket;

namespace SoketClient
{
    public partial class FormSoketClient : Form
    {
        public FormSoketClient()
        {
            InitializeComponent();
        }

        private void FormSoketClient_Load(object sender, EventArgs e)
        {
            int nTabCount = 0;
            string szFilePath = null;
            FileInfo fileInfo = null;

            szFilePath = Application.StartupPath + "\\Initialize.ini";
            fileInfo = new FileInfo(szFilePath);

            if (fileInfo.Exists)
            {
                SoketClient.XClassINI classINI = new SoketClient.XClassINI();
                classINI.Setting("Client", "Count", szFilePath);
                nTabCount = int.Parse(classINI.Read("Count"));

                for (int i = 0; i < nTabCount; i++)
                {
                    string szIPAddress = null;
                    string szPort = null;

                    TabPage tabPage = null;

                    classINI._szSection = i.ToString();
                    szIPAddress = classINI.Read("IPAddress");
                    szPort = classINI.Read("Port");

                    ClientTabAdd();

                    tabPage = tabControlSokectClinet.TabPages[i];

                    XSocketClientCtrl socketClient = (XSocketClientCtrl)tabPage.Controls[0];

                    socketClient.IPAddressText = szIPAddress;
                    socketClient.PortText = szPort;
                }
            }
            else
                buttonAdd_Click(sender, e);
        }

        private void FormSoketClient_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public void SizeChange(bool bSmall)
        {
            if (bSmall)
            {
                this.Size = new Size(225, 200);
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            else
            {
                this.Size = new Size(650, 405);
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        public void ClientTabAdd()
        {
            XSocket.XSocketClientCtrl socketClient = new XSocket.XSocketClientCtrl
            {
                IPAddressText = textBoxIPAddress.Text,
                PortText = textBoxPort.Text,
                Dock = DockStyle.Fill,
                _actionSize = SizeChange
            };

            string szTabCount = tabControlSokectClinet.TabCount.ToString();

            TabPage tabPage = new TabPage
            {
                Text = szTabCount
            };


            tabPage.Controls.Add(socketClient);
            tabControlSokectClinet.TabPages.Add(tabPage);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ClientTabAdd();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int nCount = tabControlSokectClinet.TabCount;

            tabControlSokectClinet.TabPages.RemoveAt(nCount - 1);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int nTabCount = 0;
            string szFilePath = null;
            FileInfo fileInfo = null;

            szFilePath = Application.StartupPath + "\\Initialize.ini";
            fileInfo = new FileInfo(szFilePath);

            if (fileInfo.Exists)
                fileInfo.Delete();

            nTabCount = tabControlSokectClinet.TabCount;

            SoketClient.XClassINI classINI = new SoketClient.XClassINI();
            classINI.Setting("Client", "Count", szFilePath);
            classINI.Write(nTabCount.ToString());

            for (int i = 0; i < nTabCount; i++)
            {
                TabPage tabPage = tabControlSokectClinet.TabPages[i];

                XSocketClientCtrl socketClient = (XSocketClientCtrl)tabPage.Controls[0];

                string szIPAddress = socketClient.IPAddressText;
                string szPort = socketClient.PortText;

                classINI._szSection = i.ToString();
                classINI._szKey = "IPAddress";
                classINI.Write(szIPAddress);

                classINI._szKey = "Port";
                classINI.Write(szPort);
            }
        }

        private void checkBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTopMost.Checked)
                this.TopMost = true;
            else
                this.TopMost = false;
        }
    }
}
