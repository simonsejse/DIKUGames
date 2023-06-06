using Breakout.Factories;
using Breakout.IO;

namespace Breakout.Storage;

/// <summary>
/// Responsible for storing all file paths in the Assets/Levels directory.
/// </summary>
public class LevelStorage {
    /// <summary>
    /// Stores all file paths in the Assets/Levels directory.
    /// </summary>
    public List<string> LevelPaths { get;  }
    
    /// <summary>
    /// Constructs a new LevelStorage object.
    /// Adds all file paths in the Assets/Levels directory to the LevelPaths list.
    /// </summary>
    public LevelStorage() {
        LevelPaths = DirectoryExplorer.GetDirectoryFilePaths(Path.Combine("Assets", "Levels"));
    }
}