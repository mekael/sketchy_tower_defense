// Decompiled with JetBrains decompiler
// Type: TowerDefense.Item
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;

namespace TowerDefense
{
  public class Item : AnimatedSprite
  {
    public bool deleteItem;

    public Item(string textureName, int cellWidth, int cellHeight, Vector2 pos)
      : base(textureName, cellWidth, cellHeight)
    {
      this.pos = pos;
      this.LoadContent();
    }
  }
}
