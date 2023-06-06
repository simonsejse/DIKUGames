using Breakout.Entities;

namespace Breakout.Commands.GameRunning;

public class MovePlayerLeftCommand : IKeyboardCommand
{
    private readonly PlayerEntity _playerEntity;
    private readonly bool _shouldMove;

    /// <summary>
    /// Initializes a new instance of the <see cref="MovePlayerLeftCommand"/> class.
    /// </summary>
    /// <param name="playerEntity">A player entity</param>
    /// <param name="shouldMove">A boolean indicating if the player should move or not</param>
    public MovePlayerLeftCommand(PlayerEntity playerEntity, bool shouldMove)
    {
        _playerEntity = playerEntity;
        _shouldMove = shouldMove;
    }

    /// <summary>
    /// Executes the command by setting the left movement of the player entity.
    /// </summary>
    public void Execute()
    {
        _playerEntity.SetMoveLeft(_shouldMove);
    }
}