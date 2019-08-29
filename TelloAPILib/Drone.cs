using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelloAPI
{
    public class Drone
    {
        UDPComms comms = new UDPComms();

        public enum FlipDir {
            left = 0,
            right,
            forwards,
            backwards,
            backLeft,
            backRight,
            frontLeft,
            frontRight
        }

        string[] flipDirs = { "l", "r", "f", "b", "bl", "rb", "fl", "fr" };

        public Drone()
        {
        }

        string sendQuery(string query)
        {
            comms.SendData(query);
            return comms.RecieveData().ToLower().TrimEnd('\n');
        }


        public void commandMode()
        {
            if (sendQuery("command") == "ok")
            {
                Console.WriteLine("Command Mode Entered");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void TakeOff()
        {
            if (sendQuery("takeoff") == "ok")
            {
                Console.WriteLine("Take Off Succesfull");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void Land()
        {
            if (sendQuery("land") == "ok")
            {
                Console.WriteLine("Landing Succesfull");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void StreamOn()
        {
            if (sendQuery("streamon") == "ok")
            {
                Console.WriteLine("Stream Started");
                Console.WriteLine("Not fully implemented yet");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void StreamOff()
        {
            if (sendQuery("streamoff") == "ok")
            {
                Console.WriteLine("Stream Ended");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void Emergency()
        {
            if (sendQuery("emergency") == "ok")
            {
                Console.WriteLine("Emergency Shutdown Actioned");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void Up(int height)
        {
            if (height >= 20 && height <= 500)
            {
                if (sendQuery("up " + height) == "ok")
                {
                    Console.WriteLine("Raised " + height + "cm");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Height needs to be between 20 and 500");
            }
        }

        public void Down(int height)
        {
            if (height >= 20 && height <= 500)
            {
                if (sendQuery("down " + height) == "ok")
                {
                    Console.WriteLine("Raised " + height + "cm");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Height needs to be between 20 and 500");
            }
        }

        public void Left(int distance)
        {
            if (distance >= 20 && distance <= 500)
            {
                if (sendQuery("left " + distance) == "ok")
                {
                    Console.WriteLine("Moved Left " + distance + "cm");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Distance needs to be between 20 and 500");
            }
        }

        public void Right(int distance)
        {
            if (distance >= 20 && distance <= 500)
            {
                if (sendQuery("right " + distance) == "ok")
                {
                    Console.WriteLine("Moved Right " + distance + "cm");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Distance needs to be between 20 and 500");
            }
        }

        public void Forwards(int distance)
        {
            if (distance >= 20 && distance <= 500)
            {
                if (sendQuery("forward " + distance) == "ok")
                {
                    Console.WriteLine("Moved forward " + distance + "cm");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Distance needs to be between 20 and 500");
            }
        }

        public void Backwards(int distance)
        {
            if (distance >= 20 && distance <= 500)
            {
                if (sendQuery("back " + distance) == "ok")
                {
                    Console.WriteLine("Moved back " + distance + "cm");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Distance needs to be between 20 and 500");
            }
        }

        public void RotateClockwise(int degrees)
        {
            if (degrees >= 20 && degrees <= 500)
            {
                if (sendQuery("cw " + degrees) == "ok")
                {
                    Console.WriteLine("Rotated Clockwise " + degrees + " degrees");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Degrees needs to be between 20 and 500");
            }
        }

        public void RotateCounterClockwise(int degrees)
        {
            if (degrees >= 20 && degrees <= 500)
            {
                if (sendQuery("ccw " + degrees) == "ok")
                {
                    Console.WriteLine("Rotated Counter Clockwise " + degrees + " degrees");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Degrees needs to be between 20 and 500");
            }
        }

        public void Flip(FlipDir flipDir)
        {
            if (sendQuery("flip " + flipDirs[Convert.ToInt32(flipDir)]) == "ok")
            {
                Console.WriteLine("flipped " + flipDir.ToString());
            }
            else
            {
                Console.WriteLine("Error");
            }
        }


        public void GoTo(int x, int y, int z, int speed)
        {
            if (x >= 20 && x <= 500 && y >= 20 && y <= 500  && z >= 20 && z <= 500 && speed >= 10 && speed <= 100)
            {
                if (sendQuery(string.Concat("go ",x," ",y," ",z," ",speed)) == "ok")
                {
                    Console.WriteLine("Moved to location" + string.Concat("X:", x, " Y:", y, " Z:", z, " Speed:", speed));
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Error XYZ need to be between 20-500 Speed between 10-100");
            }
        }

        public void Curve(int x1, int y1, int z1, int x2, int y2, int z2, int speed)
        {
            if (x1 >= 20 && x1 <= 500 && y1 >= 20 && y1 <= 500 && z1 >= 20 && z1 <= 500 && speed >= 10 && speed <= 60)
            {

                if (x2 >= 20 && x2 <= 500 && y2 >= 20 && y2 <= 500 && z2 >= 20 && z2 <= 500)
                {
                    if (sendQuery(string.Concat("curve ", x1, " ", y1, " ", z1, " ", x2, " ", y2, " ", z2, " ", speed)) == "ok")
                    {
                        Console.WriteLine("Curved to location" + string.Concat("X1:", x1, " Y1:", y1, " Z1:", z1, " X2:", x2, " Y2", y2, " Z2", z2, " Speed:", speed));
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                else
                {
                    Console.WriteLine("Error XYZ2 need to be between 20-500");
                }
            }
            else
            {
                Console.WriteLine("Error XYZ1 need to be between 20-500 Speed between 10-60");
            }
        }

        public void SetSpeed(int speed)
        {
            if (speed >= 10 && speed <= 100)
            {
                if (sendQuery("speed " + speed) == "ok")
                {
                    Console.WriteLine("Set Speed To " + speed + "cm");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("speed needs to be between 10 and 100");
            }
        }

        public void RCCommand(int lr, int fb, int ud, int yaw)
        {
            if (lr >= -100 && lr <= 100 && fb >= -100 && fb <= 100 && ud >= -100 && ud <= 100 && yaw >= -100 && yaw <= 100)
            {
                if (sendQuery(string.Concat("rc"," ",lr," ",fb," ",ud," ",yaw)) == "ok")
                {
                    Console.WriteLine("RC Command to " + string.Concat("Left/Right:", lr, " Forwards/Backwards:", fb, " Up/Down:", ud, " Yaw:", yaw));
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("all inputs are betwwen -100 to 100");
            }
        }

        public void SecureDrone(string ssid, string pass)
        {
            Land();
            if (sendQuery("wifi "+ssid+" "+pass) == "ok")
            {
                Console.WriteLine("Secured Drone with SSID:{0} Password:{1} Please Reconnect",ssid,pass);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public int GetSpeed()
        {
            var speed = sendQuery("speed?");
            return Convert.ToInt32(speed);
        }

        public int GetBattery()
        {
            var batt = sendQuery("battery?");
            return Convert.ToInt32(batt);
        }

        public string GetTime()
        {
            return sendQuery("time?");
        }

        public int GetHeight()
        {
            var height = sendQuery("height?");
            return Convert.ToInt32(height);
        }

        public int GetTemp()
        {
            var temp = sendQuery("temp?");
            return Convert.ToInt32(temp);
        }

        public void GetAttitude()
        {
            Console.WriteLine(sendQuery("attitude?"));
        }

        public int GetBaro()
        {
            var baro = sendQuery("baro?");
            return Convert.ToInt32(baro);
        }

        public void GetAcceleration()
        {
            Console.WriteLine(sendQuery("acceleration?"));
        }

        public int GetTof()
        {
            var tof = sendQuery("tof?");
            return Convert.ToInt32(tof);
        }

        public void GetWifi()
        {
            Console.WriteLine(sendQuery("wifi?"));
        }
    }

}

