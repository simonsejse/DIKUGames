using Breakout.States;
using Breakout.States.GameRunning;
using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Physics;

namespace Breakout.Entities;

public static class CollisionProcessor
{
    public static void CheckBlockCollisions(EntityContainer<BlockEntity> blockEntities, BallEntity ballEntity, PlayerEntity playerEntity, GameRunningState state)
    {
        CollisionDirection collisionDir = CollisionDirection.CollisionDirUnchecked;
    
        blockEntities.Iterate(block =>
        {
            CollisionDirection currentCollisionDir =
                CollisionDetection.Aabb(ballEntity.Shape.AsDynamicShape(), block.Shape).CollisionDir;
            if (currentCollisionDir == CollisionDirection.CollisionDirUnchecked)
                return;
            
            block.HandleCollision();
            
            ballEntity.BounceOffBlock(currentCollisionDir);
            
            if (!block.IsDead())
                return;
            
            playerEntity.AddPoints(block.Value);
            state.UpdateText();
            
            if (collisionDir == CollisionDirection.CollisionDirUnchecked)
                collisionDir = currentCollisionDir;


        });
    }

    public static void CheckBallPlayerCollision(BallEntity ballEntity, PlayerEntity playerEntity)
    {
        if (!CollisionDetection.Aabb(ballEntity.Shape.AsDynamicShape(), playerEntity.Shape.AsDynamicShape()).Collision)
            return;

        float ballCenterX = ballEntity.Shape.Position.X + (ballEntity.Shape.Extent.X / 2);
        float impactAreaX = playerEntity.Shape.Position.X + (playerEntity.Shape.Extent.X / 2);
        float dImpact = ballCenterX - impactAreaX;

        float maxImpact = 0.15f; // Maximum impact distance from the center
        float angle = dImpact / maxImpact * 90f; // Calculate the angle based on the impact position

        // Convert angle to radians
        float angleInRadians = angle * (float)Math.PI / 180f;

        if (dImpact > 0)
        {
            // Calculate the new direction based on the angle
            float newX = ballEntity.GetDirection().X * (float)Math.Cos(angleInRadians) - ballEntity.GetDirection().Y * (float)Math.Sin(angleInRadians);
            float newY = ballEntity.GetDirection().X * (float)Math.Sin(angleInRadians) + ballEntity.GetDirection().Y * (float)Math.Cos(angleInRadians);

            ballEntity.ChangeDirection(newX, -newY);
        }
    
        if (dImpact < 0)
        {
            // Calculate the new direction based on the angle
            float newX = ballEntity.GetDirection().X * (float)Math.Cos(angleInRadians) - ballEntity.GetDirection().Y * (float)Math.Sin(angleInRadians);
            float newY = ballEntity.GetDirection().X * (float)Math.Sin(angleInRadians) + ballEntity.GetDirection().Y * (float)Math.Cos(angleInRadians);

            ballEntity.ChangeDirection(newX, -newY);
        }

        ballEntity.Shape.Move(ballEntity.GetDirection());
    }


    public static bool CheckPowerUpPlayerCollision(PowerUpEntity powerUpEntity, PlayerEntity playerEntity)
    {
        return CollisionDetection.Aabb(powerUpEntity.Shape.AsDynamicShape(), playerEntity.Shape).Collision;
    }
}