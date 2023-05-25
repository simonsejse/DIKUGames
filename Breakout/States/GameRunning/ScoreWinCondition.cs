using Breakout.Entities;

namespace Breakout.States.GameRunning;

public class ScoreWinCondition : IWinCondition
{
    private readonly PlayerEntity _playerEntity;

    public ScoreWinCondition(PlayerEntity playerEntity)
    {
        _playerEntity = playerEntity;
    }

    public bool HasWon(int currentLevel)
    {
        return _playerEntity.GetPoints() > 3000;
    }
}