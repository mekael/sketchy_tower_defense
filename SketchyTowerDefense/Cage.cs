// Decompiled with JetBrains decompiler
// Type: TowerDefense.Cage
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TowerDefense
{
  public class Cage : Item
  {
    private float fadeInTime;
    private float totalFadeInTime = 750f;
    private bool fadeDone;
    private float fadeOutTime;
    private float totalFadeOutTime = 750f;
    private bool fadingOut;
    public bool throwing;
    public Vector2 throwStartPos;
    public Vector2 throwDest;
    private float normalScale = 0.2f;
    private float throwingScale = 3.5f;
    private byte maxAlpha = 200;
    private Monster monster;

    public Cage(Vector2 pos, Monster cagedMonster)
      : base("Sprites/Items/cage", 1, 1, pos)
    {
      this.color.A = (byte) 0;
      this.scale = 0.75f * this.normalScale;
      this.pos = pos;
      this.color = new Color((byte) 75, (byte) 65, (byte) 45);
      this.color.A = this.maxAlpha;
      this.monster = cagedMonster;
      this.normalScale = (float) this.monster.texture.Height * this.monster.normalScale / (float) this.texture.Height;
      this.normalScale *= 1f;
      Random random = new Random();
      Exit exit = this.monster._targetGate.ownerPlayerIndex != PlayerEnum.P1 ? GameMap.Instance.GetExitTower(PlayerEnum.P1, random.Next(0, 100)) : GameMap.Instance.GetExitTower(PlayerEnum.P2, random.Next(0, 100));
      this.monster._targetGate = (Tower) exit;
      this.monster.spawner = exit.spawner;
      this.monster.UpdateCellPosition(this.monster.spawner.x, this.monster.spawner.y);
      this.monster.ResetNextCell();
      this.throwStartPos = pos;
      this.throwDest = exit.spawner.pos;
    }

    public void Throw() => this.throwing = true;

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      Vector2 pos = this.monster.pos;
      float normalScale = this.monster.normalScale;
      if (!this.fadingOut)
      {
        this.monster.pos = this.pos;
        this.monster.DrawCaged(viewOffset, gameTime, spriteBatch);
        this.monster.pos = pos;
        this.monster.normalScale = normalScale;
      }
      base.Draw(viewOffset, gameTime, spriteBatch);
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (!this.fadeDone)
      {
        this.color.A = (byte) MathHelper.Lerp((float) this.color.A, (float) this.maxAlpha, this.fadeInTime / this.totalFadeInTime);
        if (!this.throwing)
        {
          if ((double) this.fadeInTime < (double) this.totalFadeInTime / 2.0)
            this.scale = MathHelper.Lerp(0.75f, 1.5f, this.fadeInTime / (this.totalFadeInTime / 2f)) * this.normalScale;
          else
            this.scale = MathHelper.Lerp(1.5f, 1f, (float) (((double) this.fadeInTime - (double) this.totalFadeInTime / 2.0) / ((double) this.totalFadeInTime / 2.0))) * this.normalScale;
        }
        this.fadeInTime += (float) gameTime.ElapsedGameTime.Milliseconds;
        if ((double) this.fadeInTime > (double) this.totalFadeInTime)
        {
          this.fadeInTime = this.totalFadeInTime;
          this.fadeDone = true;
        }
      }
      if (this.fadingOut && !this.deleteItem)
      {
        this.color.A = (byte) MathHelper.Lerp((float) this.color.A, 0.0f, this.fadeOutTime / this.totalFadeOutTime);
        this.scale = MathHelper.Lerp(1f, 1.25f, this.fadeOutTime / this.totalFadeInTime) * this.normalScale;
        this.fadeOutTime += (float) gameTime.ElapsedGameTime.Milliseconds;
        if ((double) this.fadeOutTime > (double) this.totalFadeOutTime)
        {
          this.fadeOutTime = this.totalFadeOutTime;
          this.fadingOut = false;
          this.deleteItem = true;
          this.monster.pos = this.pos;
          this.monster.UpdateCellPosition(this.monster.spawner.x, this.monster.spawner.y);
          this.monster.ResetNextCell();
        }
      }
      if (this.throwing)
      {
        float num = 0.0f;
        if ((double) (this.throwDest - this.throwStartPos).LengthSquared() != 0.0)
          num = (this.throwDest - this.pos).LengthSquared() / (this.throwDest - this.throwStartPos).LengthSquared();
        if ((double) num > 0.5)
          this.scale = MathHelper.Lerp(1f, this.throwingScale, (float) ((0.5 - ((double) num - 0.5)) / 0.5)) * this.normalScale;
        else
          this.scale = MathHelper.Lerp(this.throwingScale, 1f, (float) ((0.5 - (double) num) / 0.5)) * this.normalScale;
        if (this.pos != this.throwDest)
        {
          Vector2 vector2_1 = this.throwDest - this.pos;
          vector2_1.Normalize();
          Vector2 vector2_2 = this.pos + vector2_1 * ((float) gameTime.ElapsedGameTime.Milliseconds / 2f);
          if ((double) (this.throwDest - this.pos).LengthSquared() < (double) (this.throwDest - vector2_2).LengthSquared())
            this.pos = this.throwDest;
          else
            this.pos = vector2_2;
        }
        else
        {
          this.fadingOut = true;
          this.monster.Revive();
          GameMap.Instance.AddMonster(this.monster, this.pos);
          this.throwing = false;
        }
      }
      else
      {
        float num1 = 40f;
        float num2 = num1 * num1;
        if (GameMap.Instance.mainMenuMode || this.fadingOut || this.deleteItem || ((double) (Game.gameMap.player[0].pos - this.pos).LengthSquared() >= (double) num2 || this.monster._targetGate.ownerPlayerIndex == PlayerEnum.P1) && ((double) (Game.gameMap.player[1].pos - this.pos).LengthSquared() >= (double) num2 || this.monster._targetGate.ownerPlayerIndex == PlayerEnum.P2))
          return;
        this.Throw();
      }
    }
  }
}
