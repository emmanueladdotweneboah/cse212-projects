using System;
using System.Collections.Generic;
using System.Linq;

namespace Week05
{
    public static class Maze
    {
        public static void SolveMaze(
            int[] maze,
            int size,
            int x,
            int y,
            List<(int x, int y)> currPath,
            List<string> results)
        {
            if (!IsValidMove(maze, size, x, y, currPath))
                return;

            currPath.Add((x, y));

            if (IsEnd(maze, size, x, y))
            {
                results.Add(PathAsString(currPath));
            }
            else
            {
                SolveMaze(maze, size, x + 1, y, currPath, results); // Right
                SolveMaze(maze, size, x - 1, y, currPath, results); // Left
                SolveMaze(maze, size, x, y + 1, currPath, results); // Down
                SolveMaze(maze, size, x, y - 1, currPath, results); // Up
            }

            // Backtrack
            currPath.RemoveAt(currPath.Count - 1);
        }

        // ------------------------------------------------------------
        // Helper Methods (Already Provided in Assignment)
        // ------------------------------------------------------------
        private static bool IsEnd(int[] maze, int size, int x, int y)
        {
            return maze[y * size + x] == 2;
        }

        private static bool IsValidMove(
            int[] maze,
            int size,
            int x,
            int y,
            List<(int x, int y)> path)
        {
            if (x < 0 || y < 0 || x >= size || y >= size)
                return false;

            if (maze[y * size + x] == 0)
                return false;

            if (path.Contains((x, y)))
                return false;

            return true;
        }

        private static string PathAsString(List<(int x, int y)> path)
        {
            return string.Join(" -> ",
                path.Select(p => $"({p.x},{p.y})"));
        }
    }
}
