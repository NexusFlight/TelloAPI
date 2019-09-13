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
            drone.RotateCounterClockwise(90);
            drone.Land();

        }
    }



   


  
}
