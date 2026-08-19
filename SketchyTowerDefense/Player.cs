// Decompiled with JetBrains decompiler
// Type: TowerDefense.Player
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense
{
  public class Player : AnimatedSprite
  {
    public int money;
    public int life;
    public int x;
    public int y;
    private bool active;
    public PlayerEnum index = PlayerEnum.NONE;
    public bool showLegalCells;
    public float fade;
    public float maxFade = 0.9f;
    public Monster hoverMonster;
    private GamePadButtons oldGamepadButtons = new GamePadButtons();

    public Player()
      : base("Sprites/Characters/player", 1, 1)
    {
      this.scale = 1f;
      this.color = new Color(255,255,255, this.fade);
      this.money = 0;
      this.life = 10;
    }

    public bool Active
    {
      get => this.active;
      set
      {
        if (!this.active && value)
        {
          Exit exitTower = GameMap.Instance.GetExitTower(this.index, (int) this.index);
          if (exitTower != null)
            this.pos = exitTower.pos;
          if (GameMap.Instance.gameSpeed == GameSpeed.PREPARE && !GameMap.Instance.PvP)
          {
            if (this.index == PlayerEnum.P1)
            {
              if (GameMap.Instance.player[1].active)
              {
                int num = GameMap.Instance.player[1].money / 2;
                GameMap.Instance.player[1].money -= num;
                GameMap.Instance.player[0].money = num;
              }
            }
            else if (this.index == PlayerEnum.P2 && GameMap.Instance.player[0].active)
            {
              int num = GameMap.Instance.player[0].money / 2;
              GameMap.Instance.player[0].money -= num;
              GameMap.Instance.player[1].money = num;
            }
          }
        }
        else if (this.active && !value && !GameMap.Instance.PvP && this.money > 0)
        {
          Coin coin = new Coin(this.pos, this.money);
          coin.Throw(this.pos, PlayerEnum.NONE);
          this.money = 0;
          GameMap.Instance.AddItem((Item) coin, coin.pos);
        }
        this.active = value;
      }
    }

    public override void Update(GameTime gameTime)
    {
      if (this.index == PlayerEnum.P1)
        this.color = GameMap.Instance.game.playerOneColor;
      else
        this.color = GameMap.Instance.game.playerTwoColor;
      this.color.A = (byte) 196;
      base.Update(gameTime);
      this.x = (int) (((double) this.pos.X - (double) (Game.gameMap.cellWidth / 2)) / (double) Game.gameMap.cellWidth);
      this.y = (int) (((double) this.pos.Y - (double) (Game.gameMap.cellHeight / 2)) / (double) Game.gameMap.cellHeight);
      if (this.active)
      {
        this.fade += (float) gameTime.ElapsedGameTime.Milliseconds / 2000f;
        if ((double) this.fade > (double) this.maxFade)
          this.fade = this.maxFade;
      }
      else
      {
        this.fade -= (float) gameTime.ElapsedGameTime.Milliseconds / 2000f;
        if ((double) this.fade < 0.0)
          this.fade = 0.0f;
      }
      this.color.A = (byte) ((double) this.fade * (double) byte.MaxValue);
      if (GameMap.Instance.gameState != GameState.PLAYING || GameMap.Instance.WaitingOnPlayer(PlayerEnum.P1) || GameMap.Instance.WaitingOnPlayer(PlayerEnum.P2))
        return;
      this.CheckInput(gameTime);
      if (!this.active)
        return;
      GameMap.Instance.GetTowerAt(this.x, this.y)?.ResetRangeTime();
    }

    public void CheckInput(GameTime gameTime)
    {
      Vector2 pos = this.pos;
      this.pos.X += Controls.ThumbSticks(this.index).Left.X * 5f;
      this.pos.Y -= Controls.ThumbSticks(this.index).Left.Y * 5f;
      Vector2 vector2 = Game.gameMap.CorrectCharacterPosition(this.pos, pos, CollisionType.BOUNDARIES);
      if ((double) vector2.X > -1000.0)
        this.pos = vector2;
      if (GameMap.Instance.PvP)
      {
        if (GameMap.Instance.horizontalDivide)
        {
          if (this.index == PlayerEnum.P1)
          {
            if ((double) this.pos.Y > (double) GameMap.Instance.cellHeight * 16.0)
              this.pos.Y = (float) GameMap.Instance.cellHeight * 16f;
          }
          else if (this.index == PlayerEnum.P2 && (double) this.pos.Y < (double) GameMap.Instance.cellHeight * 17.0)
            this.pos.Y = (float) GameMap.Instance.cellHeight * 17f;
        }
        else if (this.index == PlayerEnum.P1)
        {
          if ((double) this.pos.X > (double) GameMap.Instance.cellWidth * 21.0)
            this.pos.X = (float) GameMap.Instance.cellWidth * 21f;
        }
        else if (this.index == PlayerEnum.P2 && (double) this.pos.X < (double) GameMap.Instance.cellWidth * 23.0)
          this.pos.X = (float) GameMap.Instance.cellWidth * 23f;
      }
      this.showLegalCells = Controls.Button(this.index).A == ButtonState.Pressed;
      Tower towerAt = GameMap.Instance.GetTowerAt(this.x, this.y);
      if (Controls.Button(this.index).A == ButtonState.Released && this.oldGamepadButtons.A == ButtonState.Pressed)
      {
        if (towerAt is BasicAttackTower && towerAt.ownerPlayerIndex == this.index)
        {
          if (towerAt.level < towerAt.maxLevel && this.money >= towerAt.UpgradeCost(towerAt.level + 1))
          {
            if (towerAt.Upgrade())
            {
              this.money -= towerAt.UpgradeCost(towerAt.level);
              Game.soundBank.PlayCue("construction");
            }
          }
          else
            Game.soundBank.PlayCue("buzz");
        }
        else if (towerAt != null)
          Game.soundBank.PlayCue("buzz");
        else
          this.PlaceTower();
      }
      if (Controls.Button(this.index).X == ButtonState.Released && this.oldGamepadButtons.X == ButtonState.Pressed && towerAt != null && towerAt.ownerPlayerIndex == this.index)
      {
        towerAt.Sell();
        Game.soundBank.PlayCue("construction");
      }
      if (Controls.Button(this.index).Y == ButtonState.Released && this.oldGamepadButtons.Y == ButtonState.Pressed && !GameMap.Instance.PvP)
      {
        Player player = (Player) null;
        if (this.index == PlayerEnum.P1 && GameMap.Instance.player[Util.PlayerEnumToIndex(PlayerEnum.P2)].active)
          player = GameMap.Instance.player[Util.PlayerEnumToIndex(PlayerEnum.P2)];
        if (this.index == PlayerEnum.P2 && GameMap.Instance.player[Util.PlayerEnumToIndex(PlayerEnum.P1)].active)
          player = GameMap.Instance.player[Util.PlayerEnumToIndex(PlayerEnum.P1)];
        if (player != null)
        {
          int worth = (int) ((double) this.money * 0.05000000074505806);
          if (worth < 5)
            worth = 5;
          if (worth > this.money)
            worth = this.money;
          if (worth > 0)
          {
            Coin coin = new Coin(this.pos, worth);
            coin.Throw(player.pos, player.index);
            this.money -= worth;
            GameMap.Instance.AddItem((Item) coin, coin.pos);
          }
        }
      }
      this.oldGamepadButtons = Controls.Button(this.index);
    }

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      base.Draw(viewOffset, gameTime, spriteBatch);
      if (!this.showLegalCells)
        return;
      Point[] pointArray = new Point[4]
      {
        new Point(0, 0),
        new Point(1, 0),
        new Point(0, 1),
        new Point(1, 1)
      };
      for (int index = 0; index < 4; ++index)
      {
        Color black = Color.Black;
        Color color = (!GameMap.Instance.SpaceForTower(1, this.x + pointArray[index].X, this.y + pointArray[index].Y) ? Color.Red : Color.Green) with
        {
          A = 64
        };
        spriteBatch.Draw(GameMap.Instance.squareCheckTexture, new Vector2((float) ((this.x + pointArray[index].X) * GameMap.Instance.cellWidth), (float) ((this.y + pointArray[index].Y) * GameMap.Instance.cellHeight)) + viewOffset, color);
      }
    }

    public void PlaceTower()
    {
      TowerType selectedTower = Game.gameMap.gui.GetSelectedTower(this.index);
      Tower newTower = Game.gameMap.CreateNewTower(selectedTower);
      if (newTower == null)
        return;
      int num = newTower.UpgradeCost(0) <= this.money ? newTower.UpgradeCost(0) : -1;
      if (num == -1)
        Game.soundBank.PlayCue("buzz");
      else if (Game.gameMap.AddTower(newTower, this.x, this.y))
      {
        this.money -= num;
        newTower.SetState(Tower.TowerState.BUILDING, 2000f);
        Game.soundBank.PlayCue("construction");
        newTower.SetOwner(this.index);
      }
      else
        Game.soundBank.PlayCue("buzz");
    }

    public void LifeHit(Tower targetTower, int dmg)
    {
      this.life -= dmg;
      if (this.life > 0)
        return;
      this.life = 0;
      if (!GameMap.Instance.PvP)
        GameMap.Instance.ChangeGameState(GameState.P1P2LOSE);
      else if (this.index == PlayerEnum.P1)
      {
        GameMap.Instance.ChangeGameState(GameState.P1LOSES);
      }
      else
      {
        if (this.index != PlayerEnum.P2)
          return;
        GameMap.Instance.ChangeGameState(GameState.P2LOSES);
      }
    }
  }
}
