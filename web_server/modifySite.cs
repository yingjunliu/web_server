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
    public partial class modifySite : Form
    {
        const int LINE_HIGHT = 30;
        objects[] ip_object;
        int total_site;
        Form1 fatherForm;
        int kind;

        public modifySite()
        {
            InitializeComponent();
        }

        public modifySite(objects[] ip_object,int total_site,Form1 fatherForm,int kind)
        {
            this.ip_object = ip_object;
            this.total_site = total_site;
            this.fatherForm = fatherForm;
            this.kind = kind;

            InitializeComponent();

            if (kind == 2)
            {
                modify.Text = "启动服务";
                delete_site.Text = "全部启动";
                this.Text = "选择开启服务";
            }
            else if (kind == 3)
            {
                modify.Text = "关闭服务";
                delete_site.Text = "全部关闭";
                this.Text = "选择关闭服务";
            }
            else if (kind == 4)
            {
                modify.Text = "确定";
                delete_site.Text = "取消";
                this.Text = "选择报文监听站点";
            }

            sitelist_frash();
        }

        public void sitelist_frash()
        {
            sitelist.Clear();
            ImageList il = new ImageList();
            //设置高度
            il.ImageSize = new Size(1, LINE_HIGHT);
            //绑定listView控件
            sitelist.SmallImageList = il;
            sitelist.View = View.Details;
            sitelist.Columns.Add("站点名称", 100, HorizontalAlignment.Left);
            sitelist.Columns.Add("监听IP", 100, HorizontalAlignment.Left);
            sitelist.Columns.Add("监听端口", 70, HorizontalAlignment.Left);
            sitelist.Columns.Add("主目录", 150, HorizontalAlignment.Left);

            for (int i = 0; i < total_site; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = ip_object[i].Site_Name;
                lvi.SubItems.Add(ip_object[i].IP_Address);
                lvi.SubItems.Add(ip_object[i].Port.ToString());
                lvi.SubItems.Add(ip_object[i].Dir_Path);
                sitelist.Items.Add(lvi);
            }
        }

        private void delete_site_Click(object sender, EventArgs e)
        {
            if ((kind == 1) && (sitelist.SelectedItems.Count == 0))
                MessageBox.Show("请选择站点！");
            else if (kind == 1)
            {
                for (int i = sitelist.SelectedItems[0].Index; i < total_site; i++)
                {
                    ip_object[i] = ip_object[i + 1];
                }

                total_site--;
                fatherForm.delete_site(total_site);
                sitelist_frash();
            }
            else if (kind == 2)
            {
                for (int i = 0; i < total_site; i++)
                    fatherForm.start_service(i);
                this.Close();
            }
            else if (kind == 3)
            {
                for (int i = 0; i < total_site; i++)
                    fatherForm.end_service(i);
                this.Close();
            }
            else if (kind == 4)
            {
                this.Close();
            }
        }

        private void modify_Click(object sender, EventArgs e)
        {
            if (sitelist.SelectedItems.Count == 0)
                MessageBox.Show("请选择站点！");
            else if (kind == 1)
            {
                addSite addsite = new addSite(ip_object[sitelist.SelectedItems[0].Index], fatherForm, this, 2);
                addsite.Show();
            }
            else if (kind == 2)
            {
                fatherForm.start_service(sitelist.SelectedItems[0].Index);
                this.Close();
            }
            else if (kind == 3)
            {
                fatherForm.end_service(sitelist.SelectedItems[0].Index);
                this.Close();
            }
            else if (kind == 4)
            {
                fatherForm.set_Site_Num(sitelist.SelectedItems[0].Index);
                this.Close();
            }
        }
    }
}
