using System.Collections.Generic;
using System.Linq;

public static class DictionaryExtentions
{
    private System.Random rand = new System.Random();

    public static string RouletteSelection(this Dictionary<string,int> dict)
    {

        List<int> valuelist = dict.Values.ToList();
        int sumDictValue = valuelist.Sum();
        int prob = rand.Next(0,sumDictValue);

        foreach(var key in dict.Keys)
        {
            prob -= dict[key];
            selectedKey = key;
            if(prob < 0)
            {
                break;
            }
        }

        return selectedKey;
    }

    public static string NthSelection(this Dictionary<string,int> dict, int n)
    {
        Dictionary<string,int> tempDict = dict.OrderByDescending(c => c.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        List<string> keyList = tempDict.Keys.ToList();
        
        return keyList[n];
    }
}
