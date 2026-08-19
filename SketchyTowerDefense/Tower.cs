// Decompiled with JetBrains decompiler
// Type: TowerDefense.Tower
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;

namespace TowerDefense
{
  public class Tower : AnimatedSprite
  {
    public TowerType type;
    public int level;
    public int maxLevel;
    public int x;
    public int y;
    public bool guiOnly;
    public bool dead;
    protected int[] upgradeCostLookup = new int[1];
    protected int[] rangeLookup = new int[1];
    private float rangeOffset;
    public float rangeTimeLeft;
    public float rangeTimeTotal = 250f;
    public PlayerEnum ownerPlayerIndex = PlayerEnum.NONE;
    public Tower.TowerState state = Tower.TowerState.IDLE;
    public float stateChangeTime = 2000f;
    public float totalStateChangeTime = 2000f;
    public bool newTower;
    private byte buildProgressBarFade;
    public int towerId;

    public Tower(string texture, int cellColumns, int cellRows)
      : base(texture, cellColumns, cellRows)
    {
      this.SetState(Tower.TowerState.IDLE, 0.0f);
      this.level = 0;
      this.newTower = true;
    }

    public void SetState(Tower.TowerState newState, float timeInState)
    {
      if (this.state == newState)
        return;
      this.state = newState;
      this.totalStateChangeTime = timeInState;
      this.stateChangeTime = timeInState;
      if (this.state != Tower.TowerState.BUILDING && this.state != Tower.TowerState.UPGRADING && this.state != Tower.TowerState.SELLING)
        return;
      ParticleField particleField = new ParticleField("Sprites/Particles/dustcloud", 8, 1);
      particleField.pos = this.pos;
      particleField.radius = (float) (GameMap.Instance.cellWidth / 2);
      particleField.fieldLife = timeInState;
      GameMap.Instance.particleFields.Add((object) particleField);
    }

    public virtual bool GuiOnly
    {
      set => this.guiOnly = this.GuiOnly;
      get => this.guiOnly;
    }

    public virtual bool Passable => true;

    public virtual void DrawRangeCircle(
      Vector2 viewOffset,
      GameTime gameTime,
      SpriteBatch spriteBatch,
      Color rangeColor)
    {
      if (this.guiOnly || !(this is BasicAttackTower))
        return;
      if (this.id % 2 == 0)
        this.rangeOffset += (float) gameTime.ElapsedGameTime.Milliseconds / 20000f;
      else
        this.rangeOffset -= (float) gameTime.ElapsedGameTime.Milliseconds / 20000f;
      Vector2 vector2_1 = new Vector2((float) (GameMap.Instance.rangeDotTexture.Width / 2), (float) (GameMap.Instance.rangeDotTexture.Height / 2));
      Vector2 vector2_2 = new Vector2(this.pos.X, this.pos.Y) + viewOffset;
      float num1 = this.Range(this.level, true) / 10f * (float) GameMap.Instance.cellWidth;
      int num2 = (int) ((double) num1 * 0.5);
      for (int index = 0; index < num2; ++index)
      {
        float num3 = (float) ((double) index / (double) (num2 - 1) * (2.0 * Math.PI)) + this.rangeOffset;
        Vector2 vector2_3 = new Vector2((float) Math.Sin((double) num3) * num1, (float) Math.Cos((double) num3) * num1);
        spriteBatch.Draw(GameMap.Instance.rangeDotTexture, vector2_2 + vector2_3 - vector2_1, rangeColor);
      }
    }

