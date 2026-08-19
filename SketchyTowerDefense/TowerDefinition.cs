// Decompiled with JetBrains decompiler
// Type: TowerDefense.TowerDefinition
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

namespace TowerDefense
{
  public class TowerDefinition
  {
    public TowerType type;
    public int x;
    public int y;
    public int level;
    public PlayerEnum ownerIndex;
    public int towerId;
    public float rotation;

    public TowerDefinition(
      TowerType type,
      int x,
      int y,
      int level,
      PlayerEnum ownerIndex,
      int towerId,
      float rotation)
    {
      this.type = type;
      this.x = x;
      this.y = y;
      this.level = level;
      this.ownerIndex = ownerIndex;
      this.towerId = towerId;
      this.rotation = rotation;
    }
  }
}
