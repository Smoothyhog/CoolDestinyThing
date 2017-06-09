using System.Drawing;

namespace CoolDestinyThing
{
    internal class Game
    {
        private GEngine gEngine;

        public const int CANVAS_HEIGHT = 700;
        public const int CANVAS_WIDTH = 1200;
        public const int LEVEL_WIDTH = 24;
        public const int LEVEL_HEIGHT = 14;
        public const int TILE_SIDE_LENGTH = 50;

        public void loadLevel()
        {
          Level.initlevel();
        }
        public void startGraphics(Graphics g)
        {
            gEngine = new GEngine(g);
            gEngine.init();
        }

        public void stopGame()
        {
            gEngine.stop();
        }
    }
}