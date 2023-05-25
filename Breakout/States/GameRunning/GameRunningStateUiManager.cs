using System.Drawing;
using Breakout.Factories;
using Breakout.Utility;
using DIKUArcade.Graphics;
using DIKUArcade.Timers;

namespace Breakout.States.GameRunning;
public class GameRunningStateUiManager
{
    private readonly Text _scoreText;
    private readonly Text _levelText;
    private readonly Text _healthText;
    private readonly Text _timerText;

    public GameRunningStateUiManager()
    {
        _healthText = DefaultTextFactory.Create(string.Empty, PositionUtil.HealthPosition, PositionUtil.HealthExtent, Color.Red);
        _scoreText = DefaultTextFactory.Create(string.Empty, PositionUtil.ScorePosition, PositionUtil.ScoreExtent, Color.White);
        _levelText = DefaultTextFactory.Create(string.Empty, PositionUtil.LevelPosition, PositionUtil.LevelExtent, Color.White);
        _timerText = DefaultTextFactory.Create(string.Empty, PositionUtil.TimerPosition, PositionUtil.TimerExtent, Color.White);
    }

    public void RenderText()
    {
        _scoreText.RenderText();
        _levelText.RenderText();
        _healthText.RenderText();
        _timerText.RenderText();
    }

    public void UpdateHealth(int lives)
    {
        _healthText.SetText($"{lives} {string.Concat(Enumerable.Repeat("❤", lives))}");
    }
    
    public void UpdateScore(int points)
    {
        _scoreText.SetText($"Score: {points}");
    }
    
    public void UpdateLevel(int level)
    {
        _levelText.SetText($"Level: {level}");
    }
    
    public void UpdateTimer(int? time)
    {
        if (!time.HasValue)
            return;
        _timerText.SetText($"Timer: {StaticTimer.GetElapsedSeconds():0}s/{time.ToString()}");
    }
}