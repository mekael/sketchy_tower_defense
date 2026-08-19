// Decompiled with JetBrains decompiler
// Type: TowerDefense.GameMap
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;

namespace TowerDefense
{
  public class GameMap
  {
    public ContentManager content;
    public SpriteFont debugFont;
    public int width;
    public int height;
    public int cellWidth;
    public int cellHeight;
    public Vector2 viewOffset;
    private Tower[,] cells;
    private ArrayList exitTowers;
    private ArrayList spawnTowers;
    public Player[] player;
    public ArrayList monsters;
    public ArrayList projectiles;
    public ArrayList items;
    public ArrayList particleFields;
    public byte[,] searchGraph;
    private Texture2D highlightTexture;
    private Texture2D cellBackTexture;
    private Texture2D levelTexture;
    public Texture2D progressBarBackTexture;
    public Texture2D progressBarOutlineTexture;
    public Texture2D towerLevelTexture;
    public Texture2D rangeDotTexture;
    public Texture2D squareCheckTexture;
    public Texture2D popupGameOverTexture;
    public Texture2D popupWonTexture;
    public Texture2D popupWaitingForTexture;
    public bool p1GameSpeedChangePending;
    public bool p2GameSpeedChangePending;
    public Monster[] upcomingWaves;
    public int upcomingWavesTracked = 6;
    public GUI gui;
    public bool initialized;
    public float waveInterval = 50000f;
    public float spawnToWaitRatio = 0.5f;
    public float waveTime;
    public int waveSpawns;
    public int waveIndex = -1;
    public int wave = -1;
    public int currentLevel;
    public GameSpeed gameSpeed;
    public bool PvP;
    public bool horizontalDivide;
    public Game game;
    public float currentSpeed = 1f;
    public bool mainMenuMode;
    public int levelToLoad;
    public GameState gameState;
    public float popupFade;
    public float totalPopupFade = 2000f;
    public int updateCount;
    public bool showHealthAll;
    public int updateGroup;
    public int updateTotalGroups = 10;

    public GameMap(Game game, IServiceProvider serviceProvider, string path, int levelToLoad)
    {
      this.width = 44;
      this.height = 32;
      this.cellWidth = 30;
      this.cellHeight = 30;
      this.game = game;
      this.content = new ContentManager(serviceProvider, path);
      this.monsters = new ArrayList();
      this.projectiles = new ArrayList();
      this.items = new ArrayList();
      this.particleFields = new ArrayList();
      this.levelToLoad = levelToLoad;
      this.mainMenuMode = levelToLoad == 0;
      if (!this.mainMenuMode)
        this.gui = new GUI();
      else
        this.gameSpeed = GameSpeed.NORMAL;
      this.upcomingWaves = new Monster[this.upcomingWavesTracked];
    }

    private void Init(GraphicsDevice graphicsDevice)
    {
      if (this.initialized)
        return;
      this.LoadContent();
      this.LoadMap(this.levelToLoad);
      if (!this.mainMenuMode)
        this.gui.SetViewport(new Rectangle(0, 0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height));
      this.waveTime = this.waveInterval;
      this.waveSpawns = 0;
      this.initialized = true;
    }

    public static GameMap Instance => Game.gameMap;

    public void LoadContent()
    {
      this.debugFont = this.content.Load<SpriteFont>("Fonts/debugFont");
      this.highlightTexture = this.content.Load<Texture2D>("Sprites/highlight");
      this.cellBackTexture = this.content.Load<Texture2D>("Sprites/cellback");
      this.progressBarBackTexture = this.content.Load<Texture2D>("Sprites/Towers/tower_progressbar_back");
      this.progressBarOutlineTexture = this.content.Load<Texture2D>("Sprites/Towers/tower_progressbar_outline");
      this.towerLevelTexture = this.content.Load<Texture2D>("Sprites/Towers/leveldot");
      this.rangeDotTexture = this.content.Load<Texture2D>("Sprites/Towers/range_dot");
      this.squareCheckTexture = this.content.Load<Texture2D>("Sprites/GUI/square_check");
      this.popupGameOverTexture = this.content.Load<Texture2D>("Sprites/GUI/popup_gameover");
      this.popupWonTexture = this.content.Load<Texture2D>("Sprites/GUI/popup_won");
      this.popupWaitingForTexture = this.content.Load<Texture2D>("Sprites/GUI/popup_waitingfor");
      if (this.mainMenuMode)
        return;
      this.gui.LoadContent();
    }

    public LevelDefinition Level() => this.currentLevel < 0 || this.currentLevel >= this.game.levels.Count ? (LevelDefinition) null : (LevelDefinition) this.game.levels[this.currentLevel];

