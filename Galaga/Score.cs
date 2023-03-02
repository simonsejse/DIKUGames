namespace Galaga;


public class Score {
  private int _score;

  public Score(){
    this._score = 0;
  }

  public void IncrementScore(){
    _score++;
  }
  public int GetScore(){
    return this._score;
  }
}