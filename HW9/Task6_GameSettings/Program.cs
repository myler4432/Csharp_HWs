using System.Text.Json;

var options = new JsonSerializerOptions
{
    WriteIndented = true
};

string filePath = Path.Combine(AppContext.BaseDirectory, "settings.json");

if (File.Exists(filePath))
{
    string json = File.ReadAllText(filePath);
    GameSettings? settings = JsonSerializer.Deserialize<GameSettings>(json);

    if (settings is null)
    {
        Console.WriteLine("Не удалось загрузить настройки.");
        return;
    }

    PrintSettings(settings);
}
else
{
    Console.WriteLine("Файл настроек не найден. Создаём новые настройки.");

    Console.Write("Введите имя игрока: ");
    string playerName = Console.ReadLine() ?? "";

    int difficulty = ReadInt("Введите сложность (1 — легко, 2 — нормально, 3 — сложно): ", 1, 3);
    int musicVolume = ReadInt("Введите громкость музыки (0–100): ", 0, 100);

    var settings = new GameSettings
    {
        PlayerName = playerName,
        Difficulty = difficulty,
        MusicVolume = musicVolume
    };

    string json = JsonSerializer.Serialize(settings, options);
    File.WriteAllText(filePath, json);

    Console.WriteLine();
    Console.WriteLine("Настройки сохранены.");
    PrintSettings(settings);
}

static int ReadInt(string prompt, int min, int max)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int value) && value >= min && value <= max)
        {
            return value;
        }

        Console.WriteLine($"Введите целое число от {min} до {max}.");
    }
}

static void PrintSettings(GameSettings settings)
{
    string difficulty = settings.Difficulty switch
    {
        1 => "Легко",
        2 => "Нормально",
        3 => "Сложно",
        _ => "Неизвестно"
    };

    Console.WriteLine("=== Настройки игры ===");
    Console.WriteLine($"Имя игрока: {settings.PlayerName}");
    Console.WriteLine($"Сложность: {difficulty} ({settings.Difficulty})");
    Console.WriteLine($"Громкость музыки: {settings.MusicVolume}");
}

public class GameSettings
{
    public string PlayerName { get; set; } = "";
    public int Difficulty { get; set; }
    public int MusicVolume { get; set; }
}