    public void StartNextWave()
    {
      for (int index = 0; index < this.upcomingWavesTracked - 1; ++index)
        this.upcomingWaves[index] = this.upcomingWaves[index + 1];
      this.upcomingWaves[this.upcomingWavesTracked - 1] = (Monster) null;
      if (this.waveIndex >= this.Level().waves.Count - 1)
        this.waveIndex = this.Level().waveRepeatIndex - 1;
      int num1 = 0;
      for (int index = 0; index < this.upcomingWavesTracked - 1; ++index)
      {
        if (this.upcomingWaves[index] != null)
          ++num1;
      }
      this.waveTime = this.waveInterval;
      this.waveSpawns = 0;
      ++this.waveIndex;
      ++this.wave;
      Monster monster = (Monster) null;
      int index1 = this.waveIndex + num1;
      int num2 = index1;
      for (int index2 = index1; num2 < this.waveIndex + this.upcomingWavesTracked && (this.Level().waveRepeatIndex == -1 && index2 < this.Level().waves.Count || this.Level().waveRepeatIndex != -1); ++index2)
      {
        if (index1 >= this.Level().waves.Count)
          index1 = this.Level().waveRepeatIndex + index1 % this.Level().waves.Count;
        switch (((WaveDefinition) this.Level().waves[index1]).type)
        {
          case SpawnType.SPAWNTYPE_SNOTGOBLIN:
            monster = (Monster) new SnotGoblin(1, false);
            break;
          case SpawnType.SPAWNTYPE_PIGSPIDER:
            monster = (Monster) new PigSpider(1, false);
            break;
          case SpawnType.SPAWNTYPE_FRUITBAT:
            monster = (Monster) new FruitBat(1, false);
            break;
          case SpawnType.SPAWNTYPE_STINKSLIME:
            monster = (Monster) new StinkSlime(1, false);
            break;
          case SpawnType.SPAWNTYPE_SWARMWORM:
            monster = (Monster) new SwarmWorm(1, false);
            break;
          case SpawnType.SPAWNTYPE_BIGUN:
            monster = (Monster) new Bigun(1, false);
            break;
          case SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN:
            monster = (Monster) new SnotGoblin(1, true);
            break;
          case SpawnType.SPAWNTYPE_BOSS_PIGSPIDER:
            monster = (Monster) new PigSpider(1, true);
            break;
          case SpawnType.SPAWNTYPE_BOSS_FRUITBAT:
            monster = (Monster) new FruitBat(1, true);
            break;
          case SpawnType.SPAWNTYPE_BOSS_STINKSLIME:
            monster = (Monster) new StinkSlime(1, true);
            break;
          case SpawnType.SPAWNTYPE_BOSS_SWARMWORM:
            monster = (Monster) new SwarmWorm(1, true);
            break;
          case SpawnType.SPAWNTYPE_BOSS_BIGUN:
            monster = (Monster) new Bigun(1, true);
            break;
        }
        if (monster != null)
        {
          for (int index3 = 0; index3 < this.upcomingWavesTracked; ++index3)
          {
            if (this.upcomingWaves[index3] == null)
            {
              this.upcomingWaves[index3] = monster;
              break;
            }
          }
        }
        ++index1;
        ++num2;
      }
      for (int index4 = 0; index4 < this.height; ++index4)
      {
        for (int index5 = 0; index5 < this.width; ++index5)
        {
          if (this.cells[index5, index4] is Spawner && (index4 == 0 || this.cells[index5, index4 - 1] != this.cells[index5, index4]) && (index5 == 0 || this.cells[index5 - 1, index4] != this.cells[index5, index4]))
            ((Spawner) this.cells[index5, index4]).StartNextWave();
        }
      }
    }

    public Tower CreateNewTower(TowerType type)
    {
      Tower newTower = (Tower) null;
      switch (type)
      {
        case TowerType.BLOCK:
          newTower = (Tower) new Block();
          break;
        case TowerType.SPAWNER:
          newTower = (Tower) new Spawner();
          break;
        case TowerType.EXIT:
          newTower = (Tower) new Exit();
          break;
        case TowerType.ARROW:
          newTower = (Tower) new ArrowTower();
          break;
        case TowerType.BOMB:
          newTower = (Tower) new BombTower();
          break;
        case TowerType.AIR:
          newTower = (Tower) new AirTower();
          break;
        case TowerType.ICE:
          newTower = (Tower) new IceTower();
          break;
        case TowerType.SNIPER:
          newTower = (Tower) new SniperTower();
          break;
        case TowerType.PIT:
          newTower = (Tower) new PitTower();
          break;
        case TowerType.DMGBOOST:
          newTower = (Tower) new DmgBoostTower();
          break;
        case TowerType.RNGBOOST:
          newTower = (Tower) new RngBoostTower();
          break;
      }
      return newTower;
    }

