using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareGen.RenderDemo.Scenes
{
    class MainScene : Scene
    {
        private DefaultRenderer renderer;

        public MainScene()
        {
            renderer = addRenderer(new DefaultRenderer());
            clearColor = Color.GhostWhite;
        }

        public override void initialize()
        {
            base.initialize();

            var box = createEntity("box", new Vector2(400, 400));
            box.addComponent(new Cube3D());
        }

        public override void update()
        {
            base.update();
        }
    }
}
