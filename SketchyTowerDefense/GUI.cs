// Decompiled with JetBrains decompiler
// Type: TowerDefense.GUI
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TowerDefense
{
  public class GUI
  {
    public SpriteFont smallFont;
    private Texture2D guiBarLeftTexture;
    private Texture2D guiBarRightTexture;
    private Texture2D guiBarBottomTexture;
    private Texture2D guiPlayerOneSplitTexture;
    private Texture2D guiPlayerTwoSplitTexture;
    private Texture2D guiPlayerJoinTexture;
    private Texture2D guiDigits24Texture;
    private Texture2D guiTowerHighlightTexture;
    public Texture2D guiButtonATexture;
    public Texture2D guiButtonBTexture;
    public Texture2D guiButtonXTexture;
    private Texture2D guiButtonDpadTexture;
    private Texture2D guiProgressMarkerTexture;
    private Texture2D guiProgressBarTexture;
    private Texture2D guiTowersTexture;
    public Texture2D guiTextPlayerOneTexture;
    public Texture2D guiTextPlayerTwoTexture;
    private Texture2D guiTextArrowTexture;
    private Texture2D guiTextArrowTowerTexture;
    private Texture2D guiTextCannonTowerTexture;
    private Texture2D guiTextAirTowerTexture;
    private Texture2D guiTextIceTowerTexture;
    private Texture2D guiTextSniperTowerTexture;
    private Texture2D guiTextPitTowerTexture;
    private Texture2D guiTextDmgBoostTowerTexture;
    private Texture2D guiTextRngBoostTowerTexture;
    private Texture2D guiTextBuildTexture;
    private Texture2D guiTextUpgradeTexture;
    private Texture2D guiCostTexture;
    private Texture2D guiTextPrepareTexture;
    private Texture2D guiTextNormalTexture;
    private Texture2D guiTextFastTexture;
    private Texture2D guiTextSellTexture;
    private Texture2D guiTowerLevelTexture;
    private Texture2D guiTowerDmgTexture;
    private Texture2D guiTowerRngTexture;
    private Texture2D guiTowerBoostTexture;
    private Texture2D guiTowerSlowTexture;
    private Texture2D guiTextPercentTexture;
    private Texture2D guiTextNextWaveTexture;
    private Texture2D guiTextWaveTexture;
    private Texture2D guiPopulationTexture;
    private Texture2D guiMoneyTexture;
    private Texture2D guiTextBossTexture;
    private Texture2D guiTextLifeTexture;
    private Texture2D guiTextMaxLevelTexture;
    private Texture2D guiControllerTopLeftTexture;
    private Texture2D guiControllerTopRightTexture;
    private Texture2D guiControllerBottomLeftTexture;
    private Texture2D guiControllerBottomRightTexture;
    private ArrowTower guiArrowTower;
    private BombTower guiBombTower;
    private AirTower guiAirTower;
    private IceTower guiIceTower;
    private SniperTower guiSniperTower;
    private PitTower guiPitTower;
    private DmgBoostTower guiDmgBoostTower;
    private RngBoostTower guiRngBoostTower;
    public Rectangle viewport;
    public Rectangle mainGuiRect;
    public int[] selectIndex;
    public float[] currentMoney;

    public GUI()
    {
      this.currentMoney = new float[2];
      this.currentMoney[0] = this.currentMoney[1] = 0.0f;
      this.selectIndex = new int[2];
      this.selectIndex[0] = this.selectIndex[1] = 0;
    }

    public virtual void LoadContent()
    {
      this.smallFont = GameMap.Instance.content.Load<SpriteFont>("Fonts/debugFont");
      this.guiBarLeftTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_left");
      this.guiBarRightTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_right");
      this.guiBarBottomTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_bottom2");
      this.guiPlayerOneSplitTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_playerone_split");
      this.guiPlayerTwoSplitTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_playertwo_split");
      this.guiPlayerJoinTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_player_join");
      this.guiDigits24Texture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/digits24");
      this.guiTowerHighlightTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_tower_highlight");
      this.guiButtonATexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_button_a");
      this.guiButtonBTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_button_b");
      this.guiButtonXTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_button_x");
      this.guiButtonDpadTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_button_dpad");
      this.guiProgressMarkerTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_progress_marker");
      this.guiProgressBarTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_progressbar");
      this.guiTowersTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_towers");
      this.guiTextPlayerOneTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_playerone");
      this.guiTextPlayerTwoTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_playertwo");
      this.guiTextArrowTowerTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_arrowtower");
      this.guiTextCannonTowerTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_cannontower");
      this.guiTextAirTowerTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_airtower");
      this.guiTextIceTowerTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_icetower");
      this.guiTextSniperTowerTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_lightningtower");
      this.guiTextPitTowerTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_pittraptower");
      this.guiTextDmgBoostTowerTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_dmgboosttower");
      this.guiTextRngBoostTowerTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_rngboosttower");
      this.guiTextBuildTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_build");
      this.guiTextUpgradeTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_upgrade");
      this.guiCostTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_cost");
      this.guiTextPrepareTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_prepare");
      this.guiTextNormalTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_normal");
      this.guiTextFastTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_fast");
      this.guiTextSellTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_sell");
      this.guiTowerLevelTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_level");
      this.guiTowerDmgTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_attack");
      this.guiTowerRngTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_range");
      this.guiTowerBoostTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_boost");
      this.guiTowerSlowTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_freeze");
      this.guiTextPercentTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_percent");
      this.guiTextNextWaveTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_nextwave");
      this.guiTextWaveTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_wave");
      this.guiPopulationTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_population");
      this.guiMoneyTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_money");
      this.guiTextBossTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_boss");
      this.guiTextMaxLevelTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/gui_text_maxlevel");
      this.guiControllerTopLeftTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/controller_top_left");
      this.guiControllerTopRightTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/controller_top_right");
      this.guiControllerBottomLeftTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/controller_bottom_left");
      this.guiControllerBottomRightTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/GUI/controller_bottom_right");
      this.guiArrowTower = new ArrowTower();
      this.guiBombTower = new BombTower();
      this.guiAirTower = new AirTower();
      this.guiIceTower = new IceTower();
      this.guiSniperTower = new SniperTower();
      this.guiPitTower = new PitTower();
      this.guiDmgBoostTower = new DmgBoostTower();
      this.guiRngBoostTower = new RngBoostTower();
      this.guiArrowTower.newTower = false;
      this.guiBombTower.newTower = false;
      this.guiAirTower.newTower = false;
      this.guiIceTower.newTower = false;
      this.guiSniperTower.newTower = false;
      this.guiPitTower.newTower = false;
      this.guiDmgBoostTower.newTower = false;
      this.guiRngBoostTower.newTower = false;
      this.guiArrowTower.guiOnly = true;
      this.guiBombTower.guiOnly = true;
      this.guiAirTower.guiOnly = true;
      this.guiIceTower.guiOnly = true;
      this.guiSniperTower.guiOnly = true;
      this.guiPitTower.guiOnly = true;
      this.guiDmgBoostTower.guiOnly = true;
      this.guiRngBoostTower.guiOnly = true;
      this.guiArrowTower.GuiOnly = true;
      this.guiBombTower.GuiOnly = true;
      this.guiAirTower.GuiOnly = true;
      this.guiIceTower.GuiOnly = true;
      this.guiSniperTower.GuiOnly = true;
      this.guiPitTower.GuiOnly = true;
      this.guiDmgBoostTower.GuiOnly = true;
      this.guiRngBoostTower.GuiOnly = true;
    }

    public void SetViewport(Rectangle newViewport)
    {
      this.viewport = new Rectangle(0, 0, newViewport.Width, newViewport.Height);
      this.mainGuiRect = new Rectangle(this.viewport.Width, 0, newViewport.Width - this.viewport.Width, this.viewport.Height);
    }

    public void Update(GameTime gameTime)
    {
      float amount = 0.05f;
      for (int index = 0; index < 2; ++index)
      {
        if (Math.Abs((int) Math.Round((double) this.currentMoney[index]) - GameMap.Instance.player[index].money) < 3)
          amount = 0.2f;
        this.currentMoney[index] = MathHelper.Lerp(this.currentMoney[index], (float) GameMap.Instance.player[index].money, amount);
      }
      this.CheckInput(gameTime);
    }

    public virtual int DrawDigits(
      int num,
      Vector2 pos,
      int align,
      Color color,
      SpriteBatch spriteBatch)
    {
      string str = Math.Abs(num).ToString();
      int x = 0;
      switch (align)
      {
        case 0:
          x = 0;
          break;
        case 1:
          x = -str.Length * 24;
          break;
        case 2:
          x = -str.Length * 12;
          break;
      }
      for (int index = 0; index < str.Length; ++index)
      {
        spriteBatch.Draw(this.guiDigits24Texture, pos + new Vector2((float) x, 0.0f), new Rectangle?(new Rectangle(((int) str[index] - 48) * 24, 0, 24, 50)), color, 0.0f, new Vector2(0.0f, 0.0f), 1f, SpriteEffects.None, 0.5f);
        x += 24;
      }
      return x;
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Draw(this.guiBarBottomTexture, new Vector2(0.0f, (float) (GameMap.Instance.game.dim.Height - this.guiBarBottomTexture.Height)), Color.White);
      spriteBatch.Draw(this.guiBarLeftTexture, new Vector2(0.0f, 0.0f), Color.White);
      spriteBatch.Draw(this.guiBarRightTexture, new Vector2((float) (GameMap.Instance.game.dim.Width - this.guiBarRightTexture.Width), 0.0f), Color.White);
      this.DrawPlayerInfo(gameTime, spriteBatch, PlayerEnum.P1);
      this.DrawPlayerInfo(gameTime, spriteBatch, PlayerEnum.P2);
      this.DrawWave(gameTime, spriteBatch);
    }

    public void DrawPlayerControlIndicator(
      GameTime gameTime,
      SpriteBatch spriteBatch,
      Vector2 drawOffset,
      PlayerEnum playerIndex)
    {
      PlayerIndex playerIndex1 = (PlayerIndex) Controls.P1LogicalIndex;
      if (playerIndex == PlayerEnum.P2)
        playerIndex1 = (PlayerIndex) Controls.P2LogicalIndex;
      Color limeGreen = Color.LimeGreen;
      Color color = new Color((byte) 50, (byte) 50, (byte) 50);
      if (playerIndex1 != (PlayerIndex) 4 && playerIndex1 != (PlayerIndex) 5)
      {
        spriteBatch.Draw(this.guiControllerTopLeftTexture, new Vector2(0.0f, 0.0f) + drawOffset, playerIndex1 == PlayerIndex.One ? limeGreen : color);
        spriteBatch.Draw(this.guiControllerTopRightTexture, new Vector2(24f, 0.0f) + drawOffset, playerIndex1 == PlayerIndex.Two ? limeGreen : color);
        spriteBatch.Draw(this.guiControllerBottomLeftTexture, new Vector2(0.0f, 24f) + drawOffset, playerIndex1 == PlayerIndex.Three ? limeGreen : color);
        spriteBatch.Draw(this.guiControllerBottomRightTexture, new Vector2(24f, 24f) + drawOffset, playerIndex1 == PlayerIndex.Four ? limeGreen : color);
      }
      else if (playerIndex1 == (PlayerIndex) 4)
      {
        spriteBatch.Draw(this.guiControllerTopLeftTexture, new Vector2(0.0f, 0.0f) + drawOffset, limeGreen);
        spriteBatch.Draw(this.guiControllerTopRightTexture, new Vector2(24f, 0.0f) + drawOffset, limeGreen);
        spriteBatch.Draw(this.guiControllerBottomLeftTexture, new Vector2(0.0f, 24f) + drawOffset, color);
        spriteBatch.Draw(this.guiControllerBottomRightTexture, new Vector2(24f, 24f) + drawOffset, color);
      }
      else
      {
        spriteBatch.Draw(this.guiControllerTopLeftTexture, new Vector2(0.0f, 0.0f) + drawOffset, color);
        spriteBatch.Draw(this.guiControllerTopRightTexture, new Vector2(24f, 0.0f) + drawOffset, color);
        spriteBatch.Draw(this.guiControllerBottomLeftTexture, new Vector2(0.0f, 24f) + drawOffset, limeGreen);
        spriteBatch.Draw(this.guiControllerBottomRightTexture, new Vector2(24f, 24f) + drawOffset, limeGreen);
      }
    }

    public void DrawPlayerInfo(GameTime gameTime, SpriteBatch spriteBatch, PlayerEnum playerIndex)
    {
      Vector2 vector2_1 = new Vector2(30f, 30f);
      if (playerIndex == PlayerEnum.P2)
        vector2_1 = new Vector2((float) (GameMap.Instance.game.dim.Width - 250), 30f);
      if (!GameMap.Instance.player[0].Active && playerIndex == PlayerEnum.P1)
      {
        spriteBatch.Draw(this.guiTextPlayerOneTexture, new Vector2(15f, 240f) + vector2_1, GameMap.Instance.game.playerOneColor);
        spriteBatch.Draw(this.guiPlayerJoinTexture, new Vector2(0.0f, 300f) + vector2_1, Color.White);
      }
      else if (!GameMap.Instance.player[1].Active && playerIndex == PlayerEnum.P2)
      {
        spriteBatch.Draw(this.guiTextPlayerTwoTexture, new Vector2(15f, 240f) + vector2_1, GameMap.Instance.game.playerTwoColor);
        spriteBatch.Draw(this.guiPlayerJoinTexture, new Vector2(0.0f, 300f) + vector2_1, Color.White);
      }
      else
      {
        if (playerIndex == PlayerEnum.P1)
        {
          spriteBatch.Draw(this.guiTextPlayerOneTexture, new Vector2(50f, 0.0f) + vector2_1, GameMap.Instance.game.playerOneColor);
          this.DrawPlayerControlIndicator(gameTime, spriteBatch, new Vector2(0.0f, -10f) + vector2_1, PlayerEnum.P1);
        }
        else
        {
          spriteBatch.Draw(this.guiTextPlayerTwoTexture, new Vector2(40f, 0.0f) + vector2_1, GameMap.Instance.game.playerTwoColor);
          this.DrawPlayerControlIndicator(gameTime, spriteBatch, new Vector2(-10f, -10f) + vector2_1, PlayerEnum.P2);
        }
        float y1 = 50f;
        Vector2 drawOffset1 = vector2_1 + new Vector2(0.0f, y1);
        float y2 = this.DrawPopulationMoney(gameTime, spriteBatch, drawOffset1, playerIndex);
        Vector2 drawOffset2 = drawOffset1 + new Vector2(0.0f, y2);
        Tower towerAt = GameMap.Instance.GetTowerAt(GameMap.Instance.player[Util.PlayerEnumToIndex(playerIndex)].x, GameMap.Instance.player[Util.PlayerEnumToIndex(playerIndex)].y);
        float y3 = this.DrawTowerSelection(gameTime, spriteBatch, drawOffset2, playerIndex);
        Vector2 drawOffset3 = drawOffset2 + new Vector2(0.0f, y3);
        Vector2 vector2_2;
        if (towerAt != null && towerAt is BasicAttackTower && towerAt.ownerPlayerIndex == playerIndex)
        {
          float y4 = this.DrawUpgrade(gameTime, spriteBatch, drawOffset3, playerIndex, (BasicAttackTower) towerAt);
          Vector2 drawOffset4 = drawOffset3 + new Vector2(0.0f, y4);
          float y5 = this.DrawSell(gameTime, spriteBatch, drawOffset4, playerIndex, (BasicAttackTower) towerAt);
          vector2_2 = drawOffset4 + new Vector2(0.0f, y5);
        }
        else if (GameMap.Instance.player[playerIndex == PlayerEnum.P1 ? 0 : 1].hoverMonster != null)
        {
          this.DrawMonster(gameTime, spriteBatch, drawOffset3, playerIndex);
        }
        else
        {
          float y6 = this.DrawBuild(gameTime, spriteBatch, drawOffset3, playerIndex);
          vector2_2 = drawOffset3 + new Vector2(0.0f, y6);
        }
      }
    }

    public float DrawPopulationMoney(
      GameTime gameTime,
      SpriteBatch spriteBatch,
      Vector2 drawOffset,
      PlayerEnum playerIndex)
    {
      spriteBatch.Draw(this.guiPopulationTexture, new Vector2(0.0f, 10f) + drawOffset, Color.White);
      spriteBatch.Draw(this.guiMoneyTexture, new Vector2(0.0f, 75f) + drawOffset, Color.White);
      this.DrawDigits(GameMap.Instance.player[Util.PlayerEnumToIndex(playerIndex)].life, new Vector2(65f, 15f) + drawOffset, 0, GameMap.Instance.player[Util.PlayerEnumToIndex(playerIndex)].life <= 3 ? Color.DarkRed : Color.Black, spriteBatch);
      this.DrawDigits((int) Math.Round((double) this.currentMoney[Util.PlayerEnumToIndex(playerIndex)]), new Vector2(65f, 75f) + drawOffset, 0, Color.Black, spriteBatch);
      if (playerIndex == PlayerEnum.P1)
        spriteBatch.Draw(this.guiPlayerOneSplitTexture, new Vector2(0.0f, drawOffset.Y + 140f), Color.White);
      else
        spriteBatch.Draw(this.guiPlayerTwoSplitTexture, new Vector2((float) (GameMap.Instance.game.dim.Width - this.guiPlayerTwoSplitTexture.Width), drawOffset.Y + 140f), Color.White);
      return 192f;
    }

    public float DrawUpgrade(
      GameTime gameTime,
      SpriteBatch spriteBatch,
      Vector2 drawOffset,
      PlayerEnum playerIndex,
      BasicAttackTower tower)
    {
      int num1 = 180;
      int num2 = 0;
      bool flag1 = tower.level == tower.maxLevel;
      Color white = Color.White;
      if (flag1)
        white.A = (byte) 64;
      spriteBatch.Draw(this.guiButtonATexture, new Vector2(5f, 0.0f) + drawOffset, white);
      spriteBatch.Draw(this.guiTextUpgradeTexture, new Vector2(75f, 10f) + drawOffset, white);
      if (tower is ArrowTower)
        spriteBatch.Draw(this.guiTextArrowTowerTexture, new Vector2(40f, 55f) + drawOffset, Color.White);
      if (tower is BombTower)
        spriteBatch.Draw(this.guiTextCannonTowerTexture, new Vector2(40f, 55f) + drawOffset, Color.White);
      if (tower is AirTower)
        spriteBatch.Draw(this.guiTextAirTowerTexture, new Vector2(60f, 55f) + drawOffset, Color.White);
      if (tower is IceTower)
        spriteBatch.Draw(this.guiTextIceTowerTexture, new Vector2(30f, 55f) + drawOffset, Color.White);
      if (tower is SniperTower)
        spriteBatch.Draw(this.guiTextSniperTowerTexture, new Vector2(0.0f, 55f) + drawOffset, Color.White);
      if (tower is PitTower)
        spriteBatch.Draw(this.guiTextPitTowerTexture, new Vector2(40f, 55f) + drawOffset, Color.White);
      if (tower is DmgBoostTower)
        spriteBatch.Draw(this.guiTextDmgBoostTowerTexture, new Vector2(0.0f, 55f) + drawOffset, Color.White);
      if (tower is RngBoostTower)
        spriteBatch.Draw(this.guiTextRngBoostTowerTexture, new Vector2(0.0f, 55f) + drawOffset, Color.White);
      int num3;
      if (!flag1)
      {
        spriteBatch.Draw(this.guiCostTexture, new Vector2(25f, 90f) + drawOffset, Color.White);
        num3 = this.DrawDigits(tower.UpgradeCost(tower.level + 1), new Vector2(190f, 95f) + drawOffset, 1, Color.Black, spriteBatch);
      }
      else
        spriteBatch.Draw(this.guiTextMaxLevelTexture, new Vector2((float) (110 - this.guiTextMaxLevelTexture.Width / 2), 115f) + drawOffset, Color.White);
      int num4 = (tower.level + 1).ToString().Length * 16;
      if (num4 > num2)
        num2 = num4;
      int num5 = tower.Damage(tower.level, true).ToString().Length * 16;
      if (num5 > num2)
        num2 = num5;
      int num6 = tower.Range(tower.level, true).ToString().Length * 16;
      if (num6 > num2)
        num2 = num6;
      int width = this.guiTowerLevelTexture.Width;
      int num7 = -(num2 + (width + 10)) / 2;
      if (playerIndex == PlayerEnum.P2)
        num7 -= 15;
      bool flag2 = true;
      int num8;
      switch (tower)
      {
        case RngBoostTower _:
        case DmgBoostTower _:
        case IceTower _:
          num8 = 0;
          break;
        default:
          num8 = 1;
          break;
      }
      bool flag3 = num8 != 0;
      int num9;
      switch (tower)
      {
        case RngBoostTower _:
        case DmgBoostTower _:
        case PitTower _:
          num9 = 0;
          break;
        default:
          num9 = 1;
          break;
      }
      bool flag4 = num9 != 0;
      bool flag5 = tower is IceTower;
      int num10;
      switch (tower)
      {
        case DmgBoostTower _:
        case RngBoostTower _:
          num10 = 1;
          break;
        default:
          num10 = 0;
          break;
      }
      bool flag6 = num10 != 0;
      int num11 = 0;
      if (flag2)
      {
        spriteBatch.Draw(this.guiTowerLevelTexture, new Vector2((float) (110 + num7), (float) (num1 + num11)) + drawOffset, Color.White);
        int num12 = this.DrawDigits(tower.level + (flag1 ? 0 : 1) + 1, new Vector2((float) (110 + num7 + width + 10), (float) (num1 + num11)) + drawOffset, 0, Color.Black, spriteBatch);
        tower.DrawLevel(new Vector2((float) (110 + num7 + width + 10 + num12) + 25f, (float) (num1 + num11) + 5f) + drawOffset, gameTime, spriteBatch, flag1 ? 0 : 1);
        num11 += 60;
      }
      if (flag3)
      {
        spriteBatch.Draw(this.guiTowerDmgTexture, new Vector2((float) (110 + num7), (float) (num1 + num11)) + drawOffset, Color.White);
        num3 = this.DrawDigits((int) tower.Damage(tower.level + (flag1 ? 0 : 1), true), new Vector2((float) (110 + num7 + width + 10), (float) (num1 + num11)) + drawOffset, 0, Color.Black, spriteBatch);
        num11 += 60;
      }
      if (flag5)
      {
        spriteBatch.Draw(this.guiTowerSlowTexture, new Vector2((float) (110 + num7), (float) (num1 + num11)) + drawOffset, Color.White);
        int num13 = this.DrawDigits(100 - (int) tower.Damage(tower.level + (flag1 ? 0 : 1), true), new Vector2((float) (110 + num7 + width + 10), (float) (num1 + num11)) + drawOffset, 0, Color.Black, spriteBatch);
        spriteBatch.Draw(this.guiTextPercentTexture, new Vector2((float) (110 + num7 + width + 12 + num13), (float) (num1 + num11)) + drawOffset, Color.White);
        num11 += 60;
      }
      if (flag4)
      {
        spriteBatch.Draw(this.guiTowerRngTexture, new Vector2((float) (110 + num7), (float) (num1 + num11)) + drawOffset, Color.White);
        num3 = this.DrawDigits((int) tower.Range(tower.level + (flag1 ? 0 : 1), true), new Vector2((float) (110 + num7 + width + 10), (float) (num1 + num11)) + drawOffset, 0, Color.Black, spriteBatch);
        num11 += 60;
      }
      if (flag6)
      {
        int num14 = 0;
        if (tower is DmgBoostTower)
          num14 = (int) Math.Round(((double) ((DmgBoostTower) tower).Boost(tower.level + (flag1 ? 0 : 1)) - 1.0) * 100.0);
        if (tower is RngBoostTower)
          num14 = (int) Math.Round(((double) ((RngBoostTower) tower).Boost(tower.level + (flag1 ? 0 : 1)) - 1.0) * 100.0);
        spriteBatch.Draw(this.guiTowerBoostTexture, new Vector2((float) (110 + num7), (float) (num1 + num11)) + drawOffset, Color.White);
        int num15 = this.DrawDigits(num14, new Vector2((float) (110 + num7 + width + 10), (float) (num1 + num11)) + drawOffset, 0, Color.Black, spriteBatch);
        spriteBatch.Draw(this.guiTextPercentTexture, new Vector2((float) (110 + num7 + width + 12 + num15), (float) (num1 + num11)) + drawOffset, Color.White);
        int num16 = num11 + 30;
      }
      return 390f;
    }

    public float DrawBuild(
      GameTime gameTime,
      SpriteBatch spriteBatch,
      Vector2 drawOffset,
      PlayerEnum playerIndex)
    {
      BasicAttackTower tower = (BasicAttackTower) null;
      switch (this.GetSelectedTower(playerIndex))
      {
        case TowerType.ARROW:
          tower = (BasicAttackTower) new ArrowTower();
          break;
        case TowerType.BOMB:
          tower = (BasicAttackTower) new BombTower();
          break;
        case TowerType.AIR:
          tower = (BasicAttackTower) new AirTower();
          break;
        case TowerType.ICE:
          tower = (BasicAttackTower) new IceTower();
          break;
        case TowerType.SNIPER:
          tower = (BasicAttackTower) new SniperTower();
          break;
        case TowerType.PIT:
          tower = (BasicAttackTower) new PitTower();
          break;
        case TowerType.DMGBOOST:
          tower = (BasicAttackTower) new DmgBoostTower();
          break;
        case TowerType.RNGBOOST:
          tower = (BasicAttackTower) new RngBoostTower();
          break;
      }
      if (tower == null)
        return 0.0f;
      spriteBatch.Draw(this.guiButtonATexture, new Vector2(20f, 0.0f) + drawOffset, Color.White);
      spriteBatch.Draw(this.guiTextBuildTexture, new Vector2(90f, 10f) + drawOffset, Color.White);
      if (tower is ArrowTower)
        spriteBatch.Draw(this.guiTextArrowTowerTexture, new Vector2(40f, 55f) + drawOffset, Color.White);
      if (tower is BombTower)
        spriteBatch.Draw(this.guiTextCannonTowerTexture, new Vector2(40f, 55f) + drawOffset, Color.White);
      if (tower is AirTower)
        spriteBatch.Draw(this.guiTextAirTowerTexture, new Vector2(80f, 55f) + drawOffset, Color.White);
      if (tower is IceTower)
        spriteBatch.Draw(this.guiTextIceTowerTexture, new Vector2(85f, 55f) + drawOffset, Color.White);
      if (tower is SniperTower)
        spriteBatch.Draw(this.guiTextSniperTowerTexture, new Vector2(20f, 55f) + drawOffset, Color.White);
      if (tower is PitTower)
        spriteBatch.Draw(this.guiTextPitTowerTexture, new Vector2(25f, 55f) + drawOffset, Color.White);
      if (tower is DmgBoostTower)
        spriteBatch.Draw(this.guiTextDmgBoostTowerTexture, new Vector2(15f, 55f) + drawOffset, Color.White);
      if (tower is RngBoostTower)
        spriteBatch.Draw(this.guiTextRngBoostTowerTexture, new Vector2(10f, 55f) + drawOffset, Color.White);
      spriteBatch.Draw(this.guiCostTexture, new Vector2(25f, 90f) + drawOffset, Color.White);
      this.DrawDigits(tower.UpgradeCost(0), new Vector2(190f, 95f) + drawOffset, 1, Color.Black, spriteBatch);
      return (float) (this.DrawTowerStats(gameTime, spriteBatch, drawOffset, playerIndex, tower) + 120);
    }

    public int DrawTowerStats(
      GameTime gameTime,
      SpriteBatch spriteBatch,
      Vector2 drawOffset,
      PlayerEnum playerIndex,
      BasicAttackTower tower)
    {
      int num1 = 180;
      int num2 = 0;
      int num3 = (tower.level + 1).ToString().Length * 16;
      if (num3 > num2)
        num2 = num3;
      int num4 = tower.Damage(tower.level, true).ToString().Length * 16;
      if (num4 > num2)
        num2 = num4;
      int num5 = tower.Range(tower.level, true).ToString().Length * 16;
      if (num5 > num2)
        num2 = num5;
      int width = this.guiTowerLevelTexture.Width;
      int num6 = -(num2 + (width + 10)) / 2;
      if (playerIndex == PlayerEnum.P2)
        num6 -= 15;
      bool flag1 = true;
      int num7;
      switch (tower)
      {
        case RngBoostTower _:
        case DmgBoostTower _:
        case IceTower _:
          num7 = 0;
          break;
        default:
          num7 = 1;
          break;
      }
      bool flag2 = num7 != 0;
      int num8;
      switch (tower)
      {
        case RngBoostTower _:
        case DmgBoostTower _:
        case PitTower _:
          num8 = 0;
          break;
        default:
          num8 = 1;
          break;
      }
      bool flag3 = num8 != 0;
      bool flag4 = tower is IceTower;
      int num9;
      switch (tower)
      {
        case DmgBoostTower _:
        case RngBoostTower _:
          num9 = 1;
          break;
        default:
          num9 = 0;
          break;
      }
      bool flag5 = num9 != 0;
      int num10 = 0;
      if (flag1)
      {
        spriteBatch.Draw(this.guiTowerLevelTexture, new Vector2((float) (110 + num6), (float) (num1 + num10)) + drawOffset, Color.White);
        int num11 = this.DrawDigits(tower.level + 1, new Vector2((float) (110 + num6 + width + 10), (float) (num1 + num10)) + drawOffset, 0, Color.Black, spriteBatch);
        tower.DrawLevel(new Vector2((float) (110 + num6 + width + 10 + num11) + 25f, (float) (num1 + num10) + 5f) + drawOffset, gameTime, spriteBatch, 0);
        num10 += 60;
      }
      int num12;
      if (flag2)
      {
        spriteBatch.Draw(this.guiTowerDmgTexture, new Vector2((float) (110 + num6), (float) (num1 + num10)) + drawOffset, Color.White);
        num12 = this.DrawDigits((int) tower.Damage(tower.level, true), new Vector2((float) (110 + num6 + width + 10), (float) (num1 + num10)) + drawOffset, 0, Color.Black, spriteBatch);
        num10 += 60;
      }
      if (flag4)
      {
        spriteBatch.Draw(this.guiTowerSlowTexture, new Vector2((float) (110 + num6), (float) (num1 + num10)) + drawOffset, Color.White);
        int num13 = this.DrawDigits(100 - (int) tower.Damage(tower.level, true), new Vector2((float) (110 + num6 + width + 10), (float) (num1 + num10)) + drawOffset, 0, Color.Black, spriteBatch);
        spriteBatch.Draw(this.guiTextPercentTexture, new Vector2((float) (110 + num6 + width + 12 + num13), (float) (num1 + num10)) + drawOffset, Color.White);
        num10 += 60;
      }
      if (flag3)
      {
        spriteBatch.Draw(this.guiTowerRngTexture, new Vector2((float) (110 + num6), (float) (num1 + num10)) + drawOffset, Color.White);
        num12 = this.DrawDigits((int) tower.Range(tower.level, true), new Vector2((float) (110 + num6 + width + 10), (float) (num1 + num10)) + drawOffset, 0, Color.Black, spriteBatch);
        num10 += 60;
      }
      if (flag5)
      {
        int num14 = 0;
        if (tower is DmgBoostTower)
          num14 = (int) Math.Round(((double) ((DmgBoostTower) tower).Boost(tower.level) - 1.0) * 100.0);
        if (tower is RngBoostTower)
          num14 = (int) Math.Round(((double) ((RngBoostTower) tower).Boost(tower.level) - 1.0) * 100.0);
        spriteBatch.Draw(this.guiTowerBoostTexture, new Vector2((float) (110 + num6), (float) (num1 + num10)) + drawOffset, Color.White);
        int num15 = this.DrawDigits(num14, new Vector2((float) (110 + num6 + width + 10), (float) (num1 + num10)) + drawOffset, 0, Color.Black, spriteBatch);
        spriteBatch.Draw(this.guiTextPercentTexture, new Vector2((float) (110 + num6 + width + 12 + num15), (float) (num1 + num10)) + drawOffset, Color.White);
        int num16 = num10 + 30;
      }
      return num1;
    }

    public float DrawMonster(
      GameTime gameTime,
      SpriteBatch spriteBatch,
      Vector2 drawOffset,
      PlayerEnum playerIndex)
    {
      Monster hoverMonster = GameMap.Instance.player[playerIndex == PlayerEnum.P1 ? 0 : 1].hoverMonster;
      if (hoverMonster == null)
        return 0.0f;
      Vector2 pos = hoverMonster.pos;
      Vector2 walkingOffset = hoverMonster.walkingOffset;
      Color color = hoverMonster.color;
      float scale = hoverMonster.scale;
      bool drawHealth = hoverMonster.drawHealth;
      hoverMonster.pos = drawOffset + new Vector2(106f, (float) (100 - hoverMonster.texture.Height / 2));
      hoverMonster.color.A = byte.MaxValue;
      hoverMonster.scale = hoverMonster.normalScale * 1.5f;
      hoverMonster.walkingOffset = new Vector2(0.0f, 0.0f);
      hoverMonster.drawHealth = false;
      hoverMonster.Draw(new Vector2(0.0f, 0.0f), gameTime, spriteBatch);
      hoverMonster.pos = pos;
      hoverMonster.walkingOffset = walkingOffset;
      hoverMonster.color = color;
      hoverMonster.scale = scale;
      hoverMonster.drawHealth = drawHealth;
      spriteBatch.Draw(hoverMonster.nameTexture, drawOffset + new Vector2((float) (-hoverMonster.nameTexture.Width / 2) + 100f, 120f), Color.White);
      if (hoverMonster.boss)
      {
        drawOffset.Y += 30f;
        spriteBatch.Draw(this.guiTextBossTexture, drawOffset + new Vector2((float) (-this.guiTextBossTexture.Width / 2) + 100f, 120f), Color.White);
      }
      float x = (float) (100.0 - ((double) (((int) hoverMonster.health).ToString().Length * 16) + 55.0) / 2.0);
      spriteBatch.Draw(this.guiPopulationTexture, new Vector2(x, 200f) + drawOffset, Color.White);
      this.DrawDigits((int) hoverMonster.health, new Vector2(x + 70f, 205f) + drawOffset, 0, Color.Black, spriteBatch);
      return 120f;
    }

    public float DrawSell(
      GameTime gameTime,
      SpriteBatch spriteBatch,
      Vector2 drawOffset,
      PlayerEnum playerIndex,
      BasicAttackTower tower)
    {
      spriteBatch.Draw(this.guiButtonXTexture, new Vector2(50f, 0.0f) + drawOffset, Color.White);
      spriteBatch.Draw(this.guiTextSellTexture, new Vector2(110f, 5f) + drawOffset, Color.White);
      spriteBatch.Draw(this.guiCostTexture, new Vector2(25f, 50f) + drawOffset, Color.White);
      this.DrawDigits(tower.SellValue(), new Vector2(190f, 55f) + drawOffset, 1, Color.Black, spriteBatch);
      return 0.0f;
    }

    public void DrawWave(GameTime gameTime, SpriteBatch spriteBatch)
    {
      int num1 = 275;
      spriteBatch.Draw(this.guiTextWaveTexture, new Vector2((float) (1250 + num1 - 130), (float) (GameMap.Instance.game.dim.Height - 68)), Color.White);
      this.DrawDigits(GameMap.Instance.wave + 1, new Vector2((float) (1250 + num1), (float) (GameMap.Instance.game.dim.Height - 80)), 0, Color.Black, spriteBatch);
      if (GameMap.Instance.PvP)
      {
        if (!GameMap.Instance.p1GameSpeedChangePending)
          spriteBatch.Draw(this.guiButtonBTexture, new Vector2(20f, (float) (GameMap.Instance.game.dim.Height - 60)), new Rectangle?(), Color.Gray, 0.0f, new Vector2(0.0f, 0.0f), 0.66f, SpriteEffects.None, 0.0f);
        else
          spriteBatch.Draw(this.guiButtonBTexture, new Vector2(20f, (float) (GameMap.Instance.game.dim.Height - 60)), new Rectangle?(), Color.White, 0.0f, new Vector2(0.0f, 0.0f), 0.66f, SpriteEffects.None, 0.0f);
        if (!GameMap.Instance.p2GameSpeedChangePending)
          spriteBatch.Draw(this.guiButtonBTexture, new Vector2(55f, (float) (GameMap.Instance.game.dim.Height - 60)), new Rectangle?(), Color.Gray, 0.0f, new Vector2(0.0f, 0.0f), 0.66f, SpriteEffects.None, 0.0f);
        else
          spriteBatch.Draw(this.guiButtonBTexture, new Vector2(55f, (float) (GameMap.Instance.game.dim.Height - 60)), new Rectangle?(), Color.White, 0.0f, new Vector2(0.0f, 0.0f), 0.66f, SpriteEffects.None, 0.0f);
      }
      else
        spriteBatch.Draw(this.guiButtonBTexture, new Vector2(30f, (float) (GameMap.Instance.game.dim.Height - 65)), Color.White);
      Texture2D texture = (Texture2D) null;
      if (GameMap.Instance.gameSpeed == GameSpeed.PREPARE)
        texture = this.guiTextPrepareTexture;
      else if (GameMap.Instance.gameSpeed == GameSpeed.NORMAL)
        texture = this.guiTextNormalTexture;
      else if (GameMap.Instance.gameSpeed == GameSpeed.FAST)
        texture = this.guiTextFastTexture;
      spriteBatch.Draw(texture, new Vector2(90f, (float) (GameMap.Instance.game.dim.Height - 60)), Color.White);
      float num2 = (GameMap.Instance.waveInterval - GameMap.Instance.waveTime) / GameMap.Instance.waveInterval;
      float num3 = 630f;
      float num4 = (1350f - num3) * num2;
      if (GameMap.Instance.upcomingWaves[0] != null)
      {
        Monster upcomingWave = GameMap.Instance.upcomingWaves[0];
        int cellWidth = upcomingWave.cellWidth;
        int cellHeight = upcomingWave.cellHeight;
        Rectangle rectangle = new Rectangle(0, 0, upcomingWave.cellWidth, upcomingWave.cellHeight);
        Color color = GameMap.Instance.upcomingWaves[0].color with
        {
          A = byte.MaxValue
        };
        float num5 = 0.9f;
        if ((double) num2 >= (double) num5)
          color.A = (byte) ((double) byte.MaxValue * ((1.0 - (double) num2) / (1.0 - (double) num5)));
        upcomingWave.pos = new Vector2((float) ((double) num3 + (double) num4 - (double) (upcomingWave.texture.Width / 2) + 4.0), (float) (GameMap.Instance.game.dim.Height - 25 - upcomingWave.texture.Height / 2));
        upcomingWave.pos = new Vector2(num3 + num4, (float) (GameMap.Instance.game.dim.Height - 25 - upcomingWave.texture.Height / 2));
        upcomingWave.walkingOffset = new Vector2(0.0f, 0.0f);
        upcomingWave.color = color;
        upcomingWave.scale = upcomingWave.normalScale;
        upcomingWave.Draw(new Vector2(0.0f, 0.0f), gameTime, spriteBatch);
        if (GameMap.Instance.upcomingWaves[0].nameTexture != null)
        {
          if (GameMap.Instance.upcomingWaves[0].boss)
          {
            spriteBatch.Draw(GameMap.Instance.upcomingWaves[0].nameTexture, new Vector2((float) (1200 + num1 + 150), (float) (GameMap.Instance.game.dim.Height - 95)), Color.Black);
            spriteBatch.Draw(this.guiTextBossTexture, new Vector2((float) (1200 + num1 + 150 + (GameMap.Instance.upcomingWaves[0].nameTexture.Width / 2 - this.guiTextBossTexture.Width / 2)), (float) (GameMap.Instance.game.dim.Height - 60)), Color.Black);
          }
          else
            spriteBatch.Draw(GameMap.Instance.upcomingWaves[0].nameTexture, new Vector2((float) (1200 + num1 + 150), (float) (GameMap.Instance.game.dim.Height - 70)), Color.Black);
        }
      }
      float num6 = 70f;
      for (int index = 1; index < GameMap.Instance.upcomingWavesTracked; ++index)
      {
        if (GameMap.Instance.upcomingWaves[index] != null)
        {
          Monster upcomingWave = GameMap.Instance.upcomingWaves[index];
          int cellWidth = upcomingWave.cellWidth;
          int cellHeight = upcomingWave.cellHeight;
          Rectangle rectangle = new Rectangle(0, 0, upcomingWave.cellWidth, upcomingWave.cellHeight);
          Color color = GameMap.Instance.upcomingWaves[index].color with
          {
            A = byte.MaxValue
          };
          if (index == GameMap.Instance.upcomingWavesTracked - 1)
          {
            int num7 = (int) ((double) byte.MaxValue * (double) num2 * 5.0);
            color.A = num7 > (int) byte.MaxValue ? byte.MaxValue : (byte) num7;
          }
          upcomingWave.pos = new Vector2((float) ((double) num3 - (double) index * (double) num6 + (double) num6 * (double) num2), (float) (GameMap.Instance.game.dim.Height - 25 - upcomingWave.texture.Height / 2));
          upcomingWave.color = color;
          upcomingWave.walkingOffset = new Vector2(0.0f, 0.0f);
          upcomingWave.scale = upcomingWave.normalScale;
          upcomingWave.Draw(new Vector2(0.0f, 0.0f), gameTime, spriteBatch);
        }
      }
    }

    public float DrawTowerSelection(
      GameTime gameTime,
      SpriteBatch spriteBatch,
      Vector2 drawOffset,
      PlayerEnum playerIndex)
    {
      Vector2 vector2_1 = new Vector2(20f, 25f);
      Vector2 vector2_2 = vector2_1;
      this.guiArrowTower.pos = vector2_2;
      this.guiArrowTower.SetOwner(playerIndex);
      this.guiArrowTower.Draw(drawOffset, gameTime, spriteBatch);
      Vector2 vector2_3 = vector2_2 + new Vector2((float) (GameMap.Instance.cellWidth * 2), 0.0f);
      this.guiBombTower.pos = vector2_3;
      this.guiBombTower.SetOwner(playerIndex);
      this.guiBombTower.Draw(drawOffset, gameTime, spriteBatch);
      Vector2 vector2_4 = vector2_3 + new Vector2((float) (GameMap.Instance.cellWidth * 2), 0.0f);
      this.guiAirTower.pos = vector2_4;
      this.guiAirTower.SetOwner(playerIndex);
      this.guiAirTower.Draw(drawOffset, gameTime, spriteBatch);
      this.guiIceTower.pos = vector2_4 + new Vector2((float) (GameMap.Instance.cellWidth * 2), 0.0f);
      this.guiIceTower.SetOwner(playerIndex);
      this.guiIceTower.Draw(drawOffset, gameTime, spriteBatch);
      Vector2 vector2_5 = vector2_1 + new Vector2(0.0f, (float) (GameMap.Instance.cellWidth * 2) + 5f);
      this.guiSniperTower.pos = vector2_5;
      this.guiSniperTower.SetOwner(playerIndex);
      this.guiSniperTower.Draw(drawOffset, gameTime, spriteBatch);
      Vector2 vector2_6 = vector2_5 + new Vector2((float) (GameMap.Instance.cellWidth * 2), 0.0f);
      this.guiPitTower.pos = vector2_6;
      this.guiPitTower.SetOwner(playerIndex);
      this.guiPitTower.Draw(drawOffset, gameTime, spriteBatch);
      Vector2 vector2_7 = vector2_6 + new Vector2((float) (GameMap.Instance.cellWidth * 2), 0.0f);
      this.guiDmgBoostTower.pos = vector2_7;
      this.guiDmgBoostTower.SetOwner(playerIndex);
      this.guiDmgBoostTower.Draw(drawOffset, gameTime, spriteBatch);
      this.guiRngBoostTower.pos = vector2_7 + new Vector2((float) (GameMap.Instance.cellWidth * 2), 0.0f);
      this.guiRngBoostTower.SetOwner(playerIndex);
      this.guiRngBoostTower.Draw(drawOffset, gameTime, spriteBatch);
      Color blue = Color.Blue with { A = 150 };
      Vector2 vector2_8 = new Vector2(20f, 25f) + drawOffset;
      switch (this.selectIndex[Util.PlayerEnumToIndex(playerIndex)])
      {
        case 1:
          vector2_8 += new Vector2(60f, 0.0f);
          break;
        case 2:
          vector2_8 += new Vector2(120f, 0.0f);
          break;
        case 3:
          vector2_8 += new Vector2(180f, 0.0f);
          break;
        case 4:
          vector2_8 += new Vector2(0.0f, 60f);
          break;
        case 5:
          vector2_8 += new Vector2(60f, 60f);
          break;
        case 6:
          vector2_8 += new Vector2(120f, 60f);
          break;
        case 7:
          vector2_8 += new Vector2(180f, 60f);
          break;
      }
      spriteBatch.Draw(this.guiTowerHighlightTexture, vector2_8, new Rectangle?(), blue, 0.0f, new Vector2((float) (this.guiTowerHighlightTexture.Width / 2), (float) (this.guiTowerHighlightTexture.Height / 2)), 1f, SpriteEffects.None, 0.5f);
      return 153f;
    }

    public TowerType GetSelectedTower(PlayerEnum playerIndex)
    {
      int index = 0;
      switch (playerIndex)
      {
        case PlayerEnum.P1:
          index = 0;
          break;
        case PlayerEnum.P2:
          index = 1;
          break;
        case PlayerEnum.P3:
          index = 2;
          break;
        case PlayerEnum.P4:
          index = 3;
          break;
      }
      switch (this.selectIndex[index])
      {
        case 0:
          return TowerType.ARROW;
        case 1:
          return TowerType.BOMB;
        case 2:
          return TowerType.AIR;
        case 3:
          return TowerType.ICE;
        case 4:
          return TowerType.SNIPER;
        case 5:
          return TowerType.PIT;
        case 6:
          return TowerType.DMGBOOST;
        case 7:
          return TowerType.RNGBOOST;
        default:
          return TowerType.NONE;
      }
    }

    public void CheckInput(GameTime gameTime)
    {
      for (int i1 = 0; i1 < 2; ++i1)
      {
        PlayerEnum i2 = Util.PlayerIndexToEnum(i1);
        if (Controls.DpadDownUp(i2).Down == ButtonState.Pressed && this.selectIndex[i1] < 4)
        {
          Game.soundBank.PlayCue("click2");
          this.selectIndex[i1] += 4;
        }
        if (Controls.DpadDownUp(i2).Up == ButtonState.Pressed && this.selectIndex[i1] >= 4)
        {
          Game.soundBank.PlayCue("click2");
          this.selectIndex[i1] -= 4;
        }
        if (Controls.DpadDownUp(i2).Right == ButtonState.Pressed && this.selectIndex[i1] != 3 && this.selectIndex[i1] != 7)
        {
          Game.soundBank.PlayCue("click2");
          ++this.selectIndex[i1];
        }
        if (Controls.DpadDownUp(i2).Left == ButtonState.Pressed && this.selectIndex[i1] != 0 && this.selectIndex[i1] != 4)
        {
          Game.soundBank.PlayCue("click2");
          --this.selectIndex[i1];
        }
      }
    }
  }
}
