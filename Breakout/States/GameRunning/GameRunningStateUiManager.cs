using System.Drawing;
using Breakout.Factories;
using Breakout.Utility;
using DIKUArcade.Graphics;
using DIKUArcade.Timers;

namespace Breakout.States.GameRunning;
public class GameRunningStateUiManager {
    private readonly Text _scoreText;
    private readonly Text _levelText;
    private readonly Text _healthText;
    private readonly Text _timerText;
    private readonly Text _launchText;
    private bool _launchToggled;
    
    public GameRunningStateUiManager() {
        _healthText = DefaultTextFactory.Create(string.Empty, PositionUtil.HealthPosition, 
            PositionUtil.HealthExtent, Color.Red);
        _scoreText = DefaultTextFactory.Create(string.Empty, PositionUtil.ScorePosition, 
            PositionUtil.ScoreExtent, Color.White);
        _levelText = DefaultTextFactory.Create(string.Empty, PositionUtil.LevelPosition, 
            PositionUtil.LevelExtent, Color.White);
        _timerText = DefaultTextFactory.Create(string.Empty, PositionUtil.TimerPosition, 
            PositionUtil.TimerExtent, Color.White);
        _launchText = DefaultTextFactory.Create("'L' to launch ball", PositionUtil.LaunchPosition, 
            PositionUtil.LaunchExtent, Color.White);
        _launchToggled = true;
    }

    /// <summary>
    /// Renders the text elements on the screen.
    /// </summary>
    public void RenderText() {
        _scoreText.RenderText();
        _levelText.RenderText();
        _healthText.RenderText();
        _timerText.RenderText();
        if (_launchToggled) { _launchText.RenderText(); }
    }

    /// <summary>
    /// Updates the health text with the given number of lives.
    /// </summary>
    /// <param name="lives">The number of lives.</param>
    public void UpdateHealth(int lives) {
        _healthText.SetText($"{lives} {string.Concat(Enumerable.Repeat("❤", lives))}");
    }
    
    /// <summary>
    /// Updates the score text with the given points.
    /// </summary>
    /// <param name="points">The score points.</param>
    public void UpdateScore(int points) {
        _scoreText.SetText($"Score: {points}");
    }
    
    /// <summary>
    /// Updates the level text with the given level number.
    /// </summary>
    /// <param name="level">The level number.</param>
    public void UpdateLevel(int level) {
        _levelText.SetText($"Level: {level + 1}");
    }
    
    /// <summary>
    /// Updates the timer text with the remaining time.
    /// </summary>
    /// <param name="time">The remaining time in seconds.</param>
    public void UpdateTimer(int? time) {
        if (!time.HasValue)
            return;
        _timerText.SetText($"Time left: {time-StaticTimer.GetElapsedSeconds():0}s");
    }

    /// <summary>
    /// Toggles the visibility of the launch text.
    /// </summary>
    public void ToggleLaunch() {
        _launchToggled = !_launchToggled;
    }
}