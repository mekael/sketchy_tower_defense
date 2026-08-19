// Decompiled with JetBrains decompiler
// Type: TowerDefense.Util
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using System;

namespace TowerDefense
{
  public class Util
  {
    public static float GetRotationAngle(Vector2 source, Vector2 dest)
    {
      Vector2 vector2 = dest - source;
      float rotationAngle = MathHelper.WrapAngle(MathHelper.WrapAngle(-(float) Math.Atan2((double) vector2.X, (double) vector2.Y)) - 1.57079637f + 3.14159274f);
      if ((double) rotationAngle < 0.0)
        rotationAngle += 6.28318548f;
      return rotationAngle;
    }

    public static int PlayerEnumToIndex(PlayerEnum playerIndex)
    {
      switch (playerIndex)
      {
        case PlayerEnum.P1:
          return 0;
        case PlayerEnum.P2:
          return 1;
        case PlayerEnum.P3:
          return 2;
        case PlayerEnum.P4:
          return 3;
        default:
          return -1;
      }
    }

    public static PlayerEnum PlayerIndexToEnum(int i)
    {
      switch (i)
      {
        case 0:
          return PlayerEnum.P1;
        case 1:
          return PlayerEnum.P2;
        case 2:
          return PlayerEnum.P3;
        case 3:
          return PlayerEnum.P4;
        default:
          return PlayerEnum.NONE;
      }
    }

    public static float TurnToFace(
      Vector2 position,
      Vector2 faceThis,
      float currentAngle,
      float turnSpeed)
    {
      float x = faceThis.X - position.X;
      float num = MathHelper.Clamp(Util.WrapAngle((float) Math.Atan2((double) (faceThis.Y - position.Y), (double) x) - currentAngle), -turnSpeed, turnSpeed);
      return Util.WrapAngle(currentAngle + num);
    }

    public static float WrapAngle(float radians)
    {
      while ((double) radians < -3.1415927410125732)
        radians += 6.28318548f;
      while ((double) radians > 3.1415927410125732)
        radians -= 6.28318548f;
      return radians;
    }

    public static float AngleDistance(float a1, float a2)
    {
      float num = Util.WrapAngle(Math.Abs(a1 - a2));
      if ((double) num > Math.PI)
        num = 6.28318548f - num;
      return num;
    }
  }
}
