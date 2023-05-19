using Breakout.States;
using DIKUArcade.Entities;
using DIKUArcade.Physics;

namespace Breakout.Entities;

public static class CollisionProcessor
{
    public static void CheckBlockCollisions(EntityContainer<BlockEntity> blockEntities, BallEntity ball, PlayerEntity playerEntity, GameRunningState state)
    {
        blockEntities.Iterate(block =>
        {
            if (!CollisionDetection.Aabb(ball.Shape.AsDynamicShape(), block.Shape).Collision) return;
            block.HandleCollision();
            ball.BounceOffBlock(block);
            if (!block.IsDead()) return;
            
            playerEntity.AddPoints(block.Value);
            state.UpdateText();
        });
    }
    public static void CheckBallPlayerCollision(BallEntity ballEntity, PlayerEntity playerEntity)
    {
        if (!CollisionDetection.Aabb(ballEntity.Shape.AsDynamicShape(), playerEntity.Shape.AsDynamicShape())
                .Collision) return;
        
        var ballCenter = ballEntity.Shape.Position + (ballEntity.Shape.Extent * 0.5f);
            
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

    public static bool CheckPowerUpPlayerCollision(PowerUpEntity powerUpEntity, PlayerEntity playerEntity)
    {
        //todo: check if powerup is colliding with player
        return false;
    }
}