using System;
using Battleship.Core.Enums;
using Battleship.Core.Implementations;
using BattleShip.Core.Enums;
using BattleShip.Core.Implementations;
using Xunit;

namespace Battleship.Tests
{
    public class AttackerTests
    {
        /*This test attacks at a given position and tests
        to see if the board status reflects hit or miss*/
        [Theory]
        //board row, board column, ship row, ship column, attack row, attack column, shiptype, boardcellstatus
        [InlineData(10, 10, 0, 0, 0, 0, ShipType.AircraftCarrier, BoardCellStatus.Hit)]
        [InlineData(10, 10, 0, 0, 0, 1, ShipType.AircraftCarrier, BoardCellStatus.Hit)]
        [InlineData(10, 10, 0, 0, 0, 2, ShipType.AircraftCarrier, BoardCellStatus.Hit)]
        [InlineData(10, 10, 0, 0, 0, 3, ShipType.AircraftCarrier, BoardCellStatus.Hit)]
        [InlineData(10, 10, 0, 0, 0, 4, ShipType.AircraftCarrier, BoardCellStatus.Hit)]
        [InlineData(10, 10, 0, 0, 5, 5, ShipType.AircraftCarrier, BoardCellStatus.Miss)]
        [InlineData(10, 10, 0, 0, 0, 5, ShipType.AircraftCarrier, BoardCellStatus.Miss)]
        [InlineData(10, 10, 0, 0, 3, 8, ShipType.AircraftCarrier, BoardCellStatus.Miss)]
        public void ShouldReturnCorrectAttackStatus_WhenAttackLaunched(
            int boardRows, int boardColumns,
            int placementRow, int placementColumn,
            int attackRow, int attackColumn,
            ShipType shipType, BoardCellStatus boardCellStatus)
        {
            //arrange

            //first create a board
            var boardCreator = new BoardCreator();
            var board = boardCreator.CreateBoard(boardRows, boardColumns);

            //then create a ship
            var shipCreator = new ShipCreator();
            var ship = shipCreator.CreateShip(shipType);

            //place the ship on the board
            var shipPlacer = new ShipPlacer();
            shipPlacer.AddShipToBoard(ship, board, placementRow, placementColumn);

            //act
            //now attack the ship at the given position
            var attacker = new Attacker();
            attacker.Attack(board, attackRow, attackColumn);

            //assert
            /*check that the status on the board is hit*/
            Assert.True(
                board.BoardCellStatuses[attackRow, attackColumn] == boardCellStatus
            );
        }


        /*this test verifies that an IndexOutOfRangeException exception is returned
         when invalid coordinates for an attack are provided*/
        [Theory]
        //boardRows, boardColumns, placementRow, placementColumn, attackRow, attackColumn, shipType
        [InlineData(10, 10, 0, 0, 11, 11, ShipType.AircraftCarrier)]
        [InlineData(10, 10, 0, 0, 17, 15, ShipType.AircraftCarrier)]
        public void ShouldReturnException_WhenIncorrectAttackCoordinatesProvided(
           int boardRows, int boardColumns,
           int placementRow, int placementColumn,
           int attackRow, int attackColumn,
           ShipType shipType)
        {
            //arrange

            //first create a board
            var boardCreator = new BoardCreator();
            var board = boardCreator.CreateBoard(boardRows, boardColumns);

            //then create a ship
            var shipCreator = new ShipCreator();
            var ship = shipCreator.CreateShip(shipType);

            //place the ship on the board
            var shipPlacer = new ShipPlacer();
            shipPlacer.AddShipToBoard(ship, board, placementRow, placementColumn);

            //act
            //now attack the ship at the given position
            var attacker = new Attacker();
            IndexOutOfRangeException ex = Assert.Throws<IndexOutOfRangeException>(() =>
                attacker.Attack(board, attackRow, attackColumn));

            //assert
            Assert.Equal("Attack position is out of bounds", ex.Message);
        }
    }
}
