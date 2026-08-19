// Decompiled with JetBrains decompiler
// Type: TowerDefense.Exit
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class Exit : Tower
  {
    public Spawner spawner;
    public int[,] pathGrid;
    public int[,] newPathGrid;
    private static Point[] neighbours = new Point[8]
    {
      new Point(-1, 0),
      new Point(1, 0),
      new Point(0, -1),
      new Point(0, 1),
      new Point(-1, -1),
      new Point(1, -1),
      new Point(-1, 1),
      new Point(1, 1)
    };

    public Exit()
      : base("Sprites/Gates/town", 1, 1)
    {
      this.type = TowerType.EXIT;
      this.level = -1;
      this.state = Tower.TowerState.IDLE;
      this.pathGrid = new int[GameMap.Instance.width, GameMap.Instance.height];
      this.newPathGrid = new int[GameMap.Instance.width, GameMap.Instance.height];
    }

    public override bool Passable => true;

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (GameMap.Instance.PvP)
      {
        if (this.ownerPlayerIndex == PlayerEnum.P1)
          this.color = GameMap.Instance.game.playerOneColor;
        else
          this.color = GameMap.Instance.game.playerTwoColor;
      }
      else
        this.color = Color.Brown;
      base.Draw(viewOffset, gameTime, spriteBatch);
    }

    public Point NextLeastCostCell(Point oldCell)
    {
      Point point = new Point(-1, -1);
      int num = this.pathGrid[oldCell.X, oldCell.Y];
      for (int index = 0; index < 8; ++index)
      {
        int x = oldCell.X + Exit.neighbours[index].X;
        int y = oldCell.Y + Exit.neighbours[index].Y;
        if (x >= 0 && x < GameMap.Instance.width && y >= 0 && y < GameMap.Instance.height && this.pathGrid[x, y] < num)
        {
          num = this.pathGrid[x, y];
          point = new Point(x, y);
        }
      }
      return point;
    }

    public override int Size => 2;
  }
}
