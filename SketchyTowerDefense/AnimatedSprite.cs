// Decompiled with JetBrains decompiler
// Type: TowerDefense.AnimatedSprite
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TowerDefense
{
  public class AnimatedSprite : Sprite
  {
    public int cellWidth;
    public int cellHeight;
    public int cellRows;
    public int cellColumns;
    public Dictionary<string, int[]> animations;
    public int currentFrame;
    public string currentAnim = "none";
    public float animSpeed = 10f;
    public float frameTimeLeft;

    public AnimatedSprite(string textureName, int cellColumns, int cellRows)
      : base(textureName)
    {
      this.cellRows = cellRows;
      this.cellColumns = cellColumns;
      if (this.texture != null)
      {
        this.cellWidth = this.texture.Width / cellColumns;
        this.cellHeight = this.texture.Height / cellRows;
      }
      this.animations = new Dictionary<string, int[]>();
      this.animations.Add("none", new int[1]);
    }

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (this.texture == null)
        return;
      int[] animation = this.animations[this.currentAnim];
      Rectangle rectangle = new Rectangle(animation[this.currentFrame] % this.cellColumns * this.cellWidth, animation[this.currentFrame] / this.cellColumns * this.cellHeight, this.cellWidth, this.cellHeight);
      spriteBatch.Draw(this.texture, this.pos + viewOffset, new Rectangle?(rectangle), this.color, this.rot, new Vector2((float) (this.cellWidth / 2), (float) (this.cellHeight / 2)), this.scale, SpriteEffects.None, 0.5f);
    }

    public virtual void SetAnimation(string newAnim)
    {
      this.frameTimeLeft = this.animSpeed;
      this.currentAnim = newAnim;
      this.currentFrame = 0;
    }

    protected virtual void AnimationEnd()
    {
    }

    public override void Update(GameTime gameTime)
    {
      this.frameTimeLeft -= (float) gameTime.ElapsedGameTime.Milliseconds;
      if ((double) this.frameTimeLeft > 0.0)
        return;
      this.frameTimeLeft = this.animSpeed;
      ++this.currentFrame;
      if (this.currentFrame < this.animations[this.currentAnim].Length)
        return;
      this.AnimationEnd();
      this.currentFrame = 0;
    }
  }
}
