using BattleShip.Core.Enums;

namespace Battleship.Core.Entities
{
    public class Board
    {
        public BoardCellStatus[,] BoardCellStatuses { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int OccupationCount { get; set; }
        public int HitCount { get; set; }
        public bool HasLost => HitCount >= OccupationCount;
    }
}