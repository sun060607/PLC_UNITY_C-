using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus.Device;

namespace PLC_contrl
{
    public partial class Form1 : Form
    {
        //C# 전역 변수 위치
        TcpClient tc = new TcpClient();
        ModbusIpMaster mim;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //접속버튼 클릭
            tc.Connect(textBox1.Text, 502);
            mim = ModbusIpMaster.CreateIp(tc);
            mim.Transport.WriteTimeout = 100;
            mim.Transport.Retries = 0;

            if (tc.Connected)
            {
                MessageBox.Show("접속 완료");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                mim.WriteSingleCoil(0, false);
            }
            catch
            {
                MessageBox.Show("실패");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                mim.WriteSingleCoil(0, true);
            }catch{
                MessageBox.Show("실패");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                bool[] data = mim.ReadCoils(0, 1);
                if (data[0])
                {
                    label1.Text = "결과 : 전진";
                }
                else
                {
                    label1.Text = "결과 : 후진";
                }
            }
            catch
            {
                MessageBox.Show("실패");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                mim.WriteSingleCoil(1, true);
            }
            catch
            {
                MessageBox.Show("실패");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                mim.WriteSingleCoil(1, false);
            }
            catch
            {
                MessageBox.Show("실패");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                bool[] data = mim.ReadCoils(1, 1);
                if (data[0])
                {
                    label2.Text = "결과 : 전진";
                }
                else
                {
                    label2.Text = "결과 : 정지";
                }
            }
            catch
            {
                MessageBox.Show("실패");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                mim.WriteSingleCoil(9, true);
            }
            catch
            {
                MessageBox.Show("실패");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                bool[] data = mim.ReadInputs(2, 1);
                if (data[0])
                {
                    label3.Text = "자제 : 확인";
                }
                else
                {
                    label3.Text = "자제 : 없음";
                }
            }
            catch
            {
                MessageBox.Show("실패");
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                mim.WriteSingleCoil(9, false);
            }
            catch
            {
                MessageBox.Show("실패");
            }
        }
    }
}
