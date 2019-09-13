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

        
        public UDPComms() : this("192.168.10.1",8889)
        {
        }

        public UDPComms(string ip, int dronePort)
        {
            this.dronePort = dronePort;
            udpSender = new UdpClient(ip, dronePort);
            eP = new IPEndPoint(IPAddress.Any, dronePort);
            udpReciever = new UdpClient(eP);
        }

        public void SendData(string data)
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            udpSender.Send(dataBytes, dataBytes.Length);
        }

        public string ReceiveData()
        {
            byte[] bytes = new byte[0];
            bytes = udpReciever.Receive(ref eP);
            var str = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            return rgx.Replace(str, "").ToLower().TrimEnd('\n');
        }

    }
}
