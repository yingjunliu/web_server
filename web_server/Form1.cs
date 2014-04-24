using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace web_server
{
    public partial class Form1 : Form
    {
        const int MAXSITE = 20;
        const int MAXTHREADS = 100;
        objects[] ip_object = new objects[MAXSITE];
        int total_site = 0;
        Thread[] threads = new Thread[MAXTHREADS];
        int total_threads = 0;

        public Form1()
        {
            InitializeComponent();

            if (!File.Exists(Application.StartupPath + "\\server.config"))
                return;
            
            //the services do not start
            //richTextBox2.Text = "服务器状态：\n\n\n\t\t\t监听服务均未启动";
            //richTextBox2.ForeColor = Color.Red;
            //richTextBox2.Font = new System.Drawing.Font("宋体", 12);

            //read config file
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + "\\server.config");
                string read_buffer = "";
                string buffer = "";
                read_buffer = sr.ReadLine();
                total_site = Convert.ToInt32(read_buffer.Substring(read_buffer.IndexOf(' ') + 1));
                read_buffer = sr.ReadLine();
                read_buffer = sr.ReadLine();
                for (int i = 0; i < total_site; i++)
                {
                    read_buffer = sr.ReadLine();
                    buffer = read_buffer.Substring(read_buffer.IndexOf(' ') + 1);
                    ip_object[i] = new objects();
                    ip_object[i].Site_Name = buffer;
                }
                read_buffer = sr.ReadLine();
                read_buffer = sr.ReadLine();
                for (int i = 0; i < total_site; i++)
                {
                    read_buffer = sr.ReadLine();
                    buffer = read_buffer.Substring(read_buffer.IndexOf(' ') + 1);
                    ip_object[i].IP_Address = buffer;
                }
                read_buffer = sr.ReadLine();
                read_buffer = sr.ReadLine();
                for (int i = 0; i < total_site; i++)
                {
                    read_buffer = sr.ReadLine();
                    buffer = read_buffer.Substring(read_buffer.IndexOf(' ') + 1);
                    ip_object[i].Port= Convert.ToInt32(buffer);
                }
                read_buffer = sr.ReadLine();
                read_buffer = sr.ReadLine();
                for (int i = 0; i < total_site; i++)
                {
                    read_buffer = sr.ReadLine();
                    buffer = read_buffer.Substring(read_buffer.IndexOf(' ') + 1);
                    ip_object[i].Dir_Path = buffer;
                }
                sr.Close();
            }
            catch (System.Exception ex)
            {
            	MessageBox.Show(ex.ToString());
            }
            
            //add to the treeview
            for (int i = 0; i < total_site; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = ip_object[i].Site_Name;
                treeView1.Nodes.Add(node);
                getFile(node, ip_object[i].Dir_Path);
            }
        }

        private void getFile(TreeNode node,string filepath)
        {
            DirectoryInfo theFile = new DirectoryInfo(filepath);
            DirectoryInfo[] dirInfo = new DirectoryInfo[1000];
            FileInfo[] fileInfo = new FileInfo[1000];

            try
            {
                dirInfo = theFile.GetDirectories();
            }
            catch (System.Exception ex)
            {
                dirInfo = null;
            }
            if ((dirInfo != null) && (dirInfo.Length != 0))
            {
                foreach (DirectoryInfo nextFolder in dirInfo)
                {
                    TreeNode next_nodes = new TreeNode();
                    next_nodes.Text = nextFolder.Name;
                    node.Nodes.Add(next_nodes);
                    getFile(next_nodes, nextFolder.FullName);
                }
            }

            try
            {
                fileInfo = theFile.GetFiles();
            }
            catch (System.Exception ex)
            {
                fileInfo = null;
            }
            if ((fileInfo != null) && (fileInfo.Length != 0))
            {
                foreach (FileInfo nextFile in fileInfo)
                {
                    string fileName = nextFile.Name;
                    node.Nodes.Add(fileName);
                }
            }
        }

        private void 增加站点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ip_object[total_site] = new objects();
            modifySite modifysite=new modifySite();
            addSite addsite = new addSite(ip_object[total_site], this, modifysite, 1);
            addsite.Show();
        }

        private void 修改站点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifySite modifySite = new modifySite(ip_object, total_site, this,1);
            modifySite.Show();
        }

        public void add()
        {
            for (int i = 0; i < total_site; i++)
            {
                if (ip_object[i].IP_Address == ip_object[total_site].IP_Address)
                {
                    if (ip_object[i].Port == ip_object[total_site].Port)
                    {
                        MessageBox.Show("已经具有相同站点！站点名为：" + ip_object[i].Site_Name);
                        return;
                    }
                }
            }
            TreeNode node = new TreeNode();
            node.Text = ip_object[total_site].Site_Name;
            treeView1.Nodes.Add(node);
            getFile(node, ip_object[total_site].Dir_Path);
            total_site++;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about aboutMe = new about();
            aboutMe.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\server.config"))
                File.Delete(Application.StartupPath + "\\server.config");
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\server.config");
            sw.WriteLine("#site_number " + total_site);
            sw.WriteLine();
            sw.WriteLine("#sitename");
            for (int i = 0; i < total_site; i++)
            {
                sw.WriteLine("#sitename" + (i + 1) + " " + ip_object[i].Site_Name);
            }
            sw.WriteLine();
            sw.WriteLine("#IP");
            for (int i = 0; i < total_site; i++)
            {
                sw.WriteLine("#IP" + (i + 1) + " " + ip_object[i].IP_Address);
            }
            sw.WriteLine();
            sw.WriteLine("#port");
            for (int i = 0; i < total_site; i++)
            {
                sw.WriteLine("#port" + (i + 1) + " " + ip_object[i].Port);
            }
            sw.WriteLine();
            sw.WriteLine("#dir");
            for (int i = 0; i < total_site; i++)
            {
                sw.WriteLine("#dir" + (i + 1) + " " + ip_object[i].Dir_Path);
            }
            sw.Close();

            //close webService's all thread
            foreach(Thread thread in threads)
            {
                if (thread != null)
                    if (!thread.IsBackground)
                    {
                        thread.IsBackground = true;
                        thread.Abort();
                    }
            }
        }

        public void delete_site(int total_site)
        {
            this.total_site = total_site;
        }

        private void 启动服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifySite modifysite = new modifySite(ip_object, total_site, this, 2);
            modifysite.Show();
        }

        public void start_service(int i)
        {
            threads[total_threads] = new Thread(new ThreadStart(thread_start_service));
            threads[total_threads].Name = i.ToString() + " " + ip_object[i].Site_Name + " " + ip_object[i].IP_Address + " " + ip_object[i].Port;
            threads[total_threads].Start();
            total_threads++;
        }

        private void thread_start_service()
        {
            Thread current_thread = Thread.CurrentThread;
            int i = int.Parse(current_thread.Name.Substring(0, current_thread.Name.IndexOf(" ")));
            webServers webserver = new webServers(ip_object[i], this, i);
        }

        private void 关闭服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifySite modifysite = new modifySite(ip_object, total_site, this, 3);
            modifysite.Show();
        }

        public void end_service(int i)
        {
            foreach (Thread thread in threads)
            {
                if (thread != null)
                {
                    string buffer = thread.Name;
                    buffer = buffer.Substring(buffer.IndexOf(" ") + 1);
                    if (buffer == ip_object[i].Site_Name + " " + ip_object[i].IP_Address + " " + ip_object[i].Port)
                    {
                        thread.IsBackground = true;
                        thread.Abort();
                    }
                }
            }
        }

        private void 访问日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\access.log"))
            {
                StreamReader sr = new StreamReader(Application.StartupPath + "\\access.log");
                richTextBox1.Text = sr.ReadToEnd();
                richTextBox1.Font = new System.Drawing.Font("宋体", 10);
                sr.Close();
            }
            else
            {
                MessageBox.Show("没有访问日志！");
            }
        }

        private delegate void addtextdele(string filepath);

        public void log_add(string adding)
        {
            if (richTextBox2.InvokeRequired)
            {
                addtextdele adds = new addtextdele(log_add);
                this.BeginInvoke(adds, new object[] { adding });
                return;
            }
            richTextBox2.Text += adding;
            this.richTextBox2.Select(this.richTextBox2.Text.Length, 0);
            this.richTextBox2.ScrollToCaret();
        }

        private void 请求报文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            permision = 1;
            modifySite modifysite = new modifySite(ip_object, total_site, this, 4);
            modifysite.Show();
        }

        int permision = 0;
        int site_num = -1;

        public void set_Site_Num(int k)
        {
            site_num = k;
        }

        private delegate void httpHead_Request_Dele(string request, int sitnum, int send_Or_Get);

        public void http_Head(string request,int sitenum,int send_Or_Get)
        {
            if (richTextBox1.InvokeRequired)
            {
                httpHead_Request_Dele adds = new httpHead_Request_Dele(http_Head);
                this.BeginInvoke(adds, new object[] { request, sitenum, send_Or_Get });
                return;
            }
            if ((permision == 1) && (sitenum == this.site_num) && (send_Or_Get == 1))
            {
                richTextBox1.Text = request;
            }
            else if ((permision == 2) && (sitenum == this.site_num) && (send_Or_Get == 2))
            {
                richTextBox1.Text = request;
            }
        }

        private void 发送报文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            permision = 2;
            modifySite modifysite = new modifySite(ip_object, total_site, this, 4);
            modifysite.Show();
        }

        private void 监听情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            for (int i = 0; i < total_threads; i++)
            {
                if (threads[i].IsBackground == false)
                {
                    richTextBox1.Text += threads[i].Name.Substring(threads[i].Name.IndexOf(" ") + 1);
                    richTextBox1.Text += "\r\n";
                }
            }
            if (richTextBox1.Text == "")
                richTextBox1.Text = "没有服务正在进行";
        }
    }
}
