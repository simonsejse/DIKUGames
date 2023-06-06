namespace Breakout.IO;

/// <summary>
/// Provides methods for reading files.
/// </summary>
public static class FileReader {
    /// <summary>
    /// Reads the contents of a file from the specified path.
    /// </summary>
    /// <param name="path">The path of the file to read.</param>
    /// <param name="data">The content of the file.</param>
    public static void ReadFileFromPath(string path, out string data) {
        try {
            data = File.ReadAllText(path);
        } catch (Exception) {
            data = "";
        }
    }
}