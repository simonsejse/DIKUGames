using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Galaga;


public class Score {
  private readonly Text _scoreText;
  private int _score;

  public Score(Vec2F position, Vec2F extent){
    _score = 0;
    _scoreText = new Text("Score: 0", pos: position, extent: extent);
    _scoreText.SetColor(Color.White);
  }

  public int GetScore()
  {
    return _score;
  }
  public void IncrementScore(){
    _scoreText.SetText($"Score: {++_score}");
  }
  public void RenderText()
  {
      _scoreText.RenderText();
  }
}