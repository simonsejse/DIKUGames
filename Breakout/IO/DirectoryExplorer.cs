using System.Runtime.InteropServices;

namespace Breakout.IO;

/// <summary>
/// Utility class TODO: Add XML documentation
/// </summary>
public static class DirectoryExplorer
{
    public static List<string> GetDirectoryFilePaths(string dir)
    {
        if (!Directory.Exists(dir))
            return new List<string>();
        
        try
        {
            return Directory.GetFiles(dir).Select(file => Path.GetFileName(file)).ToList();
        }
        catch (Exception e)
        {
            return new List<string>();
        }
    }
}