    public void LoadMap(int levelIndex)
    {
      Controls.ResetNonMC();
      this.p1GameSpeedChangePending = false;
      this.p2GameSpeedChangePending = false;
      this.currentLevel = levelIndex;
      LevelDefinition levelDefinition = this.Level();
      this.PvP = levelDefinition.PvP;
      this.horizontalDivide = levelDefinition.horizontalDivide;
      if (this.currentLevel > 0)
        this.levelTexture = this.content.Load<Texture2D>("Sprites/levels/" + levelDefinition.levelTextureFile);
      this.cells = new Tower[levelDefinition.width, levelDefinition.height];
      for (int x = 0; x < this.width; ++x)
      {
        for (int y = 0; y < this.height; ++y)
        {
          if (levelDefinition.blocks[x, y] == (byte) 1)
            this.AddTower((Tower) new Block(), x, y);
          else
            this.cells[x, y] = (Tower) null;
        }
      }
      ArrayList arrayList = new ArrayList();
      this.exitTowers = new ArrayList();
      this.spawnTowers = new ArrayList();
      foreach (TowerDefinition tower in levelDefinition.towers)
      {
        Tower newTower = this.CreateNewTower(tower.type);
        newTower.level = tower.level;
        newTower.SetOwner(tower.ownerIndex);
        newTower.SetPosition(tower.x, tower.y);
        newTower.towerId = tower.towerId;
        if (newTower is Spawner)
        {
          this.spawnTowers.Add((object) newTower);
          newTower.rot = tower.rotation;
        }
        this.AddTower(newTower, tower.x, tower.y);
      }
      this.GetSearchGraph(ref this.searchGraph);
      for (int index1 = 0; index1 < this.height; index1 += 2)
      {
        for (int index2 = 0; index2 < this.width; index2 += 2)
        {
          if (this.cells[index2, index1] is Spawner)
          {
            Spawner cell1 = (Spawner) this.cells[index2, index1];
            for (int index3 = 0; index3 < this.height; index3 += 2)
            {
              for (int index4 = 0; index4 < this.width; index4 += 2)
              {
                if (this.cells[index4, index3] is Exit)
                {
                  Exit cell2 = (Exit) this.cells[index4, index3];
                  if (cell1.towerId == cell2.towerId)
                  {
                    cell1.exit = cell2;
                    cell2.spawner = cell1;
                    this.exitTowers.Add((object) cell2);
                    break;
                  }
                }
              }
            }
          }
        }
      }
      this.CheckAndAssignAllPaths();
      int num1 = this.width / 2;
      int num2 = this.height / 2;
      if (!this.mainMenuMode)
      {
        this.player = new Player[2];
        this.player[0] = new Player();
        this.player[1] = new Player();
        this.player[0].index = PlayerEnum.P1;
        this.player[1].index = PlayerEnum.P2;
        this.player[0].pos = new Vector2(400f, 400f);
        this.player[1].pos = new Vector2(600f, 400f);
        this.player[0].Active = true;
        this.player[1].Active = false;
      }
      if (levelDefinition.startMoney > 0)
      {
        this.player[0].money = levelDefinition.startMoney;
        if (this.PvP)
          this.player[1].money = levelDefinition.startMoney;
      }
      this.gameState = GameState.PLAYING;
      for (int index = 0; index < this.upcomingWavesTracked; ++index)
        this.upcomingWaves[index] = (Monster) null;
      this.StartNextWave();
    }

    public bool RemoveTower(int x, int y) => x >= 0 && y >= 0 && x < this.width && y < this.width && this.RemoveTower(this.cells[x, y]);

    public bool RemoveTower(Tower tower)
    {
      if (tower == null)
        return false;
      bool flag = false;
      for (int index1 = 0; index1 < this.width; ++index1)
      {
        for (int index2 = 0; index2 < this.height; ++index2)
        {
          if (this.cells[index1, index2] == tower)
          {
            this.cells[index1, index2] = (Tower) null;
            flag = true;
          }
        }
      }
      if (flag)
        this.CheckAndAssignAllPaths();
      return flag;
    }

    public bool SpaceForTower(int size, int x, int y)
    {
      if (x < 0 || y < 0 || x > this.width - size || y > this.height - size)
        return false;
      foreach (Monster monster in this.monsters)
      {
        int num1 = (int) ((double) monster.pos.X / (double) this.cellWidth);
        int num2 = (int) ((double) monster.pos.Y / (double) this.cellHeight);
        if (num1 >= x && num2 >= y && num1 < x + size && num2 < y + size)
          return false;
      }
      switch (size)
      {
        case 1:
          if (this.cells[x, y] != null)
            return false;
          break;
        case 2:
          if (this.cells[x, y] != null || this.cells[x + 1, y] != null || this.cells[x, y + 1] != null || this.cells[x + 1, y + 1] != null)
            return false;
          break;
        case 3:
          if (this.cells[x, y] != null || this.cells[x + 1, y] != null || this.cells[x + 2, y] != null || this.cells[x, y + 1] != null || this.cells[x + 1, y + 1] != null || this.cells[x + 2, y + 1] != null || this.cells[x, y + 2] != null || this.cells[x + 1, y + 2] != null || this.cells[x + 2, y + 2] != null)
            return false;
          break;
      }
      return true;
    }

    public Tower GetTowerAt(int x, int y) => x < 0 || y < 0 || x > this.width - 1 || y > this.height - 1 ? (Tower) null : this.cells[x, y];

    public Exit GetExitTower(PlayerEnum p, int offset)
    {
      ArrayList arrayList = new ArrayList();
      Tower[,] cells = this.cells;
      int upperBound1 = cells.GetUpperBound(0);
      int upperBound2 = cells.GetUpperBound(1);
      for (int lowerBound1 = cells.GetLowerBound(0); lowerBound1 <= upperBound1; ++lowerBound1)
      {
        for (int lowerBound2 = cells.GetLowerBound(1); lowerBound2 <= upperBound2; ++lowerBound2)
        {
          Tower tower = cells[lowerBound1, lowerBound2];
          if (tower is Exit && (p == tower.ownerPlayerIndex || tower.ownerPlayerIndex == PlayerEnum.NONE))
            arrayList.Add((object) tower);
        }
      }
      if (arrayList.Count == 0)
        return (Exit) null;
      offset %= arrayList.Count;
      return (Exit) arrayList[offset];
    }

    public Monster GetGroundMonsterAt(int x, int y)
    {
      foreach (Monster monster in this.monsters)
      {
        if (!(monster is FruitBat) && monster.x == x && monster.y == y)
          return monster;
      }
      return (Monster) null;
    }

    public bool CheckAndAssignAllPaths()
    {
      byte[,] numArray = (byte[,]) null;
      this.GetSearchGraph(ref numArray);
      foreach (Exit exitTower in this.exitTowers)
        LeePathFinder.FillGrid(new Point(exitTower.x, exitTower.y + 1), ref numArray, ref exitTower.newPathGrid);
      bool flag = this.AssignAllPaths();
      if (flag)
        this.searchGraph = numArray;
      return flag;
    }

