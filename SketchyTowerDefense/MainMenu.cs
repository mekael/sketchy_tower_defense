// Decompiled with JetBrains decompiler
// Type: TowerDefense.MainMenu
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace TowerDefense
{
  public class MainMenu
  {
    public ContentManager content;
    public SpriteFont debugFont;
    public SpriteFont highScoresFont;
    private Texture2D titleTexture;
    private Texture2D optionScenarioTexture;
    private Texture2D optionVersusTexture;
    private Texture2D optionAboutTexture;
    private Texture2D optionUnderlineTexture;
    private Texture2D optionPressStartTexture;
    private Texture2D optionOptionsTexture;
    private Texture2D optionBrightnessTexture;
    private Texture2D optionScreenSizeTexture;
    private Texture2D optionSliderTexture;
    private Texture2D optionSliderMarkerTexture;
    private Texture2D guiNoTrialTexture;
    private Texture2D levelThumbFrameTexture;
    private Texture2D levelSelectLeftTexture;
    private Texture2D levelSelectRightTexture;
    private float levelLeftFade = 1f;
    private float levelRightFade = 1f;
    private float minLevelArrowFade = 0.2f;
    private float levelFade;
    private float levelFadeTotal = 250f;
    private bool levelFadingIn;
    private bool levelFadingOut;
    private Texture2D versionTexture;
    private Texture2D copyrightTexture;
    public int width;
    public int height;
    public int selectedLevelIndex;
    public int pendingSelectedLevelIndex;
    private ArrayList normalLevels;
    private ArrayList pvpLevels;
    private GamePadState oldGamePad;
    private KeyboardState oldKeyboard;
    public float sliderClickDelay = 100f;
    public float sliderClickTimeout;
    public bool initialized;
    private Game game;
    private int selectIndex;
    public static HighScores highScores;
    private Dictionary<string, MainMenu.Submenu> menus = new Dictionary<string, MainMenu.Submenu>();
    private MainMenu.Submenu currentMenu;

    public MainMenu(Game game, IServiceProvider serviceProvider, string path)
    {
      this.game = game;
      this.content = new ContentManager(serviceProvider, path);
      MainMenu.Submenu submenu1 = new MainMenu.Submenu("main", "");
      submenu1.menuDest = new string[3]
      {
        "coop_level",
        "pvp_level",
        "options"
      };
      this.menus.Add(submenu1.name, submenu1);
      MainMenu.Submenu submenu2 = new MainMenu.Submenu("pvp_level", "main");
      submenu2.menuDest = new string[1]{ "" };
      this.menus.Add(submenu2.name, submenu2);
      MainMenu.Submenu submenu3 = new MainMenu.Submenu("coop_level", "main");
      submenu3.menuDest = new string[1]{ "" };
      this.menus.Add(submenu3.name, submenu3);
      MainMenu.Submenu submenu4 = new MainMenu.Submenu("options", "main");
      submenu4.menuDest = new string[2]
      {
        "brightness",
        "screensize"
      };
      this.menus.Add(submenu4.name, submenu4);
      MainMenu.Submenu submenu5 = new MainMenu.Submenu("highscores", "main");
      this.menus.Add(submenu5.name, submenu5);
      MainMenu.Submenu submenu6 = new MainMenu.Submenu("brightness", "options");
      this.menus.Add(submenu6.name, submenu6);
      MainMenu.Submenu submenu7 = new MainMenu.Submenu("screensize", "options");
      this.menus.Add(submenu7.name, submenu7);
      this.normalLevels = new ArrayList();
      this.pvpLevels = new ArrayList();
      foreach (LevelDefinition level in game.levels)
      {
        if (level.thumbTexture != null)
        {
          if (level.PvP)
            this.pvpLevels.Add((object) level);
          else
            this.normalLevels.Add((object) level);
        }
      }
    }

    private void Init(GraphicsDevice graphicsDevice)
    {
      if (this.initialized)
        return;
      this.LoadContent();
      this.initialized = true;
      this.oldGamePad = GamePad.GetState(PlayerIndex.One);
      this.oldKeyboard = Keyboard.GetState();
      this.currentMenu = this.menus["main"];
    }

    public void LoadContent()
    {
      this.debugFont = this.content.Load<SpriteFont>("Fonts/debugFont");
      this.highScoresFont = this.content.Load<SpriteFont>("Fonts/Highscores");
      this.titleTexture = this.content.Load<Texture2D>("Sprites/GUI/title");
      this.optionScenarioTexture = this.content.Load<Texture2D>("Sprites/GUI/option_scenario");
      this.optionVersusTexture = this.content.Load<Texture2D>("Sprites/GUI/option_versus");
      this.optionAboutTexture = this.content.Load<Texture2D>("Sprites/GUI/option_about");
      this.optionUnderlineTexture = this.content.Load<Texture2D>("Sprites/GUI/option_underline");
      this.optionPressStartTexture = this.content.Load<Texture2D>("Sprites/GUI/option_pressstart");
      this.optionOptionsTexture = this.content.Load<Texture2D>("Sprites/GUI/option_options");
      this.optionBrightnessTexture = this.content.Load<Texture2D>("Sprites/GUI/option_brightness");
      this.optionScreenSizeTexture = this.content.Load<Texture2D>("Sprites/GUI/option_screensize");
      this.optionSliderTexture = this.content.Load<Texture2D>("Sprites/GUI/option_slider");
      this.optionSliderMarkerTexture = this.content.Load<Texture2D>("Sprites/GUI/option_slider_marker");
      this.guiNoTrialTexture = GameMap.Instance.content.Load<Texture2D>("Sprites/Levels/notrial");
      this.levelThumbFrameTexture = this.content.Load<Texture2D>("Sprites/GUI/level_thumb_frame");
      this.levelSelectLeftTexture = this.content.Load<Texture2D>("Sprites/GUI/gui_level_select_left");
      this.levelSelectRightTexture = this.content.Load<Texture2D>("Sprites/GUI/gui_level_select_right");
      this.versionTexture = this.content.Load<Texture2D>("Sprites/GUI/version");
      this.copyrightTexture = this.content.Load<Texture2D>("Sprites/GUI/copyright");
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (!this.initialized)
        return;
      spriteBatch.Draw(this.titleTexture, new Vector2((float) (this.game.dim.Width / 2 - this.titleTexture.Width / 2), 50f), Color.White);
      spriteBatch.Draw(this.copyrightTexture, new Vector2(30f, (float) this.game.dim.Height - 225f), Color.White);
      spriteBatch.Draw(this.versionTexture, new Vector2((float) (this.game.dim.Width - 30 - this.versionTexture.Width), (float) this.game.dim.Height - 60f), Color.White);
      float yoffset = 650f;
      if (!Controls.MCSet())
      {
        spriteBatch.Draw(this.optionPressStartTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionPressStartTexture.Width / 2), yoffset + 100f), Color.White);
      }
      else
      {
        switch (this.currentMenu.name)
        {
          case "main":
            this.DrawMain(gameTime, spriteBatch, yoffset);
            break;
          case "coop_level":
            this.DrawLevelSelect(gameTime, spriteBatch, yoffset, false);
            break;
          case "pvp_level":
            this.DrawLevelSelect(gameTime, spriteBatch, yoffset, true);
            break;
          case "options":
            this.DrawOptions(gameTime, spriteBatch, yoffset);
            break;
          case "brightness":
            this.DrawBrightness(gameTime, spriteBatch, yoffset);
            break;
          case "screensize":
            this.DrawScreenSize(gameTime, spriteBatch, yoffset);
            break;
          case "highscores":
            this.DrawHighScores(gameTime, spriteBatch, yoffset - 5f);
            break;
        }
      }
    }

    public void DrawMain(GameTime gameTime, SpriteBatch spriteBatch, float yoffset)
    {
      spriteBatch.Draw(this.optionUnderlineTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionUnderlineTexture.Width / 2), (float) ((double) yoffset + (double) (100 * this.selectIndex) + 50.0)), Color.White);
      spriteBatch.Draw(this.optionScenarioTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionScenarioTexture.Width / 2), yoffset), Color.White);
      yoffset += 100f;
      spriteBatch.Draw(this.optionVersusTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionVersusTexture.Width / 2), yoffset), Color.White);
      yoffset += 100f;
      spriteBatch.Draw(this.optionOptionsTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionOptionsTexture.Width / 2), yoffset), Color.White);
      yoffset += 100f;
    }

    public void DrawLevelSelect(
      GameTime gameTime,
      SpriteBatch spriteBatch,
      float yoffset,
      bool pvp)
    {
      yoffset -= 50f;
      int num = 10;
      Color white = Color.White;
      Texture2D thumbTexture;
      Texture2D titleTexture;
      bool noTrial;
      if (pvp)
      {
        thumbTexture = ((LevelDefinition) this.pvpLevels[this.selectedLevelIndex]).thumbTexture;
        titleTexture = ((LevelDefinition) this.pvpLevels[this.selectedLevelIndex]).titleTexture;
        noTrial = ((LevelDefinition) this.pvpLevels[this.selectedLevelIndex]).noTrial;
      }
      else
      {
        thumbTexture = ((LevelDefinition) this.normalLevels[this.selectedLevelIndex]).thumbTexture;
        titleTexture = ((LevelDefinition) this.normalLevels[this.selectedLevelIndex]).titleTexture;
        noTrial = ((LevelDefinition) this.normalLevels[this.selectedLevelIndex]).noTrial;
      }
      if (this.levelFadingIn)
        white.A = (byte) (((double) this.levelFadeTotal - (double) this.levelFade) / (double) this.levelFadeTotal * (double) byte.MaxValue);
      else if (this.levelFadingOut)
        white.A = (byte) ((double) this.levelFade / (double) this.levelFadeTotal * (double) byte.MaxValue);
      spriteBatch.Draw(thumbTexture, new Rectangle(this.game.dim.Width / 2 - thumbTexture.Width / 2 + 12 + num, (int) yoffset + 14, 465, 322), white);
      spriteBatch.Draw(titleTexture, new Vector2((float) (this.game.dim.Width / 2 - titleTexture.Width / 2 - 5 + num), (float) ((int) yoffset + 365)), new Color((byte) 0, (byte) 0, (byte) 0, white.A));
      spriteBatch.Draw(this.levelThumbFrameTexture, new Vector2((float) (this.game.dim.Width / 2 - this.levelThumbFrameTexture.Width / 2 + num), yoffset), Color.White);
      yoffset += 100f;
      spriteBatch.Draw(this.levelSelectLeftTexture, new Vector2((float) (this.game.dim.Width / 2 - this.levelSelectLeftTexture.Width / 2 - 300 + num), (float) ((int) yoffset + 50)), new Color((byte) 0, (byte) 0, (byte) 0, (byte) ((double) this.levelLeftFade * (double) byte.MaxValue)));
      spriteBatch.Draw(this.levelSelectRightTexture, new Vector2((float) (this.game.dim.Width / 2 - this.levelSelectRightTexture.Width / 2 + 290 + num), (float) ((int) yoffset + 50)), new Color((byte) 0, (byte) 0, (byte) 0, (byte) ((double) this.levelRightFade * (double) byte.MaxValue)));
     // if (!noTrial || !Guide.IsTrialMode)
      //  return;

//      spriteBatch.Draw(this.guiNoTrialTexture, new Vector2((float) (this.game.dim.Width / 2 - this.guiNoTrialTexture.Width / 2 - 5 + num), (float) ((int) yoffset + 30)), Color.White);
    }

    public void DrawOptions(GameTime gameTime, SpriteBatch spriteBatch, float yoffset)
    {
      spriteBatch.Draw(this.optionUnderlineTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionUnderlineTexture.Width / 2), (float) ((double) yoffset + (double) (100 * this.selectIndex) + 50.0)), Color.White);
      spriteBatch.Draw(this.optionBrightnessTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionBrightnessTexture.Width / 2), yoffset), Color.White);
      yoffset += 100f;
      spriteBatch.Draw(this.optionScreenSizeTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionScreenSizeTexture.Width / 2), yoffset), Color.White);
      yoffset += 100f;
    }

    public void DrawBrightness(GameTime gameTime, SpriteBatch spriteBatch, float yoffset)
    {
      spriteBatch.Draw(this.optionBrightnessTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionBrightnessTexture.Width / 2), yoffset), Color.White);
      yoffset += 100f;
      this.DrawSlider(gameTime, spriteBatch, yoffset, this.game.gamma);
    }

    public void DrawScreenSize(GameTime gameTime, SpriteBatch spriteBatch, float yoffset)
    {
      spriteBatch.Draw(this.optionScreenSizeTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionScreenSizeTexture.Width / 2), yoffset), Color.White);
      yoffset += 100f;
      this.DrawSlider(gameTime, spriteBatch, yoffset, this.game.globalScale - 0.5f);
    }

    public void DrawSlider(GameTime gameTime, SpriteBatch spriteBatch, float yoffset, float value)
    {
      spriteBatch.Draw(this.optionSliderTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionSliderTexture.Width / 2), yoffset), Color.White);
      spriteBatch.Draw(this.optionSliderMarkerTexture, new Vector2((float) (this.game.dim.Width / 2 - this.optionSliderMarkerTexture.Width / 2) + (float) ((double) value * (double) (this.optionSliderTexture.Width - this.optionSliderMarkerTexture.Width / 2) - (double) (this.optionSliderTexture.Width - this.optionSliderMarkerTexture.Width / 2) / 2.0), yoffset), Color.White);
    }

    public void DrawHighScores(GameTime gameTime, SpriteBatch spriteBatch, float yoffset)
    {
      for (int index = 0; index < MainMenu.highScores.scores.Length; ++index)
      {
        double x1 = (double) this.highScoresFont.MeasureString(MainMenu.highScores.scores[index].name + "   " + (object) MainMenu.highScores.scores[index].points).X;
        float x2 = this.highScoresFont.MeasureString(MainMenu.highScores.scores[index].name).X;
        spriteBatch.DrawString(this.highScoresFont, MainMenu.highScores.scores[index].points.ToString(), new Vector2((float) (this.game.dim.Width / 2 + 33), yoffset), Color.Black);
        spriteBatch.DrawString(this.highScoresFont, MainMenu.highScores.scores[index].name, new Vector2((float) (this.game.dim.Width / 2 - 30) - x2, yoffset), Color.Black);
        yoffset += 60f;
      }
    }

    public void Update(GameTime gameTime, GraphicsDevice graphics)
    {
      if (!this.initialized)
      {
        this.Init(graphics);
      }
      else
      {
        if (this.levelFadingOut || this.levelFadingIn)
        {
          this.levelFade -= (float) gameTime.ElapsedGameTime.Milliseconds;
          if ((double) this.levelFade <= 0.0)
          {
            if (this.levelFadingOut)
            {
              this.levelFadingOut = false;
              this.levelFadingIn = true;
              this.levelFade = this.levelFadeTotal;
              this.selectedLevelIndex = this.pendingSelectedLevelIndex;
            }
            else if (this.levelFadingIn)
              this.levelFadingIn = false;
          }
        }
        this.levelLeftFade = this.selectedLevelIndex <= 0 || this.currentMenu.name != "pvp_level" && this.currentMenu.name != "coop_level" ? MathHelper.Lerp(this.levelLeftFade, this.minLevelArrowFade, (float) gameTime.ElapsedGameTime.Milliseconds / 100f) : MathHelper.Lerp(this.levelLeftFade, 1f, (float) gameTime.ElapsedGameTime.Milliseconds / 100f);
        bool flag = false;
        if (this.currentMenu.name == "coop_level" && this.selectedLevelIndex >= this.normalLevels.Count - 1 || this.currentMenu.name == "pvp_level" && this.selectedLevelIndex >= this.pvpLevels.Count - 1)
          flag = true;
        this.levelRightFade = flag || this.currentMenu.name != "pvp_level" && this.currentMenu.name != "coop_level" ? MathHelper.Lerp(this.levelRightFade, this.minLevelArrowFade, (float) gameTime.ElapsedGameTime.Milliseconds / 100f) : MathHelper.Lerp(this.levelRightFade, 1f, (float) gameTime.ElapsedGameTime.Milliseconds / 100f);
        this.CheckInput(gameTime, graphics);
      }
    }

    public void CheckInput(GameTime gameTime, GraphicsDevice graphics)
    {
      Controls.CheckForMCJoin();
      Controls.CheckForMCLeave();
      if (!Controls.MCSet())
        return;
      if ((Controls.DpadDownUp(PlayerEnum.MC).Down == ButtonState.Pressed || Controls.DpadThumbSticksDownUp(PlayerEnum.MC).Down == ButtonState.Pressed) && this.selectIndex < this.currentMenu.menuDest.Length - 1)
      {
        Game.soundBank.PlayCue("click2");
        ++this.selectIndex;
      }
      if ((Controls.DpadDownUp(PlayerEnum.MC).Up == ButtonState.Pressed || Controls.DpadThumbSticksDownUp(PlayerEnum.MC).Up == ButtonState.Pressed) && this.selectIndex > 0)
      {
        Game.soundBank.PlayCue("click2");
        --this.selectIndex;
      }
      if (Controls.ButtonUpDown(PlayerEnum.MC).B == ButtonState.Pressed && this.currentMenu.parentMenu != "")
      {
        this.currentMenu = this.menus[this.currentMenu.parentMenu];
        this.selectIndex = 0;
        this.selectedLevelIndex = 0;
        Game.soundBank.PlayCue("click2");
      }
      else
      {
        if (Controls.ButtonUpDown(PlayerEnum.MC).A == ButtonState.Pressed && this.selectIndex < this.currentMenu.menuDest.Length)
        {
          if (this.currentMenu.menuDest[this.selectIndex] != "")
          {
            this.currentMenu = this.menus[this.currentMenu.menuDest[this.selectIndex]];
            this.selectIndex = 0;
            Game.soundBank.PlayCue("click2");
            return;
          }
          LevelDefinition levelDefinition = (LevelDefinition) null;
          switch (this.currentMenu.name)
          {
            case "coop_level":
              levelDefinition = (LevelDefinition) this.normalLevels[this.selectedLevelIndex];
              break;
            case "pvp_level":
              levelDefinition = (LevelDefinition) this.pvpLevels[this.selectedLevelIndex];
              break;
          }
          if (levelDefinition != null)
          {
            if (!levelDefinition.noTrial )
            {
              switch (this.currentMenu.name)
              {
                case "coop_level":
                  if (!this.levelFadingIn && !this.levelFadingOut)
                  {
                    this.game.levelToLoad = ((LevelDefinition) this.normalLevels[this.selectedLevelIndex]).index;
                    this.game.SetState(Game.GameState.GAMEMAP);
                    Game.soundBank.PlayCue("click2");
                    break;
                  }
                  break;
                case "pvp_level":
                  if (!this.levelFadingIn && !this.levelFadingOut)
                  {
                    this.game.levelToLoad = ((LevelDefinition) this.pvpLevels[this.selectedLevelIndex]).index;
                    this.game.SetState(Game.GameState.GAMEMAP);
                    Game.soundBank.PlayCue("click2");
                    break;
                  }
                  break;
              }
            }
            else
              Game.soundBank.PlayCue("buzz");
          }
        }
        if (Controls.ButtonUpDown(PlayerEnum.MC).Back == ButtonState.Pressed)
          this.game.ShutDown();
        switch (this.currentMenu.name)
        {
          case "brightness":
            float gamma = this.game.gamma;
            this.game.gamma += Controls.ThumbSticks(PlayerEnum.MC).Left.X * ((float) gameTime.ElapsedGameTime.Milliseconds / 4000f);
            if ((double) this.game.gamma > 1.0)
              this.game.gamma = 1f;
            else if ((double) this.game.gamma < 0.0)
              this.game.gamma = 0.0f;
            this.sliderClickTimeout -= (float) gameTime.ElapsedGameTime.Milliseconds;
            if ((double) this.game.gamma == (double) gamma || (double) this.sliderClickTimeout > 0.0)
              break;
            Game.soundBank.PlayCue("click2");
            this.sliderClickTimeout = this.sliderClickDelay;
            break;
          case "screensize":
            float globalScale = this.game.globalScale;
            this.game.globalScale += Controls.ThumbSticks(PlayerEnum.MC).Left.X * ((float) gameTime.ElapsedGameTime.Milliseconds / 4000f);
            if ((double) this.game.globalScale > 1.5)
              this.game.globalScale = 1.5f;
            else if ((double) this.game.globalScale < 0.5)
              this.game.globalScale = 0.5f;
            this.sliderClickTimeout -= (float) gameTime.ElapsedGameTime.Milliseconds;
            if ((double) this.game.globalScale == (double) globalScale || (double) this.sliderClickTimeout > 0.0)
              break;
            Game.soundBank.PlayCue("click2");
            this.sliderClickTimeout = this.sliderClickDelay;
            break;
          case "coop_level":
          case "pvp_level":
            bool flag = false;
            if (!this.levelFadingIn && !this.levelFadingOut)
            {
              if ((Controls.DpadDownUp(PlayerEnum.MC).Left == ButtonState.Pressed || Controls.DpadThumbSticksDownUp(PlayerEnum.MC).Left == ButtonState.Pressed) && this.selectedLevelIndex > 0)
              {
                this.pendingSelectedLevelIndex = this.selectedLevelIndex - 1;
                flag = true;
              }
              if (Controls.DpadDownUp(PlayerEnum.MC).Right == ButtonState.Pressed || Controls.DpadThumbSticksDownUp(PlayerEnum.MC).Right == ButtonState.Pressed)
              {
                if (this.currentMenu.name == "coop_level")
                {
                  if (this.selectedLevelIndex < this.normalLevels.Count - 1)
                  {
                    this.pendingSelectedLevelIndex = this.selectedLevelIndex + 1;
                    flag = true;
                  }
                }
                else if (this.selectedLevelIndex < this.pvpLevels.Count - 1)
                {
                  this.pendingSelectedLevelIndex = this.selectedLevelIndex + 1;
                  flag = true;
                }
              }
            }
            if (!flag)
              break;
            this.levelFade = this.levelFadeTotal;
            this.levelFadingOut = true;
            Game.soundBank.PlayCue("click2");
            break;
        }
      }
    }

    private class Submenu
    {
      public string name;
      public string parentMenu;
      public string[] menuDest;

      public Submenu(string name, string parentMenu)
      {
        this.name = name;
        this.parentMenu = parentMenu;
        this.menuDest = new string[0];
      }
    }
  }
}
