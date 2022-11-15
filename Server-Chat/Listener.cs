using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server_Chat
{
    internal class Listener
    {
        private Socket listenerSocket; //Socket that will listen incoming connections
        private short portNo = 5000;
        private EndPoint client1 = null;
        private EndPoint client2 = null;
        private byte[] byteData = new byte[1024];

        public bool continueDistribution { get; set; } = true;

        public Listener()
        {
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        public void StartListening()
        {
            Console.WriteLine("Started listenting on port: {0} in {1}", portNo, ProtocolType.Udp);
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            listenerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            listenerSocket.Bind(new IPEndPoint(IPAddress.Any, portNo));
            EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
            Array.Clear(byteData, 0, byteData.Length);//Clear array before begining to receive
            this.listenerSocket.BeginReceiveFrom(this.byteData, 0, this.byteData.Length, SocketFlags.None, ref newClientEP, DoReceiveFrom, newClientEP);
        }

        private void DoReceiveFrom(IAsyncResult iar)
        {
            EndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);
            int dataLen = 0;
            byte[] data = null;
            try
            {
                dataLen = listenerSocket.EndReceiveFrom(iar, ref clientEP);
                Console.WriteLine("Sender IP: {0}", ((IPEndPoint)clientEP).Address);
                data = new byte[dataLen];
                Array.Copy(this.byteData, data, dataLen);
                string receiveBuff = Encoding.ASCII.GetString(data);
                Console.WriteLine("Received from client some data\n {0}", receiveBuff);
                byte[] ackMssg = Encoding.ASCII.GetBytes("Server speaking back!");
                listenerSocket.BeginSendTo(ackMssg, 0, ackMssg.Length, SocketFlags.None, clientEP, DoSendTo, clientEP);
            }
            finally
            {
                if (client1 == null)
                {
                    client1 = clientEP;
                    EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
                    listenerSocket.BeginReceiveFrom(this.byteData, 0, this.byteData.Length, SocketFlags.None, ref newClientEP, DoReceiveFrom, newClientEP);
                }
                else
                {
                    client2 = clientEP;
                }
            }
        }

        public void StartDistribution()
        {
            Console.WriteLine("Distribution Started in Port: {0} with {1}", portNo, ProtocolType.Udp);
            EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
            Array.Clear(byteData, 0, byteData.Length);//Clear array before begining to receive
            this.listenerSocket.BeginReceiveFrom(this.byteData, 0, this.byteData.Length, SocketFlags.None, ref newClientEP, DoDistributionRec, newClientEP);
        }

        public void DoDistributionRec(IAsyncResult iar)
        {
            EndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);
            int dataLen = 0;
            byte[] data = null;
            if (continueDistribution)
            {
                try
                {
                    dataLen = listenerSocket.EndReceiveFrom(iar, ref clientEP);
                    data = new byte[dataLen];
                    Array.Copy(byteData, data, dataLen);
                    string receiveBuff = Encoding.ASCII.GetString(data);
                    string message = receiveBuff.Substring(1);
                    if (receiveBuff[0] == 's')
                    {
                        Console.WriteLine("Client {0} says: {1}", ((IPEndPoint)clientEP).Address, message);
                    }
                    else
                    {
                        if (((IPEndPoint)clientEP).Address.ToString() == ((IPEndPoint)client1).Address.ToString())
                        {
                            byte[] ackMssg = Encoding.ASCII.GetBytes("Client 1 says: " + message);
                            listenerSocket.BeginSendTo(ackMssg, 0, ackMssg.Length, SocketFlags.None, client2, DoSendTo, listenerSocket);
                        }
                        else
                        {
                            byte[] ackMssg = Encoding.ASCII.GetBytes("Client 2 says: " + message);
                            listenerSocket.BeginSendTo(ackMssg, 0, ackMssg.Length, SocketFlags.None, client1, DoSendTo, listenerSocket);
                        }
                    }
                }
                finally
                {
                    EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
                    listenerSocket.BeginReceiveFrom(this.byteData, 0, this.byteData.Length, SocketFlags.None, ref newClientEP, DoDistributionRec, newClientEP);
                }
            }
        }

        public void SendMessage(string mssgStr, int clientID)
        {
            string message = "Server says: ";
            message += mssgStr;
            byte[] byteMssg = Encoding.ASCII.GetBytes(message);
            switch (clientID)
            {
                case 1:
                    listenerSocket.BeginSendTo(byteMssg, 0, byteMssg.Length, SocketFlags.None, client1, DoSendTo, listenerSocket);
                    break;
                case 2:
                    listenerSocket.BeginSendTo(byteMssg, 0, byteMssg.Length, SocketFlags.None, client2, DoSendTo, listenerSocket);
                    break;
                default:
                    listenerSocket.BeginSendTo(byteMssg, 0, byteMssg.Length, SocketFlags.None, client1, DoSendTo, listenerSocket);
                    listenerSocket.BeginSendTo(byteMssg, 0, byteMssg.Length, SocketFlags.None, client2, DoSendTo, listenerSocket);
                    break;
            }
            //After sending message, server must go back to listening
            continueDistribution = true;
            Array.Clear(byteData, 0, byteData.Length);
            EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
            listenerSocket.BeginReceiveFrom(this.byteData, 0, this.byteData.Length, SocketFlags.None, ref newClientEP, DoDistributionRec, newClientEP);
        }

        public void DoSendTo(IAsyncResult iar)
        {
            listenerSocket.EndSendTo(iar);
            Console.WriteLine("Sent the ACK");
        }

        public void CheckClients()
        {
            if (client1 != null && client2 != null)
            {

                Console.WriteLine("Client 1 IP: {0}", ((IPEndPoint)client1).Address);
                Console.WriteLine("Client 2 IP: {0}", ((IPEndPoint)client2).Address);
            }
            else
            {
                Console.WriteLine("Error with one or more clients");
            }
        }

        public void Dispose()
        {
            listenerSocket.Close();
            listenerSocket = null;
        }
    }
}
