using Breakout.Entities;

namespace Breakout.Commands.GameRunning;

public class MovePlayerRightCommand : IKeyboardCommand
{
    private readonly PlayerEntity _playerEntity;
    private readonly bool _shouldMove;

    /// <summary>
    /// Initializes a new instance of the <see cref="MovePlayerRightCommand"/> class.
    /// </summary>
    /// <param name="playerEntity">A player entity</param>
    /// <param name="shouldMove">A boolean indicating if the player should move or not</param>
    public MovePlayerRightCommand(PlayerEntity playerEntity, bool shouldMove)
    {
        _playerEntity = playerEntity;
        _shouldMove = shouldMove;
    }

    /// <summary>
    /// Executes the command by setting the right movement of the player entity.
    /// </summary>
    public void Execute()
    {
        _playerEntity.SetMoveRight(_shouldMove);
    }
}