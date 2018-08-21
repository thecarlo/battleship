using Battleship.Core.Entities;

namespace Battleship.Core.Interfaces
{
    public interface IBoardCreator
    {
         Board CreateBoard(int rows, int columns);
    }
}