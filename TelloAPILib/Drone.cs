using System;

namespace TelloAPI
{
    public class Drone
    {
        UDPComms comms;

        /// <summary>
        /// used with flip command to define the flip
        /// </summary>
        public enum FlipDir
        {
            left = 0,
            right,
            forwards,
            backwards,
            backLeft,
            backRight,
            frontLeft,
            frontRight
        }

        readonly string[] flipDirs = { "l", "r", "f", "b", "bl", "rb", "fl", "fr" };

        public Drone()
        {
            comms = new UDPComms();
        }

        string SendQuery(string query)
        {
            comms.SendData(query);
            return comms.ReceiveData();
         }



        /// <summary>
        /// Place drone in command mode. Must be done before any other command
        /// </summary>
        public void CommandMode()
        {
            var state = SendQuery("command");
            if(state == "ok")
            {
            Console.WriteLine("Command Mode Entered");


            }
            else
            {
                Console.WriteLine("Command Error "+state);
            }
        }

        /// <summary>
        /// Command the drone to launch
        /// </summary>
        public void TakeOff()
        {
            var state = SendQuery("takeoff");
            if (state == "ok")
            {
                Console.WriteLine("Take Off Succesful");
            }
            else
            {
                Console.WriteLine("Take Off Error "+state);
            }
        }

        /// <summary>
        /// Command the drone to land
        /// </summary>
        public void Land()
        {
            var state = SendQuery("land");
            if (state == "ok")
            {
                Console.WriteLine("Landing Succesful");
            }
            else
            {
                Console.WriteLine("Landing Error " + state);
            }
        }

        /// <summary>
        /// Activate the drones camera stream. Feature Work In Progress
        /// </summary>
        public void StreamOn()
        {
            var state = SendQuery("streamon");
            if (state == "ok")
            {
                Console.WriteLine("Stream Started");
                Console.WriteLine("Not fully implemented yet");
            }
            else
            {
                Console.WriteLine("Stream On Error "+state);
            }
        }

        /// <summary>
        /// Deactivate the drones camera stream
        /// </summary>
        public void StreamOff()
        {
            var state = SendQuery("streamoff");
            if (state == "ok")
            {
                Console.WriteLine("Stream Ended");
            }
            else
            {
                Console.WriteLine("Stream Off Error "+state);
            }
        }

        /// <summary>
        /// Emergency Landing, This will cut the motors no matter what.
        /// </summary>
        public void Emergency()
        {
            var state = SendQuery("emergency");
            if (state == "ok")
            {
                Console.WriteLine("Emergency Shutdown Actioned");
            }
            else
            {
                Console.WriteLine("Emergency Stop Error "+state);
            }
        }

        /// <summary>
        /// Increase the height of the drone
        /// </summary>
        /// <param name="height">20 to 500 cm</param>
        public void Up(int height)
        {
            if (height >= 20 && height <= 500)
            {
                var state = SendQuery("up " + height);
                if (state == "ok")
                {
                    Console.WriteLine("Raised " + height + "cm");
                }
                else
                {
                    Console.WriteLine("Up Error " +state);
                }
            }
            else
            {
                Console.WriteLine("Height needs to be between 20 and 500");
            }
        }

        /// <summary>
        /// Decrease the height of the drone
        /// </summary>
        /// <param name="height">20 to 500 cm</param>
        public void Down(int height)
        {
            if (height >= 20 && height <= 500)
            {
                var state = SendQuery("down " + height);
                if (state == "ok")
                {
                    Console.WriteLine("Lowered " + height + "cm");
                }
                else
                {
                    Console.WriteLine("Down Error "+state);
                }
            }
            else
            {
                Console.WriteLine("Height needs to be between 20 and 500");
            }
        }

        /// <summary>
        /// Makes the drone fly left
        /// </summary>
        /// <param name="distance">20 to 500 cm</param>
        public void Left(int distance)
        {
            if (distance >= 20 && distance <= 500)
            {
                var state = SendQuery("left " + distance);
                if (state == "ok")
                {
                    Console.WriteLine("Moved Left " + distance + "cm");
                }
                else
                {
                    Console.WriteLine("Left Error "+state);
                }
            }
            else
            {
                Console.WriteLine("Distance needs to be between 20 and 500");
            }
        }

        /// <summary>
        /// Makes the drone fly right
        /// </summary>
        /// <param name="distance">20 to 500 cm</param>
        public void Right(int distance)
        {
            if (distance >= 20 && distance <= 500)
            {
                var state = SendQuery("right " + distance);
                if (state == "ok")
                {
                    Console.WriteLine("Moved Right " + distance + "cm");
                }
                else
                {
                    Console.WriteLine("Right Error "+state);
                }
            }
            else
            {
                Console.WriteLine("Distance needs to be between 20 and 500");
            }
        }

