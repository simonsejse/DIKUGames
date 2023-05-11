using Breakout.Entities.BlockTypes;
using Breakout.Entities;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

///<summary>
/// Dependency Inversion Principle (DIP) by depending on abstractions rather than concrete implementations,
/// it depends on the <see cref="IEntityFactory{T}"/> interface, which allows it to be more flexible and easily
/// interchangeable with other entity factories
///</summary>
public class BlockEntityFactory : IEntityFactory<BlockEntity>
{
    private readonly Vec2F _pos;
    private readonly Image _image;
    private readonly Image _image2;

    public BlockEntityFactory(Vec2F pos, Image image, Image image2)
    {
        _pos = pos;
        _image = image;
        _image2 = image2;
    }

    public BlockEntity Create()
    {
        return new BlockEntity(new StationaryShape(_pos, new Vec2F(0.08333333333f, 0.04f)), _image, _image2, 10, 1, new HardenedBlockType());
    }
}