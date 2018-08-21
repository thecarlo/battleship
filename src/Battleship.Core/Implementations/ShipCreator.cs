using System;
using Battleship.Core.Entities;
using Battleship.Core.Entities.Ships;
using Battleship.Core.Enums;
using Battleship.Core.Interfaces;

namespace Battleship.Core.Implementations
{
    public class ShipCreator : IShipCreator
    {
        public Ship CreateShip(ShipType shipType)
        {
            try
            {
                switch (shipType)
                {
                    case ShipType.AircraftCarrier:
                        return new AircraftCarrier();

                    case ShipType.Destroyer:
                        return new Destroyer();

                    default:
                        return new AircraftCarrier();
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Could not create ship : {ex.Message}");
            }
        }
    }
}