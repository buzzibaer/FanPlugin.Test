using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FanPlugin.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FanPlugin.Wrapper.Fan fan = new Wrapper.Fan();

            tbLog.Clear();
            tbLog.AppendText(fan.playVideoWithId(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FanPlugin.Wrapper.Fan fan = new Wrapper.Fan();

            tbLog.Clear();
            tbLog.AppendText(fan.selectSingleVideoPlaybackMode());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            FanPlugin.Wrapper.Fan fan = new Wrapper.Fan();

            tbLog.Clear();
            tbLog.AppendText(fan.getFileListFromFan());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FanPlugin.Wrapper.Fan fan = new Wrapper.Fan();

            tbLog.Clear();
            tbLog.AppendText(fan.playLastFromFan());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FanPlugin.Wrapper.Fan fan = new Wrapper.Fan();

            tbLog.Clear();
            tbLog.AppendText(fan.playOldFromFan());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FanPlugin.Wrapper.Fan fan = new Wrapper.Fan();

            tbLog.Clear();
            tbLog.AppendText(fan.selectSingleVideoPlaybackMode());

        }
    }
}
