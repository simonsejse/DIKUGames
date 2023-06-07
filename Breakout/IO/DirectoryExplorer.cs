
namespace Breakout.IO;

/// <summary>
/// Provides methods for exploring directories and retrieving file paths.
/// </summary>
public static class DirectoryExplorer {
    /// <summary>
    /// Retrieves the file paths of all files within the specified directory.
    /// </summary>
    /// <param name="dir">The directory path.</param>
    /// <returns>A list of file paths within the directory.</returns>
    public static List<string> GetDirectoryFilePaths(string dir) {
        if (!Directory.Exists(dir))
            return new List<string>();
        try {
            return Directory.GetFiles(dir).Select(file => Path.GetFileName(file)).ToList();
        } catch (Exception) {
            return new List<string>();
        }
    }
}