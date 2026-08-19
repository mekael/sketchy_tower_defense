// Decompiled with JetBrains decompiler
// Type: TowerDefense.LeePathFinder
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using BenTools.Data;
using Microsoft.Xna.Framework;

namespace TowerDefense
{
  public class LeePathFinder
  {
    public static int INVALID_PATH_CELL = int.MaxValue;
    private static BinaryPriorityQueue openList;
    private static Point[] straightNeighbours = new Point[4]
    {
      new Point(-1, 0),
      new Point(1, 0),
      new Point(0, -1),
      new Point(0, 1)
    };
    private static Point[] diagonalNeighbours = new Point[4]
    {
      new Point(-1, -1),
      new Point(1, -1),
      new Point(-1, 1),
      new Point(1, 1)
    };

    public static bool FillGrid(Point start, ref byte[,] map, ref int[,] grid)
    {
      int length1 = map.GetLength(0);
      int length2 = map.GetLength(1);
      for (int index1 = 0; index1 < length2; ++index1)
      {
        for (int index2 = 0; index2 < length1; ++index2)
          grid[index2, index1] = LeePathFinder.INVALID_PATH_CELL;
      }
      LeePathFinder.openList = new BinaryPriorityQueue();
      PathFinderNode O1 = new PathFinderNode(start.X, start.Y, 0);
      grid[O1.x, O1.y] = O1.cost;
      LeePathFinder.openList.Push((object) O1);
      while (LeePathFinder.openList.Count > 0)
      {
        PathFinderNode pathFinderNode = (PathFinderNode) LeePathFinder.openList.Pop();
        for (int index = 0; index < 4; ++index)
        {
          PathFinderNode O2 = new PathFinderNode(pathFinderNode.x + LeePathFinder.straightNeighbours[index].X, pathFinderNode.y + LeePathFinder.straightNeighbours[index].Y, pathFinderNode.cost + 10);
          if (O2.x >= 0 && O2.x < length1 && O2.y >= 0 && O2.y < length2 && map[O2.x, O2.y] != byte.MaxValue && grid[O2.x, O2.y] == LeePathFinder.INVALID_PATH_CELL)
          {
            grid[O2.x, O2.y] = O2.cost;
            LeePathFinder.openList.Push((object) O2);
          }
        }
      }
      return true;
    }
  }
}
