﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenGLUniProject.Core
{
    public class Renderer
    {
        public Color4 ClearColor = Color4.DarkSlateBlue;

        private readonly GameWindow Window;

        public Renderer(GameWindow window = null)
        {
            if (window == null)
                return;

            Window = window;
            Window.Resize += Resize; ;
        }

        private void Resize(object sender, EventArgs e)
        {
            GL.Viewport(Window.ClientRectangle);
        }
        
        public void Begin()
        {
            GL.ClearColor(ClearColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void End()
        {
            GraphicsContext.CurrentContext.SwapBuffers();
        }
    }
}