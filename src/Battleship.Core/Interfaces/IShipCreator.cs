using Battleship.Core.Entities;
using Battleship.Core.Enums;

namespace Battleship.Core.Interfaces
{
    public interface IShipCreator
    {
        Ship CreateShip(ShipType shipType);
    }
}