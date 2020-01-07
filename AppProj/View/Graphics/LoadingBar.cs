using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProj.View.Graphics
{
    public class LoadingBar
    {
        public static bool authenticationComplete = false;
        private int x;
        private int y;
        private Form sender;

        public void Activate(int x, int y, Form sender)
        {
            this.x = x;
            this.y = y;
            this.sender = sender;

            Thread t = new Thread(new ThreadStart(LoadingBarPaint));
            t.Start();
            t.Join();
            
        }

        private void LoadingBarPaint()
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            System.Drawing.Graphics formGraphics;
            formGraphics = sender.CreateGraphics();

            var rect = new RectangleF(113, 383, 175, 13);

            var font = new Font("Arial", 16);
            var brush = new SolidBrush(Color.Black);

            for (int i = 0; i < 175; i += 5)
            {
                formGraphics.FillRectangle(myBrush, new Rectangle(x, y, i, 13));
                //formGraphics.DrawString(i.ToString(), font, brush, rect);
                Thread.Sleep(45);
            }


            formGraphics.FillRectangle(myBrush, new Rectangle(x, y, 175, 13));
            myBrush.Dispose();
            formGraphics.Dispose();
        }

        private System.Drawing.Graphics CreateGraphics()
        {
            throw new NotImplementedException();
        }
    }
}
