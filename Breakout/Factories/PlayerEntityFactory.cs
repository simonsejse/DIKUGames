using Breakout.Entites;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace Breakout.Factories;

public class PlayerEntityFactory : IEntityFactory<PlayerEntity>
{
    public PlayerEntity Create()
    {
        return new PlayerEntity(new DynamicShape(0.5f - 0.2f / 2f,
                0.03f,
                0.2f,
                0.028f),
            new Image(Path.Combine("Assets",
                "Images",
                "Player.png")));
    }
}