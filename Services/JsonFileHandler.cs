using W4_assignment_template.Interfaces;
using W4_assignment_template.Models;

// NOTE: The Character class uses [JsonProperty] attributes to map C# property names
// to the lowercase JSON keys required by the assignment. This ensures correct
// serialization and deserialization when reading from or writing to JSON files.

namespace W4_assignment_template.Services;

public class JsonFileHandler : IFileHandler
{
    public List<Character> ReadCharacters(string filePath)
    {
        // TODO: Implement JSON reading logic
        throw new NotImplementedException();
    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        // TODO: Implement JSON writing logic
        throw new NotImplementedException();
    }
}
