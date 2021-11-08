using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.ConsoleUI;

namespace Ex03.GarageLogic
{
     public class CarInfo : Vehicle
     {
          private eCarColor m_CarColor;
          private int m_NumberOfDoors;

          public CarInfo()
          {
               m_CarColor = eCarColor.Red;
               m_NumberOfDoors = 5;
               Wheels.Add(new Wheel(32));
               Wheels.Add(new Wheel(32));
               Wheels.Add(new Wheel(32));
               Wheels.Add(new Wheel(32));
               this.ListOfVariables.Add(nameof(Wheel.CurrentAirPressure), Wheels[0].CurrentAirPressure);
               this.ListOfVariables.Add(nameof(Wheel.Manufacturer), Wheels[0].Manufacturer);
               this.ListOfVariables.Add(nameof(eCarColor), CarColor);
               this.ListOfVariables.Add(nameof(NumberOfDoors), NumberOfDoors);
          }

          public void InsertCarVariables(string i_Key, object i_Variable)
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
               else if (i_Key == nameof(CarColor))
               {
                    CarColor = (eCarColor)i_Variable;
               }
               else if (i_Key == nameof(NumberOfDoors))
               {
                    NumberOfDoors = (int)i_Variable;
               }
          }

          public void PrintCarData(ref Dictionary<string, object> io_DataToPrint)
          {
               io_DataToPrint.Add(nameof(eCarColor), CarColor);
               io_DataToPrint.Add(nameof(NumberOfDoors), NumberOfDoors);
          }

          public enum eCarColor
          {
               Red = 1,
               White = 2,
               Black = 3,
               Silver = 4
          }

          public eCarColor CarColor
          {
               get { return m_CarColor; }
               set
               {
                    if (Enum.IsDefined(typeof(eCarColor), value))
                    {
                         m_CarColor = value;
                    }
                    else
                    {
                         throw new ArgumentException(value.ToString());
                    }
               }
          }

          public int NumberOfDoors
          {
               get { return m_NumberOfDoors; }
               set
               {
                    if (value >= 2 && value <= 5)
                    {
                         m_NumberOfDoors = value;
                    }
                    else
                    {
                         throw new ValueOutOfRangeException(2, 5, value);
                    }
               }
          }
     }
}