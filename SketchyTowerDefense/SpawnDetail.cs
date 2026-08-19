// Decompiled with JetBrains decompiler
// Type: TowerDefense.SpawnDetail
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

namespace TowerDefense
{
  public class SpawnDetail
  {
    public SpawnType type;
    public float delay;

    public SpawnDetail(SpawnType type, float delay)
    {
      this.type = type;
      this.delay = delay;
    }
  }
}
