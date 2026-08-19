// Decompiled with JetBrains decompiler
// Type: BenTools.Data.IPriorityQueue
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using System;
using System.Collections;

namespace BenTools.Data
{
  public interface IPriorityQueue : ICloneable, IList, ICollection, IEnumerable
  {
    int Push(object O);

    object Pop();

    object Peek();

    void Update(int i);
  }
}
