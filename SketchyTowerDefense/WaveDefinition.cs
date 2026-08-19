// Decompiled with JetBrains decompiler
// Type: TowerDefense.WaveDefinition
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

namespace TowerDefense
{
  public class WaveDefinition
  {
    public SpawnType type;
    public int count;

    public WaveDefinition(SpawnType type)
    {
      this.type = type;
      switch (type)
      {
        case SpawnType.SPAWNTYPE_SNOTGOBLIN:
          this.count = 10;
          break;
        case SpawnType.SPAWNTYPE_PIGSPIDER:
          this.count = 10;
          break;
        case SpawnType.SPAWNTYPE_FRUITBAT:
          this.count = 8;
          break;
        case SpawnType.SPAWNTYPE_STINKSLIME:
          this.count = 5;
          break;
        case SpawnType.SPAWNTYPE_SWARMWORM:
          this.count = 10;
          break;
        case SpawnType.SPAWNTYPE_BIGUN:
          this.count = 6;
          break;
        case SpawnType.SPAWNTYPE_BOSS_SNOTGOBLIN:
          this.count = 2;
          break;
        case SpawnType.SPAWNTYPE_BOSS_PIGSPIDER:
          this.count = 2;
          break;
        case SpawnType.SPAWNTYPE_BOSS_FRUITBAT:
          this.count = 1;
          break;
        case SpawnType.SPAWNTYPE_BOSS_STINKSLIME:
          this.count = 1;
          break;
        case SpawnType.SPAWNTYPE_BOSS_SWARMWORM:
          this.count = 2;
          break;
        case SpawnType.SPAWNTYPE_BOSS_BIGUN:
          this.count = 1;
          break;
      }
    }
  }
}