    public bool AssignAllPaths()
    {
      foreach (Exit exitTower in this.exitTowers)
      {
        if (exitTower.newPathGrid[exitTower.spawner.x, exitTower.spawner.y] == LeePathFinder.INVALID_PATH_CELL)
          return false;
      }
      foreach (Monster monster in this.monsters)
      {
        Exit exit = monster.spawner.exit;
        if (!(monster is FruitBat) && monster.spawner.exit.newPathGrid[monster.x, monster.y] == LeePathFinder.INVALID_PATH_CELL)
          return false;
      }
      foreach (Exit exitTower in this.exitTowers)
        exitTower.pathGrid = exitTower.newPathGrid;
      foreach (Monster monster in this.monsters)
        monster.ResetNextCell();
      return true;
    }

    public bool AddTower(Tower tower, int x, int y)
    {
      if (!this.SpaceForTower(tower.Size, x, y))
        return false;
      if (tower.Size == 1)
      {
        this.cells[x, y] = tower;
        tower.pos = new Vector2((float) (x * this.cellWidth + this.cellWidth / 2), (float) (y * this.cellHeight + this.cellHeight / 2));
        tower.x = x;
        tower.y = y;
      }
      else if (tower.Size == 2)
      {
        this.cells[x, y] = tower;
        this.cells[x + 1, y] = tower;
        this.cells[x, y + 1] = tower;
        this.cells[x + 1, y + 1] = tower;
        tower.pos = new Vector2((float) ((x + 1) * this.cellWidth), (float) ((y + 1) * this.cellHeight));
        tower.x = x;
        tower.y = y;
      }
      else if (tower.Size == 3)
      {
        this.cells[x, y] = tower;
        this.cells[x + 1, y] = tower;
        this.cells[x + 2, y] = tower;
        this.cells[x, y + 1] = tower;
        this.cells[x + 1, y + 1] = tower;
        this.cells[x + 2, y + 1] = tower;
        this.cells[x, y + 2] = tower;
        this.cells[x + 1, y + 2] = tower;
        this.cells[x + 2, y + 2] = tower;
        tower.pos = new Vector2((float) (x * this.cellWidth + this.cellWidth + this.cellWidth / 2), (float) (y * this.cellHeight + this.cellHeight + this.cellHeight / 2));
        tower.x = x;
        tower.y = y;
      }
      if (tower is Block || this.CheckAndAssignAllPaths())
        return true;
      for (int index1 = 0; index1 < this.height; ++index1)
      {
        for (int index2 = 0; index2 < this.width; ++index2)
        {
          if (this.cells[index2, index1] == tower)
            this.cells[index2, index1] = (Tower) null;
        }
      }
      this.CheckAndAssignAllPaths();
      return false;
    }

    public bool AddMonster(Monster monster, Vector2 pos)
    {
      if (!this.IsTowerPassable((int) pos.X / this.cellWidth, (int) pos.Y / this.cellHeight, CollisionType.BOUNDARIES | CollisionType.BLOCKS))
        return false;
      this.monsters.Add((object) monster);
      monster.pos = pos;
      return true;
    }

    public bool RemoveMonster(Monster monster)
    {
      int index = this.monsters.IndexOf((object) monster);
      if (index == -1)
        return false;
      this.monsters.RemoveAt(index);
      return true;
    }

    public bool AddItem(Item item, Vector2 pos)
    {
      int num1 = (int) pos.X / this.cellWidth;
      int num2 = (int) pos.Y / this.cellHeight;
      this.items.Add((object) item);
      item.pos = pos;
      return true;
    }

    public void DrawCellBackground(SpriteBatch spriteBatch)
    {
      Vector2 vector2 = this.viewOffset;
      if (this.mainMenuMode)
        vector2 = new Vector2(0.0f, 0.0f);
      for (int x = -this.cellBackTexture.Width; x < this.game.dim.Width; x += this.cellBackTexture.Width)
      {
        for (int y = -this.cellBackTexture.Height; y < this.game.dim.Width; y += this.cellBackTexture.Height)
          spriteBatch.Draw(this.cellBackTexture, vector2 + new Vector2((float) x, (float) y), new Rectangle?(), Color.White);
      }
    }

    public void DrawLevelBackground(SpriteBatch spriteBatch) => spriteBatch.Draw(this.levelTexture, this.viewOffset, new Rectangle?(), Color.White);

