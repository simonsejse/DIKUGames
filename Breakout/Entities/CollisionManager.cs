using Breakout.Entities;
using DIKUArcade.Physics;
using DIKUArcade.Math;

namespace Breakout.Entities;

public static class CollisionManager
{
    #region Methods
    public static void CheckBallPlayerCollision(BallEntity ballEntity, PlayerEntity playerEntity)
    {
        if (CollisionDetection.Aabb(ballEntity.Shape.AsDynamicShape(), playerEntity.Shape.AsDynamicShape()).Collision)
        {
            Vec2F playerCenter = playerEntity.Shape.Position + (playerEntity.Shape.Extent * 0.5f);
            Vec2F ballCenter = ballEntity.Shape.Position + (ballEntity.Shape.Extent * 0.5f);

            Vec2F diff = playerCenter - ballCenter;

            Vec2F newDirection = new Vec2F(ballEntity.GetDirection().X, -ballEntity.GetDirection().Y);
            ballEntity.ChangeDirection(newDirection.X, newDirection.Y);

            float angleAdjustmentX = diff.X * 0.6f;

            ballEntity.RotateDirection(angleAdjustmentX);
            
            ballEntity.Shape.Move(new Vec2F(0.0f, 0.0f));
        }
    }
    #endregion
}