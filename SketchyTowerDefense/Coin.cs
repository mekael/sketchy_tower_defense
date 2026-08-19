// Decompiled with JetBrains decompiler
// Type: TowerDefense.Coin
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class Coin : Item
  {
    public int value;
    public int coinCount;
    private static int count;
    private float fadeInTime;
    private float totalFadeInTime = 750f;
    private bool fadeDone;
    private float fadeOutTime;
    private float totalFadeOutTime = 750f;
    private bool fadingOut;
    public bool throwing;
    public Vector2 throwStartPos;
    public Vector2 throwDest;
    public PlayerEnum receiver = PlayerEnum.NONE;
    public float dropTimeOut;
    public bool split = true;
    private int altIndex;
    private float normalScale = 0.2f;
    private float throwingScale = 3.5f;
    private byte maxAlpha = 200;

    public Coin(Vector2 pos, int worth)
      : base("Sprites/Items/coin", 3, 1, pos)
    {
      this.animations.Add("spin", new int[4]{ 0, 1, 2, 1 });
      this.SetAnimation("spin");
      this.animSpeed = 100f;
      this.value = worth;
      this.coinCount = Coin.count++;
      this.color.A = (byte) 0;
      this.scale = 0.75f * this.normalScale;
      this.pos = pos;
      this.color = Color.Gold;
      this.color.A = this.maxAlpha;
    }

    public void Throw(Vector2 dest, PlayerEnum receiver)
    {
      this.throwStartPos = this.pos;
      this.throwDest = dest;
      this.throwing = true;
      this.receiver = receiver;
      this.dropTimeOut = 1000f;
      this.split = false;
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
        if ((double) this.scale * (double) this.normalScale >= 1.2400000095367432)
        {
          this.fadingOut = false;
          this.deleteItem = true;
        }
        this.fadeOutTime += (float) gameTime.ElapsedGameTime.Milliseconds;
        if ((double) this.fadeOutTime > (double) this.totalFadeOutTime)
          this.fadeOutTime = this.totalFadeOutTime;
      }
      if (this.throwing)
      {
        float num = 0.0f;
        if ((double) (this.throwDest - this.throwStartPos).Length() != 0.0)
          num = (this.throwDest - this.pos).Length() / (this.throwDest - this.throwStartPos).Length();
        if ((double) num > 0.5)
          this.scale = MathHelper.Lerp(1f, this.throwingScale, (float) ((0.5 - ((double) num - 0.5)) / 0.5)) * this.normalScale;
        else
          this.scale = MathHelper.Lerp(this.throwingScale, 1f, (float) ((0.5 - (double) num) / 0.5)) * this.normalScale;
        if (this.pos != this.throwDest)
        {
          Vector2 vector2_1 = this.throwDest - this.pos;
          vector2_1.Normalize();
          Vector2 vector2_2 = this.pos + vector2_1 * ((float) gameTime.ElapsedGameTime.Milliseconds / 2f);
          if ((double) (this.throwDest - this.pos).Length() < (double) (this.throwDest - vector2_2).Length())
            this.pos = this.throwDest;
          else
            this.pos = vector2_2;
        }
        else
          this.throwing = false;
      }
      else
      {
        if ((double) this.dropTimeOut > 0.0)
        {
          this.dropTimeOut -= (float) gameTime.ElapsedGameTime.Milliseconds;
        }
        else
        {
          this.receiver = PlayerEnum.NONE;
          this.dropTimeOut = 0.0f;
        }
        float num = 40f;
        if (GameMap.Instance.mainMenuMode || !Game.gameMap.player[0].Active && !Game.gameMap.player[1].Active || this.fadingOut || this.deleteItem)
          return;
        if (Game.gameMap.player[0].Active && Game.gameMap.player[1].Active && this.split)
        {
          if (((double) (Game.gameMap.player[0].pos - this.pos).Length() >= (double) num || this.receiver != PlayerEnum.NONE && this.receiver != PlayerEnum.P1) && ((double) (Game.gameMap.player[1].pos - this.pos).Length() >= (double) num || this.receiver != PlayerEnum.NONE && this.receiver != PlayerEnum.P2))
            return;
          if (this.coinCount % 2 == 0)
          {
            Game.gameMap.player[0].money += this.value / 2;
            Game.gameMap.player[1].money += this.value - this.value / 2;
          }
          else
          {
            Game.gameMap.player[0].money += this.value - this.value / 2;
            Game.gameMap.player[1].money += this.value / 2;
          }
          Game.soundBank.PlayCue("coin_pickup");
          this.fadingOut = true;
        }
        else
        {
          Player player = Game.gameMap.player[this.altIndex];
          ++this.altIndex;
          if (this.altIndex > 1)
            this.altIndex = 0;
          if (player == null || !player.Active || this.receiver != PlayerEnum.NONE && this.receiver != player.index || (double) (player.pos - this.pos).Length() >= (double) num)
            return;
          player.money += this.value;
          this.fadingOut = true;
          Game.soundBank.PlayCue("coin_pickup");
        }
      }
    }
  }
}
