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
        Vec2F ballCenter = ballEntity.Shape.Position + (ballEntity.Shape.Extent * 0.5f);
        
        float playerWidth = playerEntity.Shape.Extent.X;
        float relativeCollisionX = (ballCenter.X - playerEntity.Shape.Position.X) / playerWidth;
        
                
                
                if (ballEntity.GetDirection().X > 0 && relativeCollisionX >= 0.15f && relativeCollisionX <= 0.2f)
                {
                    if (ballEntity.GetDirection().Y >= 0.68999964f && ballEntity.GetDirection().Y > 0)
                    {
                        // Only change the Y direction
                        ballEntity.ChangeDirection(ballEntity.GetDirection().X, -ballEntity.GetDirection().Y);
                    }
                    else
                    {
                        float angle = (float)Math.Atan2(ballEntity.GetDirection().Y, ballEntity.GetDirection().X);
                        float angleFactor = 1.3f + Math.Abs((float)Math.Cos(angle)) * 0.3f;
                        ballEntity.ChangeDirection(ballEntity.GetDirection().X * angleFactor, -ballEntity.GetDirection().Y * angleFactor);
                    }
                }
                else if (ballEntity.GetDirection().X < 0 && relativeCollisionX >= 0.15f && relativeCollisionX <= 0.2f)
                {
                    if (ballEntity.GetDirection().Y >= 0.68999964f && ballEntity.GetDirection().Y > 0)
                    {
                        // Only change the Y direction
                        ballEntity.ChangeDirection(ballEntity.GetDirection().X, -ballEntity.GetDirection().Y);
                    }
                    else
                    {
                        float angle = (float)Math.Atan2(ballEntity.GetDirection().Y, ballEntity.GetDirection().X);
                        float angleFactor = 1.3f + Math.Abs((float)Math.Cos(angle)) * 0.3f;
                        ballEntity.ChangeDirection(ballEntity.GetDirection().X * angleFactor, -ballEntity.GetDirection().Y * angleFactor);
                    }
                }
                else
                {
                    ballEntity.ChangeDirection(ballEntity.GetDirection().X, -ballEntity.GetDirection().Y);
                }
                
                ballEntity.Shape.Move(ballEntity.GetDirection());
    }
    }
    #endregion
}