using System.Text.Json;

GameCharacter character = new GameCharacter
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
Console.WriteLine("=== JSON персонажа ===");
Console.WriteLine(json);

GameCharacter? restoredCharacter = JsonSerializer.Deserialize<GameCharacter>(json);

if (restoredCharacter is null)
{
    Console.WriteLine("Не удалось восстановить персонажа.");
    return;
}

Console.WriteLine();
Console.WriteLine("=== Проверка десериализации ===");
Console.WriteLine($"Имя: {restoredCharacter.Name}");
Console.WriteLine($"Количество предметов: {restoredCharacter.Inventory.Length}");

public class GameCharacter
{
    public string Name { get; set; } = "";
    public int Level { get; set; }
    public double Health { get; set; }
    public string[] Inventory { get; set; } = Array.Empty<string>();
}
