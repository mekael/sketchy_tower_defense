// Decompiled with JetBrains decompiler
// Type: TowerDefense.Monster
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TowerDefense
{
  public class Monster : AnimatedSprite
  {
    public int x;
    public int y;
    public int level = 1;
    public bool boss;
    public float speed = 0.04f;
    public float monsterHealthScale = 0.2f;
    public float monsterGoldScale = 0.4f;
    public bool dead;
    public int moneyWorth;
    public float totalHealth = 100f;
    public float health = 100f;
    public Spawner spawner;
    public Tower _targetGate;
    public bool usedExistingPath;
    public Vector2 targetOffset;
    public Vector2 walkingOffset;
    public Texture2D nameTexture;
    public Texture2D healthFrameTexture;
    public Texture2D healthBarTexture;
    public bool drawHealth;
    private bool pendingHitShrink;
    protected bool dying;
    private Point nextCell = new Point(-1, -1);
    public float normalScale = 1f;
    public float freezeTime;
    public float freezeStrength = 1f;
    public float bossGlowOffset;
    public float bossGlow;
    public float timeSinceLastHit = 1000000f;
    public string deathSound;
    public bool badPath;
    public Monster.MonsterState state;
    public float stateChangeTime = 2000f;
    public float totalStateChangeTime = 2000f;
    public SpawnType type;
    protected float moneyMultiplier = 1f;
    protected float healthMultiplier = 1f;

    public Monster(
      string texture,
      int level,
      bool boss,
      SpawnType type,
      int cellColumns,
      int cellRows)
      : base(texture, cellColumns, cellRows)
    {
      this.type = type;
      Random random = new Random();
      this.targetOffset.X = random.Next(2) == 0 ? 0.0f : (float) GameMap.Instance.cellWidth;
      this.targetOffset.Y = random.Next(2) == 0 ? 0.0f : (float) GameMap.Instance.cellHeight;
      this.bossGlowOffset = (float) (random.NextDouble() * (2.0 * Math.PI));
      this.color.A = (byte) 0;
      this.walkingOffset = new Vector2((float) random.NextDouble() * (float) GameMap.Instance.cellWidth - (float) (GameMap.Instance.cellWidth / 2), (float) random.NextDouble() * (float) GameMap.Instance.cellHeight - (float) GameMap.Instance.cellHeight);
      this.SetState(Monster.MonsterState.SPAWNING, 2000f);
      switch (type)
      {
        case SpawnType.SPAWNTYPE_SNOTGOBLIN:
          this.nameTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_snotgoblin");
          break;
        case SpawnType.SPAWNTYPE_PIGSPIDER:
          this.nameTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_spiderpig");
          break;
        case SpawnType.SPAWNTYPE_FRUITBAT:
          this.nameTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_fruitbat");
          break;
        case SpawnType.SPAWNTYPE_STINKSLIME:
          this.nameTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_stinkslime");
          break;
        case SpawnType.SPAWNTYPE_SWARMWORM:
          this.nameTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_wormswarm");
          break;
        case SpawnType.SPAWNTYPE_BIGUN:
          this.nameTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_bigun");
          break;
      }
      this.healthFrameTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/Characters/health_frame");
      this.healthBarTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/Characters/health_bar");
      this.level = level;
      this.boss = boss;
      if (!this.boss)
        return;
      this.normalScale = 1.4f;
    }

    public Tower targetGate
    {
      get => this._targetGate;
      set => this._targetGate = value;
    }

    protected void CalcStats()
    {
      this.totalHealth = (float) ((double) (15 + 5 * (this.level + 1)) * (double) this.healthMultiplier * (((double) this.monsterHealthScale + 0.019999999552965164) * (double) (this.level + 1)));
      this.moneyWorth = (int) Math.Ceiling((double) (5 + this.level) * (double) this.moneyMultiplier * (double) this.monsterGoldScale);
      if ((double) this.totalHealth <= 0.0)
        this.totalHealth = 1f;
      if (this.moneyWorth <= 0)
        this.moneyWorth = 1;
      if (this.boss)
      {
        this.totalHealth *= 10f;
        this.moneyWorth *= 10;
      }
      this.health = this.totalHealth;
    }

    protected void SetState(Monster.MonsterState newState, float timeInState)
    {
      this.state = newState;
      this.totalStateChangeTime = timeInState;
      this.stateChangeTime = timeInState;
    }

    public virtual void Hit(float damage)
    {
      this.health -= damage;
      if ((double) this.health <= 0.0 && !this.dying && !this.dead)
      {
        this.health = 0.0f;
        this.StartDying();
        Random random = new Random();
        GameMap.Instance.AddItem((Item) new Coin(this.pos, this.moneyWorth), this.pos + (new Vector2(50f, 50f) * (float) random.NextDouble() - new Vector2(25f, 25f)));
        if (!this.boss && GameMap.Instance.PvP && !GameMap.Instance.mainMenuMode && random.NextDouble() <= 0.05)
          GameMap.Instance.AddItem((Item) new Cage(this.pos, this), this.pos);
      }
      else
        this.pendingHitShrink = true;
      if ((double) this.health <= 0.0)
        return;
      this.timeSinceLastHit = 0.0f;
    }

    public void SetFreeze(float duration, float strength)
    {
      this.freezeTime = duration;
      this.freezeStrength = strength;
    }

    public virtual void StartDying()
    {
      this.dying = true;
      if (!(this.deathSound != "") || this is StinkSlime)
        return;
      float num1 = 1f;
      float num2 = (float) (new Random().NextDouble() * 0.20000000298023224 - 0.10000000149011612);
      if (this.boss)
        num1 = num2 - 0.4f;
      Game.soundBank.PlayCue(this.deathSound);
    }

    public bool ResetNextCell()
    {
      Point point = this.spawner.exit.NextLeastCostCell(new Point(this.x, this.y));
      if (point.X == -1)
        return false;
      this.nextCell = point;
      this.UpdateCellPosition(this.nextCell.X, this.nextCell.Y);
      this.x = this.nextCell.X;
      this.y = this.nextCell.Y;
      return true;
    }

    public void UpdateCellPosition(int newX, int newY)
    {
      this.x = newX;
      this.y = newY;
    }

    public void Revive()
    {
      this.health = this.totalHealth;
      this.dying = false;
      this.dead = false;
      this.color.A = byte.MaxValue;
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      this.timeSinceLastHit += (float) gameTime.ElapsedGameTime.Milliseconds;
      if (this.dying && !this.dead)
      {
        this.scale = MathHelper.Lerp(this.scale, 1.5f * this.normalScale, (float) gameTime.ElapsedGameTime.Milliseconds / 100f);
        this.color.A = (byte) MathHelper.Lerp((float) this.color.A, 0.0f, (float) gameTime.ElapsedGameTime.Milliseconds / 100f);
        if ((double) this.scale < 1.4500000476837158 * (double) this.normalScale)
          return;
        this.dead = true;
      }
      else
      {
        if (this.dead)
          return;
        if (!GameMap.Instance.mainMenuMode)
        {
          if ((double) (this.pos - GameMap.Instance.player[0].pos).LengthSquared() < 1000.0)
            GameMap.Instance.player[0].hoverMonster = this;
          if ((double) (this.pos - GameMap.Instance.player[1].pos).LengthSquared() < 1000.0)
            GameMap.Instance.player[1].hoverMonster = this;
        }
        if ((double) this.freezeTime > 0.0)
          this.freezeTime -= (float) gameTime.ElapsedGameTime.Milliseconds;
        if ((double) this.freezeTime < 0.0)
        {
          this.freezeStrength = 1f;
          this.freezeTime = 0.0f;
        }
        if (this.pendingHitShrink)
        {
          this.scale = MathHelper.Lerp(this.scale, 0.75f * this.normalScale, (float) gameTime.ElapsedGameTime.Milliseconds / 50f);
          if ((double) this.scale < 0.75999999046325684 * (double) this.normalScale)
            this.pendingHitShrink = false;
        }
        else
          this.scale = MathHelper.Lerp(this.scale, 1f * this.normalScale, 0.1f);
        if (this.state == Monster.MonsterState.WALKING || this.state == Monster.MonsterState.SPAWNING)
        {
          if (this.nextCell.X == -1)
            this.ResetNextCell();
          this.FollowPath(gameTime);
        }
        if (this.state == Monster.MonsterState.SPAWNING)
        {
          this.stateChangeTime -= (float) gameTime.ElapsedGameTime.Milliseconds;
          if ((double) this.stateChangeTime <= 0.0)
          {
            this.SetState(Monster.MonsterState.WALKING, 2000f);
            this.color.A = byte.MaxValue;
          }
          else
            this.color.A = (byte) (((double) this.totalStateChangeTime - (double) this.stateChangeTime) / (double) this.totalStateChangeTime * (double) byte.MaxValue);
        }
        if (this.state == Monster.MonsterState.ATTACKING)
        {
          this.stateChangeTime -= (float) gameTime.ElapsedGameTime.Milliseconds;
          if ((double) this.stateChangeTime <= 0.0)
            this.dead = true;
          else
            this.color.A = (byte) ((double) this.stateChangeTime / (double) this.totalStateChangeTime * (double) byte.MaxValue);
        }
        if (!GameMap.Instance.mainMenuMode && GameMap.Instance.showHealthAll)
          this.drawHealth = true;
        else
          this.drawHealth = false;
      }
    }

    public virtual void FollowPath(GameTime gameTime)
    {
      if (this.nextCell.X == -1)
        return;
      Vector2 pos = this.pos;
      Vector2 vector2_1 = new Vector2((float) (this.nextCell.X * GameMap.Instance.cellWidth) + (float) (GameMap.Instance.cellWidth / 2), (float) (this.nextCell.Y * GameMap.Instance.cellHeight) + (float) (GameMap.Instance.cellHeight / 2));
      Vector2 vector2_2 = vector2_1 - this.pos;
      vector2_2.Normalize();
      Monster monster = this;
      monster.pos = monster.pos + vector2_2 * this.speed * this.freezeStrength * (float) gameTime.ElapsedGameTime.Milliseconds;
      if ((int) ((double) this.pos.X / (double) GameMap.Instance.cellWidth) != this.nextCell.X && (int) ((double) this.pos.X / (double) GameMap.Instance.cellWidth) != this.nextCell.X + 1 || (int) ((double) this.pos.Y / (double) GameMap.Instance.cellHeight) != this.nextCell.Y && (int) ((double) this.pos.Y / (double) GameMap.Instance.cellHeight) != this.nextCell.Y + 1)
        return;
      if (this.spawner.exit.pathGrid[this.nextCell.X, this.nextCell.Y] == 0)
      {
        if ((double) (vector2_1 - this.pos).LengthSquared() >= 25.0)
          return;
        this.nextCell = new Point(-1, -1);
        if (!GameMap.Instance.mainMenuMode)
        {
          if (this._targetGate.ownerPlayerIndex == PlayerEnum.NONE)
          {
            GameMap.Instance.player[0].LifeHit(this._targetGate, 1);
            GameMap.Instance.player[1].LifeHit(this._targetGate, 1);
          }
          else if (this._targetGate.ownerPlayerIndex == PlayerEnum.P1)
            GameMap.Instance.player[0].LifeHit(this._targetGate, 1);
          if (this._targetGate.ownerPlayerIndex == PlayerEnum.P2)
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
        this.ResetNextCell();
    }

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      float scale = this.scale;
      Color color = this.color;
      if ((double) this.freezeTime > 0.0)
      {
        this.scale = scale * 1.25f;
        this.color = Color.CadetBlue;
        base.Draw(viewOffset + this.walkingOffset, gameTime, spriteBatch);
      }
      if (this.boss)
      {
        this.scale = scale * 0.75f;
        this.color = Color.Red;
        this.bossGlow += (float) gameTime.TotalGameTime.Milliseconds / 5000f;
        this.color.A = (byte) (Math.Cos((double) this.bossGlow + (double) this.bossGlowOffset) * 32.0 + 32.0 + 32.0);
        base.Draw(viewOffset + this.walkingOffset, gameTime, spriteBatch);
      }
      this.scale = scale;
      this.color = color;
      if (this.badPath)
        this.color = Color.Red;
      base.Draw(viewOffset + this.walkingOffset, gameTime, spriteBatch);
      if (!this.drawHealth && (double) this.timeSinceLastHit >= 3000.0)
        return;
      byte a = byte.MaxValue;
      if (!this.drawHealth)
      {
        float num = this.timeSinceLastHit - 2500f;
        if ((double) num > 0.0)
          a = (byte) ((double) byte.MaxValue * (500.0 - (double) num) / 500.0);
      }
      int width = (int) ((double) this.healthBarTexture.Width * ((double) this.health / (double) this.totalHealth));
      Vector2 vector2 = viewOffset + this.pos + this.walkingOffset + new Vector2((float) (-this.healthBarTexture.Width / 2), (float) (this.texture.Height / 2 + 2));
      Rectangle rectangle1 = new Rectangle((int) vector2.X, (int) vector2.Y, width, this.healthBarTexture.Height);
      Rectangle rectangle2 = new Rectangle(0, 0, width, this.healthBarTexture.Height);
      spriteBatch.Draw(this.healthBarTexture, rectangle1, new Rectangle?(rectangle2), new Color(byte.MaxValue, (byte) 0, (byte) 0, a));
      spriteBatch.Draw(this.healthFrameTexture, viewOffset + this.pos + this.walkingOffset + new Vector2((float) (-this.healthFrameTexture.Width / 2), (float) (this.texture.Height / 2)), new Color((byte) 0, (byte) 0, (byte) 0, a));
    }

    public void DrawCaged(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      float scale = this.scale;
      Color color = this.color;
      this.color.A = byte.MaxValue;
      this.scale = this.normalScale * 0.75f;
      base.Draw(viewOffset, gameTime, spriteBatch);
      this.scale = scale;
      this.color = color;
    }

    public enum MonsterState
    {
      SPAWNING,
      WALKING,
      DYING,
      ATTACKING,
    }
  }
}
