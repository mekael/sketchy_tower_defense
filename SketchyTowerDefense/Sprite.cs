// Decompiled with JetBrains decompiler
// Type: TowerDefense.Sprite
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
  public class Sprite
  {
    private string textureName;
    public Texture2D texture;
    public Vector2 pos = new Vector2(0.0f, 0.0f);
    public float rot;
    public float scale = 1f;
    public Color color = Color.White;
    private static int idCounter;
    public int id;
    public int idGroup;

    public Sprite(string textureName)
    {
      this.textureName = textureName;
      this.id = Sprite.idCounter++;
      this.idGroup = this.id % GameMap.Instance.updateTotalGroups;
      this.LoadContent();
    }

    protected virtual void LoadContent()
    {
      if (this.textureName == null)
        return;
      this.texture = GameMap.Instance.content.Load<Texture2D>(this.textureName);
    }

    public virtual void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (this.texture == null)
        return;
      spriteBatch.Draw(this.texture, this.pos + viewOffset, new Rectangle?(), this.color, this.rot, new Vector2((float) (this.texture.Width / 2), (float) (this.texture.Height / 2)), this.scale, SpriteEffects.None, 0.5f);
    }

    public virtual void Update(GameTime gameTime)
    {
    }
  }
}
