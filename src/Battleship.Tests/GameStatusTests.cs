using Battleship.Core.Enums;
using Battleship.Core.Implementations;
using BattleShip.Core.Implementations;
using Xunit;

namespace Battleship.Tests
{
    public class GameStatusTests
    {
        /*This test attacks a ship at all given positions
        to see if the status of the game is lost
        it should return gamelost=true*/
        [Fact]
        public void ShouldReturnLostGameStatus_WhenShipsSunk()
        {
            //arrange

            //first create a board
            var boardCreator = new BoardCreator();
            var board = boardCreator.CreateBoard(10, 10);

            //then create a ship
            var shipCreator = new ShipCreator();
            var ship = shipCreator.CreateShip(ShipType.Destroyer);

            //place the ship on the board
            var shipPlacer = new ShipPlacer();
            shipPlacer.AddShipToBoard(ship, board, 0, 0);

            //act
            //now attack the ship at all given positions for the ship
            var attacker = new Attacker();
            attacker.Attack(board, 0, 0);
            attacker.Attack(board, 0, 1);

            //assert that the status is now lost
            Assert.True(board.HasLost);
        }

        /*This test attacks a ship at 1 position.
        It should return gamelost=false*/
        [Fact]
        public void ShouldNotReturnLostGameStatusTrue_WhenShipsNotSunk()
        {
            //arrange

            //first create a board
            var boardCreator = new BoardCreator();
            var board = boardCreator.CreateBoard(10, 10);

            //then create a ship
            var shipCreator = new ShipCreator();
            var ship = shipCreator.CreateShip(ShipType.Destroyer);

            //place the ship on the board
            var shipPlacer = new ShipPlacer();
            shipPlacer.AddShipToBoard(ship, board, 0, 0);

            //act
            //now attack the ship at all given positions for the ship
            var attacker = new Attacker();
            attacker.Attack(board, 0, 1);

            //assert that the status is now lost
            Assert.False(board.HasLost);
        }
    }
}
