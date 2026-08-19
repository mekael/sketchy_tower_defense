// Decompiled with JetBrains decompiler
// Type: TowerDefense.SniperTower
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class SniperTower : BasicAttackTower
  {
    private AnimatedSprite turret;
    private Texture2D boltTexture;
    private float totalBoltLife = 800f;
    private float boltHalfLife = 700f;
    private float boltLife;
    private byte boltAlpha = byte.MaxValue;
    private Monster hitTarget;

    public SniperTower()
      : base("Sprites/Towers/snipertower_base", 1, 1)
    {
      this.damageLookup = new int[5]
      {
        50,
        100,
        200,
        400,
        500
      };
      this.upgradeCostLookup = new int[5]
      {
        200,
        175,
        400,
        1000,
        2000
      };
      this.rangeLookup = new int[5]{ 60, 80, 100, 120, 140 };
      this.maxLevel = this.damageLookup.Length - 1;
      this.attackSpeed = 6000f;
      this.type = TowerType.SNIPER;
      this.turret = new AnimatedSprite("Sprites/Towers/snipertower_turret", 1, 1);
      this.boltTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/Towers/bolt");
      this.ground = true;
    }

    public override bool Passable => false;

    public override bool Attack()
    {
      if (this.target == null)
        return false;
      this.boltLife = this.totalBoltLife;
      this.hitTarget = this.target;
      this.target.Hit(this.Damage(this.level, true));
      Game.soundBank.PlayCue("bolt_hit");
      return true;
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      this.turret.pos = this.pos;
      this.turret.color.A = this.color.A;
      if (this.target != null)
      {
        if (this.id % 2 == 0)
          this.turret.rot += (float) gameTime.ElapsedGameTime.Milliseconds / 100f;
        else
          this.turret.rot -= (float) gameTime.ElapsedGameTime.Milliseconds / 100f;
      }
      else if (this.target == null)
      {
        if (this.id % 2 == 0)
          this.turret.rot += (float) gameTime.ElapsedGameTime.Milliseconds / 1000f;
        else
          this.turret.rot -= (float) gameTime.ElapsedGameTime.Milliseconds / 1000f;
      }
      this.turret.Update(gameTime);
      if ((double) this.boltLife > 0.0)
      {
        this.boltLife -= (float) gameTime.ElapsedGameTime.Milliseconds;
        if ((double) this.boltLife < 0.0)
          this.boltLife = 0.0f;
        if ((double) this.boltLife >= (double) this.boltHalfLife)
          this.boltAlpha = (byte) ((double) byte.MaxValue - ((double) this.boltLife - (double) this.boltHalfLife) / ((double) this.totalBoltLife - (double) this.boltHalfLife) * (double) byte.MaxValue);
        else
          this.boltAlpha = (byte) ((double) this.boltLife / (double) this.boltHalfLife * (double) byte.MaxValue);
      }
      else
        this.boltAlpha = byte.MaxValue;
    }

    public override int Size => 2;

    private void DrawBolt(GameTime gameTime, SpriteBatch spriteBatch, Vector2 start, Vector2 end)
    {
      int r = (int) ((double) this.color.R * 1.7999999523162842);
      int g = (int) ((double) this.color.G * 1.7999999523162842);
      int b = (int) ((double) this.color.B * 1.7999999523162842);
      if (r > (int) byte.MaxValue)
        r = (int) byte.MaxValue;
      if (g > (int) byte.MaxValue)
        g = (int) byte.MaxValue;
      if (b > (int) byte.MaxValue)
        b = (int) byte.MaxValue;
      Color color = new Color((byte) r, (byte) g, (byte) b, this.boltAlpha);
      Rectangle rectangle = new Rectangle((int) start.X, (int) start.Y, (int) ((double) (end - start).Length() * 1.1499999761581421), this.boltTexture.Height);
      spriteBatch.Draw(this.boltTexture, rectangle, new Rectangle?(), color, Util.GetRotationAngle(start, end), new Vector2(0.0f, (float) (this.boltTexture.Height / 2)), SpriteEffects.None, 0.0f);
    }

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (this.newTower)
        return;
      base.Draw(viewOffset, gameTime, spriteBatch);
      if ((double) this.boltLife > 0.0)
        this.DrawBolt(gameTime, spriteBatch, this.pos + viewOffset - new Vector2(0.0f, 32f), this.hitTarget.pos + viewOffset);
      this.turret.pos = this.pos;
      this.turret.Draw(viewOffset - new Vector2(0.0f, 26f), gameTime, spriteBatch);
      this.DrawLevel(viewOffset + this.pos, gameTime, spriteBatch, 0);
      this.DrawBuildProgressBar(viewOffset, gameTime, spriteBatch);
    }

    public new static string Name() => "Sniper Tower";

    public override void SetOwner(PlayerEnum index)
    {
      base.SetOwner(index);
      this.turret.color = this.color;
    }
  }
}
