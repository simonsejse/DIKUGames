using System;
using DIKUArcade.Events;
using DIKUArcade.Events.Generic;
using DIKUArcade.State;

namespace Galaga.GalagaStates;

public class StateMachine : IGameEventProcessor<GameEventType>
{
    private readonly StateTransformer _stateTransformer = new();
    public IGameState ActiveState { get; private set; }

    public StateMachine()
    {
        GalagaBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
        GalagaBus.GetBus().Subscribe(GameEventType.InputEvent, this);
        ActiveState = MainMenu.GetInstance();
    }

    private void SwitchState(GameStateType stateType)
    {
        ActiveState = stateType switch
        {
            GameStateType.GamePaused => GamePaused.GetInstance(),
            GameStateType.GameRunning => GameRunning.GetInstance(),
            GameStateType.MainMenu => MainMenu.GetInstance(),
            _ => throw new ArgumentOutOfRangeException(nameof(stateType), stateType, null)
        };
    }

    public void ProcessEvent(GameEvent<GameEventType> gameEvent)
    {
        if (gameEvent.EventType is not GameEventType.GameStateEvent) return;
        if (!gameEvent.Message.Equals("CHANGE_STATE")) return;
        
        string gameEventStringArg1 = gameEvent.StringArg1;
        SwitchState(_stateTransformer.TransformStringToState(gameEventStringArg1));
    }
}

