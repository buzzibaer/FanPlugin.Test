namespace FanPlugin.Test
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabV2 = new System.Windows.Forms.TabPage("Fan V2");
            this.tabV3 = new System.Windows.Forms.TabPage("Fan V3");
            this.tab20320 = new System.Windows.Forms.TabPage("Fan20320");
            this.tbLog = new System.Windows.Forms.TextBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txt20320VideoId = new System.Windows.Forms.TextBox();
            this.txtV2Ip = NewSetting("txtV2Ip", "192.168.4.1");
            this.txtV2Port = NewSetting("txtV2Port", "5233");
            this.txtV2ConnectTimeout = NewSetting("txtV2ConnectTimeout", "3000");
            this.txtV2SocketTimeout = NewSetting("txtV2SocketTimeout", "3000");
            this.txtV3Ip = NewSetting("txtV3Ip", "192.168.4.1");
            this.txtV3Port = NewSetting("txtV3Port", "5233");
            this.txtV3ConnectTimeout = NewSetting("txtV3ConnectTimeout", "3000");
            this.txtV3SocketTimeout = NewSetting("txtV3SocketTimeout", "3000");
            this.txt20320Ip = NewSetting("txt20320Ip", "192.168.4.1");
            this.txt20320Port = NewSetting("txt20320Port", "20320");
            this.txt20320ConnectTimeout = NewSetting("txt20320ConnectTimeout", "3000");
            this.txt20320SocketTimeout = NewSetting("txt20320SocketTimeout", "3000");

            this.tabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabs.Height = 285;
            this.tabs.Controls.Add(this.tabV2);
            this.tabs.Controls.Add(this.tabV3);
            this.tabs.Controls.Add(this.tab20320);
            this.tabV2.Controls.Add(CreateSettingsPanel("Fan V2 settings", txtV2Ip, txtV2Port, txtV2ConnectTimeout, txtV2SocketTimeout));
            this.tabV3.Controls.Add(CreateSettingsPanel("Fan V3 settings", txtV3Ip, txtV3Port, txtV3ConnectTimeout, txtV3SocketTimeout));
            this.tab20320.Controls.Add(CreateSettingsPanel("Fan20320 settings", txt20320Ip, txt20320Port, txt20320ConnectTimeout, txt20320SocketTimeout));

            AddButton(this.tabV2, "Set Video on Fan", 15, 105, this.button1_Click);
            AddLabel(this.tabV2, "Video ID", 15, 80);
            this.textBox1.Location = new System.Drawing.Point(85, 77); this.textBox1.Size = new System.Drawing.Size(70, 20); this.textBox1.Text = "6";
            this.tabV2.Controls.Add(this.textBox1);
            AddButton(this.tabV2, "Single Video Mode", 15, 140, this.radioActionV2Single);
            AddButton(this.tabV2, "Loop through Videos", 175, 140, this.radioActionV2Loop);
            AddButton(this.tabV2, "Get File List From Fan", 15, 175, this.button3_Click);
            AddButton(this.tabV2, "Play last Video", 175, 175, this.button4_Click);
            AddButton(this.tabV2, "Play Old Video File", 335, 175, this.button5_Click);

            AddLabel(this.tabV3, "Video ID", 15, 80);
            this.textBox3.Location = new System.Drawing.Point(85, 77); this.textBox3.Size = new System.Drawing.Size(70, 20); this.textBox3.Text = "6";
            this.tabV3.Controls.Add(this.textBox3);
            AddButton(this.tabV3, "Set Video on Fan", 15, 105, this.button9_Click);
            AddButton(this.tabV3, "Single Video Mode", 15, 140, this.radioActionV3Single);
            AddButton(this.tabV3, "Loop through Videos", 175, 140, this.radioActionV3Loop);
            AddButton(this.tabV3, "Get File List From Fan", 15, 175, this.button12_Click);
            AddButton(this.tabV3, "Play last Video", 175, 175, this.button11_Click);
            AddButton(this.tabV3, "Play Old Video File", 335, 175, this.button10_Click);
            AddButton(this.tabV3, "Turn Fan ON", 15, 210, this.button8_Click);
            AddButton(this.tabV3, "Turn Fan OFF", 175, 210, this.button7_Click);

            AddLabel(this.tab20320, "Video ID", 15, 80);
            this.txt20320VideoId.Location = new System.Drawing.Point(85, 77); this.txt20320VideoId.Size = new System.Drawing.Size(90, 20); this.txt20320VideoId.Text = "5";
            this.tab20320.Controls.Add(this.txt20320VideoId);
            AddButton(this.tab20320, "Play Video", 15, 115, this.buttonFan20320Play_Click);
            var note = new System.Windows.Forms.Label();
            note.AutoSize = true; note.Location = new System.Drawing.Point(15, 155);
            note.Text = "File list is obtained automatically. ID 5 resolves to 000005.bin.";
            this.tab20320.Controls.Add(note);

            this.labelLog.AutoSize = true; this.labelLog.Location = new System.Drawing.Point(12, 298); this.labelLog.Text = "Log output";
            this.tbLog.Location = new System.Drawing.Point(15, 318); this.tbLog.Multiline = true; this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.tbLog.Size = new System.Drawing.Size(760, 220);
            this.ClientSize = new System.Drawing.Size(790, 550);
            this.Controls.Add(this.tbLog); this.Controls.Add(this.labelLog); this.Controls.Add(this.tabs);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "Form1"; this.Text = "Fan Test App";
            this.ResumeLayout(false); this.PerformLayout();
        }

        private System.Windows.Forms.TextBox NewSetting(string name, string value)
        {
            var box = new System.Windows.Forms.TextBox(); box.Name = name; box.Text = value; box.Size = new System.Drawing.Size(115, 20); return box;
        }

        private System.Windows.Forms.Panel CreateSettingsPanel(string title, System.Windows.Forms.TextBox ip, System.Windows.Forms.TextBox port, System.Windows.Forms.TextBox connect, System.Windows.Forms.TextBox socket)
        {
            var panel = new System.Windows.Forms.Panel(); panel.Location = new System.Drawing.Point(5, 5); panel.Size = new System.Drawing.Size(745, 65);
            var group = new System.Windows.Forms.GroupBox(); group.Text = title; group.Dock = System.Windows.Forms.DockStyle.Fill; panel.Controls.Add(group);
            AddConfig(group, "Server IP", ip, 12); AddConfig(group, "Server Port", port, 195); AddConfig(group, "Connect Timeout ms", connect, 360); AddConfig(group, "Socket Timeout ms", socket, 550);
            return panel;
        }

        private void AddConfig(System.Windows.Forms.Control parent, string label, System.Windows.Forms.TextBox box, int x)
        {
            var caption = new System.Windows.Forms.Label(); caption.AutoSize = true; caption.Location = new System.Drawing.Point(x, 22); caption.Text = label;
            box.Location = new System.Drawing.Point(x, 40); parent.Controls.Add(caption); parent.Controls.Add(box);
        }

        private void AddLabel(System.Windows.Forms.Control parent, string text, int x, int y)
        {
            var label = new System.Windows.Forms.Label(); label.AutoSize = true; label.Location = new System.Drawing.Point(x, y); label.Text = text; parent.Controls.Add(label);
        }

        private void AddButton(System.Windows.Forms.Control parent, string text, int x, int y, System.EventHandler handler)
        {
            var button = new System.Windows.Forms.Button(); button.Text = text; button.Location = new System.Drawing.Point(x, y); button.Size = new System.Drawing.Size(150, 25); button.Click += handler; parent.Controls.Add(button);
        }

        private void radioActionV2Single(object sender, System.EventArgs e) { RunV2(f => f.selectSingleVideoPlaybackMode()); }
        private void radioActionV2Loop(object sender, System.EventArgs e) { RunV2(f => f.selectLoopVideoPlaybackMode()); }
        private void radioActionV3Single(object sender, System.EventArgs e) { RunV3(f => f.selectSingleVideoPlaybackMode()); }
        private void radioActionV3Loop(object sender, System.EventArgs e) { RunV3(f => f.selectLoopVideoPlaybackMode()); }

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabV2, tabV3, tab20320;
        private System.Windows.Forms.TextBox tbLog, textBox1, textBox3, txt20320VideoId;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.TextBox txtV2Ip, txtV2Port, txtV2ConnectTimeout, txtV2SocketTimeout;
        private System.Windows.Forms.TextBox txtV3Ip, txtV3Port, txtV3ConnectTimeout, txtV3SocketTimeout;
        private System.Windows.Forms.TextBox txt20320Ip, txt20320Port, txt20320ConnectTimeout, txt20320SocketTimeout;
    }
}
