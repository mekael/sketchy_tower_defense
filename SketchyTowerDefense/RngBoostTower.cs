// Decompiled with JetBrains decompiler
// Type: TowerDefense.RngBoostTower
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class RngBoostTower : BasicAttackTower
  {
    protected float[] boostLookup = new float[1];

    public RngBoostTower()
      : base("Sprites/Towers/rngboosttower_base", 1, 1)
    {
      this.boostLookup = new float[5]
      {
        1.05f,
        1.1f,
        1.15f,
        1.2f,
        1.25f
      };
      this.upgradeCostLookup = new int[5]
      {
        200,
        175,
        350,
        800,
        1500
      };
      this.maxLevel = this.boostLookup.Length - 1;
      this.type = TowerType.DMGBOOST;
    }

    public override float Range(int i, bool boosted) => 20f;

    public override bool Passable => false;

    public float Boost(int level) => this.boostLookup[level];

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (this.target == null)
        return;
      int state = (int) this.state;
    }

    public override int Size => 2;

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (this.newTower)
        return;
      base.Draw(viewOffset, gameTime, spriteBatch);
      this.DrawLevel(viewOffset + this.pos, gameTime, spriteBatch, 0);
      this.DrawBuildProgressBar(viewOffset, gameTime, spriteBatch);
    }

    public new static string Name() => "Range Boost Tower";

    public override void SetOwner(PlayerEnum index) => base.SetOwner(index);
  }
}
