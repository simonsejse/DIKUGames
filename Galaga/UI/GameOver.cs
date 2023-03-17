using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Galaga;


public class GameOver {
  private readonly Text _gameOverText;

  public GameOver(Vec2F position, Vec2F extent){
    _gameOverText = new Text("Game Over", pos: position, extent: extent);
    _gameOverText.SetColor(Color.White);
  }
  
  public void RenderText(int score, int finalLevel)
  {
      _gameOverText.SetText($"Game Over\n-  Score {score}\n-  Level {finalLevel}");
      _gameOverText.RenderText();
  }
}