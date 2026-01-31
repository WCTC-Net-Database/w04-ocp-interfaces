using W4_assignment_template.Models;

namespace W4_assignment_template.Interfaces;

/// <summary>
/// Interface for handling character data storage in any format.
///
/// This interface demonstrates the Open/Closed Principle (OCP):
/// - We can add new handlers (JSON, XML, etc.) without modifying existing code
/// - Each implementation handles its own format-specific logic
///
/// Notice how this builds on Week 3's CharacterReader/CharacterWriter:
/// - ReadAll() and WriteAll() come from those classes
/// - FindByName() and FindByClass() bring in the LINQ methods you learned
///
/// This same pattern extends to databases in Week 9:
/// - DbContext is essentially an IFileHandler for SQL Server!
/// - You can swap database providers without changing business logic
/// </summary>
public interface IFileHandler
{
    /// <summary>
    /// Reads all characters from the data source.
    /// (From Week 3's CharacterReader.ReadAll)
    /// </summary>
    List<Character> ReadAll();

    /// <summary>
    /// Writes all characters to the data destination, replacing existing content.
    /// (From Week 3's CharacterWriter.WriteAll)
    /// </summary>
    void WriteAll(List<Character> characters);

    /// <summary>
    /// Appends a single character to the existing data.
    /// (From Week 3's CharacterWriter.AppendCharacter)
    /// </summary>
    void AppendCharacter(Character character);

    /// <summary>
    /// Finds a character by name using LINQ.
    /// (From Week 3's CharacterReader.FindByName)
    /// </summary>
    Character? FindByName(List<Character> characters, string name);

    /// <summary>
    /// Finds all characters of a specific class using LINQ.
    /// (From Week 3's CharacterReader.FindByClass)
    /// </summary>
    List<Character> FindByClass(List<Character> characters, string characterClass);
}
