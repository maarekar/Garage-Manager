using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public class Car : CarInfo
     {
          public Car()
          {
               EngineType = new FuelEngine();
               (this.EngineType as FuelEngine).FuelType = FuelEngine.eFuelType.Octan96;
               EngineType.MaximumEnergy = 60;
          } 
     }
}