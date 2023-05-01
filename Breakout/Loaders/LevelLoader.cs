using Breakout.Entities;
using Breakout.Factories;
using Breakout.IO;
using Breakout.Storage;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;

namespace Breakout.Loaders;


public class LevelLoader
{
    #region Properties
    private LevelStorage _levelStorage;
    private IModelFactory<Level> _levelFactory;
    
    #endregion
    #region Constructor
    public LevelLoader()
    {
        _levelFactory = new LevelFactory();
        _levelStorage = new LevelStorage();
    }
    #endregion
    #region Methods
    public void LoadLevel(int levelNum, EntityContainer<BlockEntity> blockEntities)
    {
        var filePath = _levelStorage.LevelPaths[levelNum];
        FileReader.ReadFileFromPath(Path.Combine("Assets", "Levels", filePath), out var data);
        var level = _levelFactory.Parse(data);
        for (var row = 0; row < level.Map.Length; row++)
        {
            for (var column = 0; column < level.Map[row].Length; column++)
            {
                char key = level.Map[row][column];
                if (key == '-') continue;

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
    }
    #endregion
}