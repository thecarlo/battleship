using Battleship.Core.Enums;
using Battleship.Core.Implementations;
using Xunit;

namespace Battleship.Tests
{
    public class ShipTests
    {
        [Theory]
        [InlineData(ShipType.AircraftCarrier)]
        public void ShouldReturnShip_WhenShipCreated(ShipType shipType)
        {
            //arrange
            var shipCreator = new ShipCreator();

            //act
            var ship = shipCreator.CreateShip(shipType);

            //assert
            Assert.NotNull(ship);
        }
    }
}
