using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GroupProject_3037_.csengine
{

    class instanceGame : Form
    {
        public instanceGame()
        {
            this.DoubleBuffered = true;
        }
    }
    
    public abstract class game
    {
        private g2dvec windowSize = new g2dvec(960, 960);
        private string showTitleText;
        public Color Background =  Color.Black;
        private instanceGame thisGame = null;
        private Thread gamethread = null;

        private static List<g2dshape> gameShapes = new List<g2dshape>();
        private static List<g2dsprite> gameSprites = new List<g2dsprite>();

        public game(g2dvec pixels, string name)
        {
            consoleLog.info("Game is starting. . .");
            this.windowSize = pixels;
            this.showTitleText = name;


            thisGame = new instanceGame();
            thisGame.Size = new Size((int)windowSize.x, (int)windowSize.y);
            thisGame.Text = this.showTitleText;
            thisGame.Paint += renderer;
            

            gamethread = new Thread(GameLoop);
            gamethread.Start();
            Application.Run(thisGame);
            
        }

        internal static void unregisterSprite(g2dsprite sprite)
        {
            gameSprites.Add(sprite);
        }

        internal static void registerSprite(g2dsprite sprite)
        {
            gameSprites.Add(sprite);
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {

            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "FormClosing Event");
        }

        public static void registerShapes(g2dshape shape)
        {
            gameShapes.Add(shape);
        }
        public static void unregisterShapes(g2dshape shape)
        {
            gameShapes.Remove(shape);
        }
        void GameLoop()
        {
            OnLoad();
            // Keep the game running and refreshing while the thread is valid
            while (gamethread.IsAlive)
            {
                
                try
                {
                    OnDraw();
                    thisGame.BeginInvoke((MethodInvoker)delegate { thisGame.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch
                {
                    consoleLog.error("Cannot open window. . .");
                }

            }

        }
        private void renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Background);

            foreach(g2dshape shape in gameShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Blue), shape.position.x, shape.position.y, shape.scale.x, shape.scale.y);
            }
            foreach(g2dsprite sprite in gameSprites)
            {
                g.DrawImage(sprite.sprite, sprite.position.x, sprite.position.y, sprite.scale.x, sprite.scale.y);
            }
            
        }
        public abstract void OnLoad();
        public abstract void OnUpdate();

        public abstract void OnDraw();

    }
}
