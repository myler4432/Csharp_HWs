# Часть 1. Задачи на понимание

## Задача 1. Анализ JSON-сериализации

**а)** В стандартном режиме `System.Text.Json` сериализуются публичные свойства:
- `Name` — попадёт в JSON, потому что это публичное свойство с публичными `get` и `set`.
- `Score` — попадёт по той же причине.
- `secretCode` — не попадёт, потому что это приватное поле.
- `IsAlive` — не попадёт, потому что по умолчанию поля не сериализуются, даже если они public.

Результат будет примерно таким:

```json
{
  "Name": "Alex",
  "Score": 100
}
```

**б)** Можно оставить поле приватным и добавить атрибут `[JsonInclude]`:

```csharp
using System.Text.Json.Serialization;

public class Player
{
    public string Name { get; set; }
    public int Score { get; set; }

    [JsonInclude]
    private int secretCode = 42;

    public bool IsAlive;
}
```

**в)** Поле `IsAlive` не сериализуется, потому что сериализация полей отключена по умолчанию. Два варианта:
1. Добавить к полю атрибут `[JsonInclude]`.
2. Включить сериализацию полей через настройки: `new JsonSerializerOptions { IncludeFields = true }`.

## Задача 2. Восстановление объекта из JSON

**а)** Подходящий класс:

```csharp
public class Game
{
    public string Title { get; set; }
    public int Year { get; set; }
    public double Rating { get; set; }
    public string[] Genres { get; set; }
    public bool IsMultiplayer { get; set; }
}
```

- `Title` — `string`, так как в JSON строка.
- `Year` — `int`, так как год задан целым числом.
- `Rating` — `double`, так как рейтинг дробный.
- `Genres` — `string[]`, так как это массив строк.
- `IsMultiplayer` — `bool`, так как значение логическое.

Десериализация:

```csharp
Game game = JsonSerializer.Deserialize<Game>(json);
```

**б)** По умолчанию имена свойств сопоставляются с учётом регистра. Поэтому ключ `title` не совпадает с `Title`. Можно включить нечувствительность к регистру:

```csharp
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

Game game = JsonSerializer.Deserialize<Game>(json, options);
```

**в)** Строка `[1, "hello", true, null]` является валидным JSON. Это массив из числа, строки, логического значения и null. Его можно десериализовать в `JsonElement`, либо в `object[]` с дополнительной обработкой элементов. Самый универсальный вариант без потери JSON-типов:

```csharp
JsonElement element = JsonSerializer.Deserialize<JsonElement>(
    "[1, \"hello\", true, null]"
);
```

## Задача 3. File vs FileStream

1. **File.** Небольшой файл можно целиком прочитать методом `File.ReadAllText`. Это проще и не требует самостоятельно управлять потоком.
2. **File.** Для обычного автосохранения небольшого набора данных удобно сериализовать состояние и записать его методом `File.WriteAllText`. Если запись должна идти частями или нужен особый контроль над буфером, тогда подойдёт `FileStream`.
3. **FileStream.** Для большого лог-файла поток позволяет дописывать данные в конец без чтения всего файла в память. Можно открыть его с режимом `FileMode.Append`.
4. **File.** Сначала удобно проверить наличие через `File.Exists`, затем прочитать всё содержимое через `File.ReadAllText`.
5. **FileStream.** Он позволяет перейти к нужной позиции через `Seek` и заменить конкретные байты, не загружая весь большой файл в память.
