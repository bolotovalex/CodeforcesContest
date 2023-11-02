using System.Text;

namespace Stickers;

public class Program
{
    public static void Main(string[] args)
    {  
        var sticker = new StringBuilder(Console.ReadLine());
        var stickersCount = int.Parse(Console.ReadLine());
        for (int i = 0; i<stickersCount; i++)
        {
            sticker = ChangeString(sticker, Console.ReadLine().Split(' '));
        }
        Console.WriteLine(sticker.ToString());
    }

    public static StringBuilder ChangeString(StringBuilder str, string[] args)
    {
        var startPos = int.Parse(args[0]) - 1;
        var endPos = int.Parse(args[1]) - 1;
        str.Remove(startPos, endPos - startPos + 1);
        str.Insert(startPos, args[2]);
        return str;
    }
}