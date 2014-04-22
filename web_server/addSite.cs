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
    public partial class addSite : Form
    {
        objects ip_object;
        Form1 fatherForm;
        modifySite modifysite;
        int kind;

        public addSite()
        {
            InitializeComponent();
        }

        public addSite(objects ip_object, Form1 fatherForm, modifySite modifysite, int kind)
        {
            InitializeComponent();
            this.ip_object = ip_object;
            this.fatherForm = fatherForm;
            this.modifysite = modifysite;
            this.kind = kind;

            if (kind == 2)
            {
                textBox1.Text = ip_object.IP_Address;
                textBox2.Text = ip_object.Port.ToString();
                textBox3.Text = ip_object.Dir_Path;
                textBox4.Text = ip_object.Site_Name;
                button1.Text = "确定修改";
                this.Text = "modifySite";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dialog.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sure to add site
            ip_object.IP_Address = textBox1.Text;
            ip_object.Port = Convert.ToInt32(textBox2.Text);
            ip_object.Dir_Path = textBox3.Text;
            ip_object.Site_Name = textBox4.Text;
            if (kind == 1)
            {
                fatherForm.add();
            }
            else if (kind == 2)
            {
                modifysite.sitelist_frash();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
