using Battleship.Core.Entities;

namespace Battleship.Core.Interfaces
{
    public interface IShipPlacer
    {
        void AddShipToBoard(Ship ship, Board board, int row, int column);
    }
}