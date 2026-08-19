// Decompiled with JetBrains decompiler
// Type: TowerDefense.LevelDefinition
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace TowerDefense
{
  public class LevelDefinition
  {
    public int index;
    public string levelTextureFile;
    public byte[,] blocks;
    public string name;
    public int width;
    public int height;
    public ArrayList waves;
    public int waveRepeatIndex;
    public ArrayList towers;
    public int startMoney;
    public Vector2 startMoneyLocation;
    public bool PvP;
    public bool horizontalDivide;
    public Texture2D thumbTexture;
    public Texture2D titleTexture;
    public bool noTrial;
  }
}