    public virtual void DrawRangeSquare(
      Vector2 viewOffset,
      GameTime gameTime,
      SpriteBatch spriteBatch,
      Color rangeColor)
    {
      if (this.guiOnly || !(this is BasicAttackTower))
        return;
      bool flag = false;
      if (this.id % 2 == 0)
      {
        flag = true;
        this.rangeOffset += (float) gameTime.ElapsedGameTime.Milliseconds / 200f;
      }
      else
        this.rangeOffset -= (float) gameTime.ElapsedGameTime.Milliseconds / 200f;
      Vector2 vector2_1 = new Vector2((float) (GameMap.Instance.rangeDotTexture.Width / 2), (float) (GameMap.Instance.rangeDotTexture.Height / 2));
      Vector2 vector2_2 = new Vector2(this.pos.X, this.pos.Y) + viewOffset;
      float num1 = this.Range(this.level, true) / 10f * (float) GameMap.Instance.cellWidth;
      int num2 = (int) ((double) num1 * 0.75) / 4;
      float num3 = num1 * 2f / (float) num2;
      if ((double) this.rangeOffset > (double) num3 || (double) this.rangeOffset < -(double) num3)
        this.rangeOffset = 0.0f;
      Vector2 vector2_3 = new Vector2(0.0f, 0.0f);
      for (int index = 0; index < num2; ++index)
      {
        vector2_3.Y = -num1;
        vector2_3.X = (float) (-(double) num1 + (double) num3 * (double) index + (double) this.rangeOffset + (flag ? 0.0 : (double) num3));
        spriteBatch.Draw(GameMap.Instance.rangeDotTexture, vector2_2 + vector2_3 - vector2_1, rangeColor);
      }
      for (int index = 0; index < num2; ++index)
      {
        vector2_3.X = -num1;
        vector2_3.Y = (float) (-(double) num1 + (double) num3 * (double) index - (double) this.rangeOffset + (flag ? (double) num3 : 0.0));
        spriteBatch.Draw(GameMap.Instance.rangeDotTexture, vector2_2 + vector2_3 - vector2_1, rangeColor);
      }
      for (int index = 0; index < num2; ++index)
      {
        vector2_3.X = num1;
        vector2_3.Y = (float) (-(double) num1 + (double) num3 * (double) index + (double) this.rangeOffset + (flag ? 0.0 : (double) num3));
        spriteBatch.Draw(GameMap.Instance.rangeDotTexture, vector2_2 + vector2_3 - vector2_1, rangeColor);
      }
      for (int index = 0; index < num2; ++index)
      {
        vector2_3.Y = num1;
        vector2_3.X = (float) (-(double) num1 + (double) num3 * (double) index - (double) this.rangeOffset + (flag ? (double) num3 : 0.0));
        spriteBatch.Draw(GameMap.Instance.rangeDotTexture, vector2_2 + vector2_3 - vector2_1, rangeColor);
      }
    }

    public void ResetRangeTime() => this.rangeTimeLeft = this.rangeTimeTotal;

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (this.newTower)
        return;
      base.Draw(viewOffset, gameTime, spriteBatch);
      if ((double) this.rangeTimeLeft <= 0.0)
        return;
      Color rangeColor = new Color(Color.DarkOrange.R, Color.DarkOrange.G, Color.DarkOrange.B, (byte) ((double) byte.MaxValue * (double) this.rangeTimeLeft / (double) this.rangeTimeTotal));
      switch (this)
      {
        case DmgBoostTower _:
        case RngBoostTower _:
          this.DrawRangeSquare(viewOffset, gameTime, spriteBatch, rangeColor);
          break;
        case PitTower _:
          break;
        default:
          this.DrawRangeCircle(viewOffset, gameTime, spriteBatch, rangeColor);
          break;
      }
    }

