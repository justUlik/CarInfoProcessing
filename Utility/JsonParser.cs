using System.Text;
using System.Text.RegularExpressions;

namespace Utility;

/// <summary>
/// A utility class for parsing JSON data and converting it into a list of CarInfo objects.
/// </summary>
public static class JsonParser
{
    /// <summary>
    /// Parses a JSON string into a list of lists of strings.
    /// </summary>
    /// <param name="inputString">The JSON string to parse.</param>
    /// <returns>A list of lists of strings representing the parsed JSON data.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the input string is null or empty.</exception>
    /// <exception cref="FormatException">Thrown if the input string is incorrectly formatted.</exception>
    private static List<List<string>> ParseJsonString(string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            throw new ArgumentNullException("Empty or null string given.");
        }

        StringBuilder element = new StringBuilder();
        List<String> line = new List<string>();
        List<List<String>> allLines = new List<List<string>>();
        State state;
        
        string regexPattern = @"^[a-zA-Z0-9]$";

        try
        {
            if (inputString[0] == '{')
            {
                state = State.StartLine;
            }
            else
            {
                throw new FormatException("Incorrect string.");
            }

            for (int i = 1; i < inputString.Length; ++i)
            {
                char ch = inputString[i];
                switch (state)
                {
                    case State.StartLine:
                        if (ch == '\"')
                        {
                            state = State.ElementInsideQuotes;
                            element = new StringBuilder();
                            line = new List<string>();
                        }

                        break;
                    case State.ElementInsideQuotes:
                        if (ch == '\"')
                        {
                            state = State.InsideLine;
                            line.Add(element.ToString());
                        }
                        else
                        {
                            element.Append(ch);
                        }

                        break;
                    case State.ElementLine:
                        if (ch == ',')
                        {
                            state = State.StartLine;
                            line.Add(element.ToString());
                            allLines.Add(line);
                        }
                        else
                        {
                            element.Append(ch);
                        }

                        break;
                    case State.InsideLine:
                        if (Regex.IsMatch(ch.ToString(), regexPattern))
                        {
                            element = new StringBuilder();
                            element.Append(ch);
                            state = State.ElementLine;
                        }
                        else if (ch == '\"')
                        {
                            element = new StringBuilder();
                            state = State.ElementInsideQuotes;
                        }
                        else if (ch == '[')
                        {
                            state = State.StartList;
                        }
                        else if (ch == '}')
                        {
                            allLines.Add(line);
                        }
                        else if (ch == ',')
                        {
                            state = State.StartLine;
                            allLines.Add(line);
                        }

                        break;
                    case State.StartList:
                        if (ch == '\"')
                        {
                            element = new StringBuilder();
                            state = State.ElementList;
                        }

                        break;

                    case State.ElementList:
                        if (ch == '\"')
                        {
                            state = State.InsideList;
                            line.Add(element.ToString());
                        }
                        else
                        {
                            element.Append(ch);
                        }

                        break;

                    case State.InsideList:
                        if (ch == '\"')
                        {
                            state = State.ElementList;
                            element = new StringBuilder();
                        }
                        else if (ch == ']')
                        {
                            allLines.Add(line);
                        }

                        break;
                }

            }

            return allLines;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Splits a JSON string into individual records.
    /// </summary>
    /// <param name="inputData">The JSON string to split.</param>
    /// <returns>A list of lists of lists of strings representing the split JSON records.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the input string is null or empty.</exception>
    /// <exception cref="FormatException">Thrown if the input string does not correspond to the expected format.</exception>
    private static List<List<List<string>>> SplitJsonRecordsToString(string inputData)
    {
        if (string.IsNullOrEmpty(inputData))
        {
            throw new ArgumentNullException("Empty or null string given.");
        }

        try
        {
            //inputData = inputData.Replace('\n', ' ');
            if (!Regex.IsMatch(inputData, @"^\s*\[\s*((\{\s*([^}]*)\s*\}(,\s*\{\s*([^}]*)\s*\})*))\s*\]\s*$"))
            {
                throw new FormatException("Data does not correspond the format.");
            }
            string pattern = @"\{[^}]*\[[^]]*\][^}]*\}";
            MatchCollection matches = Regex.Matches(inputData, pattern);
            if (matches is null)
            {
                throw new ArgumentNullException(nameof(matches));
            }
            List<List<List<string>>> records = new List<List<List<string>>>();
            foreach (Match match in matches)
            {
                var record = ParseJsonString(match.ToString());
                if (record is null || (record is not null && record.Count == 0))
                {
                    throw new ArgumentNullException(nameof(matches));
                }
                records.Add(record);
            }
            return records;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Reads a JSON string from the console and converts it into a list of CarInfo objects.
    /// </summary>
    /// <returns>A list of CarInfo objects representing the read and converted JSON data.</returns>
    /// <exception cref="Exception">Thrown if an error occurs during reading or conversion.</exception>
    public static List<CarInfo> ReadJson()
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder();
            string data = Console.ReadLine()!;
            while (!string.IsNullOrEmpty(data))
            {
                stringBuilder.Append(data);
                data = Console.ReadLine()!;
            }
            string inputData = stringBuilder.ToString();
        
            List<List<List<string>>> records = SplitJsonRecordsToString(inputData);
            return Converting.JsonToCarInfo(records);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Writes a JSON string to a file.
    /// </summary>
    /// <param name="data">The JSON string to write.</param>
    /// <param name="filePath">The path to the file to write to.</param>
    /// <exception cref="ArgumentNullException">Thrown if the input string or file path is null or empty.</exception>
    /// <exception cref="Exception">Thrown if an error occurs during writing.</exception>
    public static void WriteJson(string data, string filePath)
    {
        if (string.IsNullOrEmpty(data))
        {
            throw new ArgumentNullException(nameof(data));
        }

        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentNullException(nameof(data));
        }

        try
        {
            if (!File.Exists(filePath))
            {
                var file = File.Create(filePath);
                file.Close();
            }
            
            var encoding = Console.OutputEncoding;
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Console.SetOut(writer);
                Console.WriteLine(data);
            }
            StreamWriter defConsoleWriter = new StreamWriter(Console.OpenStandardOutput(), encoding:encoding);
            defConsoleWriter.AutoFlush = true;
            Console.SetOut(defConsoleWriter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}