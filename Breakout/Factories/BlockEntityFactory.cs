using Breakout.Entities;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

public class BlockEntityFactory : IEntityFactory<BlockEntity>
{
    private readonly Vec2F _pos;
    private readonly Image _image;

    public BlockEntityFactory(Vec2F pos, Image image)
    {
        _pos = pos;
        _image = image;
    }

    public BlockEntity Create()
    {
        return new BlockEntity(new StationaryShape(_pos, new Vec2F(0.08333333333f, 0.04f)), _image, 0, 100);
    }
}