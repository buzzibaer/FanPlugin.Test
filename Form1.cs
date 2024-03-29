﻿using System;
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
            tbLog.AppendText(fan.selectLoopVideoPlaybackMode());

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if (((RadioButton)sender).Checked)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;

                FanPlugin.Wrapper.Fan fan = new Wrapper.Fan();

                tbLog.Clear();
                tbLog.AppendText(fan.selectSingleVideoPlaybackMode());
                tbLog.AppendText("RadioButton Single Video Mode Selected");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if (((RadioButton)sender).Checked)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;


                FanPlugin.Wrapper.Fan fan = new Wrapper.Fan();

                tbLog.Clear();
                tbLog.AppendText(fan.selectLoopVideoPlaybackMode());
                tbLog.AppendText("RadioButton Loop Video Mode Selected");
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            FanPlugin.Wrapper.FanV3 fan = new Wrapper.FanV3();

            tbLog.Clear();
            tbLog.AppendText(fan.playVideoWithId(textBox1.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            FanPlugin.Wrapper.FanV3 fan = new Wrapper.FanV3();

            tbLog.Clear();
            tbLog.AppendText(fan.getFileListFromFan());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FanPlugin.Wrapper.FanV3 fan = new Wrapper.FanV3();

            tbLog.Clear();
            tbLog.AppendText(fan.playLastFromFan());
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if (((RadioButton)sender).Checked)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;

                FanPlugin.Wrapper.FanV3 fan = new Wrapper.FanV3();

                tbLog.Clear();
                tbLog.AppendText(fan.selectSingleVideoPlaybackMode());
                tbLog.AppendText("RadioButton Single Video Mode Selected");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if (((RadioButton)sender).Checked)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;


                FanPlugin.Wrapper.FanV3 fan = new Wrapper.FanV3();

                tbLog.Clear();
                tbLog.AppendText(fan.selectLoopVideoPlaybackMode());
                tbLog.AppendText("RadioButton Loop Video Mode Selected");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FanPlugin.Wrapper.FanV3 fan = new Wrapper.FanV3();

            tbLog.Clear();
            tbLog.AppendText(fan.sendPowerOn());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FanPlugin.Wrapper.FanV3 fan = new Wrapper.FanV3();

            tbLog.Clear();
            tbLog.AppendText(fan.sendPowerOff());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FanPlugin.Wrapper.FanV3 fan = new Wrapper.FanV3();

            tbLog.Clear();
            tbLog.AppendText(fan.playOldFromFan());
        }
    }
}
