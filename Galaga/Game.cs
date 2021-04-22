using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;

namespace Galaga
{
    public class Game : DIKUGame
    {
        public Game(WindowArgs windowArgs) : base(windowArgs) {
            // TODO: Set key event handler (inherited window field of DIKUGame class)
        }

        //private void KeyHandler(KeyboardAction action, KeyboardKey key) {} // TODO: Outcomment

        public override void Render()
        {
            throw new System.NotImplementedException("Galaga game has nothing to render yet.");
        }

        public override void Update()
        {
            throw new System.NotImplementedException("Galaga game has no entities to update yet.");
        }
    }
}
