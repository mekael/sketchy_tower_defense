// Decompiled with JetBrains decompiler
// Type: TowerDefense.StinkSlime
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TowerDefense
{
  public class StinkSlime : Monster
  {
    public int splitCount;
    public int maxSplits = 2;
    private static Point[] straightNeighbours = new Point[4]
    {
      new Point(-1, 0),
      new Point(1, 0),
      new Point(0, -1),
      new Point(0, 1)
    };

    public StinkSlime(int level, bool boss)
      : base("Sprites/Characters/slime", level, boss, SpawnType.SPAWNTYPE_STINKSLIME, 1, 1)
    {
      this.color = new Color((byte) 90, (byte) 150, (byte) 20, this.color.A);
      this.speed = 0.01f;
      this.healthMultiplier = 1.25f;
      this.moneyMultiplier = 1.5f;
      this.deathSound = "slime_death";
      this.CalcStats();
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);

    public override void StartDying()
    {
      Random random = new Random();
      if (this.deathSound != null)
        Game.soundBank.PlayCue(this.deathSound);
      if (this.splitCount < this.maxSplits)
      {
        ++this.splitCount;
        for (int index1 = 0; index1 < 2; ++index1)
        {
          int index2 = -1;
          for (int index3 = 0; index3 < 4; ++index3)
          {
            index2 = random.Next(0, 5);
            if (index2 == 4)
            {
              index2 = -1;
              break;
            }
            Exit targetGate = (Exit) this.targetGate;
            int index4 = this.x + StinkSlime.straightNeighbours[index2].X;
            int index5 = this.y + StinkSlime.straightNeighbours[index2].Y;
            if (index4 < 0 || index5 < 0 || index4 >= GameMap.Instance.width || index5 >= GameMap.Instance.height || targetGate.pathGrid[index4, index5] < 0)
              index2 = -1;
            else
              break;
          }
          Vector2 pos = index2 == -1 ? new Vector2((float) (this.x * GameMap.Instance.cellWidth) + (float) random.NextDouble() * (float) GameMap.Instance.cellWidth, (float) (this.y * GameMap.Instance.cellHeight) + (float) random.NextDouble() * (float) GameMap.Instance.cellHeight) : new Vector2((float) ((this.x + StinkSlime.straightNeighbours[index2].X) * GameMap.Instance.cellWidth) + (float) random.NextDouble() * (float) GameMap.Instance.cellWidth, (float) ((this.y + StinkSlime.straightNeighbours[index2].Y) * GameMap.Instance.cellHeight) + (float) random.NextDouble() * (float) GameMap.Instance.cellHeight);
          StinkSlime stinkSlime = new StinkSlime(this.level, this.boss);
          stinkSlime.splitCount = this.splitCount;
          stinkSlime.targetGate = this.targetGate;
          stinkSlime.spawner = this.spawner;
          stinkSlime.normalScale = this.normalScale * 0.75f;
          stinkSlime.moneyMultiplier = this.moneyMultiplier * 0.5f;
          stinkSlime.healthMultiplier = this.healthMultiplier * 0.75f;
          GameMap.Instance.AddMonster((Monster) stinkSlime, pos);
          stinkSlime.UpdateCellPosition(this.x, this.y);
          stinkSlime.ResetNextCell();
          stinkSlime.CalcStats();
        }
      }
      this.dying = true;
    }

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch) => base.Draw(viewOffset, gameTime, spriteBatch);
  }
}
