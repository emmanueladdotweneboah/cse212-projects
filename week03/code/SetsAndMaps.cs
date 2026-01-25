using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // -------------------- Problem 1 --------------------
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> results = new List<string>();

        foreach (string word in words)
        {
            string reversed = $"{word[1]}{word[0]}";

            if (seen.Contains(reversed) && word[0] != word[1])
            {
                results.Add($"{reversed} & {word}");
            }

            seen.Add(word);
        }

        return results.ToArray();
    }

    // -------------------- Problem 2 --------------------
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            if (fields.Length < 4)
                continue;

            string degree = fields[3].Trim();

            if (!degrees.ContainsKey(degree))
                degrees[degree] = 0;

            degrees[degree]++;
        }

        return degrees;
    }

    // -------------------- Problem 3 --------------------
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;
            counts[c]++;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;
            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    // -------------------- Problem 5 --------------------
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var response = client.GetAsync(uri).Result;
        using var stream = response.Content.ReadAsStream();
        using var reader = new StreamReader(stream);

        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        List<string> results = new List<string>();

        foreach (var feature in featureCollection.features)
        {
            if (feature.properties.mag != null)
            {
                results.Add($"{feature.properties.place} - Mag {feature.properties.mag}");
            }
        }

        return results.ToArray();
    }
}
