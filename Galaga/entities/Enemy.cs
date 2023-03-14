using System;
using System.Collections.Generic;
using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Events;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Galaga;

public class Enemy : Entity, IGameEventProcessor
{
    private int Hitpoints { set; get; } = 10;
    private IBaseImage _enrageImage;

    public Enemy(DynamicShape shape, IBaseImage baseImage, IBaseImage enrageImage) : base(shape, baseImage)
    {
        _enrageImage = enrageImage;
    }
    
    public void ProcessEvent(GameEvent gameEvent)
    {
        if (gameEvent.From is not Game game) return;
        Hitpoints--;

        switch (Hitpoints)
        {
        case < 3 and > 0:
            Image = _enrageImage;
            break;
        case <= 0:
            DeleteEntity();
            game.AddExplosion(Shape.Position, Shape.Extent);
            break;
            
        } 
    }
}
