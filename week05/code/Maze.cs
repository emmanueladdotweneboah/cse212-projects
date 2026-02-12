using System;
using System.Collections.Generic;

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
            results.Add(currPath.AsString());
        }
        else
        {
            SolveMaze(maze, size, x + 1, y, currPath, results);
            SolveMaze(maze, size, x - 1, y, currPath, results);
            SolveMaze(maze, size, x, y + 1, currPath, results);
            SolveMaze(maze, size, x, y - 1, currPath, results);
        }

        currPath.RemoveAt(currPath.Count - 1);
    }
}
