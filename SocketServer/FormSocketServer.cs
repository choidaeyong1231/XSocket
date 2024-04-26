using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class FormSocketServer : Form
    {
        public FormSocketServer()
        {
            InitializeComponent();
        }

        private void FormSocketServer_Load(object sender, EventArgs e)
        {
            buttonAdd_Click(sender, e);
        }

        public void SizeChange(bool bSmall)
        {
            if(bSmall)
            {
                this.Size = new Size(225, 200);
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            else
            {
                this.Size = new Size(600, 405);
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        // 내 아이피를 가져온다
        private string GetMyIp()
        {
            IPHostEntry host;
            string szLocalIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    szLocalIP = ip.ToString();
                }
            }
            return szLocalIP;
        } 

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string szTabName = textBoxIPAddress.Text + " : " + textBoxPort.Text;

            Control[] controls = tabControlSokectClinet.Controls.Find(szTabName, true);

            if (controls.Length == 0)
            {
                XSocket.XSocketServerCtrl soketServer = new XSocket.XSocketServerCtrl
                {
                    Name = szTabName,
                    IPAddressText = textBoxIPAddress.Text,
                    //IPAddressText = getMyIp(),
                    PortText = textBoxPort.Text
                };


                TabPage tabPage = new TabPage
                {
                    Text = szTabName
                };


                soketServer.Dock = DockStyle.Fill;
                soketServer._actionSize = SizeChange;
                tabPage.Controls.Add(soketServer);

                tabControlSokectClinet.TabPages.Add(tabPage);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int nIndex = tabControlSokectClinet.SelectedIndex;

            Control[] controls = tabControlSokectClinet.TabPages[nIndex].Controls.Find(tabControlSokectClinet.TabPages[nIndex].Text, true);

            XSocket.XSocketServerCtrl soketServer = (XSocket.XSocketServerCtrl)controls[0];

            soketServer.Close();
            soketServer.Dispose();

            tabControlSokectClinet.TabPages.RemoveAt(nIndex);
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
