using Battleship.Core.Enums;

namespace Battleship.Core.Entities.Ships
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier()
        {
            Size = 5;
            ShipType = ShipType.AircraftCarrier;
        }
    }
}