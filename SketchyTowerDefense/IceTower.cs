// Decompiled with JetBrains decompiler
// Type: TowerDefense.IceTower
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TowerDefense
{
  public class IceTower : BasicAttackTower
  {
    private AnimatedSprite turret;

    public IceTower()
      : base("Sprites/Towers/icetower_base", 1, 1)
    {
      this.damageLookup = new int[5]{ 70, 60, 50, 40, 30 };
      this.upgradeCostLookup = new int[5]
      {
        100,
        90,
        250,
        500,
        1000
      };
      this.rangeLookup = new int[5]{ 50, 60, 70, 80, 90 };
      this.maxLevel = this.damageLookup.Length - 1;
      this.attackSpeed = 4000f;
      this.type = TowerType.ICE;
      this.turret = new AnimatedSprite("Sprites/Towers/icetower_turret", 1, 1);
      this.ground = true;
      this.air = true;
      this.ice = true;
      this.turret.rot = (float) (new Random().NextDouble() * (2.0 * Math.PI) - Math.PI);
    }

    public override bool GuiOnly
    {
      set
      {
        this.guiOnly = this.GuiOnly;
        this.turret.rot = 0.0f;
      }
      get => this.guiOnly;
    }

    public override bool Passable => false;

    public override bool Attack()
    {
      if (this.target == null || (double) Util.AngleDistance(Util.GetRotationAngle(this.pos, this.target.pos), this.turret.rot) > 0.10000000149011612)
        return false;
      GameMap.Instance.projectiles.Add((object) this.CreateProjectile());
      return true;
    }

    public override Projectile CreateProjectile()
    {
      Random random = new Random();
      Projectile projectile = (Projectile) new Snowflake(GameMap.Instance, this.Damage(this.level, true), this.pos - new Vector2(0.0f, 13f), this.target, (BasicAttackTower) this);
      projectile.color = this.color;
      return projectile;
    }

    public override void ProjectileHitTarget()
    {
      float num = this.Range(this.level, true) / 10f * (float) GameMap.Instance.cellWidth;
      this.AcquireClosestTarget(num * num);
    }

    private double wrapValue(double value)
    {
      while (value < 0.0)
        value += 360.0;
      while (value > 360.0)
        value -= 360.0;
      return value;
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      this.turret.pos = this.pos;
      this.turret.color.A = this.color.A;
      if (this.target != null && this.state == Tower.TowerState.IDLE)
        this.turret.rot = Util.TurnToFace(this.pos, this.target.pos, this.turret.rot, (float) gameTime.ElapsedGameTime.Milliseconds / 600f);
      this.turret.Update(gameTime);
    }

    public override int Size => 2;

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (this.newTower)
        return;
      base.Draw(viewOffset, gameTime, spriteBatch);
      this.turret.pos = this.pos;
      this.turret.Draw(viewOffset - new Vector2(0.0f, 13f), gameTime, spriteBatch);
      this.DrawLevel(viewOffset + this.pos, gameTime, spriteBatch, 0);
      this.DrawBuildProgressBar(viewOffset, gameTime, spriteBatch);
    }

    public new static string Name() => "Ice Tower";

    public override void SetOwner(PlayerEnum index)
    {
      base.SetOwner(index);
      this.turret.color = this.color;
    }
  }
}
