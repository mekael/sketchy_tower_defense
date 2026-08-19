// Decompiled with JetBrains decompiler
// Type: TowerDefense.ParticleField
// Assembly: Sketchy Tower Defense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 86919A57-AEB8-43BD-B37F-A02705BC409E
// Assembly location: C:\Users\Lenovo  IP5P\Desktop\New folder\SketchyTowerDefense.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;

namespace TowerDefense
{
  public class ParticleField : Sprite
  {
    public int cellWidth;
    public int cellHeight;
    public int cellRows;
    public int cellColumns;
    public float radius;
    public int maxParticles = 10;
    public float spawnInterval = 500f;
    public float nextSpawn;
    public float particleLife;
    public float particleVelocity = 0.005f;
    public float fieldLife = 4000f;
    public bool dead;
    public ArrayList particles;

    public ParticleField(string textureName, int cellColumns, int cellRows)
      : base(textureName)
    {
      this.cellRows = cellRows;
      this.cellColumns = cellColumns;
      this.particleLife = this.fieldLife / 1f;
      this.particles = new ArrayList();
      if (this.texture != null)
      {
        this.cellWidth = this.texture.Width / cellColumns;
        this.cellHeight = this.texture.Height / cellRows;
      }
      this.nextSpawn = 0.0f;
    }

    public override void Draw(Vector2 viewOffset, GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (this.texture == null)
        return;
      foreach (ParticleField.Particle particle in this.particles)
      {
        Rectangle rectangle = new Rectangle(particle.variant % this.cellColumns * this.cellWidth, particle.variant / this.cellColumns * this.cellHeight, this.cellWidth, this.cellHeight);
        spriteBatch.Draw(this.texture, particle.pos + viewOffset, new Rectangle?(rectangle), particle.color, particle.rot, new Vector2((float) (this.cellWidth / 2), (float) (this.cellHeight / 2)), particle.scale, SpriteEffects.None, 0.5f);
      }
    }

    public override void Update(GameTime gameTime)
    {
      this.fieldLife -= (float) gameTime.ElapsedGameTime.Milliseconds;
      if ((double) this.fieldLife < 0.0)
      {
        this.fieldLife = 0.0f;
        if (this.particles.Count == 0)
        {
          this.dead = true;
          return;
        }
      }
      this.nextSpawn -= (float) gameTime.ElapsedGameTime.Milliseconds;
      if ((double) this.nextSpawn <= 0.0)
      {
        this.nextSpawn = 0.0f;
        if (this.particles.Count < this.maxParticles && (double) this.fieldLife > 0.0)
        {
          Random random = new Random();
          ParticleField.Particle particle = new ParticleField.Particle()
          {
            pos = this.pos + new Vector2((float) (random.NextDouble() * (double) this.radius * 2.0) - this.radius, (float) (random.NextDouble() * (double) this.radius * 2.0) - this.radius)
          };
          particle.vel = particle.pos - this.pos;
          particle.vel.Normalize();
          particle.vel *= this.particleVelocity;
          particle.rot = (float) (random.NextDouble() * Math.PI);
          particle.variant = random.Next(this.cellRows * this.cellColumns);
          particle.life = this.particleLife;
          particle.scale = 0.5f;
          particle.rotateClockwise = random.Next(2) == 0;
          this.particles.Add((object) particle);
          this.nextSpawn = this.spawnInterval;
        }
      }
      foreach (ParticleField.Particle particle in this.particles)
      {
        if (particle != null)
        {
          particle.life -= (float) gameTime.ElapsedGameTime.Milliseconds;
          particle.pos += particle.vel * (float) gameTime.ElapsedGameTime.Milliseconds;
          if (particle.rotateClockwise)
            particle.rot += 0.0002f * (float) gameTime.ElapsedGameTime.Milliseconds;
          else
            particle.rot -= 0.0002f * (float) gameTime.ElapsedGameTime.Milliseconds;
          particle.scale = MathHelper.Lerp(0.5f, 1f, (this.particleLife - particle.life) / this.particleLife);
          float num = 0.1f;
          particle.color.A = ((double) this.particleLife - (double) particle.life) / (double) this.particleLife >= (double) num ? (byte) MathHelper.Lerp((float) byte.MaxValue, 0.0f, (this.particleLife - particle.life) / this.particleLife) : (byte) MathHelper.Lerp(0.0f, (float) byte.MaxValue, (this.particleLife - particle.life) / this.particleLife / num);
        }
      }
      bool flag;
      do
      {
        flag = false;
        foreach (ParticleField.Particle particle in this.particles)
        {
          if (particle != null && (double) particle.life <= 0.0)
          {
            this.particles.Remove((object) particle);
            flag = true;
            break;
          }
        }
      }
      while (flag);
    }

    private class Particle
    {
      public Vector2 pos = new Vector2(0.0f, 0.0f);
      public Vector2 vel = new Vector2(0.0f, 0.0f);
      public float scale = 1f;
      public float rot;
      public Color color = Color.White;
      public float life = 1000f;
      public int variant;
      public bool rotateClockwise;
    }
  }
}
