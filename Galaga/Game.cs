using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using System;
using DIKUArcade.Events;
using DIKUArcade.Input;
using System.Collections.Generic;
namespace Galaga
{
    public class Game : DIKUGame, IGameEventProcessor
    {
        private GameEventBus eventBus;
        private Player _player;

        public Game(WindowArgs windowArgs) : base(windowArgs)
        {
            eventBus = new GameEventBus();
            eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.InputEvent });
            window.SetKeyEventHandler(KeyHandler);
            eventBus.Subscribe(GameEventType.InputEvent, this);
            _player = new Player(
                new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.1f)),
                new Image(Path.Combine("Assets", "Images", "Player.png"))
            );
            // TODO: Set key event handler (inherited window field of DIKUGame class)
        }

        private void KeyPress(KeyboardKey key)
        {
            switch (key)
            {
                case KeyboardKey.Escape:
                    window.CloseWindow();
                    break;
                case KeyboardKey.A:
                    _player.SetMoveLeft(true);
                    break;
                case KeyboardKey.D:
                    _player.SetMoveRight(true);
                    break;
            }
            // TODO: Close window if escape is pressed
            // TODO: switch on key string and set the player's move direction
        }
        private void KeyRelease(KeyboardKey key)
        {
            switch (key)
            {
                case KeyboardKey.A:
                    _player.SetMoveLeft(false);
                    break;
                case KeyboardKey.D:
                    _player.SetMoveRight(false);
                    break;
            }
        }
        private void KeyHandler(KeyboardAction action, KeyboardKey key)
        {
            if (action == KeyboardAction.KeyRelease)
            {
                KeyRelease(key);
            }
            KeyPress(key);
            // TODO: Switch on KeyBoardAction and call proper method
        }
        public void ProcessEvent(GameEvent gameEvent)
        {
            if (gameEvent.EventType == GameEventType.WindowEvent)
            {
                Console.WriteLine("Test");
            }
        }

        public override void Render()
        {
            this._player.Render();
        }

        public override void Update()
        {
            window.PollEvents();
            eventBus.ProcessEventsSequentially();
            _player.Move();
        }


    }
}
