using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace TelloAPI
{
    public class UDPComms
    {
        readonly int dronePort;
        UdpClient udpSender;
        UdpClient udpReciever;
        IPEndPoint eP;
        string ip;

        
        public UDPComms() : this("192.168.10.1",8889)
        {
        }

        public UDPComms(string ip, int dronePort)
        {
            this.dronePort = dronePort;
            this.ip = ip;
            eP = new IPEndPoint(IPAddress.Any, dronePort);
        }

        public void SendData(string data)
        {
            using (var udpSender = new UdpClient(ip,dronePort))
            {
                var dataBytes = Encoding.UTF8.GetBytes(data);
                udpSender.Send(dataBytes, dataBytes.Length);
            }
        }

        public string ReceiveData()
        {
            using (var udpReciever = new UdpClient(eP))
            {
                byte[] bytes = new byte[0];
                bytes = udpReciever.Receive(ref eP);
                var str = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                return rgx.Replace(str, "").ToLower().TrimEnd('\n');
            }
        }

    }
}
