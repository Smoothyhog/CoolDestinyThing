using System;
using System.Drawing;
using System.Threading;
using CoolDestinyThing.Properties;

namespace CoolDestinyThing
{
    internal class GEngine
    {
        private readonly Graphics drawHandle;
        private Bitmap grass;
        private Thread renderThread;

        private Bitmap sled;

        public GEngine(Graphics g)
        {
            drawHandle = g;
        }

        public void init()
        {
            loadAssets();
            renderThread = new Thread(render);
            renderThread.Start();
        }

        //Load resources
        private void loadAssets()
        {
            grass = Resources.Grass;
            sled = Resources.sled;
        }

        public void stop()
        {
            renderThread.Abort();
        }

        private void render()
        {
            var framesRendered = 0;
            long startTime = Environment.TickCount;

            var frame = new Bitmap(Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
            var frameGraphics = Graphics.FromImage(frame);

            var textures = Level.Blocks;


            while (true)
            {
                frameGraphics.FillRectangle(new SolidBrush(Color.Aqua), 0, 0, 1200, 700);

                for (var x = 0; x < Game.LEVEL_WIDTH; x++)
                for (var y = 0; y < Game.LEVEL_HEIGHT; y++)
                    switch (textures[x, y])
                    {
                        case TextureID.air:
                            break;
                        case TextureID.dirt:
                            frameGraphics.DrawImage(grass, x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH);
                            break;
                    }
                frameGraphics.DrawImage(sled, 950, 350);

                drawHandle.DrawImage(frame, 0, 0);

                //Benchmarking
                framesRendered++;
                if (Environment.TickCount >= startTime + 1000)
                {
                    Console.WriteLine("GEngine: " + framesRendered + " fps");
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                }
            }
        }
    }

    public enum TextureID
    {
        air,
        dirt
    }
}