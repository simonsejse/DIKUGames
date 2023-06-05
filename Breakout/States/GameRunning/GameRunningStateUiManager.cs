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
    private readonly Text _launchText;
    private bool _launchToggled;
    
    public GameRunningStateUiManager()
    {
        _healthText = DefaultTextFactory.Create(string.Empty, PositionUtil.HealthPosition, PositionUtil.HealthExtent, Color.Red);
        _scoreText = DefaultTextFactory.Create(string.Empty, PositionUtil.ScorePosition, PositionUtil.ScoreExtent, Color.White);
        _levelText = DefaultTextFactory.Create(string.Empty, PositionUtil.LevelPosition, PositionUtil.LevelExtent, Color.White);
        _timerText = DefaultTextFactory.Create(string.Empty, PositionUtil.TimerPosition, PositionUtil.TimerExtent, Color.White);
        _launchText = DefaultTextFactory.Create("'L' to launch ball", PositionUtil.LaunchPosition, PositionUtil.LaunchExtent, Color.White);
        _launchToggled = true;
    }

    public void RenderText()
    {
        _scoreText.RenderText();
        _levelText.RenderText();
        _healthText.RenderText();
        _timerText.RenderText();
        if (_launchToggled) { _launchText.RenderText(); }
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
        _timerText.SetText($"Time left: {time-StaticTimer.GetElapsedSeconds():0}s");
    }

    public void ToggleLaunch()
    {
        _launchToggled = !_launchToggled;
    }
}