    public bool WaitingOnPlayer(PlayerEnum p) => this.PvP && this.updateCount >= 5 && (p == PlayerEnum.P1 && !this.player[0].Active || p == PlayerEnum.P2 && !this.player[1].Active);

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (!this.initialized)
        return;
      float num1 = (float) (this.width * this.cellWidth - this.game.dim.Width);
      float num2 = (float) (this.height * this.cellHeight - this.game.dim.Height);
      if (this.width * this.cellWidth < this.game.dim.Width)
      {
        this.viewOffset.X = (float) ((this.game.dim.Width - this.width * this.cellWidth) / 2);
      }
      else
      {
        if ((double) this.viewOffset.X > 0.0)
          this.viewOffset.X = 0.0f;
        if ((double) this.viewOffset.X < -(double) num1)
          this.viewOffset.X = -num1;
      }
      if (this.height * this.cellHeight < this.game.dim.Height)
      {
        this.viewOffset.Y = (float) ((this.game.dim.Height - this.height * this.cellHeight) / 2);
      }
      else
      {
        if ((double) this.viewOffset.Y > 0.0)
          this.viewOffset.Y = 0.0f;
        if ((double) this.viewOffset.Y < -(double) num2)
          this.viewOffset.Y = -num2;
      }
      this.viewOffset = new Vector2(0.0f, 0.0f);
      this.DrawCellBackground(spriteBatch);
      if (!this.mainMenuMode)
        this.DrawLevelBackground(spriteBatch);
      this.viewOffset = new Vector2((float) (GameMap.Instance.cellWidth * 10), 0.0f);
      for (int index1 = 0; index1 < this.width; ++index1)
      {
        for (int index2 = 0; index2 < this.height; ++index2)
        {
          if (this.cells[index1, index2] != null && (index2 == 0 || this.cells[index1, index2 - 1] != this.cells[index1, index2]) && (index1 == 0 || this.cells[index1 - 1, index2] != this.cells[index1, index2]))
            this.cells[index1, index2].Draw(this.viewOffset, gameTime, spriteBatch);
        }
      }
      foreach (Sprite sprite in this.items)
        sprite.Draw(this.viewOffset, gameTime, spriteBatch);
      foreach (Sprite monster in this.monsters)
        monster.Draw(this.viewOffset, gameTime, spriteBatch);
      foreach (Sprite particleField in this.particleFields)
        particleField.Draw(this.viewOffset, gameTime, spriteBatch);
      foreach (Projectile projectile in this.projectiles)
        projectile?.Draw(this.viewOffset, gameTime, spriteBatch);
      if (!this.mainMenuMode)
      {
        this.player[0].Draw(this.viewOffset, gameTime, spriteBatch);
        this.player[1].Draw(this.viewOffset, gameTime, spriteBatch);
      }
      if (!this.mainMenuMode)
        this.gui.Draw(gameTime, spriteBatch);
      if (this.gameState == GameState.P1P2LOSE)
        this.DrawGameOverPopup(spriteBatch, gameTime);
      if (this.gameState == GameState.P1LOSES)
        this.DrawWonPopup(spriteBatch, gameTime, PlayerEnum.P2);
      if (this.gameState == GameState.P2LOSES)
        this.DrawWonPopup(spriteBatch, gameTime, PlayerEnum.P1);
      if (!this.WaitingOnPlayer(PlayerEnum.P1) && !this.WaitingOnPlayer(PlayerEnum.P2))
        return;
      this.DrawWaitingForPopup(spriteBatch, gameTime, this.WaitingOnPlayer(PlayerEnum.P1), this.WaitingOnPlayer(PlayerEnum.P2));
    }

    public void DrawGameOverPopup(SpriteBatch spriteBatch, GameTime gameTime)
    {
      float a1 = (double) this.popupFade > (double) this.totalPopupFade * 0.25 ? 1f : this.popupFade / (this.totalPopupFade * 0.25f);
      float a2;
      if ((double) this.popupFade >= (double) this.totalPopupFade * 0.75)
      {
        a2 = (float) (((double) this.popupFade - (double) this.totalPopupFade * 0.75) / ((double) this.totalPopupFade * 0.25));
        if ((double) a2 > 1.0)
          a2 = 1f;
      }
      else
        a2 = 0.0f;
      spriteBatch.Draw(this.popupGameOverTexture, new Vector2((float) (this.game.dim.Width / 2 - this.popupGameOverTexture.Width / 2), (float) this.game.dim.Height * 0.33f), new Color(1f, 1f, 1f, a1));
      spriteBatch.Draw(this.gui.guiButtonATexture, new Vector2((float) (this.game.dim.Width / 2 - this.gui.guiButtonATexture.Width / 2), (float) ((double) this.game.dim.Height * 0.33000001311302185 + 100.0)), new Color(1f, 1f, 1f, a2));
    }

    public void DrawWonPopup(SpriteBatch spriteBatch, GameTime gameTime, PlayerEnum p)
    {
      if (this.gui == null)
        return;
      float a1 = (double) this.popupFade > (double) this.totalPopupFade * 0.25 ? 1f : this.popupFade / (this.totalPopupFade * 0.25f);
      float a2;
      if ((double) this.popupFade >= (double) this.totalPopupFade * 0.75)
      {
        a2 = (float) (((double) this.popupFade - (double) this.totalPopupFade * 0.75) / ((double) this.totalPopupFade * 0.25));
        if ((double) a2 > 1.0)
          a2 = 1f;
      }
      else
        a2 = 0.0f;
      spriteBatch.Draw(this.popupWonTexture, new Vector2((float) (this.game.dim.Width / 2 - this.popupWonTexture.Width / 2), (float) this.game.dim.Height * 0.33f), new Color(1f, 1f, 1f, a1));
      switch (p)
      {
        case PlayerEnum.P1:
          spriteBatch.Draw(this.gui.guiTextPlayerOneTexture, new Vector2((float) (this.game.dim.Width / 2 - this.gui.guiTextPlayerOneTexture.Width / 2), (float) ((double) this.game.dim.Height * 0.33000001311302185 + 40.0)), this.game.playerOneColor);
          break;
        case PlayerEnum.P2:
          spriteBatch.Draw(this.gui.guiTextPlayerTwoTexture, new Vector2((float) (this.game.dim.Width / 2 - this.gui.guiTextPlayerTwoTexture.Width / 2), (float) ((double) this.game.dim.Height * 0.33000001311302185 + 40.0)), this.game.playerTwoColor);
          break;
      }
      spriteBatch.Draw(this.gui.guiButtonATexture, new Vector2((float) (this.game.dim.Width / 2 - this.gui.guiButtonATexture.Width / 2), (float) ((double) this.game.dim.Height * 0.33000001311302185 + 140.0)), new Color(1f, 1f, 1f, a2));
    }

