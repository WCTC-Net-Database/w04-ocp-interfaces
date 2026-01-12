# Week 4: Open/Closed Principle (OCP) & Interfaces

> **Template Purpose:** This template represents a working solution through Week 3. Use YOUR repo if you're caught up. Use this as a fresh start if needed.

---

## Overview

This week introduces **interfaces** and the **Open/Closed Principle (OCP)**: software should be open for extension but closed for modification. You'll create an `IFileHandler` interface that allows your program to support multiple file formats (CSV and JSON) without changing the core logic. This is a key concept - when your boss says "we need JSON support," you can add it without breaking existing code.

## Learning Objectives

By completing this assignment, you will:
- [ ] Understand and apply the Open/Closed Principle
- [ ] Create and implement interfaces in C#
- [ ] Add JSON file support alongside existing CSV
- [ ] See how interfaces enable extensibility

## Prerequisites

Before starting, ensure you have:
- [ ] Completed Week 3 assignment (or are using this template)
- [ ] Working CharacterReader and CharacterWriter classes
- [ ] Understanding of classes and methods

## What's New This Week

| Concept | Description |
|---------|-------------|
| OCP | Open for extension, closed for modification |
| Interface | Contract that classes must implement |
| `IFileHandler` | Interface defining read/write methods |
| `JsonFileHandler` | New implementation for JSON format |
| Strategy Pattern | Swap implementations at runtime |

---

## Assignment Tasks

### Task 1: Create the IFileHandler Interface

**What to do:**
- Create `IFileHandler.cs` with methods for reading and writing
- This defines the "contract" all file handlers must follow

**Example:**
```csharp
public interface IFileHandler
{
    List<Character> ReadCharacters(string filePath);
    void WriteCharacters(string filePath, List<Character> characters);
}
```

### Task 2: Implement CsvFileHandler

**What to do:**
- Create `CsvFileHandler.cs` that implements `IFileHandler`
- Move your existing CSV logic into this class

**Example:**
```csharp
public class CsvFileHandler : IFileHandler
{
    public List<Character> ReadCharacters(string filePath)
    {
        // Your existing CSV reading logic
    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        // Your existing CSV writing logic
    }
}
```

### Task 3: Implement JsonFileHandler

**What to do:**
- Create `JsonFileHandler.cs` that implements `IFileHandler`
- Use `System.Text.Json` or `Newtonsoft.Json` for JSON handling

**Example:**
```csharp
using System.Text.Json;

public class JsonFileHandler : IFileHandler
{
    public List<Character> ReadCharacters(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Character>>(json);
    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        string json = JsonSerializer.Serialize(characters, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}
```

### Task 4: Update Program to Use Interface

**What to do:**
- Declare your file handler as `IFileHandler` type
- The program doesn't need to know which implementation it's using

**Example:**
```csharp
// Program only knows about IFileHandler, not the specific implementation
IFileHandler fileHandler = new JsonFileHandler(); // or CsvFileHandler
var characters = fileHandler.ReadCharacters("input.json");
```

---

## Stretch Goal (+10%)

**Strategy Pattern - Switch Formats at Runtime**

Add a menu option to switch between CSV and JSON without restarting:

```
1. Display Characters
2. Find Character
3. Add Character
4. Level Up Character
5. Change File Format (CSV/JSON)
0. Exit
```

```csharp
// Switch handler based on user choice
if (userChoice == "json")
    fileHandler = new JsonFileHandler();
else
    fileHandler = new CsvFileHandler();
```

---

## JSON File Format

Your JSON file should look like:
```json
[
  {
    "Name": "John",
    "Class": "Fighter",
    "Level": 1,
    "HP": 10,
    "Equipment": ["sword", "shield", "potion"]
  },
  {
    "Name": "Jane",
    "Class": "Wizard",
    "Level": 2,
    "HP": 6,
    "Equipment": ["staff", "robe", "book"]
  }
]
```

---

## Project Structure

```
YourProjectName/
├── Program.cs              # Main program using IFileHandler
├── Character.cs            # Character data class
├── Interfaces/
│   └── IFileHandler.cs     # Interface definition
├── FileHandlers/
│   ├── CsvFileHandler.cs   # CSV implementation
│   └── JsonFileHandler.cs  # JSON implementation
├── input.csv               # CSV data file
└── input.json              # JSON data file
```

---

## The Power of OCP

**Before (violates OCP):**
```csharp
// Adding XML support requires modifying existing code
if (format == "csv") { /* csv logic */ }
else if (format == "json") { /* json logic */ }
else if (format == "xml") { /* must add here */ }
```

**After (follows OCP):**
```csharp
// Adding XML support = create new class, no existing code changes
IFileHandler handler = new XmlFileHandler(); // Just add new implementation!
```

---

## Grading Rubric

| Criteria | Points | Description |
|----------|--------|-------------|
| IFileHandler Interface | 25 | Properly defined interface with read/write methods |
| CsvFileHandler | 20 | Correctly implements interface for CSV |
| JsonFileHandler | 25 | Correctly implements interface for JSON |
| OCP Compliance | 20 | Program uses interface, not concrete classes |
| Code Quality | 10 | Clean, readable, well-commented |
| **Total** | **100** | |
| **Stretch: Strategy Pattern** | **+10** | Switch formats via menu at runtime |

---

## How This Connects to the Final Project

- `IFileHandler` pattern is the same pattern used for database access
- In Week 9, you'll see how EF Core uses similar interface patterns
- The Strategy Pattern appears throughout professional code
- This is exactly how you'd handle "boss wants a new format" in real work

---

## Tips

- Start by creating the interface before implementations
- Test each handler independently with simple read/write
- JSON is easier to debug (human-readable format)
- Use `JsonSerializerOptions { WriteIndented = true }` for readable JSON output

---

## Submission

1. Commit your changes with a meaningful message
2. Push to your GitHub Classroom repository
3. Submit the repository URL in Canvas

---

## Resources

- [C# Interfaces](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/)
- [System.Text.Json](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview)
- [Open/Closed Principle](https://stackify.com/solid-design-open-closed-principle/)

---

## Need Help?

- Post questions in the Canvas discussion board
- Attend office hours
- Review the in-class repository for additional examples
