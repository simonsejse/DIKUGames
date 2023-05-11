using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

public class BackgroundFactory : IEntityFactory<Entity>
{
    private readonly string _imagePath;
    
    public BackgroundFactory(params string[] args)
    {
        _imagePath = Path.Combine(args);
    }
    
    public Entity Create()
    {
        Image image = new Image(_imagePath);
        return new Entity(new StationaryShape(new Vec2F(0, 0), new Vec2F(1, 1)), image);
    }
}