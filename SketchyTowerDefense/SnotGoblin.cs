// Decompiled with JetBrains decompiler
// Type: TowerDefense.SnotGoblin
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class SnotGoblin : Monster
  {
    public SnotGoblin(int level, bool boss)
      : base("Sprites/Characters/snot_goblin", level, boss, SpawnType.SPAWNTYPE_SNOTGOBLIN, 1, 1)
    {
      this.color = new Color((byte) 33, (byte) 100, (byte) 0, this.color.A);
      this.speed = 0.02f;
      this.healthMultiplier = 1f;
      this.moneyMultiplier = 1f;
      this.deathSound = "goblin_death";
      this.CalcStats();
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch) => base.Draw(viewOffset, gameTime, spriteBatch);
  }
}