    public void DrawWaitingForPopup(SpriteBatch spriteBatch, GameTime gameTime, bool p1, bool p2)
    {
      if (this.gui == null || !p1 && !p2)
        return;
      float a = (double) this.popupFade > (double) this.totalPopupFade * 0.25 ? 1f : this.popupFade / (this.totalPopupFade * 0.25f);
      spriteBatch.Draw(this.popupWaitingForTexture, new Vector2((float) (this.game.dim.Width / 2 - this.popupWaitingForTexture.Width / 2), (float) this.game.dim.Height * 0.33f), new Color(1f, 1f, 1f, a));
      if (p1 & p2)
      {
        spriteBatch.Draw(this.gui.guiTextPlayerOneTexture, new Vector2((float) (this.game.dim.Width / 2 - 200), (float) ((double) this.game.dim.Height * 0.33000001311302185 + 110.0)), this.game.playerOneColor);
        spriteBatch.Draw(this.gui.guiTextPlayerTwoTexture, new Vector2((float) (this.game.dim.Width / 2 + 25), (float) ((double) this.game.dim.Height * 0.33000001311302185 + 110.0)), this.game.playerTwoColor);
      }
      else if (p1)
        spriteBatch.Draw(this.gui.guiTextPlayerOneTexture, new Vector2((float) (this.game.dim.Width / 2 - this.gui.guiTextPlayerOneTexture.Width / 2), (float) ((double) this.game.dim.Height * 0.33000001311302185 + 110.0)), this.game.playerOneColor);
      else
        spriteBatch.Draw(this.gui.guiTextPlayerTwoTexture, new Vector2((float) (this.game.dim.Width / 2 - this.gui.guiTextPlayerOneTexture.Width / 2), (float) ((double) this.game.dim.Height * 0.33000001311302185 + 110.0)), this.game.playerTwoColor);
    }

    public void CheckForPlayerStarts()
    {
      if (!Controls.P1Set() && Controls.CheckForPlayerJoin(PlayerEnum.P1))
        this.player[0].Active = true;
      if (!Controls.P2Set() && Controls.CheckForPlayerJoin(PlayerEnum.P2))
        this.player[1].Active = true;
      if (Controls.MCSet())
        return;
      Controls.CheckForMCJoin();
    }

    public void CheckForPlayerLeaves()
    {
      if (Controls.P1Set() && Controls.CheckForPlayerLeave(PlayerEnum.P1))
        this.player[0].Active = false;
      if (Controls.P2Set() && Controls.CheckForPlayerLeave(PlayerEnum.P2))
        this.player[1].Active = false;
      if (!Controls.MCSet())
        return;
      Controls.CheckForMCLeave();
    }

    public void ChangeGameState(GameState newState)
    {
      this.gameState = newState;
      this.gameSpeed = GameSpeed.NORMAL;
      this.popupFade = 0.0f;
    }

    public void Update(GameTime gameTime, GraphicsDevice graphics)
    {
      if (!this.initialized)
      {
        this.Init(graphics);
      }
      else
      {
        ++this.updateGroup;
        if (this.updateGroup > this.updateTotalGroups)
          this.updateGroup = 0;
        ++this.updateCount;
        if (!this.mainMenuMode)
        {
          this.CheckInput(gameTime, graphics);
          this.gui.Update(gameTime);
        }
        if (!this.mainMenuMode && this.gameState == GameState.PLAYING)
        {
          this.CheckForPlayerStarts();
          this.CheckForPlayerLeaves();
        }
        if (!this.mainMenuMode)
        {
          this.player[0].Update(gameTime);
          this.player[1].Update(gameTime);
          this.player[0].hoverMonster = (Monster) null;
          this.player[1].hoverMonster = (Monster) null;
        }
        if (this.gameState != GameState.PLAYING || this.WaitingOnPlayer(PlayerEnum.P1) || this.WaitingOnPlayer(PlayerEnum.P2))
        {
          this.popupFade += (float) gameTime.ElapsedGameTime.Milliseconds;
          if ((double) this.popupFade > (double) this.totalPopupFade)
            this.popupFade = this.totalPopupFade;
          if (this.gameState != GameState.P1P2LOSE && this.gameState != GameState.P1LOSES && this.gameState != GameState.P2LOSES || (double) this.popupFade <= (double) this.totalPopupFade * 0.75 || Controls.ButtonUpDown(PlayerEnum.P1).A != ButtonState.Pressed && Controls.ButtonUpDown(PlayerEnum.P1).A != ButtonState.Pressed)
            return;
          this.game.SetState(Game.GameState.MAIN_MENU);
        }
        else
        {
          if (this.gameSpeed == GameSpeed.PREPARE || this.gameSpeed == GameSpeed.NORMAL)
            this.currentSpeed = MathHelper.Lerp(this.currentSpeed, 2f, 0.1f);
          else if (this.gameSpeed == GameSpeed.FAST)
            this.currentSpeed = MathHelper.Lerp(this.currentSpeed, 6f, 0.1f);
          TimeSpan timeSpan = new TimeSpan((long) ((double) gameTime.ElapsedGameTime.Ticks * (double) this.currentSpeed));
          gameTime = new GameTime(gameTime.TotalRealTime, gameTime.ElapsedRealTime, gameTime.TotalGameTime, timeSpan, false);
          foreach (Sprite sprite in this.items)
            sprite.Update(gameTime);
          foreach (Sprite monster in this.monsters)
            monster.Update(gameTime);
          for (int index1 = 0; index1 < this.height; ++index1)
          {
            for (int index2 = 0; index2 < this.width; ++index2)
            {
              if ((index1 == 0 || this.cells[index2, index1 - 1] != this.cells[index2, index1]) && (index2 == 0 || this.cells[index2 - 1, index1] != this.cells[index2, index1]))
                this.cells[index2, index1]?.Update(gameTime);
            }
          }
          foreach (Sprite particleField in this.particleFields)
            particleField.Update(gameTime);
          foreach (Projectile projectile in this.projectiles)
            projectile?.Update(gameTime);
          bool flag1;
          do
          {
            flag1 = false;
            foreach (ParticleField particleField in this.particleFields)
            {
              if (particleField != null && particleField.dead)
              {
                this.particleFields.Remove((object) particleField);
                flag1 = true;
                break;
              }
            }
          }
          while (flag1);
          bool flag2;
          do
          {
            flag2 = false;
            foreach (Monster monster in this.monsters)
            {
              if (monster != null && monster.dead)
              {
                this.RemoveMonster(monster);
                flag2 = true;
                break;
              }
            }
          }
          while (flag2);
          bool flag3;
          do
          {
            flag3 = false;
            for (int index3 = 0; index3 < this.height; ++index3)
            {
              for (int index4 = 0; index4 < this.width; ++index4)
              {
                if ((index3 == 0 || this.cells[index4, index3 - 1] != this.cells[index4, index3]) && (index4 == 0 || this.cells[index4 - 1, index3] != this.cells[index4, index3]))
                {
                  Tower cell = this.cells[index4, index3];
                  if (cell != null && cell is BasicAttackTower && cell.dead)
                    this.RemoveTower(cell);
                }
              }
            }
          }
          while (flag3);
          bool flag4;
          do
          {
            flag4 = false;
            foreach (Projectile projectile in this.projectiles)
            {
              if (projectile != null && projectile.expired)
              {
                this.projectiles.Remove((object) projectile);
                flag4 = true;
                break;
              }
            }
          }
          while (flag4);
          bool flag5;
          do
          {
            flag5 = false;
            foreach (Item obj in this.items)
            {
              if (obj != null && obj.deleteItem)
              {
                this.items.Remove((object) obj);
                flag5 = true;
                break;
              }
            }
          }
          while (flag5);
          this.searchGraph = (byte[,]) null;
          this.WaveUpdate(gameTime);
        }
      }
    }

