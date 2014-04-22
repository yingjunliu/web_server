using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace web_server
{
    class webServers
    {
        const int MAXTHREAD = 100;

        objects ip_object;
        Thread[] thread = new Thread[MAXTHREAD];
        int total_thread = 0;

        public webServers(objects ip_object)
        {
            this.ip_object = ip_object;
            IPAddress ip = IPAddress.Parse(ip_object.IP_Address);
            IPEndPoint iep = new IPEndPoint(ip, ip_object.Port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(iep);
            socket.Listen(100);
            while (true)
            {   
                int numBytes;
                Socket clientSocket = socket.Accept();
                //socket.IOControl(IOControlCode.KeepAliveValues, KeepAlive(1, 1000, 1000), null);
                byte[] message = new byte[2048];
                clientSocket.Receive(message);
                if(message[0]!=0)
                {
                    thread[total_thread] = new Thread(new ThreadStart(web_service));
                    thread[total_thread].Name = System.Text.Encoding.Default.GetString(message);
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
                
                clientSocket.Close();
            }
        }

        private void web_service()
        {
            Thread current_thread = Thread.CurrentThread;
            string massage = current_thread.Name;

            if (massage.Substring(0, 3) != "GET")
            {
                error(1);
                return;
            }

            //requested file path
            string serviceVirtualPath = massage.Substring(massage.IndexOf(" ") + 1, massage.IndexOf("HTTP") - massage.IndexOf(" ") - 2);
            serviceVirtualPath.Replace("\\", "/");
            //the http version
            string serviceHttpVersion = massage.Substring(massage.IndexOf("HTTP", 3), massage.IndexOf('\r') - massage.IndexOf("HTTP", 3));

            //request file name
            string serviceFile = serviceVirtualPath.Substring(serviceVirtualPath.LastIndexOf("/") + 1);

            //request file dir path
            string serviceDirName = serviceVirtualPath.Substring(serviceVirtualPath.IndexOf("/"), serviceVirtualPath.LastIndexOf("/") - 3);


        }

        private void error(int k)
        {
            if (k == 1)
            {
                //only handle 'GET' request
                ;
            }
        }
    }
}
