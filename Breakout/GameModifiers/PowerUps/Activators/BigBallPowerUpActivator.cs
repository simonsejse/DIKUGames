﻿using Breakout.Containers;
using Breakout.Entities;
using DIKUArcade.Entities;
using DIKUArcade.Math;

namespace Breakout.GameModifiers.PowerUps.Activators;

/// <summary>
/// Represents an activator for the Big Ball power-up.
/// </summary>
public class BigBallPowerUpActivator : IGameModifierActivator {
    private const float ScaleFactor = 1.5f;
    private readonly EntityManager _entityManager;

    /// <summary>
    /// Initializes a new instance of the BigBallPowerUpActivator class.
    /// </summary>
    /// <param name="entityManager">The EntityManager instance.</param>
    public BigBallPowerUpActivator(EntityManager entityManager) {
        _entityManager = entityManager;
    }
    
    /// <summary>
    /// Activates the Big Ball power-up.
    /// </summary>
    public void Activate() {
        List<BallEntity> existingBalls = new();
        EntityContainer<BallEntity> entityManagerBallEntities = _entityManager.BallEntities;
        entityManagerBallEntities.Iterate(ball => existingBalls.Add(ball));
        
        Scale(existingBalls, ScaleFactor);
        Task.Delay(5000).ContinueWith(t => Scale(existingBalls, 1f/ScaleFactor));
    }
    
    /// <summary>
    /// Helper function to scale a list of balls by a factor.
    /// </summary>
    /// <param name="balls">The list of BallEntity instances to be scaled.</param>
    /// <param name="factor">The scaling factor.</param>
    private static void Scale(List<BallEntity> balls, float factor) {
        balls.ForEach(ball => ball.MultiplyExtent(new Vec2F(factor, factor)));
    }
}