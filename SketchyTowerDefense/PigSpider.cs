// Decompiled with JetBrains decompiler
// Type: TowerDefense.PigSpider
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class PigSpider : Monster
  {
    public PigSpider(int level, bool boss)
      : base("Sprites/Characters/pig_spider", level, boss, SpawnType.SPAWNTYPE_PIGSPIDER, 1, 1)
    {
      this.color = new Color((byte) 110, (byte) 120, (byte) 35, this.color.A);
      this.speed = 0.04f;
      this.healthMultiplier = 0.9f;
      this.moneyMultiplier = 1f;
      this.deathSound = "pigspider_death";
      this.CalcStats();
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch) => base.Draw(viewOffset, gameTime, spriteBatch);
  }
}
