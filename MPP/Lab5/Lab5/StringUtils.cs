namespace Lab5;

public static class StringUtils
{
    public static string Repeat(string pattern, int repeats)
    {
        if (repeats < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(repeats), "Repeats count cannot be less than zero");
        }
        
        var result = "";
        for (var i = 0; i < repeats; i++)
        {
            result += pattern;
        }

        return result;
    }

    public static string Repeat(string pattern, char separator, int repeats)
    {
        if (repeats < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(repeats), "Repeats count cannot be less than zero");
        }

        var result = "";
        for (var i = 0; i < repeats; i++)
        {
            result += $"{pattern}{separator}";
        }

        return result.TrimEnd(separator);
    }

    public static string Keep(string str, string pattern)
    {
        if (pattern == "*")
        {
            return str;
        }

        foreach (var c in str.Where(c => !pattern.Contains(c)))
        {
            str = str.Replace(c.ToString(), "");
        }
        
        return str;
    }

    public static string Loose(string str, string pattern)
    {
        return pattern == "*" 
            ? str 
            : pattern.Aggregate(str, (current, c) => current.Replace(c.ToString(), ""));
    }

    public static int IndexOfDifference(string str1, string str2)
    {
        if (str1 == str2)
        {
            return -1;
        }

        int iterationsCount = str1.Length > str2.Length ? str2.Length : str1.Length;

        for (var i = 0; i < iterationsCount; i++)
        {
            if (str1[i] != str2[i])
            {
                return i;
            }
        }

        return iterationsCount;
    }

    public static string Common(string str1, string str2)
    {
        string smallest = str1.Length <= str2.Length ? str1 : str2;
        string largest = str1.Length > str2.Length ? str1 : str2;
        return GetCommon(smallest, largest);
    }

    private static string GetCommon(string smallest, string largest)
    {
        if (largest.Contains(smallest))
        {
            return smallest;
        }
        
        if (smallest.Length == 2)
        {
            foreach (char c in smallest)
            {
                if (largest.Contains(c))
                {
                    return c.ToString();
                }
            }

            return "";
        }

        if (largest.Contains(smallest[..^1]))
        {
            return smallest[..^1];
        }

        if (largest.Contains(smallest[1..]))
        {
            return smallest;
        }

        return GetCommon(smallest[1..^1], largest);
    }

    public static string SubstringBetween(string str, string open, string close)
    {
        if (!str.Contains(open) || !str.Contains(close))
        {
            return "";
        }

        int startIndex = str.IndexOf(open, StringComparison.Ordinal) + open.Length;
        int endIndex = str.IndexOf(close, StringComparison.Ordinal);
        return str.Substring(startIndex, endIndex - startIndex);
    }

    public static int LevenshteinDistance(string str1, string str2)
    {
        if (str1 == str2)
        {
            return 0;
        }

        int levenshteinDistance = Math.Abs(str1.Length - str2.Length);
        string smallest = str1.Length >= str2.Length ? str2 : str1;
        for (var i = 0; i < smallest.Length; i++)
        {
            if (str1[i] != str2[i])
            {
                levenshteinDistance++;
            }
        }

        return levenshteinDistance;
    }

    public static int HamingDistance(string str1, string str2)
    {
        if (str1.Length != str2.Length)
        {
            throw new ArgumentException("Length of str1 and str2 should be equal");
        }

        return str1.Where((t, i) => t != str2[i]).Count();
    }
}