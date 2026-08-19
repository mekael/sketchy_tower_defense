// Decompiled with JetBrains decompiler
// Type: TowerDefense.PathFinderNode
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using System;

namespace TowerDefense
{
  public class PathFinderNode : IComparable
  {
    public int x;
    public int y;
    public int cost;

    public PathFinderNode(int x, int y, int cost)
    {
      this.x = x;
      this.y = y;
      this.cost = cost;
    }

    public PathFinderNode(int x, int y)
    {
      this.x = x;
      this.y = y;
      this.cost = -1;
    }

    public int CompareTo(object obj) => obj is PathFinderNode ? this.cost.CompareTo(((PathFinderNode) obj).cost) : throw new ArgumentException("object is not a PathFinderNode");

    public override bool Equals(object obj)
    {
      if (obj is PathFinderNode)
      {
        PathFinderNode pathFinderNode = (PathFinderNode) obj;
        if (this.x == pathFinderNode.x && this.y == pathFinderNode.y)
          return true;
      }
      return false;
    }

    public override int GetHashCode() => base.GetHashCode();
  }
}
