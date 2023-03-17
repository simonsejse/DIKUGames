using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using DIKUArcade.Entities;
using DIKUArcade.Events;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using Galaga.entities;
using Galaga.MovementStrategy;

namespace Galaga;

public class Enemy : Entity, IGameEventProcessor
{
    public float Speed { get; set; } = 0.0003f;
    public int Hitpoints { get; set; } = 5; 
    

    public readonly float Xo;
    public readonly float Yo;
    public IBaseImage AlternativeEnemyStride { get; }
    
    //Using composition to follow strategy design pattern
    private IMovementStrategy _movementStrategy;

    public Enemy(DynamicShape shape, IBaseImage enemyStride, IBaseImage alternativeEnemyStride, IMovementStrategy movementStrategy) : base(shape, enemyStride)
    {
        Xo = shape.Position.X;
        Yo = shape.Position.Y;
        AlternativeEnemyStride = alternativeEnemyStride;
        _movementStrategy = movementStrategy;
    }

    public void Move()
    {
        _movementStrategy.MoveEnemy(this);
    }

    public void ProcessEvent(GameEvent gameEvent)
    {
        if (gameEvent.From is not Game game) return;
        
        Hitpoints--;
        switch (Hitpoints)
        {
            case < 3 and > 0:
                Image = AlternativeEnemyStride;
                Speed += 0.003f;
                break;
            case <= 0:
                game.AddExplosion(Shape.Position, Shape.Extent);
                DeleteEntity();
                break;
        }
    }
}
