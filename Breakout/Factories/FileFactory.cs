namespace Breakout.Factories;

public class FileFactory : IFileFactory
{
    public void ReadFile(string path, out string data)
    {
        try
        {
            data = File.ReadAllText(Path.Combine(path));
        }
        catch (Exception e)
        {
            data = "";
        }
    }
}