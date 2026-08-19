// Decompiled with JetBrains decompiler
// Type: TowerDefense.Program
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

namespace TowerDefense
{
  internal static class Program
  {
    private static void Main(string[] args)
    {
      using (Game game = new Game())
        game.Run();
    }
  }
}
