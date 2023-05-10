using Breakout.Entities;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Factories;

public class BallEntityFactory : IEntityFactory<BallEntity>
{
    #region Properties and fields
    private readonly float _speed;
    private readonly Vec2F _direction;
    #endregion
    
    #region Constructor

    public BallEntityFactory(float speed, Vec2F direction)
    {
        _speed = speed;
        _direction = direction;
    }
    #endregion
    public BallEntity Create()
    {
        return new BallEntity(new DynamicShape(0.5f - 0.03f / 2,
                0.03f + 0.03f,
                0.03f,
                0.03f),
            new Image(Path.Combine("Assets",
                "Images",
                "Ball.png")), _direction, _speed);
        
        }
}