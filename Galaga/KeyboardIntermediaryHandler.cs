using DIKUArcade.Events;
using DIKUArcade.Input;
using DIKUArcade.Math;

namespace Galaga;

public class KeyboardIntermediaryHandler
{
    private readonly Game _game;
    
    // Dependency injection 
    public KeyboardIntermediaryHandler(Game game)
    {
        _game = game;
    }
    
    /// <summary>
        /// Registers keyboard events on Key Press to the Event Bus.
        /// </summary>
        /// <param name="key">The specific key pressed.</param>
        private void KeyPress(KeyboardKey key)
        {
            switch (key)
            {
               case KeyboardKey.Escape:
                    var close = new GameEvent {
                        To = _game,
                        EventType = GameEventType.WindowEvent
                    };
                    _game.EventBus.RegisterEvent(close);
                    break;
               case KeyboardKey.Space:
                    var pos = _game.Player.GetPosition();
                    _game.PlayerShots.AddEntity(
                        new PlayerShot(new Vec2F(pos.X + _game.Player.GetExtent().X / 2, pos.Y + _game.Player.GetExtent().Y / 2), _game.PlayerShotImage)
                    );
                    break;
                case KeyboardKey.W:
                    _game.EventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Forward),
                        To = _game.Player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
                case KeyboardKey.A:
                    _game.EventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Left),
                        To = _game.Player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
                case KeyboardKey.S:
                    _game.EventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Backward),
                        To = _game.Player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
                case KeyboardKey.D:
                    _game.EventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Right),
                        To = _game.Player, //IGameEventProcessor
                        IntArg1 = 1,
                    });
                    break;
            }
        }
        /// <summary>
        /// Registers keyboard events on Key Release to the Event Bus.
        /// </summary>
        /// <param name="key">The specific key pressed.</param>
        private void KeyRelease(KeyboardKey key)
        {
            switch (key)
            {
                case KeyboardKey.W:
                    _game.EventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Forward),
                        To = _game.Player, //IGameEventProcessor
                        IntArg1 = 0,
                    });
                    break;
                case KeyboardKey.A:
                    _game.EventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Left),
                        To = _game.Player, //IGameEventProcessor
                        IntArg1 = 0,
                    });
                    break;
                case KeyboardKey.S:
                    _game.EventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Backward),
                        To = _game.Player, //IGameEventProcessor
                        IntArg1 = 0,
                    });
                    break;
                case KeyboardKey.D:
                    _game.EventBus.RegisterEvent(new GameEvent
                    {
                        From = this,
                        Message = nameof(MovementDirection.Right),
                        To = _game.Player, //IGameEventProcessor
                        IntArg1 = 0,
                    });
                    break;
                case KeyboardKey.Space:
                    break;
            }
        }
        
        public void KeyHandler(KeyboardAction action, KeyboardKey key)
        {
            switch(action){
                case KeyboardAction.KeyPress:
                    KeyPress(key);
                    break;
                case KeyboardAction.KeyRelease:
                    KeyRelease(key);
                    break;
            }            
        }
}