// Decompiled with JetBrains decompiler
// Type: TowerDefense.BombTower
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TowerDefense
{
  public class BombTower : BasicAttackTower
  {
    private AnimatedSprite turret;

    public BombTower()
      : base("Sprites/Towers/cannontower_base", 1, 1)
    {
      this.damageLookup = new int[5]{ 10, 20, 35, 60, 100 };
      this.upgradeCostLookup = new int[5]
      {
        50,
        45,
        100,
        300,
        800
      };
      this.rangeLookup = new int[5]{ 40, 50, 60, 70, 80 };
      this.maxLevel = this.damageLookup.Length - 1;
      this.attackSpeed = 5000f;
      this.projectileRadius = (float) (GameMap.Instance.cellWidth * 3);
      this.type = TowerType.BOMB;
      this.turret = new AnimatedSprite("Sprites/Towers/cannontower_turret", 1, 1);
      this.ground = true;
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
      return (Projectile) new Bomb(GameMap.Instance, this.Damage(this.level, true), this.projectileRadius, this.pos - new Vector2(0.0f, 13f), this.target, (BasicAttackTower) this);
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

    public new static string Name() => "Bomb Tower";

    public override void SetOwner(PlayerEnum index)
    {
      base.SetOwner(index);
      this.turret.color = this.color;
    }
  }
}
