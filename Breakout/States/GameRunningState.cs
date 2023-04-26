using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;

namespace Breakout.States;

public class GameRunningState : IGameState
{

    private static GameRunningState? _instance;

    private Entity _background;

    public static GameRunningState GetInstance()
    {
        GameRunningState CreateInstance()
        {
            var gameRunningState = new GameRunningState();
            gameRunningState.Init();
            return gameRunningState;
        }
        return _instance ??= CreateInstance();
    }

    private void Init()
    {
        var stationaryShape = new StationaryShape(new Vec2F(0, 0), new Vec2F(1, 1));
        _background = new Entity(stationaryShape, new Image(Path.Combine("Assets", "Images", "SpaceBackground.png")));

        
    }

    public void ResetState()
    {
    }

    public void UpdateState()
    {
    }

    public void RenderState()
    {
        _background.RenderEntity();
    }

    public void HandleKeyEvent(KeyboardAction action, KeyboardKey key)
    {
    }
}