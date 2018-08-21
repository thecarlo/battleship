using Battleship.Core.Entities;
using Battleship.Core.Enums;

namespace Battleship.Core.Interfaces
{
    public interface IAttacker
    {
         AttackStatus Attack(Board board, int row, int column);
    }
}