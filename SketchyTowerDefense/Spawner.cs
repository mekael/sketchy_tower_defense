// Decompiled with JetBrains decompiler
// Type: TowerDefense.Spawner
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TowerDefense
{
  public class Spawner : Tower
  {
    public Exit _exit;
    public int[,] pathGrid;

    public Spawner()
      : base("Sprites/Towers/spawngate", 1, 1)
    {
      this.type = TowerType.SPAWNER;
      this.level = -1;
      this.color = Color.Green;
    }

    public Exit exit
    {
      get => this._exit;
      set => this._exit = value;
    }

    public override bool Passable => true;

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      this.color.A = (byte) 96;
      Exit exit = this.exit;
    }

    public void SpawnMonster(SpawnType type, int level)
    {
      Random random = new Random();
      Monster monster1;
      switch (type)
      {
        case SpawnType.SPAWNTYPE_SNOTGOBLIN:
          monster1 = (Monster) new SnotGoblin(level, false);
          break;
        case SpawnType.SPAWNTYPE_PIGSPIDER:
          monster1 = (Monster) new PigSpider(level, false);
          break;
        case SpawnType.SPAWNTYPE_FRUITBAT:
          monster1 = (Monster) new FruitBat(level, false);
          break;
        case SpawnType.SPAWNTYPE_STINKSLIME:
          monster1 = (Monster) new StinkSlime(level, false);
          break;
        case SpawnType.SPAWNTYPE_SWARMWORM:
          for (int index = 0; index < 5; ++index)
          {
            Monster monster2 = (Monster) new SwarmWorm(level, false);
            monster2.targetGate = (Tower) this.exit;
            monster2.spawner = this;
            Vector2 pos = new Vector2((float) (this.x * GameMap.Instance.cellWidth) + (float) random.NextDouble() * (float) GameMap.Instance.cellWidth, (float) (this.y * GameMap.Instance.cellHeight) + (float) random.NextDouble() * (float) GameMap.Instance.cellHeight);
            GameMap.Instance.AddMonster(monster2, pos);
            monster2.UpdateCellPosition(this.x, this.y);
            monster2.ResetNextCell();
          }
          return;
        case SpawnType.SPAWNTYPE_BIGUN:
          monster1 = (Monster) new Bigun(level, false);
          break;
        case SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN:
          monster1 = (Monster) new SnotGoblin(level, true);
          break;
        case SpawnType.SPAWNTYPE_BOSS_PIGSPIDER:
          monster1 = (Monster) new PigSpider(level, true);
          break;
        case SpawnType.SPAWNTYPE_BOSS_FRUITBAT:
          monster1 = (Monster) new FruitBat(level, true);
          break;
        case SpawnType.SPAWNTYPE_BOSS_STINKSLIME:
          monster1 = (Monster) new StinkSlime(level, true);
          break;
        case SpawnType.SPAWNTYPE_BOSS_SWARMWORM:
          for (int index = 0; index < 5; ++index)
          {
            Monster monster3 = (Monster) new SwarmWorm(level, true);
            monster3.targetGate = (Tower) this.exit;
            monster3.spawner = this;
            Vector2 pos = new Vector2((float) (this.x * GameMap.Instance.cellWidth) + (float) random.NextDouble() * (float) GameMap.Instance.cellWidth, (float) (this.y * GameMap.Instance.cellHeight) + (float) random.NextDouble() * (float) GameMap.Instance.cellHeight);
            GameMap.Instance.AddMonster(monster3, pos);
            monster3.UpdateCellPosition(this.x, this.y);
            monster3.ResetNextCell();
          }
          return;
        case SpawnType.SPAWNTYPE_BOSS_BIGUN:
          monster1 = (Monster) new Bigun(level, true);
          break;
        default:
          return;
      }
      monster1.targetGate = (Tower) this.exit;
      monster1.spawner = this;
      Vector2 pos1 = new Vector2((float) (this.x * GameMap.Instance.cellWidth) + (float) random.NextDouble() * (float) GameMap.Instance.cellWidth, (float) (this.y * GameMap.Instance.cellHeight) + (float) random.NextDouble() * (float) GameMap.Instance.cellHeight);
      GameMap.Instance.AddMonster(monster1, pos1);
      monster1.UpdateCellPosition(this.x, this.y);
      monster1.ResetNextCell();
    }

    public void StartNextWave()
    {
    }

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch) => base.Draw(viewOffset, gameTime, spriteBatch);

    public override int Size => 2;
  }
}
