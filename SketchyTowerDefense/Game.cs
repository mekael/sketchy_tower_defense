// Decompiled with JetBrains decompiler
// Type: TowerDefense.Game
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace TowerDefense
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D guiFillerTexture;
        private Texture2D borderLeftTexture;
        private Texture2D borderRightTexture;
        private Texture2D borderTopTexture;
        private Texture2D borderBottomTexture;
        private Controls controls = new Controls();
        public static GameMap gameMap;
        public static MainMenu mainMenu;
        public float globalScale = 1f;
        public float oldGamma;
        public float gamma = 0.5f;
        public Color playerOneColor = Color.DarkSlateBlue;
        public Color playerTwoColor = Color.Firebrick;
        public Rectangle dim = new Rectangle(0, 0, 1920, 1080);
        public ArrayList levels;
        public int levelToLoad;
        public static AudioEngine audioEngine;
        public static WaveBank waveBank;
        public static SoundBank soundBank;
        private Game.GameState state;
        private Game.GameState pendingState;

        public Game()
        {
            this.graphics = new GraphicsDeviceManager((Microsoft.Xna.Framework.Game)this);
            this.Content.RootDirectory = "Content";
            this.oldGamma = -1f;
        }

        private void AddStandardWaves(ref LevelDefinition level)
        {
            level.waves = new ArrayList();
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_FRUITBAT));
            level.waveRepeatIndex = level.waves.Count;
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_PIGSPIDER));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_FRUITBAT));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SWARMWORM));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_BIGUN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_STINKSLIME));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN));
            level.waves.Add((object)new WaveDefinition(SpawnType.SPAWNTYPE_BOSS_SWARMWORM));
        }

        private void LoadLevelDefinitions()
        {
            int num1 = 30;
            int num2 = 30;
            int num3 = 0;
            this.levels = new ArrayList();
            LevelDefinition level1 = new LevelDefinition();
            LevelDefinition levelDefinition1 = level1;
            int num4 = num3;
            int num5 = num4 + 1;
            levelDefinition1.index = num4;
            level1.name = "Main Menu";
            level1.levelTextureFile = "l";
            level1.width = 44;
            level1.height = 32;
            level1.thumbTexture = (Texture2D)null;
            level1.titleTexture = (Texture2D)null;
            level1.towers = new ArrayList();
            TowerDefinition towerDefinition1 = new TowerDefinition(TowerType.SPAWNER, 1, 16, 0, PlayerEnum.NONE, 1, 0.0f);
            level1.towers.Add((object)towerDefinition1);
            TowerDefinition towerDefinition2 = new TowerDefinition(TowerType.EXIT, 41, 16, 0, PlayerEnum.NONE, 1, 0.0f);
            level1.towers.Add((object)towerDefinition2);
            TowerDefinition towerDefinition3 = new TowerDefinition(TowerType.BLOCK, 17, 13, 0, PlayerEnum.P1, 1, 0.0f);
            level1.towers.Add((object)towerDefinition3);
            TowerDefinition towerDefinition4 = new TowerDefinition(TowerType.BLOCK, 17, 14, 0, PlayerEnum.P1, 1, 0.0f);
            level1.towers.Add((object)towerDefinition4);
            TowerDefinition towerDefinition5 = new TowerDefinition(TowerType.ARROW, 17, 15, 0, PlayerEnum.P1, 1, 0.0f);
            level1.towers.Add((object)towerDefinition5);
            TowerDefinition towerDefinition6 = new TowerDefinition(TowerType.BOMB, 25, 16, 0, PlayerEnum.P1, 1, 0.0f);
            level1.towers.Add((object)towerDefinition6);
            TowerDefinition towerDefinition7 = new TowerDefinition(TowerType.BLOCK, 25, 18, 0, PlayerEnum.P1, 1, 0.0f);
            level1.towers.Add((object)towerDefinition7);
            TowerDefinition towerDefinition8 = new TowerDefinition(TowerType.BLOCK, 25, 19, 0, PlayerEnum.P1, 1, 0.0f);
            level1.towers.Add((object)towerDefinition8);
            level1.noTrial = false;
            this.AddStandardWaves(ref level1);



            level1.blocks = new byte[44, 32]
            {
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        }
            };



            this.levels.Add((object)level1);
            LevelDefinition level2 = new LevelDefinition();
            LevelDefinition levelDefinition2 = level2;
            int num6 = num5;
            int num7 = num6 + 1;
            levelDefinition2.index = num6;
            level2.name = "The Beginning";
            level2.levelTextureFile = "level9";
            level2.width = 44;
            level2.height = 32;
            level2.thumbTexture = this.Content.Load<Texture2D>("Sprites/Levels/level9_thumb");
            level2.titleTexture = this.Content.Load<Texture2D>("Sprites/Levels/level9_title");
            level2.towers = new ArrayList();
            TowerDefinition towerDefinition9 = new TowerDefinition(TowerType.SPAWNER, 0, 15, 0, PlayerEnum.NONE, 1, 0.0f);
            level2.towers.Add((object)towerDefinition9);
            TowerDefinition towerDefinition10 = new TowerDefinition(TowerType.EXIT, 40, 15, 0, PlayerEnum.NONE, 1, 0.0f);
            level2.towers.Add((object)towerDefinition10);
            level2.noTrial = false;
            this.AddStandardWaves(ref level2);
            level2.PvP = false;
            level2.startMoney = 100;
            level2.startMoneyLocation = new Vector2((float)(20 * num1), (float)(16 * num2));
            level2.blocks = new byte[44, 32]
            {
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        }
            };
            this.levels.Add((object)level2);
            LevelDefinition level3 = new LevelDefinition();
            LevelDefinition levelDefinition3 = level3;
            int num8 = num7;
            int num9 = num8 + 1;
            levelDefinition3.index = num8;
            level3.name = "The Beginning";
            level3.levelTextureFile = "level1";
            level3.width = 44;
            level3.height = 32;
            level3.thumbTexture = this.Content.Load<Texture2D>("Sprites/Levels/level1_thumb");
            level3.titleTexture = this.Content.Load<Texture2D>("Sprites/Levels/level1_title");
            level3.towers = new ArrayList();
            TowerDefinition towerDefinition11 = new TowerDefinition(TowerType.SPAWNER, 0, 20, 0, PlayerEnum.NONE, 1, 0.0f);
            level3.towers.Add((object)towerDefinition11);
            TowerDefinition towerDefinition12 = new TowerDefinition(TowerType.EXIT, 40, 16, 0, PlayerEnum.NONE, 1, 0.0f);
            level3.towers.Add((object)towerDefinition12);
            TowerDefinition towerDefinition13 = new TowerDefinition(TowerType.EXIT, 20, 28, 0, PlayerEnum.NONE, 2, 0.0f);
            level3.towers.Add((object)towerDefinition13);
            TowerDefinition towerDefinition14 = new TowerDefinition(TowerType.SPAWNER, 21, 2, 0, PlayerEnum.NONE, 2, 1.57079637f);
            level3.towers.Add((object)towerDefinition14);
            level3.noTrial = true;
            this.AddStandardWaves(ref level3);
            level3.PvP = false;
            level3.startMoney = 100;
            level3.startMoneyLocation = new Vector2((float)(20 * num1), (float)(16 * num2));
            level3.blocks = new byte[44, 32]
            {
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        }
            };
            this.levels.Add((object)level3);
            LevelDefinition level4 = new LevelDefinition();
            LevelDefinition levelDefinition4 = level4;
            int num10 = num9;
            int num11 = num10 + 1;
            levelDefinition4.index = num10;
            level4.name = "PvP";
            level4.levelTextureFile = "level2";
            level4.width = 44;
            level4.height = 32;
            level4.thumbTexture = this.Content.Load<Texture2D>("Sprites/Levels/level2_thumb");
            level4.titleTexture = this.Content.Load<Texture2D>("Sprites/Levels/level2_title");
            level4.towers = new ArrayList();
            TowerDefinition towerDefinition15 = new TowerDefinition(TowerType.SPAWNER, 0, 8, 0, PlayerEnum.P1, 1, 0.0f);
            level4.towers.Add((object)towerDefinition15);
            TowerDefinition towerDefinition16 = new TowerDefinition(TowerType.EXIT, 41, 8, 0, PlayerEnum.P1, 1, 0.0f);
            level4.towers.Add((object)towerDefinition16);
            TowerDefinition towerDefinition17 = new TowerDefinition(TowerType.EXIT, 41, 23, 0, PlayerEnum.P2, 2, 0.0f);
            level4.towers.Add((object)towerDefinition17);
            TowerDefinition towerDefinition18 = new TowerDefinition(TowerType.SPAWNER, 0, 23, 0, PlayerEnum.P2, 2, 0.0f);
            level4.towers.Add((object)towerDefinition18);
            this.AddStandardWaves(ref level4);
            level4.noTrial = false;
            level4.PvP = true;
            level4.horizontalDivide = true;
            level4.startMoney = 100;
            level4.startMoneyLocation = new Vector2((float)(20 * num1), (float)(16 * num2));
            level4.blocks = new byte[44, 32]
            {
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        }
            };
            this.levels.Add((object)level4);
            LevelDefinition level5 = new LevelDefinition();
            LevelDefinition levelDefinition5 = level5;
            int num12 = num11;
            int num13 = num12 + 1;
            levelDefinition5.index = num12;
            level5.name = "lvl3";
            level5.levelTextureFile = "level3";
            level5.width = 44;
            level5.height = 32;
            level5.thumbTexture = this.Content.Load<Texture2D>("Sprites/Levels/level3_thumb");
            level5.titleTexture = this.Content.Load<Texture2D>("Sprites/Levels/level3_title");
            level5.towers = new ArrayList();
            TowerDefinition towerDefinition19 = new TowerDefinition(TowerType.SPAWNER, 0, 15, 0, PlayerEnum.NONE, 1, 0.0f);
            level5.towers.Add((object)towerDefinition19);
            TowerDefinition towerDefinition20 = new TowerDefinition(TowerType.EXIT, 41, 15, 0, PlayerEnum.NONE, 1, 0.0f);
            level5.towers.Add((object)towerDefinition20);
            TowerDefinition towerDefinition21 = new TowerDefinition(TowerType.EXIT, 21, 29, 0, PlayerEnum.NONE, 2, 0.0f);
            level5.towers.Add((object)towerDefinition21);
            TowerDefinition towerDefinition22 = new TowerDefinition(TowerType.SPAWNER, 21, 0, 0, PlayerEnum.NONE, 2, 1.57079637f);
            level5.towers.Add((object)towerDefinition22);
            level5.noTrial = true;
            this.AddStandardWaves(ref level5);
            level5.PvP = false;
            level5.horizontalDivide = false;
            level5.startMoney = 100;
            level5.startMoneyLocation = new Vector2((float)(20 * num1), (float)(16 * num2));
            level5.blocks = new byte[44, 32]
            {
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        }
            };
            this.levels.Add((object)level5);
            LevelDefinition level6 = new LevelDefinition();
            LevelDefinition levelDefinition6 = level6;
            int num14 = num13;
            int num15 = num14 + 1;
            levelDefinition6.index = num14;
            level6.name = "lvl4";
            level6.levelTextureFile = "level4";
            level6.width = 44;
            level6.height = 32;
            level6.thumbTexture = this.Content.Load<Texture2D>("Sprites/Levels/level4_thumb");
            level6.titleTexture = this.Content.Load<Texture2D>("Sprites/Levels/level4_title");
            level6.towers = new ArrayList();
            TowerDefinition towerDefinition23 = new TowerDefinition(TowerType.SPAWNER, 12, 15, 0, PlayerEnum.NONE, 1, 0.0f);
            level6.towers.Add((object)towerDefinition23);
            TowerDefinition towerDefinition24 = new TowerDefinition(TowerType.EXIT, 30, 15, 0, PlayerEnum.NONE, 1, 0.0f);
            level6.towers.Add((object)towerDefinition24);
            TowerDefinition towerDefinition25 = new TowerDefinition(TowerType.EXIT, 21, 24, 0, PlayerEnum.NONE, 2, 0.0f);
            level6.towers.Add((object)towerDefinition25);
            TowerDefinition towerDefinition26 = new TowerDefinition(TowerType.SPAWNER, 21, 7, 0, PlayerEnum.NONE, 2, 1.57079637f);
            level6.towers.Add((object)towerDefinition26);
            level6.noTrial = true;
            this.AddStandardWaves(ref level6);
            level6.PvP = false;
            level6.horizontalDivide = false;
            level6.startMoney = 100;
            level6.startMoneyLocation = new Vector2((float)(20 * num1), (float)(16 * num2));
            level6.blocks = new byte[44, 32]
            {
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        }
            };
            this.levels.Add((object)level6);
            LevelDefinition level7 = new LevelDefinition();
            LevelDefinition levelDefinition7 = level7;
            int num16 = num15;
            int num17 = num16 + 1;
            levelDefinition7.index = num16;
            level7.name = "lvl4";
            level7.levelTextureFile = "level5";
            level7.width = 44;
            level7.height = 32;
            level7.thumbTexture = this.Content.Load<Texture2D>("Sprites/Levels/level5_thumb");
            level7.titleTexture = this.Content.Load<Texture2D>("Sprites/Levels/level5_title");
            level7.towers = new ArrayList();
            TowerDefinition towerDefinition27 = new TowerDefinition(TowerType.EXIT, 21, 15, 0, PlayerEnum.NONE, 1, 0.0f);
            level7.towers.Add((object)towerDefinition27);
            TowerDefinition towerDefinition28 = new TowerDefinition(TowerType.SPAWNER, 0, 15, 0, PlayerEnum.NONE, 1, 0.0f);
            level7.towers.Add((object)towerDefinition28);
            TowerDefinition towerDefinition29 = new TowerDefinition(TowerType.SPAWNER, 21, 0, 0, PlayerEnum.NONE, 1, 1.57079637f);
            level7.towers.Add((object)towerDefinition29);
            TowerDefinition towerDefinition30 = new TowerDefinition(TowerType.SPAWNER, 42, 15, 0, PlayerEnum.NONE, 1, 3.14159274f);
            level7.towers.Add((object)towerDefinition30);
            TowerDefinition towerDefinition31 = new TowerDefinition(TowerType.SPAWNER, 21, 30, 0, PlayerEnum.NONE, 1, 4.712389f);
            level7.towers.Add((object)towerDefinition31);
            level7.noTrial = true;
            this.AddStandardWaves(ref level7);
            level7.PvP = false;
            level7.horizontalDivide = false;
            level7.startMoney = 100;
            level7.startMoneyLocation = new Vector2((float)(20 * num1), (float)(16 * num2));
            level7.blocks = new byte[44, 32]
            {
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        }
            };
            this.levels.Add((object)level7);
            LevelDefinition level8 = new LevelDefinition();
            LevelDefinition levelDefinition8 = level8;
            int num18 = num17;
            int num19 = num18 + 1;
            levelDefinition8.index = num18;
            level8.name = "lvl4";
            level8.levelTextureFile = "level6";
            level8.width = 44;
            level8.height = 32;
            level8.thumbTexture = this.Content.Load<Texture2D>("Sprites/Levels/level6_thumb");
            level8.titleTexture = this.Content.Load<Texture2D>("Sprites/Levels/level6_title");
            level8.towers = new ArrayList();
            TowerDefinition towerDefinition32 = new TowerDefinition(TowerType.EXIT, 0, 15, 0, PlayerEnum.NONE, 1, 0.0f);
            level8.towers.Add((object)towerDefinition32);
            TowerDefinition towerDefinition33 = new TowerDefinition(TowerType.SPAWNER, 42, 3, 0, PlayerEnum.NONE, 1, 3.14159274f);
            level8.towers.Add((object)towerDefinition33);
            TowerDefinition towerDefinition34 = new TowerDefinition(TowerType.SPAWNER, 42, 15, 0, PlayerEnum.NONE, 1, 3.14159274f);
            level8.towers.Add((object)towerDefinition34);
            TowerDefinition towerDefinition35 = new TowerDefinition(TowerType.SPAWNER, 42, 26, 0, PlayerEnum.NONE, 1, 3.14159274f);
            level8.towers.Add((object)towerDefinition35);
            level8.noTrial = true;
            this.AddStandardWaves(ref level8);
            level8.PvP = false;
            level8.horizontalDivide = false;
            level8.startMoney = 100;
            level8.startMoneyLocation = new Vector2((float)(20 * num1), (float)(16 * num2));
            level8.blocks = new byte[44, 32]
            {
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        }
            };
            this.levels.Add((object)level8);
            LevelDefinition level9 = new LevelDefinition();
            LevelDefinition levelDefinition9 = level9;
            int num20 = num19;
            int num21 = num20 + 1;
            levelDefinition9.index = num20;
            level9.name = "lvl4";
            level9.levelTextureFile = "level7";
            level9.width = 44;
            level9.height = 32;
            level9.thumbTexture = this.Content.Load<Texture2D>("Sprites/Levels/level7_thumb");
            level9.titleTexture = this.Content.Load<Texture2D>("Sprites/Levels/level7_title");
            level9.towers = new ArrayList();
            TowerDefinition towerDefinition36 = new TowerDefinition(TowerType.EXIT, 10, 29, 0, PlayerEnum.P1, 1, 0.0f);
            level9.towers.Add((object)towerDefinition36);
            TowerDefinition towerDefinition37 = new TowerDefinition(TowerType.EXIT, 33, 29, 0, PlayerEnum.P2, 2, 0.0f);
            level9.towers.Add((object)towerDefinition37);
            TowerDefinition towerDefinition38 = new TowerDefinition(TowerType.SPAWNER, 10, 0, 0, PlayerEnum.P1, 1, 1.57079637f);
            level9.towers.Add((object)towerDefinition38);
            TowerDefinition towerDefinition39 = new TowerDefinition(TowerType.SPAWNER, 33, 0, 0, PlayerEnum.P2, 2, 1.57079637f);
            level9.towers.Add((object)towerDefinition39);
            level9.noTrial = true;
            this.AddStandardWaves(ref level9);
            level9.PvP = true;
            level9.horizontalDivide = false;
            level9.startMoney = 100;
            level9.startMoneyLocation = new Vector2((float)(20 * num1), (float)(16 * num2));
            level9.blocks = new byte[44, 32]
            {
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  0,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        },
        {
          (byte) 1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1,(byte)  1
        }
            };
            this.levels.Add((object)level9);
        }

        public void SetState(Game.GameState newState)
        {
            if (this.state == newState)
                return;
            this.pendingState = newState;
        }

        public void UpdateState()
        {
            if (this.state == this.pendingState)
                return;
            switch (this.state)
            {
                case Game.GameState.MAIN_MENU:
                    if (Game.mainMenu != null)
                    {
                        Game.mainMenu = (MainMenu)null;
                        break;
                    }
                    break;
                case Game.GameState.GAMEMAP:
                    if (Game.gameMap != null)
                    {
                        Game.gameMap = (GameMap)null;
                        break;
                    }
                    break;
            }
            GameTime gameTime = new GameTime();
            switch (this.pendingState)
            {
                case Game.GameState.MAIN_MENU:
                    Game.mainMenu = new MainMenu(this, (IServiceProvider)this.Services,  "./Content");
                    Game.gameMap = new GameMap(this, (IServiceProvider)this.Services,   "./Content", 0);
                    Game.gameMap.mainMenuMode = true;
                    break;
                case Game.GameState.GAMEMAP:
                    Game.gameMap = new GameMap(this, (IServiceProvider)this.Services,  "./Content", this.levelToLoad);
                    break;
            }
            this.state = this.pendingState;
        }

        protected override void Initialize()
        {
            this.graphics.PreferredBackBufferWidth = this.dim.Width;
            this.graphics.PreferredBackBufferHeight = this.dim.Height;
            this.graphics.IsFullScreen = true;
            this.graphics.ApplyChanges();
            this.globalScale = ((float)this.graphics.GraphicsDevice.Viewport.TitleSafeArea.Width + (float)(((double)this.graphics.GraphicsDevice.Viewport.Width - (double)this.graphics.GraphicsDevice.Viewport.TitleSafeArea.Width) / 2.0)) / (float)this.dim.Width;
            Game.audioEngine = new AudioEngine("Content\\Sounds\\td_sounds.xgs");
            Game.waveBank = new WaveBank(Game.audioEngine, "Content\\Sounds\\Wave Bank.xwb");
            Game.soundBank = new SoundBank(Game.audioEngine, "Content\\Sounds\\Sound Bank.xsb");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.guiFillerTexture = this.Content.Load<Texture2D>("Sprites/GUI/filler");
            this.borderLeftTexture = this.Content.Load<Texture2D>("Sprites/GUI/border_left");
            this.borderRightTexture = this.Content.Load<Texture2D>("Sprites/GUI/border_right");
            this.borderTopTexture = this.Content.Load<Texture2D>("Sprites/GUI/border_top");
            this.borderBottomTexture = this.Content.Load<Texture2D>("Sprites/GUI/border_bottom");
            this.SetState(Game.GameState.MAIN_MENU);
            this.LoadLevelDefinitions();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if ((double)this.gamma != (double)this.oldGamma)
            {
              /*  GammaRamp ramp = new GammaRamp();
                short[] numArray = new short[256];
                int num1 = (int)((1.0 - (double)this.gamma - 0.5) * 256.0);
                int num2 = 0;
                if (num1 < 0)
                    num2 = -num1;
                for (int index = 0; index < 256; ++index)
                {
                    numArray[index] = (short)(num2 * (int)byte.MaxValue);
                    if (index >= num1)
                    {
                        ++num2;
                        if (num2 > (int)byte.MaxValue)
                            num2 = (int)byte.MaxValue;
                    }
                }
                ramp.SetRed(numArray);
                ramp.SetGreen(numArray);
                ramp.SetBlue(numArray);
                this.graphics.GraphicsDevice.SetGammaRamp(false, ramp);
                this.oldGamma = this.gamma;*/
            }
            this.controls.UpdateStart();
            this.UpdateState();
            if (this.IsActive)
            {
                switch (this.state)
                {
                    case Game.GameState.MAIN_MENU:
                        Game.gameMap.Update(gameTime, this.GraphicsDevice);
                        Game.mainMenu.Update(gameTime, this.GraphicsDevice);
                        break;
                    case Game.GameState.GAMEMAP:
                        Game.gameMap.Update(gameTime, this.GraphicsDevice);
                        break;
                }
            }
            base.Update(gameTime);
            this.controls.UpdateEnd();
            Game.audioEngine.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.White);

            float offsetX = (float)(-((double)this.globalScale * (double)this.dim.Width - (double)this.GraphicsDevice.Viewport.Width) / 2.0);
            float offsetY = (float)(-((double)this.globalScale * (double)this.dim.Height - (double)this.GraphicsDevice.Viewport.Height) / 2.0);

            Matrix transformMatrix = Matrix.CreateScale(this.globalScale) * Matrix.CreateTranslation(offsetX, offsetY, 0.0f);

            this.spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.NonPremultiplied,
                null,
                null,
                null,
                null,
                transformMatrix
            );


            switch (this.state)
            {
                case Game.GameState.MAIN_MENU:
                    Game.gameMap.Draw(gameTime, this.spriteBatch);
                    Game.mainMenu.Draw(gameTime, this.spriteBatch);
                    break;
                case Game.GameState.GAMEMAP:
                    Game.gameMap.Draw(gameTime, this.spriteBatch);
                    break;
            }
            int num = 1600;
            this.spriteBatch.Draw(this.guiFillerTexture, new Rectangle(-num, 1080, 1920 + num * 2, num), Color.Black);
            this.spriteBatch.Draw(this.guiFillerTexture, new Rectangle(-num, -num, 1920 + num * 2, num), Color.Black);
            this.spriteBatch.Draw(this.guiFillerTexture, new Rectangle(-num, -num, num, 1080 + num * 2), Color.Black);
            this.spriteBatch.Draw(this.guiFillerTexture, new Rectangle(1920, -num, num, 1080 + num * 2), Color.Black);
            this.spriteBatch.Draw(this.borderLeftTexture, new Vector2(0.0f, 0.0f), Color.White);
            this.spriteBatch.Draw(this.borderRightTexture, new Vector2((float)(this.dim.Width - this.borderRightTexture.Width), 0.0f), Color.White);
            this.spriteBatch.Draw(this.borderTopTexture, new Vector2(0.0f, 0.0f), Color.White);
            this.spriteBatch.Draw(this.borderBottomTexture, new Vector2(0.0f, (float)(this.dim.Height - this.borderBottomTexture.Height)), Color.White);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ShutDown() => this.Exit();

        public enum GameState
        {
            NONE,
            MAIN_MENU,
            GAMEMAP,
        }
    }
}
