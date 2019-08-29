using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelloAPI;

namespace TelloAPI
{
    class Program
    {
        static void Main()
        {
            Drone drone = new Drone();
            drone.Flip(Drone.FlipDir.backLeft);

        }
    }



   


  
}
