using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TelloAPI
{
    public class UDPComms
    {
        readonly int dronePort;
        UdpClient udpSender;
        UdpClient udpReciever;



        public UDPComms() : this("192.168.10.1",8889)
        {
        }

        public UDPComms(string ip, int dronePort)
        {
            this.dronePort = dronePort;
            udpSender = new UdpClient(ip, dronePort);
            udpReciever = new UdpClient(dronePort);
        }

        public void SendData(string data)
        {
            
            var dataBytes = Encoding.UTF8.GetBytes(data);

            udpSender.Send(dataBytes, dataBytes.Length);

        }

        public string ReceiveData()
        {
            IPEndPoint eP = new IPEndPoint(IPAddress.Any, 8889);
            byte[] bytes = new byte[0];
            while (bytes.Length < 1)
            {
                bytes = udpReciever.Receive(ref eP);
            }
            return Encoding.ASCII.GetString(bytes, 0, bytes.Length);
        }

    }
}