    public void WaveUpdate(GameTime gameTime)
    {
      if (this.gameSpeed == GameSpeed.PREPARE || this.wave == -1)
        return;
      WaveDefinition wave = (WaveDefinition) this.Level().waves[this.waveIndex];
      int num = (int) ((double) (this.waveInterval * this.spawnToWaitRatio) / (double) wave.count);
      this.waveTime -= (float) gameTime.ElapsedGameTime.Milliseconds;
      if (this.waveSpawns < wave.count * (GameMap.Instance.currentLevel == 40 ? 20 : 1) && (double) this.waveTime < (double) (this.waveInterval - (float) (this.waveSpawns * num)))
      {
        ++this.waveSpawns;
        foreach (Spawner spawnTower in this.spawnTowers)
          spawnTower.SpawnMonster(wave.type, this.wave);
      }
      if ((double) this.waveTime > 0.0)
        return;
      this.waveTime = 0.0f;
      this.StartNextWave();
    }

    public void CheckInput(GameTime gameTime, GraphicsDevice graphics)
    {
      if (this.PvP)
      {
        if (this.p1GameSpeedChangePending && this.p2GameSpeedChangePending)
        {
          if (this.gameSpeed == GameSpeed.PREPARE)
            this.gameSpeed = GameSpeed.NORMAL;
          else if (this.gameSpeed == GameSpeed.NORMAL)
            this.gameSpeed = GameSpeed.FAST;
          else if (this.gameSpeed == GameSpeed.FAST)
            this.gameSpeed = GameSpeed.NORMAL;
          this.p1GameSpeedChangePending = this.p2GameSpeedChangePending = false;
        }
        else if ((this.p1GameSpeedChangePending || this.p2GameSpeedChangePending) && this.gameSpeed == GameSpeed.FAST)
        {
          this.p1GameSpeedChangePending = false;
          this.p2GameSpeedChangePending = false;
          this.gameSpeed = GameSpeed.NORMAL;
        }
        if (Controls.ButtonUpDown(PlayerEnum.P1).B == ButtonState.Pressed)
          this.p1GameSpeedChangePending = !this.p1GameSpeedChangePending;
        if (Controls.ButtonUpDown(PlayerEnum.P2).B == ButtonState.Pressed)
          this.p2GameSpeedChangePending = !this.p2GameSpeedChangePending;
      }
      else if (Controls.ButtonUpDown(PlayerEnum.P1).B == ButtonState.Pressed || Controls.ButtonUpDown(PlayerEnum.P2).B == ButtonState.Pressed)
      {
        if (this.gameSpeed == GameSpeed.PREPARE)
          this.gameSpeed = GameSpeed.NORMAL;
        else if (this.gameSpeed == GameSpeed.NORMAL)
          this.gameSpeed = GameSpeed.FAST;
        else if (this.gameSpeed == GameSpeed.FAST)
          this.gameSpeed = GameSpeed.NORMAL;
      }
      this.viewOffset = new Vector2(0.0f, 0.0f);
      if (Controls.ButtonUpDown(PlayerEnum.MC).Back == ButtonState.Pressed)
        this.game.SetState(Game.GameState.MAIN_MENU);
      if (Controls.ButtonUpDown(PlayerEnum.P1).LeftShoulder != ButtonState.Pressed && Controls.ButtonUpDown(PlayerEnum.P1).RightShoulder != ButtonState.Pressed && Controls.ButtonUpDown(PlayerEnum.P2).LeftShoulder != ButtonState.Pressed && Controls.ButtonUpDown(PlayerEnum.P2).RightShoulder != ButtonState.Pressed)
        return;
      this.showHealthAll = !this.showHealthAll;
    }

