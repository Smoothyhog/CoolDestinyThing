namespace CoolDestinyThing
{
    internal class Level
    {
        private static TextureID[,] blocks = new TextureID[Game.LEVEL_WIDTH, Game.LEVEL_HEIGHT];

        public static TextureID[,] Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        }
        public static void initlevel()
        {
            for (var x = 0; x < Game.LEVEL_WIDTH; x++)
            for (var y = 0; y < Game.LEVEL_HEIGHT; y++)
                if (y >= 11)
                    blocks[x, y] = TextureID.dirt;
                else
                    blocks[x, y] = TextureID.air;
        }
    }
}