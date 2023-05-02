using Breakout.Entities;
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
    private static readonly HashSet<char> ExcludedChars = new () { '-', ' ' };
    
    private LevelStorage _levelStorage;
    private IModelFactory<Level> _levelFactory;

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
                if (ExcludedChars.Contains(key)) continue;
                
                const float offsetY = 0.1f;
                float posX = 100f/level.Map[0].Length/100f * column;
                float posY = offsetY + 90f/level.Map.Length/100f * row;
                
                var pos = new Vec2F(posX, posY);
        
                string path = level.Legends.TryGetValue(key, out string? image) ? image : "error-block.png";
                
                var factory = new BlockEntityFactory(pos, new Image(Path.Combine("Assets", "Images", path)));
                var blockEntity = factory.Create();
                blockEntities.AddEntity(blockEntity);
            }
        }

        return blockEntities;
    }
}