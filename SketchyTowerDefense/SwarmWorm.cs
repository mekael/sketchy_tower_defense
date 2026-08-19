// Decompiled with JetBrains decompiler
// Type: TowerDefense.SwarmWorm
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class SwarmWorm : Monster
  {
    public SwarmWorm(int level, bool boss)
      : base("Sprites/Characters/swarm_worm", level, boss, SpawnType.SPAWNTYPE_SWARMWORM, 1, 1)
    {
      this.color = new Color((byte) 100, (byte) 100, (byte) 55, this.color.A);
      this.speed = 0.02f;
      this.healthMultiplier = 0.2f;
      this.moneyMultiplier = 0.2f;
      this.deathSound = "worm_death";
      this.CalcStats();
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch) => base.Draw(viewOffset, gameTime, spriteBatch);
  }
}
