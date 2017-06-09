using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace CoolDestinyThing
{
    public partial class GameWind : Form
    {
        private Game game = new Game();

        public GameWind()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            game.loadLevel();
            Graphics g = canvas.CreateGraphics();
            game.startGraphics(g);

        }

        private void GameWind_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.stopGame();
        }


        //Allows the command line to be seen during normal execution 
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void GameWind_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }
    }

}
