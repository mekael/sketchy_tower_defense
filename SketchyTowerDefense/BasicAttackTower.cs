// Decompiled with JetBrains decompiler
// Type: TowerDefense.BasicAttackTower
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections;

namespace TowerDefense
{
  public class BasicAttackTower : Tower
  {
    public Monster target;
    protected float attackSpeed = 2000f;
    protected float attackDelay;
    protected float projectileRadius;
    protected int[] damageLookup = new int[1];
    public bool air;
    public bool ground;
    public bool resist;
    public bool ice;

    public BasicAttackTower(string texture, int cellColumns, int cellRows)
      : base(texture, cellColumns, cellRows)
    {
      this.attackDelay = this.attackSpeed;
    }

    public override bool Passable => false;

    public virtual Projectile CreateProjectile() => (Projectile) null;

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (this.state != Tower.TowerState.IDLE)
        return;
      float num = this.Range(this.level, true) / 10f * (float) GameMap.Instance.cellWidth;
      float towerRangeSqr = num * num;
      if (GameMap.Instance.updateGroup == this.idGroup && (this.target == null || this.target.dead || (double) (this.pos - this.target.pos).LengthSquared() > (double) towerRangeSqr))
      {
        this.target = (Monster) null;
        this.AcquireClosestTarget(towerRangeSqr);
      }
      this.attackDelay -= (float) gameTime.ElapsedGameTime.Milliseconds;
      if ((double) this.attackDelay > 0.0 || !this.Attack())
        return;
      this.attackDelay = this.attackSpeed;
    }

    public virtual bool Attack()
    {
      GameMap.Instance.projectiles.Add((object) this.CreateProjectile());
      return true;
    }

    public virtual void ProjectileHitTarget()
    {
    }

    public virtual void AcquireClosestTarget(float towerRangeSqr)
    {
      float num1 = 1E+08f;
      Monster monster1 = (Monster) null;
      Monster monster2 = (Monster) null;
      float num2 = 9999999f;
      foreach (Monster monster3 in GameMap.Instance.monsters)
      {
        if (!monster3.dead && (!(monster3 is FruitBat) || this.air) && (monster3 is FruitBat || this.ground) && (monster3._targetGate.ownerPlayerIndex != PlayerEnum.P1 || this.ownerPlayerIndex == PlayerEnum.P1) && (monster3._targetGate.ownerPlayerIndex != PlayerEnum.P2 || this.ownerPlayerIndex == PlayerEnum.P2))
        {
          float num3 = (monster3.pos - this.pos).LengthSquared();
          bool flag = (double) num3 <= (double) towerRangeSqr && (double) num3 < (double) num1;
          if ((double) monster3.freezeTime > 0.0 && this.ice && flag)
          {
            if ((double) monster3.freezeTime < (double) num2)
            {
              num2 = monster3.freezeTime;
              monster2 = monster3;
            }
          }
          else if (flag)
          {
            num1 = num3;
            monster1 = monster3;
          }
        }
      }
      if (monster1 != null)
        this.target = monster1;
      if (this.target != null || monster2 == null)
        return;
      this.target = monster2;
    }

    public static ArrayList GetMonstersInRadius(Vector2 pos, float radius, PlayerEnum playerIndex)
    {
      ArrayList monstersInRadius = new ArrayList();
      float num = radius * radius;
      foreach (Monster monster in GameMap.Instance.monsters)
      {
        if ((double) (monster.pos - pos).LengthSquared() <= (double) num && (monster._targetGate.ownerPlayerIndex != PlayerEnum.P1 || playerIndex == PlayerEnum.P1) && (monster._targetGate.ownerPlayerIndex != PlayerEnum.P2 || playerIndex == PlayerEnum.P2) && !monster.dead)
          monstersInRadius.Add((object) monster);
      }
      return monstersInRadius;
    }

    public virtual float Damage(int i, bool boosted)
    {
      if (i < 0 || i >= this.damageLookup.Length)
        return 0.0f;
      if (boosted)
      {
        switch (this)
        {
          case IceTower _:
          case DmgBoostTower _:
          case RngBoostTower _:
            break;
          default:
            Point[] pointArray = new Point[12]
            {
              new Point(-1, -1),
              new Point(0, -1),
              new Point(1, -1),
              new Point(2, -1),
              new Point(2, 0),
              new Point(2, 1),
              new Point(2, 2),
              new Point(1, 2),
              new Point(0, 2),
              new Point(-1, 2),
              new Point(-1, 1),
              new Point(-1, 0)
            };
            ArrayList arrayList = new ArrayList();
            float num = (float) this.damageLookup[i];
            float d = num;
            for (int index = 0; index < pointArray.Length; ++index)
            {
              Tower towerAt = GameMap.Instance.GetTowerAt(this.x + pointArray[index].X, this.y + pointArray[index].Y);
              if (towerAt != null && towerAt is DmgBoostTower)
              {
                bool flag = false;
                DmgBoostTower dmgBoostTower1 = (DmgBoostTower) towerAt;
                foreach (DmgBoostTower dmgBoostTower2 in arrayList)
                {
                  if (dmgBoostTower2 == dmgBoostTower1)
                  {
                    flag = true;
                    break;
                  }
                }
                if (!flag)
                {
                  d += num * (dmgBoostTower1.Boost(dmgBoostTower1.level) - 1f);
                  arrayList.Add((object) dmgBoostTower1);
                }
              }
            }
            return (float) Math.Floor((double) d);
        }
      }
      return (float) this.damageLookup[i];
    }
  }
}
