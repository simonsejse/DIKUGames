namespace Breakout.IO;

public static class FileReader 
{
    public static void ReadFileFromPath(string path, out string data)
    {
        try
        {
            data = File.ReadAllText(path);
        }
        catch (Exception e)
        {
            data = "";
        }
    }
}