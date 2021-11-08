using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public class ElectricCar : CarInfo
     {
          public ElectricCar()
          {
               EngineType = new ElectricEngine();
               EngineType.MaximumEnergy = 2.1f;
          }
     }
}