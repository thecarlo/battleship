using System;
using Battleship.Core.Entities;
using Battleship.Core.Interfaces;
using BattleShip.Core.Enums;

namespace Battleship.Core.Implementations
{
    public class BoardCreator : IBoardCreator
    {
        public Board CreateBoard(int rows, int columns) 
        {
            try
            {
                //build up the board and set all cells to unoccupied
                BoardCellStatus[,] statusArray = new BoardCellStatus[rows, columns];
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < columns; column++)
                    {
                        statusArray[row, column] = BoardCellStatus.Unoccupied;
                    }
                }

                //return the board
                return new Board
                {
                    BoardCellStatuses = statusArray,
                    Rows = rows,
                    Columns = columns
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating board : {ex.Message}");
            }
        }
    }
}