    public override void Update(GameTime gameTime)
    {
      this.newTower = false;
      if ((double) this.rangeTimeLeft > 0.0)
      {
        this.rangeTimeLeft -= (float) gameTime.ElapsedGameTime.Milliseconds;
        if ((double) this.rangeTimeLeft < 0.0)
          this.rangeTimeLeft = 0.0f;
      }
      if (GameMap.Instance.gameSpeed == GameSpeed.PREPARE)
        this.stateChangeTime -= (float) gameTime.ElapsedGameTime.Milliseconds * 10f;
      else
        this.stateChangeTime -= (float) gameTime.ElapsedGameTime.Milliseconds;
      if ((double) this.stateChangeTime < 0.0)
        this.stateChangeTime = 0.0f;
      if (this.state == Tower.TowerState.UPGRADING)
      {
        byte num1 = 128;
        float num2 = 500f;
        if ((double) this.stateChangeTime > (double) this.totalStateChangeTime - (double) num2)
          this.color.A = (byte) MathHelper.Lerp((float) byte.MaxValue, (float) num1, (this.totalStateChangeTime - this.stateChangeTime) / num2);
        else if ((double) this.stateChangeTime < (double) num2)
          this.color.A = (byte) MathHelper.Lerp((float) num1, (float) byte.MaxValue, (num2 - this.stateChangeTime) / num2);
        else
          this.color.A = (byte) 128;
      }
      else if (this.state == Tower.TowerState.BUILDING)
        this.color.A = (byte) MathHelper.Lerp(0.0f, (float) byte.MaxValue, (this.totalStateChangeTime - this.stateChangeTime) / this.totalStateChangeTime);
      else if (this.state == Tower.TowerState.SELLING)
        this.color.A = (byte) MathHelper.Lerp((float) byte.MaxValue, 0.0f, (this.totalStateChangeTime - this.stateChangeTime) / this.totalStateChangeTime);
      else
        this.color.A = byte.MaxValue;
      if (this.state == Tower.TowerState.BUILDING || this.state == Tower.TowerState.UPGRADING)
      {
        if ((double) this.stateChangeTime <= 0.0)
          this.SetState(Tower.TowerState.IDLE, 0.0f);
      }
      else if (this.state == Tower.TowerState.SELLING && (double) this.stateChangeTime <= 0.0)
        this.dead = true;
      base.Update(gameTime);
    }

    public virtual int Size => 1;

    public static string Name() => "Base Tower";

    public virtual int UpgradeCost(int i) => i >= 0 && i < this.upgradeCostLookup.Length ? this.upgradeCostLookup[i] : 0;

    public virtual int SellValue()
    {
      int num = 0;
      for (int index = 0; index <= this.level; ++index)
        num += this.upgradeCostLookup[index];
      return num / 3;
    }

    public virtual float Range(int i, bool boosted)
    {
      if (i < 0 || i >= this.rangeLookup.Length)
        return 0.0f;
      if (boosted)
      {
        switch (this)
        {
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
            float num = (float) this.rangeLookup[i];
            float d = num;
            for (int index = 0; index < pointArray.Length; ++index)
            {
              Tower towerAt = GameMap.Instance.GetTowerAt(this.x + pointArray[index].X, this.y + pointArray[index].Y);
              if (towerAt != null && towerAt is RngBoostTower)
              {
                bool flag = false;
                RngBoostTower rngBoostTower1 = (RngBoostTower) towerAt;
                foreach (RngBoostTower rngBoostTower2 in arrayList)
                {
                  if (rngBoostTower2 == rngBoostTower1)
                  {
                    flag = true;
                    break;
                  }
                }
                if (!flag)
                {
                  d += num * (rngBoostTower1.Boost(rngBoostTower1.level) - 1f);
                  arrayList.Add((object) rngBoostTower1);
                }
              }
            }
            return (float) Math.Floor((double) d);
        }
      }
      return (float) this.rangeLookup[i];
    }

    public virtual bool Upgrade()
    {
      if (this.level >= this.maxLevel || this.state != Tower.TowerState.IDLE)
        return false;
      ++this.level;
      if (GameMap.Instance.gameSpeed == GameSpeed.PREPARE)
        this.SetState(Tower.TowerState.UPGRADING, 1000f);
      else
        this.SetState(Tower.TowerState.UPGRADING, (float) (1000.0 * (double) this.level * (double) this.level * 2.0 + 2000.0));
      return true;
    }

