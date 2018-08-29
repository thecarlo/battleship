# Battleship
Based on the game Battleship. Game rules and explanation at http://www.mathematicshed.com/uploads/1/2/5/7/12572836/battleships.pdf

## Functionality
The functionality includes:

* Create a board
* Add a battleship to the board
* Take an "attack" at a given position, and report back whether the attack resulted in a
hit or a miss
* Return whether the player has lost the game yet (i.e. all battleships are sunk)

No UI was developed. The unit tests verify all the functionality.

## Quick Walkthrough of the Application Structure

The application consists of the following projects:
1) Battleship.Core project
    * This project houses the logic, interfaces and entities

2) Battleship.Tests
    * This project has unit tests for all the acceptance criteria

## Quick walkthrough of the application logic

### Entities
There are only 2 main entities :

* Board.cs
    * Stores the status of individual grid cells
    * Keeps track of hit count and number of cells ships occupy on the board
    * Keeps track of number of rows and column on the board
    * Keeps track of if the game is lost based on the hitcount and number of cells occupied by ships

* Ship.cs
    * AircraftCarrier.cs (inherits from ship)
    * Destroyer.cs (inherits from ship)

### Logic
There are only a few methods. Each interface and implementation only adheres to a single responsibility.

    * IBoardCreator.cs
        * CreateBoard (creates and returns a board)

    * IShipCreator.cs
        * CreateShip (creates and returns a ship)

    * IShipPlacer.cs
        * AddShipToBoard (Places a ship at a given position on the board)
        
    * IAttacker.cs
        * Attack (launches an attack at a given position)

### Unit tests

    * BoardTests.cs
        * ShouldReturnValidBoard_WhenBoardCreated
            * Verifies that a valid board is returned on creation

    * ShipTests.cs
        * ShouldReturnShip_WhenShipCreated
            * Verifies that a new ship is created
    
    * ShipPlacementTests.cs
        * ShouldPlaceAShip_WhenCorrectPositionsProvided
            * Verifies that a ship is placed on the board when correct coordinates are provided

        * ShouldFailToPlaceAShip_WhenIncorrectCorrectPositionsProvided
            * Verifies that an IndexOutOfRange exception is returned when invalid coordinates are provided
        
    AttackerTests.cs
        * ShouldReturnCorrectAttackStatus_WhenAttackLaunched
            * This test attacks at a given position and tests
        to see if the board status reflects hit or miss

        * ShouldReturnException_WhenIncorrectAttackCoordinatesProvided
            * This test verifies that an IndexOutOfRangeException exception is returned
         when invalid coordinates for an attack are provided

    * GameStatusTests.cs
        * ShouldReturnLostGameStatus_WhenShipsSunk
            * This test attacks a ship at all given positions
        to see if the status of the game is lost.
        It should return gamelost=true

        * ShouldNotReturnLostGameStatusTrue_WhenShipsNotSunk
            * This test attacks a ship at 1 position.
        It should return gamelost=false
    

## How to Run the Application
The application was written in .NET Core 2.1.400, so please ensure you have .NET Core 2.1 installed. If you don't, you may download it at https://www.microsoft.com/net/download/dotnet-core/2.1

## Get up and running from the command prompt
* Ensure you've installed .NET Core 2.1 from https://www.microsoft.com/net/download/dotnet-core/2.1

* Open the command prompt
* Ensure you have git installed
* Run the following git clone command to clone the repo onto your local computer : ```git clone git@github.com:thecarlo/flare-hr.git```
* Change into the directory, and change into the ```src\Battleship.Tests``` directory. (On my computer the full location is ```D:\projects\flare-battleship\src\Battleship.Tests```)
* Type ```dotnet restore``` in the command prompt
* Type ```dotnet build``` in the command prompt
* Type ```dotnet test``` to run the unit tests.

## Run the Tests from Visual Studio
* To run the unit tests from Visual Studio, simply right-click the Unit Test project (Battleship.Tests) and select Run Unit Tests.
