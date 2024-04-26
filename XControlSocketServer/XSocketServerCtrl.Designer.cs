namespace XSocket
{
    partial class XSocketServerCtrl
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XSocketServerCtrl));
            this.listBoxMsg = new System.Windows.Forms.ListBox();
            this.textBoxSendMsg = new System.Windows.Forms.TextBox();
            this.timerConnectCheck = new System.Windows.Forms.Timer(this.components);
            this.listBoxClient = new System.Windows.Forms.ListBox();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSendAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelIPAddress = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxIPAddress = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelPort = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxPort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelBufSize = new System.Windows.Forms.ToolStripLabel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxMsg
            // 
            this.listBoxMsg.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxMsg.FormattingEnabled = true;
            this.listBoxMsg.ItemHeight = 12;
            this.listBoxMsg.Location = new System.Drawing.Point(219, 65);
            this.listBoxMsg.Name = "listBoxMsg";
            this.listBoxMsg.Size = new System.Drawing.Size(359, 205);
            this.listBoxMsg.TabIndex = 39;
            // 
            // textBoxSendMsg
            // 
            this.textBoxSendMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSendMsg.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxSendMsg.Location = new System.Drawing.Point(0, 35);
            this.textBoxSendMsg.Multiline = true;
            this.textBoxSendMsg.Name = "textBoxSendMsg";
            this.textBoxSendMsg.Size = new System.Drawing.Size(578, 30);
            this.textBoxSendMsg.TabIndex = 37;
            // 
            // timerConnectCheck
            // 
            this.timerConnectCheck.Interval = 1000;
            this.timerConnectCheck.Tick += new System.EventHandler(this.timerConnectCheck_Tick);
            // 
            // listBoxClient
            // 
            this.listBoxClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxClient.FormattingEnabled = true;
            this.listBoxClient.ItemHeight = 12;
            this.listBoxClient.Location = new System.Drawing.Point(0, 65);
            this.listBoxClient.Name = "listBoxClient";
            this.listBoxClient.Size = new System.Drawing.Size(578, 205);
            this.listBoxClient.TabIndex = 42;
            this.listBoxClient.SelectedIndexChanged += new System.EventHandler(this.listBoxClient_SelectedIndexChanged);
            // 
            // toolStripMain
            // 
            this.toolStripMain.AutoSize = false;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSize,
            this.toolStripButtonStart,
            this.toolStripButtonSendAll,
            this.toolStripButtonSend,
            this.toolStripButtonClear,
            this.toolStripLabelIPAddress,
            this.toolStripTextBoxIPAddress,
            this.toolStripLabelPort,
            this.toolStripTextBoxPort,
            this.toolStripLabelBufSize});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(578, 35);
            this.toolStripMain.TabIndex = 43;
            this.toolStripMain.Text = "toolStrip";
            // 
            // toolStripButtonSize
            // 
            this.toolStripButtonSize.AutoSize = false;
            this.toolStripButtonSize.AutoToolTip = false;
            this.toolStripButtonSize.CheckOnClick = true;
            this.toolStripButtonSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSize.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSize.Image")));
            this.toolStripButtonSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSize.Name = "toolStripButtonSize";
            this.toolStripButtonSize.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonSize.Text = "L";
            this.toolStripButtonSize.CheckedChanged += new System.EventHandler(this.toolStripButtonSize_CheckedChanged);
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.AutoSize = false;
            this.toolStripButtonStart.AutoToolTip = false;
            this.toolStripButtonStart.BackColor = System.Drawing.Color.Red;
            this.toolStripButtonStart.CheckOnClick = true;
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(70, 30);
            this.toolStripButtonStart.Text = "Stop";
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            this.toolStripButtonStart.MouseEnter += new System.EventHandler(this.toolStripButtonStart_MouseEnter);
            // 
            // toolStripButtonSendAll
            // 
            this.toolStripButtonSendAll.AutoSize = false;
            this.toolStripButtonSendAll.AutoToolTip = false;
            this.toolStripButtonSendAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripButtonSendAll.Checked = true;
            this.toolStripButtonSendAll.CheckOnClick = true;
            this.toolStripButtonSendAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonSendAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSendAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSendAll.Image")));
            this.toolStripButtonSendAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSendAll.Name = "toolStripButtonSendAll";
            this.toolStripButtonSendAll.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonSendAll.Text = "All";
            this.toolStripButtonSendAll.Click += new System.EventHandler(this.toolStripButtonSendAll_Click);
            this.toolStripButtonSendAll.MouseEnter += new System.EventHandler(this.toolStripButtonSendAll_MouseEnter);
            // 
            // toolStripButtonSend
            // 
            this.toolStripButtonSend.AutoSize = false;
            this.toolStripButtonSend.AutoToolTip = false;
            this.toolStripButtonSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSend.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSend.Image")));
            this.toolStripButtonSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSend.Name = "toolStripButtonSend";
            this.toolStripButtonSend.Size = new System.Drawing.Size(40, 40);
            this.toolStripButtonSend.Text = "Send";
            this.toolStripButtonSend.Click += new System.EventHandler(this.toolStripButtonSend_Click);
            this.toolStripButtonSend.MouseEnter += new System.EventHandler(this.toolStripButtonSend_MouseEnter);
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.AutoSize = false;
            this.toolStripButtonClear.AutoToolTip = false;
            this.toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClear.Image")));
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(40, 40);
            this.toolStripButtonClear.Text = "Clear";
            this.toolStripButtonClear.Click += new System.EventHandler(this.toolStripButtonClear_Click);
            this.toolStripButtonClear.MouseEnter += new System.EventHandler(this.toolStripButtonClear_MouseEnter);
            // 
            // toolStripLabelIPAddress
            // 
            this.toolStripLabelIPAddress.Name = "toolStripLabelIPAddress";
            this.toolStripLabelIPAddress.Size = new System.Drawing.Size(59, 32);
            this.toolStripLabelIPAddress.Text = "IPAddress";
            // 
            // toolStripTextBoxIPAddress
            // 
            this.toolStripTextBoxIPAddress.AutoSize = false;
            this.toolStripTextBoxIPAddress.Name = "toolStripTextBoxIPAddress";
            this.toolStripTextBoxIPAddress.Size = new System.Drawing.Size(110, 43);
            this.toolStripTextBoxIPAddress.Text = "127.0.0.1";
            // 
            // toolStripLabelPort
            // 
            this.toolStripLabelPort.Name = "toolStripLabelPort";
            this.toolStripLabelPort.Size = new System.Drawing.Size(29, 32);
            this.toolStripLabelPort.Text = "Port";
            // 
            // toolStripTextBoxPort
            // 
            this.toolStripTextBoxPort.AutoSize = false;
            this.toolStripTextBoxPort.Name = "toolStripTextBoxPort";
            this.toolStripTextBoxPort.Size = new System.Drawing.Size(50, 43);
            this.toolStripTextBoxPort.Text = "9001";
            // 
            // toolStripLabelBufSize
            // 
            this.toolStripLabelBufSize.AutoSize = false;
            this.toolStripLabelBufSize.Name = "toolStripLabelBufSize";
            this.toolStripLabelBufSize.Size = new System.Drawing.Size(80, 32);
            this.toolStripLabelBufSize.Text = "-";
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelStatus.Location = new System.Drawing.Point(0, 270);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(20, 3, 3, 10);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(578, 30);
            this.labelStatus.TabIndex = 44;
            this.labelStatus.Text = "-";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // XSocketServerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxMsg);
            this.Controls.Add(this.listBoxClient);
            this.Controls.Add(this.textBoxSendMsg);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.labelStatus);
            this.Name = "XSocketServerCtrl";
            this.Size = new System.Drawing.Size(578, 300);
            this.Load += new System.EventHandler(this.XControlSocketServer_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxMsg;
        private System.Windows.Forms.TextBox textBoxSendMsg;
        private System.Windows.Forms.Timer timerConnectCheck;
        private System.Windows.Forms.ListBox listBoxClient;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonSend;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.ToolStripLabel toolStripLabelIPAddress;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxIPAddress;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPort;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxPort;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ToolStripButton toolStripButtonSize;
        private System.Windows.Forms.ToolStripLabel toolStripLabelBufSize;
        private System.Windows.Forms.ToolStripButton toolStripButtonSendAll;
    }
}
