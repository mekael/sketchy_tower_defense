// Decompiled with JetBrains decompiler
// Type: TowerDefense.RectangleExtensions
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using System;

namespace TowerDefense
{
  public static class RectangleExtensions
  {
    public static Vector2 GetIntersectionDepth(this Rectangle rectA, Rectangle rectB)
    {
      float num1 = (float) rectA.Width / 2f;
      float num2 = (float) rectA.Height / 2f;
      float num3 = (float) rectB.Width / 2f;
      float num4 = (float) rectB.Height / 2f;
      Vector2 vector2_1 = new Vector2((float) rectA.Left + num1, (float) rectA.Top + num2);
      Vector2 vector2_2 = new Vector2((float) rectB.Left + num3, (float) rectB.Top + num4);
      float num5 = vector2_1.X - vector2_2.X;
      float num6 = vector2_1.Y - vector2_2.Y;
      float num7 = num1 + num3;
      float num8 = num2 + num4;
      return (double) Math.Abs(num5) >= (double) num7 || (double) Math.Abs(num6) >= (double) num8 ? Vector2.Zero : new Vector2((double) num5 > 0.0 ? num7 - num5 : -num7 - num5, (double) num6 > 0.0 ? num8 - num6 : -num8 - num6);
    }

    public static Vector2 GetBottomCenter(this Rectangle rect) => new Vector2((float) rect.X + (float) rect.Width / 2f, (float) rect.Bottom);
  }
}
