using RLNET;
using RogueSharp;

namespace RogueTutorial.Core
{
    public class DungeonMap : Map
    {
        // The draw method will be called each time the map is updated
        // It will render all of the symbols/colors for each cell to the map
        // sub-console
        public void Draw(RLConsole mapConsole)
        {
            mapConsole.Clear();
            foreach (Cell cell in GetAllCells())
            {
                SetConsoleSymbolForCell(mapConsole, cell);
            }
        }

        private void SetConsoleSymbolForCell(RLConsole console, Cell cell)
        {
            // If cell not explored, don't draw anything
            if (!cell.IsExplored)
            {
                return;
            }

            // when a cell is currently in FOV, it should be drawn with lighter
            // colors
            if (IsInFov(cell.X, cell.Y))
            {
                // Choose symbol to draw based on if cell walkable or not
                // '.' for floor and '#' for walls
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colors.FloorFov, Colors.FloorBackgroundFov, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colors.WallFov, Colors.WallBackgroundFov, '#');
                }
            }
            // when cell is outside FOV, draw with darker colors
            else
            {
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colors.Floor, Colors.FloorBackground, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colors.Wall, Colors.WallBackground, '#');
                }
            }

        }
    }
}
