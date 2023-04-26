namespace Breakout.Factories;

public interface IFileFactory
{
    void ReadFile(string path, out string data);
}