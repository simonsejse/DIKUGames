using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace Breakout.Entities;

public class Level : Entity
{
    private char[][] _map;
    private Meta _meta;
    private Dictionary<char, string> _legends;
    
    public Level(Shape shape, IBaseImage image) : base(shape, image)
    {
        
    }
}