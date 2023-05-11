using Breakout.Entities;
using Breakout.Entities.BlockTypes;
using Breakout.Factories;
using Breakout.IO;
using Breakout.Storage;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Levels;

/// <summary>
/// A LevelLoader class implementation that follows the Dependency Inversion Principle (DIP) by
/// depending on abstractions rather than concrete implementations.
/// Makes it more flexible and easily interchangeable with new LevelLoaders.
/// follows 
/// </summary>
public class LevelLoader : ILevelLoader<BlockEntity>
{
    private readonly LevelStorage _levelStorage;
    private readonly IModelFactory<Level> _levelFactory;

    public LevelLoader()
    {
        _levelFactory = new LevelFactory();
        _levelStorage = new LevelStorage();
    }

    public EntityContainer<BlockEntity> LoadLevel(int levelNum)
    {
        EntityContainer<BlockEntity> blockEntities = new();
        string filePath = _levelStorage.LevelPaths[levelNum];
        FileReader.ReadFileFromPath(Path.Combine("Assets", "Levels", filePath), out var data);
        var level = _levelFactory.Parse(data);
        for (int row = 0; row < level.Map.Length; row++)
        {
            for (int column = 0; column < level.Map[row].Length; column++)
            {
                char key = level.Map[row][column];
                if (key == '-') continue;

                const float offsetY = 0.1f;
                
                int rowLength = level.Map[0].Length;
                float posX = 100f / rowLength / 100f * column;
                
                int columnLength = level.Map.Length;
                float posY = offsetY + 90f/columnLength/100f * row;
                
                Vec2F pos = new Vec2F(posX, posY);
        
                string path = level.Legends.TryGetValue(key, out string? image) ? image : "error-block.png";
                string path2 = path.Replace(".png", "-damaged.png");
                BlockEntityFactory factory = new BlockEntityFactory(pos, new Image(Path.Combine("Assets", "Images", path)),
                    new Image(Path.Combine("Assets", "Images", path2)));
                BlockEntity blockEntity = factory.Create();
                blockEntities.AddEntity(blockEntity);
            }
        }

        return blockEntities;
    }
}