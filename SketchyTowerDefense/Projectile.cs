// Decompiled with JetBrains decompiler
// Type: TowerDefense.Projectile
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TowerDefense
{
  public class Projectile : AnimatedSprite
  {
    public Monster target;
    public float damage;
    public float speed = 0.3f;
    public bool expired;
    public bool flying = true;
    public BasicAttackTower parentTower;
    public bool fired;
    public string fireSound;
    public string hitSound;

    public Projectile(
      string texture,
      int cellColumns,
      int cellRows,
      float damage,
      Vector2 pos,
      Monster target,
      BasicAttackTower parent)
      : base(texture, cellColumns, cellRows)
    {
      this.pos = pos;
      this.target = target;
      this.damage = damage;
      this.parentTower = parent;
      this.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (this.flying)
        this.FlyToTarget(gameTime);
      if (this.fired)
        return;
      this.fired = true;
      if (!(this.fireSound != ""))
        return;
      Game.soundBank.PlayCue(this.fireSound);
    }

    protected virtual void FlyToTarget(GameTime gameTime)
    {
      if (this.target == null || this.expired)
      {
        this.expired = true;
      }
      else
      {
        Vector2 vector2_1 = this.target.pos - this.pos;
        Vector2 vector2_2 = vector2_1;
        vector2_2.Normalize();
        Vector2 vector2_3 = vector2_2 * this.speed * (float) gameTime.ElapsedGameTime.Milliseconds;
        if ((double) vector2_1.LengthSquared() < (double) vector2_3.LengthSquared())
          vector2_3 = vector2_1;
        Projectile projectile = this;
        projectile.pos = projectile.pos + vector2_3;
        if ((double) (this.target.pos - this.pos).LengthSquared() >= 1.0)
          return;
        this.Hit();
        this.flying = false;
      }
    }

    protected virtual void Hit()
    {
      this.target.Hit(this.damage);
      if (!this.expired && this.hitSound != "")
        Game.soundBank.PlayCue(this.hitSound);
      this.expired = true;
    }

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      Vector2 vector2 = this.target.pos - this.pos;
      this.rot = -(float) Math.Atan2((double) vector2.X, (double) vector2.Y);
      this.rot -= 1.57079637f;
      this.rot += 3.14159274f;
      if (!this.flying)
        this.rot = 0.0f;
      base.Draw(viewOffset, gameTime, spriteBatch);
    }

    public void BaseDraw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch) => base.Draw(viewOffset, gameTime, spriteBatch);
  }
}
