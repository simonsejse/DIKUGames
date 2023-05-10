using Breakout.Entities;

namespace Breakout.Commands.GameRunning;

public class MovePlayerRightCommand : IKeyboardCommand
{
    private readonly PlayerEntity _playerEntity;
    private readonly bool _shouldMove;

    public MovePlayerRightCommand(PlayerEntity playerEntity, bool shouldMove)
    {
        _playerEntity = playerEntity;
        _shouldMove = shouldMove;
    }

    public void Execute()
    {
        _playerEntity.SetMoveRight(_shouldMove);
    }
}