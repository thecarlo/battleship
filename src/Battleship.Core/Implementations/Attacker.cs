using System;
using Battleship.Core.Entities;
using Battleship.Core.Enums;
using Battleship.Core.Interfaces;
using BattleShip.Core.Enums;

namespace BattleShip.Core.Implementations
{
    public class Attacker : IAttacker
    {
        public AttackStatus Attack(Board board, int row, int column)
        {
            //validate that the attack coordinates are valid
            Validate(board, row, column);

            //if the attack lands on an occupied position, set the status as hit
            if (board.BoardCellStatuses[row, column] == BoardCellStatus.Occupied ||
                board.BoardCellStatuses[row, column] == BoardCellStatus.Hit
                )
            {
                board.BoardCellStatuses[row, column] = BoardCellStatus.Hit;

                //update the hitcount (used to determine win /lost)
                board.HitCount++;

                //return attack status
                return AttackStatus.Hit;
            }

            board.BoardCellStatuses[row, column] = BoardCellStatus.Miss;
            return AttackStatus.Miss;
        }

        private void Validate(Board board, int row, int column)
        {
            var errorMessage = "Attack position is out of bounds";

            //validate check if attack positions in bounds of the board
            if (row > board.Rows)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }

            if (column > board.Columns)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }
        }
    }
}