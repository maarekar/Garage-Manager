using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public class ElectricBike : BikeInfo
     {
          public ElectricBike()
          {
               EngineType = new ElectricEngine();
               EngineType.MaximumEnergy = 1.2f;
          }
     }
}