using Breakout.Containers;
using Breakout.States;
using Breakout.States.GameRunning;
using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Physics;

namespace Breakout.Entities;

public static class CollisionProcessor
{
    /// <summary>
    /// Checks for collisions between a ball and blocks in the block entities container.
    /// If a collision is detected, the block is handled (e.g., destroyed), and the ball bounces off the block.
    /// If the block is destroyed, the player earns points and the game state is updated.
    /// </summary>
    /// <param name="blockEntities">The container of block entities to check against.</param>
    /// <param name="ballEntity">The ball entity to check for collisions.</param>
    /// <param name="playerEntity">The player entity.</param>
    /// <param name="state">The current game running state.</param>
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

        if (!ballEntity.HardBallMode)
        {
            ballEntity.BallBounceOff(currentCollisionDir);
        }

        if (!block.IsDead())
            return;

        playerEntity.AddPoints(block.Value);
        state.UpdateText();

        if (collisionDir == CollisionDirection.CollisionDirUnchecked)
            collisionDir = currentCollisionDir;
    });
}

    
    /// <summary>
    /// Checks for collisions between a ball and other balls in the ball entities container.
    /// If a collision is detected, the balls bounce off each other based on the collision direction.
    /// </summary>
    /// <param name="ball">The ball to check for collisions.</param>
    /// <param name="ballEntities">The container of ball entities to check against.</param>
    public static void CheckBallCollisions(BallEntity ball, EntityContainer<BallEntity> ballEntities)
    {
        var ballsToCheck = new List<BallEntity>();

        ballEntities.Iterate(otherBall =>
        {
            if (ball == otherBall || ball.IsDeleted() || otherBall.IsDeleted())
                return;

            ballsToCheck.Add(otherBall);
        });

        foreach (var otherBall in ballsToCheck)
        {
            CollisionDirection currentCollisionDir =
                CollisionDetection.Aabb(ball.Shape.AsDynamicShape(), otherBall.Shape.AsDynamicShape()).CollisionDir;

            if (currentCollisionDir == CollisionDirection.CollisionDirUnchecked)
                continue;
            
            ball.BallBounceOff(currentCollisionDir);
            otherBall.BallBounceOff(currentCollisionDir);
        }
    }

    /// <summary>
    /// Checks for a collision between a ball entity and a player entity using Axis-Aligned Bounding Box (AABB) collision detection.
    /// If a collision is detected, it calculates the new direction of the ball based on the impact position.
    /// </summary>
    /// <param name="ballEntity">The ball entity to check for collision.</param>
    /// <param name="playerEntity">The player entity to check for collision.</param>
    public static void CheckBallPlayerCollision(BallEntity ballEntity, PlayerEntity playerEntity)
    {
        if (!CollisionDetection.Aabb(ballEntity.Shape.AsDynamicShape(), playerEntity.Shape.AsDynamicShape()).Collision)
            return;

        float ballCenterX = ballEntity.Shape.Position.X + (ballEntity.Shape.Extent.X / 2);
        float impactAreaX = playerEntity.Shape.Position.X + (playerEntity.Shape.Extent.X / 2);
        float dImpact = ballCenterX - impactAreaX;

        const float maxImpact = 0.15f;
        float angle = dImpact / maxImpact * 90f;
        
        float angleInRadians = angle * (float)Math.PI / 180f;

        float newX = ballEntity.GetDirection().X * (float)Math.Cos(angleInRadians) - ballEntity.GetDirection().Y * (float)Math.Sin(angleInRadians);
        float newY = ballEntity.GetDirection().X * (float)Math.Sin(angleInRadians) + ballEntity.GetDirection().Y * (float)Math.Cos(angleInRadians);
        ballEntity.ChangeDirection(newX, -newY);

        ballEntity.Shape.Move(ballEntity.GetDirection());
    }
    
    /// <summary>
    /// Checks for a collision between a power-up entity and a player entity using Axis-Aligned Bounding Box (AABB) collision detection.
    /// </summary>
    /// <param name="gameModifierEntity">The power-up entity to check for collision.</param>
    /// <param name="playerEntity">The player entity to check for collision.</param>
    /// <returns>True if a collision is detected; otherwise, false.</returns>
    public static bool CheckGameModifierEntityPlayerCollision(GameModifierEntity gameModifierEntity, PlayerEntity playerEntity)
    {
        return CollisionDetection.Aabb(gameModifierEntity.Shape.AsDynamicShape(), playerEntity.Shape).Collision;
    }
}