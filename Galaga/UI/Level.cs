using System.Drawing;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Galaga;


public class Level {
  private readonly Text _levelText;
  private int _level;

  public Level(Vec2F position, Vec2F extent){
    _level = 0;
    _levelText = new Text("Level: 0", pos: position, extent: extent);
    _levelText.SetColor(Color.White);
  }

  public void IncrementLevel(){
    _levelText.SetText($"Level: {++_level}");
  }
  public void RenderText()
  {
    _levelText.RenderText();
  }

  public int GetScore()
  {
    return _level;
  }
}