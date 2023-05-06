using System;
using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Events;
using System.Collections.Generic;
using DIKUArcade.Events.Generic;
using Galaga.GalagaStates;
namespace Galaga
{
    public class Game : DIKUGame, IGameEventProcessor<GameEventType>
    {
        private readonly StateMachine _stateMachine;

        public Game(WindowArgs windowArgs) : base(windowArgs)
        {
            GameEventBus<GameEventType> gameEventBus = GalagaBus.GetBus();
            gameEventBus.InitializeEventBus(new List<GameEventType>
            {
                GameEventType.WindowEvent, GameEventType.GameStateEvent, GameEventType.InputEvent,
                GameEventType.PlayerEvent
            });
            _stateMachine = new StateMachine();
            
            gameEventBus.Subscribe(GameEventType.WindowEvent, this);
            gameEventBus.Subscribe(GameEventType.InputEvent, this); //Redundant?? Jeg registrer ingen input events hertil
            window.SetKeyEventHandler(KeyHandler);
            gameEventBus.ProcessEventsSequentially();
        }
        
        public override void Render()
        {
            window.PollEvents();
            _stateMachine.ActiveState.RenderState();
        }

        public override void Update()
        {
            GalagaBus.GetBus().ProcessEventsSequentially(); //Needed to process the events continuously if events is registered.
            _stateMachine.ActiveState.UpdateState();
        }

        private void KeyHandler(KeyboardAction action, KeyboardKey key)
        {
            _stateMachine.ActiveState.HandleKeyEvent(action, key);      
        }
        
        public void ProcessEvent(GameEvent<GameEventType> gameEvent)
        {
            if (gameEvent.EventType is not GameEventType.WindowEvent) return;
            if (gameEvent.Message is not "CLOSE_GAME") return;
            
            window.CloseWindow();
        }
    }
}
