namespace XSocket
{
    partial class XSocketClientCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XSocketClientCtrl));
            this.listBoxMsg = new System.Windows.Forms.ListBox();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.timerConnectCheck = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelIPAddress = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxServerIPAddress = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelPort = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxPort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelBufSize = new System.Windows.Forms.ToolStripLabel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxMsg
            // 
            this.listBoxMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMsg.FormattingEnabled = true;
            this.listBoxMsg.ItemHeight = 12;
            this.listBoxMsg.Location = new System.Drawing.Point(0, 69);
            this.listBoxMsg.Name = "listBoxMsg";
            this.listBoxMsg.Size = new System.Drawing.Size(620, 231);
            this.listBoxMsg.TabIndex = 28;
            // 
            // textBoxSend
            // 
            this.textBoxSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSend.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxSend.Location = new System.Drawing.Point(0, 35);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(620, 34);
            this.textBoxSend.TabIndex = 26;
            // 
            // timerConnectCheck
            // 
            this.timerConnectCheck.Interval = 1000;
            this.timerConnectCheck.Tick += new System.EventHandler(this.timerConnectCheck_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSize,
            this.toolStripButtonConnect,
            this.toolStripButtonSend,
            this.toolStripButtonClear,
            this.toolStripLabelIPAddress,
            this.toolStripTextBoxServerIPAddress,
            this.toolStripLabelPort,
            this.toolStripTextBoxPort,
            this.toolStripLabelBufSize});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(620, 35);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripButtonConnect
            // 
            this.toolStripButtonConnect.AutoSize = false;
            this.toolStripButtonConnect.AutoToolTip = false;
            this.toolStripButtonConnect.BackColor = System.Drawing.Color.Red;
            this.toolStripButtonConnect.CheckOnClick = true;
            this.toolStripButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonConnect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonConnect.Image")));
            this.toolStripButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConnect.Name = "toolStripButtonConnect";
            this.toolStripButtonConnect.Size = new System.Drawing.Size(70, 30);
            this.toolStripButtonConnect.Text = "Connect";
            this.toolStripButtonConnect.Click += new System.EventHandler(this.toolStripButtonConnect_Click);
            this.toolStripButtonConnect.MouseEnter += new System.EventHandler(this.toolStripButtonConnect_MouseEnter);
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
            this.toolStripLabelIPAddress.Size = new System.Drawing.Size(100, 32);
            this.toolStripLabelIPAddress.Text = "IPAddress(Server)";
            // 
            // toolStripTextBoxServerIPAddress
            // 
            this.toolStripTextBoxServerIPAddress.AutoSize = false;
            this.toolStripTextBoxServerIPAddress.Name = "toolStripTextBoxServerIPAddress";
            this.toolStripTextBoxServerIPAddress.Size = new System.Drawing.Size(110, 43);
            this.toolStripTextBoxServerIPAddress.Text = "127.0.0.1";
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
            this.toolStripLabelBufSize.Size = new System.Drawing.Size(120, 32);
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
            this.labelStatus.Size = new System.Drawing.Size(620, 30);
            this.labelStatus.TabIndex = 45;
            this.labelStatus.Text = "-";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // XSocketClientCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.listBoxMsg);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.toolStrip1);
            this.Name = "XSocketClientCtrl";
            this.Size = new System.Drawing.Size(620, 300);
            this.Load += new System.EventHandler(this.XControlSoketClient_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxMsg;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Timer timerConnectCheck;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonConnect;
        private System.Windows.Forms.ToolStripButton toolStripButtonSend;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.ToolStripLabel toolStripLabelIPAddress;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxServerIPAddress;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPort;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxPort;
        private System.Windows.Forms.ToolStripButton toolStripButtonSize;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ToolStripLabel toolStripLabelBufSize;
    }
}