        /// <summary>
        /// Makes the drone fly forwards
        /// </summary>
        /// <param name="distance">20 to 500 cm</param>
        public void Forwards(int distance)
        {
            if (distance >= 20 && distance <= 500)
            {
                var state = SendQuery("forward " + distance);
                if (state == "ok")
                {
                    Console.WriteLine("Moved forward " + distance + "cm");
                }
                else
                {
                    Console.WriteLine("Forward Error "+state);
                }
            }
            else
            {
                Console.WriteLine("Distance needs to be between 20 and 500");
            }
        }

        /// <summary>
        /// Makes the drone fly backwards
        /// </summary>
        /// <param name="distance">20 to 500 cm</param>
        public void Backwards(int distance)
        {
            if (distance >= 20 && distance <= 500)
            {
                var state = SendQuery("back " + distance);
                if (state == "ok")
                {
                    Console.WriteLine("Moved back " + distance + "cm");
                }
                else
                {
                    Console.WriteLine("Backwards Error "+state);
                }
            }
            else
            {
                Console.WriteLine("Distance needs to be between 20 and 500");
            }
        }

        /// <summary>
        /// Make the drone rotate clockwise
        /// </summary>
        /// <param name="degrees">1 to 3600 degrees</param>
        public void RotateClockwise(int degrees)
        {
            if (degrees >= 1 && degrees <= 3600)
            {
                var state = SendQuery("cw " + degrees);
                if (state == "ok")
                {
                    Console.WriteLine("Rotated Clockwise " + degrees + " degrees");
                }
                else
                {
                    Console.WriteLine("Rotate Clockwise Error "+state);
                }
            }
            else
            {
                Console.WriteLine("Degrees needs to be between 20 and 500");
            }
        }

        /// <summary>
        /// Makes the drone rotate counter clockwise 
        /// </summary>
        /// <param name="degrees">1 to 3600 degrees</param>
        public void RotateCounterClockwise(int degrees)
        {
            if (degrees >= 1 && degrees <= 3600)
            {
                var state = SendQuery("ccw " + degrees);
                if (state == "ok")
                {
                    Console.WriteLine("Rotated Counter Clockwise " + degrees + " degrees");
                }
                else
                {
                    Console.WriteLine("Rotate Counter Clockwise Error "+state);
                }
            }
            else
            {
                Console.WriteLine("Degrees needs to be between 20 and 500");
            }
        }

        /// <summary>
        /// Makes the drone flip. 
        /// </summary>
        /// <param name="flipDir">Use the TelloAPI.FlipDir enum</param>
        public void Flip(FlipDir flipDir)
        {
            var state = SendQuery("flip " + flipDirs[Convert.ToInt32(flipDir)]);
            if (state == "ok")
            {
                Console.WriteLine("flipped " + flipDir.ToString());
            }
            else
            {
                Console.WriteLine("Flip Error");
            }
        }

        /// <summary>
        /// Makes the drone fly to X Y Z Cordinates at specified speed
        /// </summary>
        /// <param name="x">20 to 500</param>
        /// <param name="y">20 to 500</param>
        /// <param name="z">20 to 500</param>
        /// <param name="speed">10 to 100</param>
        public void GoTo(int x, int y, int z, int speed)
        {
            if (x >= 20 && x <= 500 && y >= 20 && y <= 500 && z >= 20 && z <= 500 && speed >= 10 && speed <= 100)
            {
                var state = SendQuery(string.Concat("go ", x, " ", y, " ", z, " ", speed));
                if (state == "ok")
                {
                    Console.WriteLine("Moved to location" + string.Concat("X:", x, " Y:", y, " Z:", z, " Speed:", speed));
                }
                else
                {
                    Console.WriteLine("Go To Error "+state);
                }
            }
            else
            {
                Console.WriteLine("Error XYZ need to be between 20-500 Speed between 10-100");
            }
        }