    public virtual void Sell()
    {
      if (this.type == TowerType.SPAWNER || this.type == TowerType.EXIT || this.dead || this.level < 0 || this.state != Tower.TowerState.IDLE)
        return;
      GameMap.Instance.player[Util.PlayerEnumToIndex(this.ownerPlayerIndex)].money += this.SellValue();
      this.SetState(Tower.TowerState.SELLING, 3000f);
    }

    public virtual void SetOwner(PlayerEnum index)
    {
      this.ownerPlayerIndex = index;
      if (index == PlayerEnum.P1)
      {
        this.color = GameMap.Instance.game.playerOneColor;
      }
      else
      {
        if (index != PlayerEnum.P2)
          return;
        this.color = GameMap.Instance.game.playerTwoColor;
      }
    }

    public virtual void DrawLevel(
      Vector2 viewOffset,
      GameTime gameTime,
      SpriteBatch spriteBatch,
      int levelOffset)
    {
      if (GameMap.Instance.mainMenuMode || this.guiOnly)
        return;
      Color color = Color.Black;
      int num1 = 0;
      int num2 = this.level + levelOffset;
      float x = 20f;
      if (num2 >= 2)
        num1 = 2;
      if (num2 >= 4)
        num1 = 4;
      if (num2 == 0 || num2 == 2 || num2 == 4)
        x = 10f;
      for (int index = num1; index <= num2; ++index)
      {
        switch (index)
        {
          case 0:
            color = new Color((byte) 150, (byte) 150, (byte) 150, this.color.A);
            break;
          case 1:
            color = new Color((byte) 200, (byte) 200, (byte) 200, this.color.A);
            break;
          case 2:
            color = new Color((byte) 0, (byte) 159, (byte) 0, this.color.A);
            break;
          case 3:
            color = new Color((byte) 0, (byte) 200, (byte) 0, this.color.A);
            break;
          case 4:
            color = new Color((byte) 250, (byte) 0, (byte) 250, this.color.A);
            break;
        }
        spriteBatch.Draw(GameMap.Instance.towerLevelTexture, viewOffset - new Vector2(x, -10f) + new Vector2((float) (index - num1) * 20f, 0.0f), color);
      }
    }

    public virtual void DrawBuildProgressBar(
      Vector2 viewOffset,
      GameTime gameTime,
      SpriteBatch spriteBatch)
    {
      if (this.state == Tower.TowerState.IDLE && this.buildProgressBarFade == (byte) 0)
        return;
      Color darkRed = Color.DarkRed;
      Color black = Color.Black;
      darkRed.A = this.buildProgressBarFade;
      black.A = this.buildProgressBarFade;
      spriteBatch.Draw(GameMap.Instance.progressBarBackTexture, this.pos + viewOffset - new Vector2(23f, 10f), new Rectangle?(new Rectangle(0, 0, (int) ((double) GameMap.Instance.progressBarBackTexture.Width * (((double) this.totalStateChangeTime - (double) this.stateChangeTime) / (double) this.totalStateChangeTime)), GameMap.Instance.progressBarBackTexture.Height)), darkRed);
      spriteBatch.Draw(GameMap.Instance.progressBarOutlineTexture, this.pos + viewOffset - new Vector2(23f, 10f), black);
      if (this.state == Tower.TowerState.IDLE)
        this.buildProgressBarFade = (byte) MathHelper.Lerp((float) this.buildProgressBarFade, 0.0f, 0.1f);
      else
        this.buildProgressBarFade = (byte) MathHelper.Lerp((float) this.buildProgressBarFade, (float) byte.MaxValue, 0.1f);
    }

    public virtual void SetPosition(int x, int y)
    {
      this.x = x;
      this.y = y;
      this.pos = new Vector2((float) (x * GameMap.Instance.cellWidth), (float) (y * GameMap.Instance.cellHeight));
    }

    public enum TowerState
    {
      BUILDING,
      IDLE,
      SELLING,
      UPGRADING,
    }
  }
}
