using System;
using System.Globalization;
using System.Windows.Forms;

namespace FanPlugin.Test
{
    public partial class Form1 : Form
    {
        private FanPlugin.Wrapper.Fan fan;
        private FanPlugin.Wrapper.FanV3 fanV3;
        private FanPlugin.Wrapper.Fan20320 fan20320;

        public Form1()
        {
            InitializeComponent();
        }

        private bool ApplySettings(string model, TextBox ip, TextBox port, TextBox connectTimeout, TextBox socketTimeout, Action<string, int, int, int> apply)
        {
            int parsedPort;
            int parsedConnectTimeout;
            int parsedSocketTimeout;
            if (!int.TryParse(port.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out parsedPort) || parsedPort <= 0 || parsedPort > 65535)
                return LogInputError(model + " Server Port must be a positive number from 1 to 65535.");
            if (!int.TryParse(connectTimeout.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out parsedConnectTimeout) || parsedConnectTimeout <= 0)
                return LogInputError(model + " Connect Timeout ms must be a positive integer.");
            if (!int.TryParse(socketTimeout.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out parsedSocketTimeout) || parsedSocketTimeout <= 0)
                return LogInputError(model + " Socket Timeout ms must be a positive integer.");
            if (string.IsNullOrWhiteSpace(ip.Text))
                return LogInputError(model + " Server IP is required.");

            apply(ip.Text.Trim(), parsedPort, parsedConnectTimeout, parsedSocketTimeout);
            return true;
        }

        private bool LogInputError(string message)
        {
            AppendLog("Invalid configuration: " + message);
            return false;
        }

        private void AppendLog(string message)
        {
            if (tbLog.TextLength > 0)
                tbLog.AppendText(Environment.NewLine);
            tbLog.AppendText(message);
        }

        private void RunV2(Func<FanPlugin.Wrapper.Fan, string> operation)
        {
            try
            {
                if (!ApplySettings("Fan V2", txtV2Ip, txtV2Port, txtV2ConnectTimeout, txtV2SocketTimeout,
                    (ip, port, connect, socket) => { if (fan == null) fan = new FanPlugin.Wrapper.Fan(); fan.ServerIp = ip; fan.ServerPort = port; fan.ConnectTimeoutMs = connect; fan.SocketTimeoutMs = socket; })) return;
                AppendLog(operation(fan));
            }
            catch (Exception ex) { AppendLog("Fan V2 operation failed: " + ex.Message); }
        }

        private void RunV3(Func<FanPlugin.Wrapper.FanV3, string> operation)
        {
            try
            {
                if (!ApplySettings("Fan V3", txtV3Ip, txtV3Port, txtV3ConnectTimeout, txtV3SocketTimeout,
                    (ip, port, connect, socket) => { if (fanV3 == null) fanV3 = new FanPlugin.Wrapper.FanV3(); fanV3.ServerIp = ip; fanV3.ServerPort = port; fanV3.ConnectTimeoutMs = connect; fanV3.SocketTimeoutMs = socket; })) return;
                AppendLog(operation(fanV3));
            }
            catch (Exception ex) { AppendLog("Fan V3 operation failed: " + ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e) { RunV2(f => f.playVideoWithId(textBox1.Text)); }
        private void button2_Click(object sender, EventArgs e) { RunV2(f => f.selectSingleVideoPlaybackMode()); }
        private void button3_Click(object sender, EventArgs e) { RunV2(f => f.getFileListFromFan()); }
        private void button4_Click(object sender, EventArgs e) { RunV2(f => f.playLastFromFan()); }
        private void button5_Click(object sender, EventArgs e) { RunV2(f => f.playOldFromFan()); }
        private void button6_Click(object sender, EventArgs e) { RunV2(f => f.selectLoopVideoPlaybackMode()); }
        private void button9_Click(object sender, EventArgs e) { RunV3(f => f.playVideoWithId(textBox3.Text)); }
        private void button12_Click(object sender, EventArgs e) { RunV3(f => f.getFileListFromFan()); }
        private void button11_Click(object sender, EventArgs e) { RunV3(f => f.playLastFromFan()); }
        private void button8_Click(object sender, EventArgs e) { RunV3(f => f.sendPowerOn()); }
        private void button7_Click(object sender, EventArgs e) { RunV3(f => f.sendPowerOff()); }
        private void button10_Click(object sender, EventArgs e) { RunV3(f => f.playOldFromFan()); }

        private void buttonFan20320Play_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ApplySettings("Fan20320", txt20320Ip, txt20320Port, txt20320ConnectTimeout, txt20320SocketTimeout,
                    (ip, port, connect, socket) => { if (fan20320 == null) fan20320 = new FanPlugin.Wrapper.Fan20320(); fan20320.ServerIp = ip; fan20320.ServerPort = port; fan20320.ConnectTimeoutMs = connect; fan20320.SocketTimeoutMs = socket; })) return;
                AppendLog(fan20320.playVideoWithId(txt20320VideoId.Text));
            }
            catch (Exception ex) { AppendLog("Fan20320 operation failed: " + ex.Message); }
        }
    }
}
