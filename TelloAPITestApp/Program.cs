using System;
using TelloAPI;

namespace TelloAPITestApp
{
    class Program
    {
        static void Main()
        {
            Drone drone = new Drone();
            drone.CommandMode();
            Console.WriteLine(drone.GetBattery());
            drone.TakeOff();
            drone.Up(100);
            drone.RotateCounterClockwise(180);
            drone.Land();

        }
    }



   


  
}
