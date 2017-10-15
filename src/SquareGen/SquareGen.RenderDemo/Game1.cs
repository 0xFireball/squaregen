using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using SquareGen.RenderDemo.Scenes;

namespace SquareGen.RenderDemo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Core
    {
        public Game1() : base(1280, 720, false, true, "RenderDemo")
        {
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            if (System.Environment.OSVersion.Platform == System.PlatformID.Win32NT)
            {
                Window.Position = new Point(200, 200);
            }

            scene = new MainScene();
        }
    }
}
