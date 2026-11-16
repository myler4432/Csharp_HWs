using System.Text.Json;

var character = new GameCharacter
{
    Name = "Alex",
    Level = 15,
    Health = 87.5,
    Inventory = new[] { "Меч", "Щит", "Зелье здоровья" }
};

var options = new JsonSerializerOptions
{
    WriteIndented = true
};

string json = JsonSerializer.Serialize(character, options);
string filePath = Path.Combine(AppContext.BaseDirectory, "save.json");

File.WriteAllText(filePath, json);
Console.WriteLine($"Персонаж сохранён в файл: {filePath}");

string loadedJson = File.ReadAllText(filePath);
GameCharacter? loadedCharacter = JsonSerializer.Deserialize<GameCharacter>(loadedJson);

if (loadedCharacter is null)
{
    Console.WriteLine("Не удалось загрузить персонажа.");
    return;
}

Console.WriteLine();
Console.WriteLine("=== Загруженный персонаж ===");
Console.WriteLine($"Имя: {loadedCharacter.Name}");
Console.WriteLine($"Уровень: {loadedCharacter.Level}");
Console.WriteLine($"Здоровье: {loadedCharacter.Health}");
Console.WriteLine($"Инвентарь: {string.Join(", ", loadedCharacter.Inventory)}");

public class GameCharacter
{
    public string Name { get; set; } = "";
    public int Level { get; set; }
    public double Health { get; set; }
    public string[] Inventory { get; set; } = Array.Empty<string>();
}
