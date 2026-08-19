// Decompiled with JetBrains decompiler
// Type: BenTools.Data.BinaryPriorityQueue
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using System;
using System.Collections;

namespace BenTools.Data
{
  public class BinaryPriorityQueue : IPriorityQueue, ICloneable, IList, ICollection, IEnumerable
  {
    protected ArrayList InnerList = new ArrayList();
    protected IComparer Comparer;

    public BinaryPriorityQueue()
      : this((IComparer) System.Collections.Comparer.Default)
    {
    }

    public BinaryPriorityQueue(IComparer c) => this.Comparer = c;

    public BinaryPriorityQueue(int C)
      : this((IComparer) System.Collections.Comparer.Default, C)
    {
    }

    public BinaryPriorityQueue(IComparer c, int Capacity)
    {
      this.Comparer = c;
      this.InnerList.Capacity = Capacity;
    }

    protected BinaryPriorityQueue(ArrayList Core, IComparer Comp, bool Copy)
    {
      this.InnerList = !Copy ? Core : Core.Clone() as ArrayList;
      this.Comparer = Comp;
    }

    protected void SwitchElements(int i, int j)
    {
      object inner = this.InnerList[i];
      this.InnerList[i] = this.InnerList[j];
      this.InnerList[j] = inner;
    }

    protected virtual int OnCompare(int i, int j) => this.Comparer.Compare(this.InnerList[i], this.InnerList[j]);

    public int Push(object O)
    {
      int i = this.InnerList.Count;
      this.InnerList.Add(O);
      int j;
      for (; i != 0; i = j)
      {
        j = (i - 1) / 2;
        if (this.OnCompare(i, j) < 0)
          this.SwitchElements(i, j);
        else
          break;
      }
      return i;
    }

    public object Pop()
    {
      object inner = this.InnerList[0];
      int i = 0;
      this.InnerList[0] = this.InnerList[this.InnerList.Count - 1];
      this.InnerList.RemoveAt(this.InnerList.Count - 1);
      while (true)
      {
        int j1 = i;
        int j2 = 2 * i + 1;
        int j3 = 2 * i + 2;
        if (this.InnerList.Count > j2 && this.OnCompare(i, j2) > 0)
          i = j2;
        if (this.InnerList.Count > j3 && this.OnCompare(i, j3) > 0)
          i = j3;
        if (i != j1)
          this.SwitchElements(i, j1);
        else
          break;
      }
      return inner;
    }

    public void Update(int i)
    {
      int i1;
      int j1;
      for (i1 = i; i1 != 0; i1 = j1)
      {
        j1 = (i1 - 1) / 2;
        if (this.OnCompare(i1, j1) < 0)
          this.SwitchElements(i1, j1);
        else
          break;
      }
      if (i1 < i)
        return;
      while (true)
      {
        int j2 = i1;
        int j3 = 2 * i1 + 1;
        int j4 = 2 * i1 + 2;
        if (this.InnerList.Count > j3 && this.OnCompare(i1, j3) > 0)
          i1 = j3;
        if (this.InnerList.Count > j4 && this.OnCompare(i1, j4) > 0)
          i1 = j4;
        if (i1 != j2)
          this.SwitchElements(i1, j2);
        else
          break;
      }
    }

    public object Peek() => this.InnerList.Count > 0 ? this.InnerList[0] : (object) null;

    public bool Contains(object value) => this.InnerList.Contains(value);

    public void Clear() => this.InnerList.Clear();

    public int Count => this.InnerList.Count;

    IEnumerator IEnumerable.GetEnumerator() => this.InnerList.GetEnumerator();

    public void CopyTo(Array array, int index) => this.InnerList.CopyTo(array, index);

    public object Clone() => (object) new BinaryPriorityQueue(this.InnerList, this.Comparer, true);

    public bool IsSynchronized => this.InnerList.IsSynchronized;

    public object SyncRoot => (object) this;

    bool IList.IsReadOnly => false;

    object IList.this[int index]
    {
      get => this.InnerList[index];
      set
      {
        this.InnerList[index] = value;
        this.Update(index);
      }
    }

    int IList.Add(object o) => this.Push(o);

    void IList.RemoveAt(int index) => throw new NotSupportedException();

    void IList.Insert(int index, object value) => throw new NotSupportedException();

    void IList.Remove(object value) => throw new NotSupportedException();

    int IList.IndexOf(object value) => throw new NotSupportedException();

    bool IList.IsFixedSize => false;

    public static BinaryPriorityQueue Syncronized(BinaryPriorityQueue P) => new BinaryPriorityQueue(ArrayList.Synchronized(P.InnerList), P.Comparer, false);
  }
}
