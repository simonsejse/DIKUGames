using System.Drawing;
using System.Linq;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Galaga.entities;

public class Health {
    private int _health;
    private Text _display;
    
    public Health (Vec2F position, Vec2F extent) {
        _health = 3;
        _display = new Text($"{_health} {string.Concat(Enumerable.Repeat("❤", _health))}", position, extent);
        _display.SetColor(Color.Red);
    }

    public int GetHealth()
    {
        return _health;
    }

    // Remember to explaination your choice as to what happens
    //when losing health.
    public void LoseHealth ()
    {
        if (_health < 1) return;
        _health--;
        _display.SetText($"{_health} {string.Concat(Enumerable.Repeat("❤", _health))}");

        //Prevent ArgumentOutOfRangeException for Enumerable.Repeat
    }
    
    public void RenderHealth () {
        _display.RenderText();
    }
}