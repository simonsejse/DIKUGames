using System;
using System.Collections.Generic;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using Galaga.MovementStrategy;

namespace Galaga.Squadron;

public class ZigSquadron : ISquadron
{
    private readonly Random _random = new();
    public EntityContainer<Enemy> Enemies { get; } = new();
    public int MaxEnemies => 8;

    public void CreateEnemies(List<Image> enemyStride, List<Image> alternativeEnemyStride)
    {
        bool s = false; 
        for (int i = 0; i < _random.Next(MaxEnemies) + 1; i++)
        {
            s = !s;
            var enemy = new Enemy(
                new DynamicShape(new Vec2F(0.1f + i * 0.1f, s ? 0.9f : 0.9f - 0.1f), new Vec2F(0.1f, 0.1f)),
                enemyStride: new ImageStride(80, enemyStride),
                alternativeEnemyStride: new ImageStride(80, alternativeEnemyStride),
                new ZigZagDown()
            );
            Enemies.AddEntity(enemy);
        }
    }
}