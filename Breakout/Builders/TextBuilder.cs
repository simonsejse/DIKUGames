using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Builders;

public class TextBuilder
{
    private string _text;
    private Vec2F _pos;
    private Vec2F _extent;

    public TextBuilder()
    {
        _text = "";
        _pos = new Vec2F(0, 0);
        _extent = new Vec2F(0, 0);
    }
    
    public static TextBuilder Builder()
    {
        return new TextBuilder();
    }
    
    public TextBuilder SetText(string text)
    {
        _text = text;
        return this;
    }

    public TextBuilder SetPos(Vec2F pos)
    {
        _pos = pos;
        return this;
    }

    public TextBuilder SetExtent(Vec2F extent)
    {
        _extent = extent;
        return this;
    }
    
    public Text CreateText()
    {
        return new Text(_text, _pos, _extent);
    }
}