// Decompiled with JetBrains decompiler
// Type: TowerDefense.Bomb
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class Bomb : Projectile
  {
    public float radius;

    public Bomb(
      GameMap gameMap,
      float damage,
      float radius,
      Vector2 pos,
      Monster target,
      BasicAttackTower parent)
      : base("Sprites/Projectiles/cannonball", 4, 1, damage, pos, target, parent)
    {
      this.animations.Add("explode", new int[3]{ 1, 2, 3 });
      this.animSpeed = 50f;
      this.speed = 0.15f;
      this.radius = radius;
      this.fireSound = "cannon_shot";
      this.hitSound = "cannon_hit";
    }

    protected override void Hit()
    {
      foreach (Monster monstersInRadiu in BasicAttackTower.GetMonstersInRadius(this.pos, this.radius, this.parentTower.ownerPlayerIndex))
      {
        if (!(monstersInRadiu is FruitBat))
          monstersInRadiu.Hit(this.damage);
      }
      Game.soundBank.PlayCue(this.hitSound);
      this.SetAnimation("explode");
    }

    protected override void AnimationEnd()
    {
      if (!(this.currentAnim == "explode"))
        return;
      this.expired = true;
    }

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch) => this.BaseDraw(viewOffset, gameTime, spriteBatch);

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (this.id % 2 == 0)
        this.rot += (float) gameTime.ElapsedGameTime.Milliseconds / 200f;
      else
        this.rot -= (float) gameTime.ElapsedGameTime.Milliseconds / 200f;
    }
  }
}
