using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace Breakout.Entities;

public class WallEntity : Entity
{
    public WallEntity(Shape shape, IBaseImage image) : base(shape, image)
    {
        
    }

    public static WallEntity Create()
    {
        return new WallEntity(new StationaryShape(0, 0, 0, 1), new Image("Assets/Images/Overlay.png"));
    }
}