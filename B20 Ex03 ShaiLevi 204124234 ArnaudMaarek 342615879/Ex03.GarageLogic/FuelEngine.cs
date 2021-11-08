using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.ConsoleUI;

namespace Ex03.GarageLogic
{
     public class FuelEngine : Engine
     {
          private eFuelType m_FuelType;

          public enum eFuelType
          {
               Octan98,
               Octan96,
               Octan95,
               Soler
          }

          public eFuelType FuelType
          {
               get { return m_FuelType; }
               set { m_FuelType = value; }
          }
     }
}