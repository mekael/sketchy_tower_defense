// Decompiled with JetBrains decompiler
// Type: TowerDefense.PitTower
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class PitTower : BasicAttackTower
  {
    private bool dying;
    private float totalDieTime = 2000f;
    private float dieTimer;

    public PitTower()
      : base("Sprites/Towers/pittower_base", 1, 1)
    {
      this.damageLookup = new int[5]
      {
        100,
        200,
        400,
        800,
        1600
      };
      this.upgradeCostLookup = new int[5]
      {
        25,
        50,
        150,
        300,
        500
      };
      this.rangeLookup = new int[5]{ 5, 5, 5, 5, 5 };
      this.maxLevel = this.damageLookup.Length - 1;
      this.attackSpeed = 500f;
      this.type = TowerType.PIT;
      this.dieTimer = this.totalDieTime;
      this.ground = true;
    }

    public override bool Passable => true;

    public override float Range(int i, bool boosted) => 0.0f;

    public override bool Attack() => true;

    public override Projectile CreateProjectile() => (Projectile) null;

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (!this.dying)
      {
        if (this.state != Tower.TowerState.IDLE)
          return;
        Monster monster = ((GameMap.Instance.GetGroundMonsterAt(this.x, this.y) ?? GameMap.Instance.GetGroundMonsterAt(this.x + 1, this.y)) ?? GameMap.Instance.GetGroundMonsterAt(this.x, this.y + 1)) ?? GameMap.Instance.GetGroundMonsterAt(this.x + 1, this.y + 1);
        if (monster == null)
          return;
        monster.Hit(this.Damage(this.level, true));
        this.dying = true;
        Game.soundBank.PlayCue("knife_pit");
      }
      else
      {
        this.dieTimer -= (float) gameTime.ElapsedGameTime.Milliseconds;
        if ((double) this.dieTimer > 0.0)
          return;
        this.dead = true;
      }
    }

    public override int Size => 2;

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (this.newTower)
        return;
      this.color.A = (byte) ((double) this.dieTimer / (double) this.totalDieTime * (double) byte.MaxValue);
      base.Draw(viewOffset, gameTime, spriteBatch);
      this.DrawLevel(viewOffset + this.pos, gameTime, spriteBatch, 0);
      this.DrawBuildProgressBar(viewOffset, gameTime, spriteBatch);
    }

    public new static string Name() => "Pit Tower";

    public override void SetOwner(PlayerEnum index) => base.SetOwner(index);
  }
}
