using Battleship.Core.Enums;

namespace Battleship.Core.Entities
{
    public abstract class Ship
    {
        public ShipType ShipType { get; set; }
        public int Size { get; set; }
    }
}