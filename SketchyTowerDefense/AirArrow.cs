// Decompiled with JetBrains decompiler
// Type: TowerDefense.AirArrow
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;

namespace TowerDefense
{
  public class AirArrow : Projectile
  {
    public AirArrow(
      GameMap gameMap,
      float damage,
      Vector2 pos,
      Monster target,
      BasicAttackTower parent)
      : base("Sprites/Projectiles/air_arrow", 1, 1, damage, pos, target, parent)
    {
      this.fireSound = "air_arrow_shot";
      this.hitSound = "air_arrow_hit";
    }
  }
}
