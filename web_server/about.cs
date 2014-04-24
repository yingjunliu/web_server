using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace web_server
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
            label1.Text = "作者：刘志毅\r\n\r\n学号：U201114384\r\n\r\n班级：CS1108班\r\n\r\n邮箱：yingjun@hust.edu.cn";
            label1.Font = new System.Drawing.Font("黑体", 14);
            label1.ForeColor = Color.Blue;
        }
    }
}
