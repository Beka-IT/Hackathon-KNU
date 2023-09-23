namespace Hackathon_KNU.Helpers;

public class CensorTextHelper
{
    private static readonly string[] consoredWords =
    {
        "сука", "бля", "пизд", "еба", "долб", "оху", "аху"
    };
    
    public static bool IsCensored(string text)
    {
        foreach (var word in consoredWords)
        {
            if (text.ToLower().Contains(word)) return true;
        }

        return false;
    }
}