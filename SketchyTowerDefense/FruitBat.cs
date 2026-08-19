// Decompiled with JetBrains decompiler
// Type: TowerDefense.FruitBat
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class FruitBat : Monster
  {
    public FruitBat(int level, bool boss)
      : base("Sprites/Characters/fruitbat", level, boss, SpawnType.SPAWNTYPE_FRUITBAT, 1, 1)
    {
      this.color = new Color((byte) 150, (byte) 90, (byte) 10, this.color.A);
      this.speed = 0.02f;
      this.healthMultiplier = 0.75f;
      this.moneyMultiplier = 1.5f;
      this.deathSound = "bat_death";
      this.CalcStats();
    }

    public override void Update(GameTime gameTime) => base.Update(gameTime);

    public override void FollowPath(GameTime gameTime)
    {
      Vector2 pos = this.pos;
      int x = this.x;
      int y = this.y;
      Vector2 vector2 = new Vector2((float) (this.targetGate.x * GameMap.Instance.cellWidth) + (float) (GameMap.Instance.cellWidth / 2), (float) ((this.targetGate.y + 1) * GameMap.Instance.cellHeight) + (float) (GameMap.Instance.cellHeight / 2)) - this.pos;
      if ((double) vector2.LengthSquared() < 25.0)
      {
        if (!GameMap.Instance.mainMenuMode)
        {
          GameMap.Instance.player[0].LifeHit(this._targetGate, 1);
          GameMap.Instance.player[1].LifeHit(this._targetGate, 1);
        }
        this.SetState(Monster.MonsterState.ATTACKING, 1000f);
        ParticleField particleField = new ParticleField("Sprites/Particles/dustcloud", 8, 1);
        particleField.pos = new Vector2((float) ((this.x + 1) * GameMap.Instance.cellWidth), (float) (this.y * GameMap.Instance.cellWidth));
        particleField.radius = (float) GameMap.Instance.cellWidth;
        particleField.fieldLife = 2000f;
        GameMap.Instance.particleFields.Add((object) particleField);
      }
      else
      {
        vector2.Normalize();
        FruitBat fruitBat = this;
        fruitBat.pos = fruitBat.pos + vector2 * this.speed * this.freezeStrength * (float) gameTime.ElapsedGameTime.Milliseconds;
      }
    }

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch) => base.Draw(viewOffset, gameTime, spriteBatch);
  }
}
