using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace web_server
{
    class webServers
    {
        const int MAXTHREAD = 100;
        const int MAXSOCKET=100;
        const int OK = 0;
        const int NOTGET = 1;
        const int NOFILE = 2;

        objects ip_object;
        Thread[] thread = new Thread[MAXTHREAD];
        int total_thread = 0;
        Socket[] clientSocket = new Socket[MAXSOCKET];
        int total_socket = -1;
        Form1 fatherForm;
        int ip_object_num;

        public webServers(objects ip_object,Form1 fatherForm,int ip_object_num)
        {
            this.ip_object = ip_object;
            this.fatherForm = fatherForm;
            this.ip_object_num = ip_object_num;
            IPAddress ip = IPAddress.Parse(ip_object.IP_Address);
            IPEndPoint iep = new IPEndPoint(ip, ip_object.Port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Bind(iep);
            }
            catch
            {
                return;
            }
            socket.Listen(100);
            while (true)
            {
                total_socket++;
                clientSocket[total_socket] = socket.Accept();
                //socket.IOControl(IOControlCode.KeepAliveValues, KeepAlive(1, 1000, 1000), null);
                byte[] message = new byte[2048];
                clientSocket[total_socket].Receive(message);
                if(message[0]!=0)
                {
                    thread[total_thread] = new Thread(new ThreadStart(web_service));
                    thread[total_thread].Name = total_thread + " " + System.Text.Encoding.Default.GetString(message);
                    thread[total_thread].Start();
                    total_thread++;
                }
#region the network test
                /*
                //NetworkStream netStream = new NetworkStream(clientSocket);
                //int len = netStream.Read(message, 0, message.Length);
                string str = System.Text.Encoding.Default.GetString(message);
                byte[] returnMessage = new byte[2048];
                returnMessage = System.Text.Encoding.Default.GetBytes("HTTP/1.1 404 Not Found\r\nDate: Apr 11 2006 15:32:08 GMT\r\nServer: handsome/1.0\r\nAccept-Ranges: bytes\r\nContent-Type: text/html\r\nContent-Lenth: 43\r\n\r\n");
                //clientSocket.Send(returnMessage);
                if ((numBytes = clientSocket.Send(returnMessage, returnMessage.Length, 0)) == -1)
                    Console.WriteLine("Socket Error cannot Send Packet");
                //Console.WriteLine(System.Text.Encoding.Default.GetString(returnMessage));
                string sErrorMessage = "<H2>Error!! Requested Directory does not exists</H2><Br>";
                returnMessage = System.Text.Encoding.Default.GetBytes(sErrorMessage);
                if (message[0] != 0)
                    if ((numBytes = clientSocket.Send(returnMessage, returnMessage.Length, 0)) == -1)
                        Console.WriteLine("Socket Error cannot Send Packet");
                 */
#endregion
                
                //clientSocket.Close();
            }
        }

        private void web_service()
        {
            Thread current_thread = Thread.CurrentThread;
            int socket_Num = Convert.ToInt32(current_thread.Name.Substring(0, current_thread.Name.IndexOf(" ")));
            string massage = current_thread.Name.Substring(current_thread.Name.IndexOf(" ") + 1);

            fatherForm.http_Head(massage, ip_object_num, 1);

            ///*
            if (!File.Exists(Application.StartupPath + "\\access.log"))
            {
                FileStream file = File.Create(Application.StartupPath + "\\access.log");
                file.Close();
            }
            //*/

            if (massage.Substring(0, 3) != "GET")
            {
                //error(NOTGET);
                return;
            }

            //requested file path
            string serviceVirtualPath = massage.Substring(massage.IndexOf(" ") + 1, massage.IndexOf("HTTP") - massage.IndexOf(" ") - 2);
            serviceVirtualPath = serviceVirtualPath.Replace("/", "\\");

            //requested file type
            string serviceFileType = "";
            if (serviceVirtualPath.LastIndexOf(".") > -1)
                serviceFileType = serviceVirtualPath.Substring(serviceVirtualPath.LastIndexOf("."));
            if (serviceFileType == ".jpg")
                serviceFileType = "image/jpeg";
            else if (serviceFileType == ".gif")
                serviceFileType = "image/gif";

            //the http version
            string serviceHttpVersion = massage.Substring(massage.IndexOf("HTTP", 3), massage.IndexOf('\r') - massage.IndexOf("HTTP", 3));

            //request file name
            string serviceFile = serviceVirtualPath.Substring(serviceVirtualPath.LastIndexOf("\\") + 1);

            //request file dir path
            string serviceDirName = serviceVirtualPath.Substring(serviceVirtualPath.IndexOf("\\"), serviceVirtualPath.LastIndexOf("\\") - serviceVirtualPath.IndexOf("\\"));
            if (serviceVirtualPath == "\\")
            {
                serviceVirtualPath += "index.html";
                serviceFileType = "text/html";
            }

            //the file path in local computer
            string serviceMainDir = ip_object.Dir_Path + serviceVirtualPath;

            //read the file and write log file
            string times = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\access.log", true);
            sw.Write(clientSocket[socket_Num].RemoteEndPoint.ToString() + "--[" + ip_object.Site_Name + "]--[" + times + "]" + massage.Substring(0, massage.IndexOf("\r\n")));
            fatherForm.log_add("[" + ip_object.Site_Name + "]" + clientSocket[socket_Num].RemoteEndPoint.ToString() + massage.Substring(0, massage.IndexOf("\r\n")));
            //sw.Close();
            try
            {
                if ((serviceFileType == "image/jpeg") || (serviceFileType == "image/gif"))
                {
                    FileInfo fileinfo = new FileInfo(serviceMainDir);
                    byte[] buf = new byte[fileinfo.Length];
                    FileStream fs = new FileStream(serviceMainDir, FileMode.Open, FileAccess.Read);
                    fs.Read(buf, 0, buf.Length);
                    fs.Close();
                    GC.ReRegisterForFinalize(fileinfo);
                    GC.ReRegisterForFinalize(fs);
                    send_head(OK, serviceHttpVersion, serviceFileType, buf.Length, buf, socket_Num);
                }
                else
                {
                    StreamReader reader = new StreamReader(serviceMainDir);
                    string result = reader.ReadToEnd();
                    byte[] send_message = System.Text.Encoding.Default.GetBytes(result);
                    send_head(OK, serviceHttpVersion, serviceFileType, send_message.Length, send_message, socket_Num);
                }
                sw.Write(" 200\r\n");
                sw.Close();
                fatherForm.log_add(" 200\r\n");
            }
            catch(Exception e)
            {
                //string errors = e.ToString();
                if ((e.ToString().IndexOf("未能找到文件") > -1) || (e.ToString().IndexOf("路径中具有非法字符") > -1))
                {
                    error(NOFILE, serviceHttpVersion, socket_Num);
                    sw.Write(" 404\r\n");
                    sw.Close();
                    fatherForm.log_add(" 404\r\n");
                }
                else
                {
                    sw.Write(" 400\r\n");
                    sw.Close();
                    fatherForm.log_add(" 400\r\n");
                }
            }
            
        }

        private void error(int k,string serviceHttpVertion,int num)
        {
            string errormessage;
            if (k == NOTGET)
            {
                //only handle 'GET' request
                errormessage = "<H2>400 Error! The server can only handle the get request!</H2>";
                send_head(k, serviceHttpVertion, "text/html", System.Text.Encoding.Default.GetBytes(errormessage).Length, System.Text.Encoding.Default.GetBytes(errormessage), num);
            }
            else if (k == NOFILE)
            {
                //there is no file that broswer requst;
                errormessage = "<H2>404 Error! File Does Not Exists...</H2>";
                send_head(k, serviceHttpVertion, "text/html", System.Text.Encoding.Default.GetBytes(errormessage).Length, System.Text.Encoding.Default.GetBytes(errormessage), num);
                ;
            }
        }

        private void send_head(int k,string serviceHttpVertion,string serviceFileType,int length,byte[] data,int num)
        {
            string sendBack = "";
            string serviceStatus = "";

            if (k == OK)
            {
                serviceStatus = "200 OK";
            }
            else if (k == NOFILE)
            {
                serviceStatus = "404 Not Found";
            }
            else
            {
                serviceStatus = "400 Bad Request";
            }

            sendBack = serviceHttpVertion + " " + serviceStatus + "\r\n";
            sendBack += "Server: handsome-server 1.0\r\n";
            sendBack += "Accept-Ranges: bytes\r\n";
            sendBack += "Content-Type: " + serviceFileType + "\r\n";
            sendBack += "Content-Length: " + length + "\r\n\r\n";

            fatherForm.http_Head(sendBack, ip_object_num, 2);

            byte[] return_message=System.Text.Encoding.Default.GetBytes(sendBack);
            clientSocket[num].Send(return_message,return_message.Length,0);

            return_message = data;
            clientSocket[num].Send(return_message, return_message.Length, 0);

            clientSocket[num].Close();
        }
    }
}
