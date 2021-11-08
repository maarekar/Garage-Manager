using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Ex03.ConsoleUI;

namespace Ex03.GarageLogic
{
     public class BikeInfo : Vehicle
     {
          private eLicenseType m_LicenseType;
          private int m_VolumeEngine;

          public BikeInfo()
          {
               m_LicenseType = eLicenseType.A;
               m_VolumeEngine = 0;
               Wheels.Add(new Wheel(30));
               Wheels.Add(new Wheel(30));
               this.ListOfVariables.Add(nameof(Wheel.CurrentAirPressure), Wheels[0].CurrentAirPressure);
               this.ListOfVariables.Add(nameof(Wheel.Manufacturer), Wheels[0].Manufacturer);
               this.ListOfVariables.Add(nameof(eLicenseType), LicenseType);
               this.ListOfVariables.Add(nameof(VolumeEngine), VolumeEngine);
          }

          public void InsertBikeVariables(string i_Key, object i_Variable)
          {
               if (i_Key == nameof(Wheel.CurrentAirPressure))
               {
                    for (int i = 0; i < Wheels.Count; i++)
                    {
                         Wheels[i].CurrentAirPressure = (float)i_Variable;
                    }
               }

               if (i_Key == nameof(Wheel.Manufacturer))
               {
                    for (int i = 0; i < Wheels.Count; i++)
                    {
                         Wheels[i].Manufacturer = (string)i_Variable;
                    }
               }
               else if (i_Key == nameof(eLicenseType))
               {
                    LicenseType = (eLicenseType)i_Variable;
               }
               else if (i_Key == nameof(VolumeEngine))
               {
                    VolumeEngine = (int)i_Variable;
               }
          }

          public void PrintBikeData(ref Dictionary<string, object> io_DataToPrint)
          {
               io_DataToPrint.Add(nameof(LicenseType), LicenseType);
               io_DataToPrint.Add(nameof(VolumeEngine), VolumeEngine);
          }

          public enum eLicenseType
          {
               A = 1,
               A1 = 2,
               AA = 3,
               B = 4
          }

          public int VolumeEngine
          {
               get { return m_VolumeEngine; }
               set
               {
                    if (value > 0 && value < 3001)
                    {
                         m_VolumeEngine = value;
                    }
                    else
                    {
                         throw new ValueOutOfRangeException(1, 3000, value);
                    }
               }
          }

          public eLicenseType LicenseType
          {
               get { return m_LicenseType; }
               set
               {
                    if (Enum.IsDefined(typeof(eLicenseType), value))
                    {
                         m_LicenseType = value;
                    }
                    else
                    {
                         throw new ArgumentException(value.ToString());
                    }
               }
          }
     }
}