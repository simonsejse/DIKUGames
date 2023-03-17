using System;
using System.Collections.Generic;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using Galaga.MovementStrategy;

namespace Galaga.Squadron;

public class CircleSquadron : ISquadron
{
    private Random _random = new Random();
    public EntityContainer<Enemy> Enemies { get; } = new();
    public int MaxEnemies { get; }
    public void CreateEnemies(List<Image> enemyStride, List<Image> alternativeEnemyStride)
    {
        for (float i = 0; i < 2 * Math.PI; i+=(float) (_random.NextDouble() +_random.NextDouble()))
        {
            var enemy = new Enemy(
                new DynamicShape(new Vec2F(0.4f + (float) Math.Cos(i)/ 5.0f, (float)(Math.Sin(i) / 5) + 0.7f), new Vec2F(0.1f, 0.1f)),
                enemyStride: new ImageStride(80, enemyStride),
                alternativeEnemyStride: new ImageStride(80, alternativeEnemyStride),
                new ZigZagDown()
            );
            Enemies.AddEntity(enemy);
        }
       
    }
}