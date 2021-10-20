using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace OpenTKFirstProject
{
    class SimpleWindow : GameWindow
    {

        // Constructor.
        public SimpleWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
            if (e.Key == Key.Up)
                GL.ClearColor(Color.Aqua);
            if (e.Key == Key.Down)
                GL.ClearColor(Color.MediumVioletRed);
            if (e.Key == Key.Left)
                GL.ClearColor(Color.RoyalBlue);
            if (e.Key == Key.Right)
                GL.ClearColor(Color.Azure);
            if (e.Key == Key.Enter)
                GL.ClearColor(Color.MediumPurple);

        }
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.PeachPuff);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            MouseState mouse_Click = Mouse.GetState();

            if (mouse_Click.IsButtonDown(MouseButton.Left))
            {
                GL.ClearColor(Color.GreenYellow);
                Console.WriteLine("Mouse Left clicked on: ( " + mouse_Click.X + " , " + mouse_Click.Y + " )");
            }

            if (mouse_Click.IsButtonDown(MouseButton.Right))
            {
                GL.ClearColor(Color.Black);
                Console.WriteLine("Mouse Right clicked on: ( " + mouse_Click.X + " , " + mouse_Click.Y + " )");
            }
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-0.3f, 0.2f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(1.0f, -1f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(0.4f, 1.0f);

            GL.End();

            this.SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
