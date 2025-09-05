namespace Mxemelt;

public static class Reader
{
    static Reader()
    {
        
    }
    
    public static string ReadFile(string path)
    {
        return File.ReadAllText(path);
    }
}