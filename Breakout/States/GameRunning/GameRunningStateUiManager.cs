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

    public GameRunningStateUiManager(ITextFactory textFactory)
    {
        _healthText = textFactory.Create(string.Empty, ConstantsUtil.HealthPosition, ConstantsUtil.HealthExtent, Color.Red);
        _scoreText = textFactory.Create(string.Empty, ConstantsUtil.ScorePosition, ConstantsUtil.ScoreExtent, Color.White);
        _levelText = textFactory.Create(string.Empty, ConstantsUtil.LevelPosition, ConstantsUtil.LevelExtent, Color.White);
        _timerText = textFactory.Create(string.Empty, ConstantsUtil.TimerPosition, ConstantsUtil.TimerExtent, Color.White);
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
        string displayTime = time.Value.ToString();
        _timerText.SetText($"Timer: {StaticTimer.GetElapsedSeconds():0}s/{displayTime}s");
    }
}