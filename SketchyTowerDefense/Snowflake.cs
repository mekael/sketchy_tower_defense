// Decompiled with JetBrains decompiler
// Type: TowerDefense.Snowflake
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class Snowflake : Projectile
  {
    private float slow;

    public Snowflake(
      GameMap gameMap,
      float damage,
      Vector2 pos,
      Monster target,
      BasicAttackTower parent)
      : base("Sprites/Projectiles/snowflake", 1, 1, damage, pos, target, parent)
    {
      this.slow = damage / 100f;
      this.speed = 0.05f;
      this.fireSound = "ice_shot";
      this.hitSound = "ice_hit";
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (this.id % 2 == 0)
        this.rot += (float) gameTime.ElapsedGameTime.Milliseconds / 200f;
      else
        this.rot -= (float) gameTime.ElapsedGameTime.Milliseconds / 200f;
    }

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch) => this.BaseDraw(viewOffset, gameTime, spriteBatch);

    protected override void Hit()
    {
      this.target.SetFreeze(5000f, this.slow);
      if (this.hitSound != "")
        Game.soundBank.PlayCue(this.hitSound);
      if (this.parentTower != null)
        this.parentTower.ProjectileHitTarget();
      this.expired = true;
    }
  }
}
