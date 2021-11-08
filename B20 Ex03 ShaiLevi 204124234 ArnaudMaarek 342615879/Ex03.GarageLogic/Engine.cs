using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.ConsoleUI;

namespace Ex03.GarageLogic
{
     public abstract class Engine
     {
          private float m_EnergyLeft;
          private float m_MaximumEnergy;

          public void PrintData(ref Dictionary<string, object> io_DataToPrint)
          {
               EnergyLeft = 1;
               MaximumEnergy = 1;
               io_DataToPrint.Add(nameof(EnergyLeft), EnergyLeft);
               io_DataToPrint.Add(nameof(MaximumEnergy), MaximumEnergy);
          }

          public float EnergyLeft
          {
               get { return m_EnergyLeft; }
               set
               {
                    if (value >= 0 && value <= MaximumEnergy)
                    {
                         m_EnergyLeft = value;
                    }
                    else
                    {
                         throw new ValueOutOfRangeException(0, MaximumEnergy - EnergyLeft, value - EnergyLeft);
                    }
               }
          }

          public float MaximumEnergy
          {
               get { return m_MaximumEnergy; }
               set { m_MaximumEnergy = value; }
          }
     }
}
