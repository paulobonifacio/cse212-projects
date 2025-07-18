using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Linq;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var w in words)
        {
            if (w[0] == w[1]) continue;
            var rev = new string(new[] { w[1], w[0] });
            if (seen.Contains(rev))
            {
                result.Add($"{rev} & {w}");
                seen.Remove(rev);
            }
            else
            {
                seen.Add(w);
            }
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            if (fields.Length < 4) continue;
            var degree = fields[3].Trim();
            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }
        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        int[] counts = new int[26];
        int total = 0;

        foreach (char ch in word1)
        {
            if (ch == ' ') continue;
            char c = char.ToLower(ch);
            if (c < 'a' || c > 'z') continue;
            counts[c - 'a']++;
            total++;
        }

        foreach (char ch in word2)
        {
            if (ch == ' ') continue;
            char c = char.ToLower(ch);
            if (c < 'a' || c > 'z') continue;
            int idx = c - 'a';
            if (counts[idx] == 0) return false;
            counts[idx]--;
            total--;
        }

        return total == 0;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        if (featureCollection?.Features == null) return new string[0];

        return featureCollection.Features
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
            .ToArray();
    }
}