    public Vector2 GetPlayerStartPosition() => new Vector2((float) (this.width * this.cellWidth / 2), (float) (this.height * this.cellHeight / 2));

    public bool IsTowerPassable(int x, int y, CollisionType collisionType) => x >= 0 && y >= 0 && x < this.width && (y < this.height || (collisionType & CollisionType.BOUNDARIES) <= CollisionType.NONE) && (this.cells[x, y] == null || this.cells[x, y].Passable || (collisionType & CollisionType.BLOCKS) <= CollisionType.NONE);

    public Vector2 CorrectCharacterPosition(
      Vector2 newPos,
      Vector2 oldPos,
      CollisionType collisionType)
    {
      if (collisionType == CollisionType.NONE)
        return newPos;
      int x1 = (double) newPos.X >= 0.0 ? (int) ((double) newPos.X / (double) this.cellWidth) : -1;
      int y1 = (double) newPos.Y >= 0.0 ? (int) ((double) newPos.Y / (double) this.cellHeight) : -1;
      int x2 = (int) ((double) oldPos.X / (double) this.cellWidth);
      int y2 = (int) ((double) oldPos.Y / (double) this.cellHeight);
      int num1 = x1 - x2;
      int num2 = y1 - y2;
      if (num1 == 0 && num2 == 0)
        return new Vector2(-1000f, -1000f);
      float x3 = (float) (x2 * this.cellWidth);
      float x4 = (float) (x2 * this.cellWidth + this.cellWidth - 1);
      float y3 = (float) (y2 * this.cellHeight);
      float y4 = (float) (y2 * this.cellHeight + this.cellHeight - 1);
      if (!this.IsTowerPassable(x1, y1, collisionType))
      {
        if (num1 == -1 && num2 == -1)
        {
          if (this.IsTowerPassable(x2 - 1, y2, collisionType))
            return new Vector2(newPos.X, y3);
          return this.IsTowerPassable(x2, y2 - 1, collisionType) ? new Vector2(x3, newPos.Y) : new Vector2(x3, y3);
        }
        if (num1 == 0 && num2 == -1)
          return new Vector2(newPos.X, y3);
        if (num1 == 1 && num2 == -1)
        {
          if (this.IsTowerPassable(x2 + 1, y2, collisionType))
            return new Vector2(newPos.X, y3);
          return this.IsTowerPassable(x2, y2 - 1, collisionType) ? new Vector2(x4, newPos.Y) : new Vector2(x4, y3);
        }
        if (num1 == -1 && num2 == 0)
          return new Vector2(x3, newPos.Y);
        if (num1 == 1 && num2 == 0)
          return new Vector2(x4, newPos.Y);
        if (num1 == -1 && num2 == 1)
        {
          if (this.IsTowerPassable(x2 - 1, y2, collisionType))
            return new Vector2(newPos.X, y4);
          return this.IsTowerPassable(x2, y2 + 1, collisionType) ? new Vector2(x3, newPos.Y) : new Vector2(x3, y4);
        }
        if (num1 == 0 && num2 == 1)
          return new Vector2(newPos.X, y4);
        if (num1 != 1 || num2 != 1)
          return new Vector2(-1000f, -1000f);
        if (this.IsTowerPassable(x2 + 1, y2, collisionType))
          return new Vector2(newPos.X, y4);
        return this.IsTowerPassable(x2, y2 + 1, collisionType) ? new Vector2(x4, newPos.Y) : new Vector2(x4, y4);
      }
      if (num1 == -1 && num2 == -1 && !this.IsTowerPassable(x2 - 1, y2, collisionType) && !this.IsTowerPassable(x2, y2 - 1, collisionType))
        return new Vector2(x3, y3);
      if (num1 == 1 && num2 == -1 && !this.IsTowerPassable(x2 + 1, y2, collisionType) && !this.IsTowerPassable(x2, y2 - 1, collisionType))
        return new Vector2(x4, y3);
      if (num1 == -1 && num2 == 1 && !this.IsTowerPassable(x2 - 1, y2, collisionType) && !this.IsTowerPassable(x2, y2 + 1, collisionType))
        return new Vector2(x3, y4);
      return num1 == 1 && num2 == 1 && !this.IsTowerPassable(x2 + 1, y2, collisionType) && !this.IsTowerPassable(x2, y2 + 1, collisionType) ? new Vector2(x4, y4) : new Vector2(-1000f, -1000f);
    }

    public void GetSearchGraph(ref byte[,] retGraph)
    {
      int width = this.width;
      int height = this.height;
      if (retGraph == null)
        retGraph = new byte[width, height];
      for (int y = 0; y < height; ++y)
      {
        for (int x = 0; x < width; ++x)
          retGraph[x, y] = this.IsTowerPassable(x, y, CollisionType.BOUNDARIES | CollisionType.BLOCKS) ? (byte) 0 : byte.MaxValue;
      }
    }
  }
}
