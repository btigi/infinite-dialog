public class BaldurLuaReader
{
    private readonly string[] lines;

    public BaldurLuaReader(string path)
    {
        lines = File.ReadAllLines(path);
    }

    public bool HasEntry(string name, int number)
    {
        foreach (var line in lines)
        {
            if (line.Trim().Equals($"SetPrivateProfileString('Script','{name}','{number}')", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}