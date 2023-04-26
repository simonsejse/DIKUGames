using Breakout.Factories;
using Breakout.IO;

namespace Breakout.Storage;

public class LevelStorage
{
    #region Fields
    public List<string> LevelPaths { get;  }
    #endregion
    
    #region Constructors
    public LevelStorage()
    {
        LevelPaths = DirectoryExplorer.GetDirectoryFilePaths("Assets\\Levels");
    }
    #endregion
}