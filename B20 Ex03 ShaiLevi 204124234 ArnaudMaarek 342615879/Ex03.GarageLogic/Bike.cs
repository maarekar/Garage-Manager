using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public class Bike : BikeInfo
     {
          public Bike()
          {
               EngineType = new FuelEngine();
               (this.EngineType as FuelEngine).FuelType = FuelEngine.eFuelType.Octan95;
               EngineType.MaximumEnergy = 7;
          }
     }
}