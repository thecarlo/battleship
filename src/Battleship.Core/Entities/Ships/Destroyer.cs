using Battleship.Core.Enums;

namespace Battleship.Core.Entities.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Size = 2;
            ShipType = ShipType.Destroyer;
        }
    }
}