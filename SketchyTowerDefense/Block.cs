// Decompiled with JetBrains decompiler
// Type: TowerDefense.Block
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class Block : Tower
  {
    public Block()
      : base("Sprites/Towers/block", 1, 1)
    {
      this.type = TowerType.BLOCK;
      this.level = -1;
    }

    public override bool Passable => false;

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
    }

    public override int Size => 1;
  }
}
