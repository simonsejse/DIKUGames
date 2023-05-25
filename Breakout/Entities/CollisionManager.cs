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
        float previousX = float.NaN;  // Variable to store the previous X position
        float previousY = float.NaN;  // Variable to store the previous Y position
    
        blockEntities.Iterate(block =>
        {
            if (!CollisionDetection.Aabb(ballEntity.Shape.AsDynamicShape(), block.Shape).Collision)
                return;
        
            float ballCenterX = ballEntity.Shape.Position.X + (ballEntity.Shape.Extent.X / 2);
            block.HandleCollision();
        
            /* BURDE ikke tillade at to blocke lige opad hinanden kan blive slettet på samme tid, men fungerer ikke
             if (!float.IsNaN(previousX) && (block.Shape.Position.X == previousX || block.Shape.Position.Y == previousY))
            {
                Console.WriteLine("Double BounceOffblock skip " + block.Shape.Position);
                return;
            }*/

            //else
                ballEntity.BounceOffBlock(block);
                if (!block.IsDead())
                    return;
                playerEntity.AddPoints(block.Value);
                state.UpdateText();
            

            Console.WriteLine(block.Shape.Position);

            previousX = block.Shape.Position.X;  // Update the previous X position
            previousY = block.Shape.Position.Y;  // Update the previous Y position
        });
    }

    public static void CheckBallPlayerCollision(BallEntity ballEntity, PlayerEntity playerEntity)
    {
        if (!CollisionDetection.Aabb(ballEntity.Shape.AsDynamicShape(), playerEntity.Shape.AsDynamicShape()).Collision)
            return;

        float ballCenterX = ballEntity.Shape.Position.X + (ballEntity.Shape.Extent.X / 2);
        float impactAreaX = playerEntity.Shape.Position.X + (playerEntity.Shape.Extent.X / 2);
        float dImpact = ballCenterX - impactAreaX;

        float maxImpact = 0.134f; // Maximum impact distance from the center
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