        /// <summary>
        /// Tello fly a curve defined by the
        /// current and two given coordinates
        ///with speed(cm/s)
        ///If the arc radius is not within
        ///the range of 0.5-10 meters, it
        ///responses false
        ///x/y/z can’t be between -20 – 20 at
        /// the same time.
        /// </summary>
        /// <param name="x1">20 to 500</param>
        /// <param name="y1">20 to 500</param>
        /// <param name="z1">20 to 500</param>
        /// <param name="x2">20 to 500</param>
        /// <param name="y2">20 to 500</param>
        /// <param name="z2">20 to 500</param>
        /// <param name="speed">10 to 60</param>
        public void Curve(int x1, int y1, int z1, int x2, int y2, int z2, int speed)
        {
            if (x1 >= 20 && x1 <= 500 && y1 >= 20 && y1 <= 500 && z1 >= 20 && z1 <= 500 && speed >= 10 && speed <= 60)
            {

                if (x2 >= 20 && x2 <= 500 && y2 >= 20 && y2 <= 500 && z2 >= 20 && z2 <= 500)
                {
                    var state = SendQuery(string.Concat("curve ", x1, " ", y1, " ", z1, " ", x2, " ", y2, " ", z2, " ", speed));
                    if (state == "ok")
                    {
                        Console.WriteLine("Curved to location" + string.Concat("X1:", x1, " Y1:", y1, " Z1:", z1, " X2:", x2, " Y2", y2, " Z2", z2, " Speed:", speed));
                    }
                    else
                    {
                        Console.WriteLine("Curve Error "+state);
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

        /// <summary>
        /// Sets the drone speed
        /// </summary>
        /// <param name="speed">10 to 100</param>
        public void SetSpeed(int speed)
        {
            if (speed >= 10 && speed <= 100)
            {
                var state = SendQuery("speed " + speed);
                if (state == "ok")
                {
                    Console.WriteLine("Set Speed To " + speed);
                }
                else
                {
                    Console.WriteLine("Set Speed Error "+state);
                }
            }
            else
            {
                Console.WriteLine("Speed needs to be between 10 and 100");
            }
        }

        /// <summary>
        /// Send RC control via four channels.
        ///lr: left/right(-100~100)
		///fb: forward/backward(-100~100)
		///ud: up/down(-100~100)
		///yaw(-100~100)
        /// </summary>
        /// <param name="lr">-100 to 100</param>
        /// <param name="fb">-100 to 100</param>
        /// <param name="ud">-100 to 100</param>
        /// <param name="yaw">-100 to 100</param>
        public void RCCommand(int lr, int fb, int ud, int yaw)
        {
            if (lr >= -100 && lr <= 100 && fb >= -100 && fb <= 100 && ud >= -100 && ud <= 100 && yaw >= -100 && yaw <= 100)
            {
                var state = SendQuery(string.Concat("rc", " ", lr, " ", fb, " ", ud, " ", yaw));
                if (state == "ok")
                {
                    Console.WriteLine("RC Command to " + string.Concat("Left/Right:", lr, " Forwards/Backwards:", fb, " Up/Down:", ud, " Yaw:", yaw));
                }
                else
                {
                    Console.WriteLine("RC Command Error "+state);
                }
            }
            else
            {
                Console.WriteLine("All inputs are between -100 to 100");
            }
        }

        /// <summary>
        /// Secures Drones wifi
        /// </summary>
        /// <param name="ssid">Id of the drones Wifi hotspot</param>
        /// <param name="pass">New password for the Wifi hotspot</param>
        public void SecureDrone(string ssid, string pass)
        {
            Land();
            var state = SendQuery("wifi " + ssid + " " + pass);
            if (state == "ok")
            {
                Console.WriteLine("Secured Drone with SSID:{0} Password:{1} Please Reconnect", ssid, pass);
            }
            else
            {
                Console.WriteLine("Secure Drone Error "+state);
            }
        }

        /// <summary>
        /// get the speed parameter of the drone
        /// </summary>
        /// <returns>speed as an int</returns>
        public int GetSpeed()
        {
            var speed = SendQuery("speed?");
            return Convert.ToInt32(speed);
        }

        /// <summary>
        /// get the percentage of the battery
        /// </summary>
        /// <returns>returns between 100 and 0</returns>
        public int GetBattery()
        {
            var batt = SendQuery("battery?");
            return Convert.ToInt32(batt);
        }

        /// <summary>
        /// gets flight time
        /// </summary>
        /// <returns></returns>
        public string GetTime()
        {
            return SendQuery("time?");
        }

        /// <summary>
        /// get height from starting point
        /// </summary>
        /// <returns></returns>
        public int GetHeight()
        {
            var height = SendQuery("height?");
            return Convert.ToInt32(height);
        }

        /// <summary>
        /// get temperature
        /// </summary>
        /// <returns></returns>
        public int GetTemp()
        {
            var temp = SendQuery("temp?");
            return Convert.ToInt32(temp);
        }

        /// <summary>
        /// Reports the pitch roll and yaw of the drone
        /// </summary>
        public void GetAttitude()
        {
            Console.WriteLine(SendQuery("attitude?"));
        }

        /// <summary>
        /// get the barometer reading from the drone
        /// </summary>
        /// <returns></returns>
        public int GetBaro()
        {
            var baro = SendQuery("baro?");
            return Convert.ToInt32(baro);
        }

        /// <summary>
        /// reports the acceleration of the drone
        /// </summary>
        public void GetAcceleration()
        {
            Console.WriteLine(SendQuery("acceleration?"));
        }

        /// <summary>
        /// gets the distance to the floor
        /// </summary>
        /// <returns></returns>
        public int GetTof()
        {
            var tof = SendQuery("tof?");
            return Convert.ToInt32(tof);
        }

        /// <summary>
        /// reports Wifi info
        /// </summary>
        public void GetWifi()
        {
            Console.WriteLine(SendQuery("wifi?"));
        }
    }

}

