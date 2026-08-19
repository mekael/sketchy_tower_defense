// Decompiled with JetBrains decompiler
// Type: TowerDefense.HighScores
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework.Storage;
using System;
using System.IO;
using System.Xml.Serialization;

namespace TowerDefense
{
  [Serializable]
  public class HighScores
  {
    public HighScores.Score[] scores;

    public HighScores() => this.scores = new HighScores.Score[5];

    public void LoadScores()
    {
    }

    public void SaveScores()
    {
      FileStream fileStream = File.Open(Path.Combine( "highscores.dat"), FileMode.OpenOrCreate);
      try
      {
        new XmlSerializer(typeof (HighScores)).Serialize((Stream) fileStream, (object) this);
      }
      finally
      {
        fileStream.Close();
      }
    }

    public static HighScores LoadHighScores()
    {
      string path = Path.Combine( "highscores.dat");
      if (!File.Exists(path))
        return HighScores.NewHighScores();
      FileStream fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
      try
      {
        return (HighScores) new XmlSerializer(typeof (HighScores)).Deserialize((Stream) fileStream);
      }
      finally
      {
        fileStream.Close();
      }
    }

    private static HighScores NewHighScores()
    {
      HighScores highScores = new HighScores();
      int index1 = 0;
      highScores.scores[index1].name = "Martin";
      highScores.scores[index1].points = 100000;
      int index2 = index1 + 1;
      highScores.scores[index2].name = "Kamila";
      highScores.scores[index2].points = 50000;
      int index3 = index2 + 1;
      highScores.scores[index3].name = "William";
      highScores.scores[index3].points = 25000;
      int index4 = index3 + 1;
      highScores.scores[index4].name = "Sam";
      highScores.scores[index4].points = 12500;
      int index5 = index4 + 1;
      highScores.scores[index5].name = "Oscar";
      highScores.scores[index5].points = 5000;
      int num = index5 + 1;
      return highScores;
    }

    public void AddScore(string name, int points)
    {
      bool flag = false;
      for (int index1 = 0; index1 < this.scores.Length; ++index1)
      {
        if (this.scores[index1].points < points)
        {
          flag = true;
          for (int index2 = this.scores.Length - 1; index2 != index1; --index2)
            this.scores[index2] = this.scores[index2 - 1];
          this.scores[index1].name = name;
          this.scores[index1].points = points;
          break;
        }
      }
      if (!flag)
        return;
      this.SaveScores();
    }

    public struct Score
    {
      public string name;
      public int points;
    }
  }
}
