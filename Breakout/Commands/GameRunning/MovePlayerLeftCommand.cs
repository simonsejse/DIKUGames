using Breakout.Entities;

namespace Breakout.Commands.GameRunning;

public class MovePlayerLeftCommand : IKeyboardCommand
{
    private readonly PlayerEntity _playerEntity;
    private readonly bool _shouldMove;

    public MovePlayerLeftCommand(PlayerEntity playerEntity, bool shouldMove)
    {
        _playerEntity = playerEntity;
        _shouldMove = shouldMove;
    }

    public void Execute()
    {
        _playerEntity.SetMoveLeft(_shouldMove);
    }
}