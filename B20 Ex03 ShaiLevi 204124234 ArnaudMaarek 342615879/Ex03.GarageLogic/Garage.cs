using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public class Garage
     {
          private Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();

          public Dictionary<string, Vehicle> Vehicles
          {
               get { return m_Vehicles; }
               set { m_Vehicles = value; }
          }

          public Vehicle MakeNewVehicle(string i_TypeOfVehicule, string i_LicenseNumber)
          {
               Vehicle newVehicle;
               newVehicle = NewVehicle.NewVehicleInTheGarage(i_TypeOfVehicule);
               newVehicle.LicenseNumber = i_LicenseNumber;
               m_Vehicles.Add(i_LicenseNumber, newVehicle);

               return newVehicle;
          }

          public bool FindVehicle(string i_LicenseNumber, out Vehicle o_FoundVehicle)
          {
               return m_Vehicles.TryGetValue(i_LicenseNumber, out o_FoundVehicle);
          }

          public void ChangeVehicleStatus(string i_LicenseNumber, OwnerInfo.eVehicleStatus i_VehicleStatus)
          {
               Vehicle currentVehicle;
               if (FindVehicle(i_LicenseNumber, out currentVehicle))
               {
                    currentVehicle.Owner.VehicleStatus = i_VehicleStatus;
               }
               else
               {
                    throw new KeyNotFoundException(i_LicenseNumber);
               }
          }

          public void BlowAirInWheels(string i_LicenseNumber)
          {
               Vehicle currentVehicle;
               if (FindVehicle(i_LicenseNumber, out currentVehicle))
               {
                    foreach (Vehicle.Wheel wheel in currentVehicle.Wheels)
                    {
                         wheel.CurrentAirPressure = wheel.MaximalAirPressure;
                    }
               }
               else
               {
                    throw new KeyNotFoundException(i_LicenseNumber);
               }
          }

          public void AddFuelToVehicle(string i_LicenseNumber, string i_TypeOfFuel, float i_QuantityOfFuel)
          {
               Vehicle currentVehicle;

               if (!FindVehicle(i_LicenseNumber, out currentVehicle))
               {
                    throw new KeyNotFoundException(i_LicenseNumber);
               }

               if (currentVehicle.EngineType is FuelEngine)
               {
                    if (i_TypeOfFuel.ToLower() == (currentVehicle.EngineType as FuelEngine).FuelType.ToString().ToLower())
                    {
                         (currentVehicle.EngineType as FuelEngine).EnergyLeft += i_QuantityOfFuel;
                    }
                    else
                    {
                         throw new ArgumentException(i_TypeOfFuel);
                    }
               }
               else
               {
                    throw new ArgumentException(i_LicenseNumber);
               }
          }

          public void ChargeElectricCarBattery(string i_LicenseNumber, float i_NumberOfMinutesToCharge)
          {
               Vehicle currentVehicle;

               if (!FindVehicle(i_LicenseNumber, out currentVehicle))
               {
                    throw new KeyNotFoundException(i_LicenseNumber);
               }

               float minutesToHoursToCharge = i_NumberOfMinutesToCharge / 60;

               if (currentVehicle.EngineType is ElectricEngine)
               {
                    (currentVehicle.EngineType as ElectricEngine).EnergyLeft += minutesToHoursToCharge;
               }
               else
               {
                    throw new ArgumentException(i_LicenseNumber);
               }
          }

          public void PrintData(string i_LicenseNumber, ref Dictionary<string, object> io_DataToPrint)
          {
               Vehicle currentVehicle;

               if (FindVehicle(i_LicenseNumber, out currentVehicle))
               {
                    currentVehicle.PrintData(ref io_DataToPrint);
               }
               else
               {
                    throw new KeyNotFoundException(i_LicenseNumber);
               }
          }

          public class NewVehicle
          {
               public static Vehicle NewVehicleInTheGarage(string i_TypeOfVehicule)
               {
                    Vehicle newVehicle = new Vehicle();
                    if (i_TypeOfVehicule.ToLower() == nameof(Bike).ToLower())
                    {
                         newVehicle = new Bike();
                    }
                    else if (i_TypeOfVehicule.ToLower() == nameof(ElectricBike).ToLower())
                    {
                         newVehicle = new ElectricBike();
                    }
                    else if (i_TypeOfVehicule.ToLower() == nameof(Car).ToLower())
                    {
                         newVehicle = new Car();
                    }
                    else if (i_TypeOfVehicule.ToLower() == nameof(ElectricCar).ToLower())
                    {
                         newVehicle = new ElectricCar();
                    }
                    else if (i_TypeOfVehicule.ToLower() == nameof(Truck).ToLower())
                    {
                         newVehicle = new Truck();
                    }
                    else
                    {
                         if (i_TypeOfVehicule.All(char.IsLetter))
                         {
                              throw new Exception(i_TypeOfVehicule);
                         }
                         else
                         {
                              throw new ArgumentException(i_TypeOfVehicule);
                         }
                    }

                    return newVehicle;
               }
          }
     }
}
