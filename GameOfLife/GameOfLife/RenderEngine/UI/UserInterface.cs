﻿using System;
using GameOfLife.RenderEngine.UI.Elements;
using SlimDX;
using GameOfLife.Storage;
using System.Drawing;
using GameOfLife.RenderEngine;
using GameOfLife.RenderEngine.UI;

namespace GameOfLife.UI
{
  class Userinterface
  {
    int frames, Second, thick = Config.LineThickness;
    readonly Vector2 position = new Vector2(10, 10);
    readonly Vector2 offset = new Vector2(0, 20);
    float timeElapsed;

    DrawableString thickness, pause;
    DrawableString fpsString;

    Rectangle2D sideBar;
    // Color kann auch anders angegeben werden Color.FromArgb(128,128,128,128)

    public Userinterface()
    {
      pause = new DrawableString("PAUSED (P)", position + new Vector2(Config.Width - 10 * 14, 0), Color.OrangeRed);
      fpsString = new DrawableString("FPS: 0", position, Color.White);
      thickness = new DrawableString("Thickness: " + Config.LineThickness, position + offset, Color.White);
      sideBar = new Rectangle2D(new Vector2(0, 0), 250, Config.Height, Color.FromArgb(200, 200, 200, 200));
    }

    public void Update(float elapsed)
    {
      timeElapsed += elapsed;
      if (thick != Config.LineThickness)
      {
        thickness.Dispose();
        thickness = new DrawableString("Thickness: " + Config.LineThickness, position + offset, Color.White);
        thick = Config.LineThickness;
      }

      if (DateTime.Now.Second != Second)
      {
        Second = DateTime.Now.Second;
        fpsString.Dispose();
        fpsString = new DrawableString("FPS: " + frames, position, Color.White);
        frames = 0;
      }
      frames++;
    }

    public void Draw(SpriteBatch sb)
    {
      // sideBar.Draw(sb);
      sb.DrawString(thickness);
      sb.DrawString(fpsString);

      if (Config.Paused)// && timeElapsed % 1 > 0.5)
      {
        sb.DrawString(pause);
      }
    }

    internal void Dispose()
    {
      fpsString.Dispose();
      thickness.Dispose();
      pause.Dispose();
      sideBar.Dispose();
    }
  }
}