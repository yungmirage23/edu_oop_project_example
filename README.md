## Основний стек знань для якісного виконання роботи

|Етап|Дії|Ресурси|
|---|---|---|
|**База (C# / ООП / LINQ)**|Пройти стартовий курс, практикуватися на задачках|CodeUA, ItProger, ITVDN|
|**SQL та БД**|Повторити SELECT, JOIN, INSERT, UPDATE, DELETE|Metanit (SQL + EF Core)|
|**EF Core**|Вивчити міграції, Fluent API, CRUD-операції|Microsoft Docs, Metanit, відео EF Core|
|**.NET Host, DI, Logging**|Ознайомитися з HostBuilder, IServiceCollection|Microsoft Learn, блоги ASP.NET|
|**UI (WinForms/WPF/Blazor)**|Подивитися уроки UI, приклади на GitHub|C# Українською, офіційні гіди|
|**Алгоритми**|Вчити базові структури даних і складність алгоритмів|ITVDN “Алгоритми та структури даних”|

---
###  Додаткові рекомендації для ефективного навчання та роботи над курсовою

1. **Не ігноруй незрозумілі терміни чи файли**
    
    - Якщо ти бачиш у коді або документації щось незрозуміле (клас, метод, атрибут, структура), **не залишай це без уваги**.
        
    - Шукайте інформацію в інтернеті: офіційні сайти, Stack Overflow, блоги, документація.
        
    - Можна також звертатися до ШІ, наприклад ChatGPT, щоб швидко отримати пояснення та приклади.
        
2. **Документуй свої відповіді та відкриття**
    
    - Всі пояснення, приклади, важливі принципи **записуй у власну базу знань**.
        
    - Це допомагає:
        
        - швидко згадати інформацію при написанні курсової;
            
        - уникнути повторного пошуку;
            
        - систематизувати знання для майбутніх проєктів.
            
3. **Обирай корисний інструмент для структурування знань**
    
    - **Obsidian** — дуже зручний для цього інструмент.
        
    - Переваги Obsidian:
        
        - Працює з Markdown-файлами, легко писати текст, код, вставляти посилання.
            
        - Можна створювати **взаємопов’язані нотатки**, як у вікі.
            
        - Підтримує теги, графи зв’язків між поняттями, що допомагає бачити загальну картину.
            
        - Можна вести окремі бази знань для C#, .NET, EF Core, UI, алгоритмів тощо.
            
    - Таким чином, коли ти зустрінеш новий клас або метод, ти можеш створити для нього окрему нотатку з поясненням і прикладом.
        
4. **Регулярно оновлюй базу знань**
    
    - Кожен новий приклад коду, конфігурація, порада або хитрість – додавай у свою базу.
        
    - Через час у тебе буде **структурована документація**, яка спрощує виконання курсової, підготовку до захисту та майбутню роботу над проєктами.
        

---

# Покроковий план для курсової

1. Вибрати предметну область (бібліотека, магазин, система обліку).
    
2. Намалювати UML-діаграми (класи, зв’язки) та ERD (таблиці).
    
3. Створити проєкт (.NET Console / WPF / Blazor), налаштувати DI, конфігурацію, логування.
    
4. Підключити EF Core, створити моделі й DbContext, налаштувати зв’язки.
    
5. Зробити CRUD-операції, написати бізнес-логіку.
    
6. Зробити UI для взаємодії користувача.
    
7. Додати додаткову логіку (звітність, пошук, статистику).
    
8. Протестувати, написати звіт з UML, кодом, скріншотами.
    
9. Підготувати презентацію та демонстрацію.

# Гайд по запуску цього демонстраційного проєкту

## 1️⃣ Клонування репозиторію

Виконай у терміналі:

`git clone https://github.com/yungmirage23/edu_oop_project_example.git cd edu_oop_project_example`

Тепер у тебе локальна копія з усіма файлами (`Kursova_Bank.sln`, `src/BankStaffApp`, `docker-compose.yml` тощо) ( в папці з якої виконувалась команда `git clone`.

---

## 2️⃣ Перевірка .NET SDK

Переконайся, що встановлено **.NET 8/9, відповідно до проєкту:

`dotnet --version`

- Якщо версія не підходить — встанови актуальну з офіційного сайту .NET.
    

---

## 3️⃣ Підняття MySQL через Docker (якщо потрібно)

В репозиторії є `docker-compose.yml`, значить база даних налаштована для запуску через Docker:

`docker-compose up -d`

- Перевір, що Docker запущений на твоєму ПК.
    
- Після цього в тебе буде MySQL база, яку проєкт підключає через connection string.
    

> Переконайся, що `appsettings.json` або `DbContext` правильно вказує на хост Docker (`localhost`, порт, юзер/пароль).

---

## 4️⃣ Відкриття проєкту у Visual Studio

1. Відкрий **Visual Studio 2022** або новішу.
    
2. Файл → Відкрити → Рішення → обери `Kursova_Bank.sln`.
    
3. Дочекайся, поки Visual Studio відновить NuGet пакети (`nuget.config` є в репо).
    

---

## 5️⃣ Налаштування і перевірка бази

1. Якщо використовується **EF Core**, можливо треба застосувати міграції:
    

`dotnet ef database update --project ./src/BankStaffApp/BankStaffApp.csproj`

- Це створить таблиці в MySQL, якщо їх ще немає.
    

---

## 6️⃣ Перший запуск аплікації

### a) Через Visual Studio

- Вибери проєкт **BankStaffApp** як StartUp Project.
    
- Натисни **F5** → аплікація запуститься в режимі дебагу.
    

### b) Через CLI (.NET CLI)

`dotnet run --project ./src/BankStaffApp/BankStaffApp.csproj`

- Відкриється WPF-аплікація.
    

---

## 7️⃣ Можливі проблеми та поради

|Проблема|Рішення|
|---|---|
|NuGet пакети не відновились|`dotnet restore` або через Visual Studio “Restore NuGet Packages”|
|MySQL не запускається|Переконайся, що Docker працює; перевір порти та credentials|
|EF Core не знаходить БД|Перевір connection string у `appsettings.json`|
|WPF не компілюється|Переконайся, що встановлено workload **Desktop development with C#** у Visual Studio|

---

✅ Після цього аплікація повинна працювати на твоєму комп’ютері, підключатися до локальної MySQL і бути готовою до тестування CRUD та UI.

# Рекомендації з покращення демонстраційного прикладу

## 1️⃣ Винесення підключення БД у конфіг

Зараз у `AppDbContext` підключення до MySQL хардкодиться:
```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseMySql("server=localhost;database=BankDb;user=root;password=root",new MySqlServerVersion(new Version(8, 0, 36)));
}
```
### Чому варто винести в конфіг:

1. Не потрібно перекомпілювати код, якщо змінюється сервер, пароль або база.
    
2. Безпечніше – не зберігаєш пароль у коді.
    
3. Легко використовувати різні середовища (dev, prod, тест).
    

### Як винести:

1. Додати файл `appsettings.json` у корінь проекту:
    
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=BankDb;user=root;password=root"
  }
}
```
2. Змінити `AppDbContext`:
    
```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Position> Positions { get; set; }

    private readonly string _connectionString;

    public AppDbContext()
    {
        // Читаємо конфіг з appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_connectionString, new MySqlServerVersion(new Version(8, 0, 36)));
    }
}

```




✅ Тепер усі налаштування БД винесені в конфіг і змінюються без перекомпіляції.

---

## 2️⃣ MainViewModel – що тут відбувається

`MainViewModel` відповідає за **дані, логіку CRUD і зв’язок з UI** (MVVM-патерн):

- Колекції `Employees`, `Branches`, `Positions` – **ObservableCollection**, щоб UI автоматично оновлювався при зміні даних.
    
- Властивості `SelectedEmployee`, `NewEmployee` та ін. – **зв’язування з формами** для редагування та додавання.
    
- Методи:
    
    - `LoadData()` – завантажує дані з БД і оновлює колекції для UI.
        
    - `AddEmployee()`, `UpdateEmployee()`, `DeleteEmployee()` – CRUD-операції через EF Core.
        
    - `AddBranch()`, `AddPosition()` – додавання нових відділень і посад.
        

> Кожен раз створюється новий `AppDbContext()` у using, щоб правильно закривати підключення.

---

## 3️⃣ XAML – UI

### Структура `MainWindow.xaml`:

1. **Grid** з 3 рядками:
    
    - Row 0 – **DataGrid** для списку працівників.
        
    - Row 1 – **форма додавання/редагування працівника**.
        
    - Row 2 – **форма додавання відділення і посади**.
        
2. **DataGrid**:
    
    - `ItemsSource="{Binding Employees}"` – зв’язує дані з колекцією працівників.
        
    - `SelectedItem="{Binding SelectedEmployee}"` – обрана людина відображається у формі.
        
3. **Форма додавання працівника**:
    
    - `TextBox`, `DatePicker`, `ComboBox` – зв’язуються з `NewEmployee`.
        
    - Кнопки: “Додати”, “Оновити”, “Видалити” викликають методи у код-біхайнд (`Add_Click`, `Update_Click`, `Delete_Click`), які, у свою чергу, викликають методи `MainViewModel`.
        
4. **Додавання відділення та посади**:
    
    - `TextBox` для імені, міста, зарплати.
        
    - Кнопки викликають методи `AddBranch_Click`, `AddPosition_Click`, які додають нові сутності у базу через `MainViewModel`.
        

> Весь UI повністю **зв’язаний з ViewModel через Data Binding**, тому при зміні даних в `ObservableCollection` DataGrid оновлюється автоматично.

---

## 4️⃣ Рекомендації по покращенню

1. **Винести підключення до БД в `appsettings.json`** (як показано вище).
    
2. **Використовувати Dependency Injection** для `DbContext`:
    
    - Замість створення нового `AppDbContext()` у кожному методі, реєструвати його через DI.
        
    - Це дозволяє легше тестувати код та підключати сервіси.
        
3. **Async/await**:
    
    - CRUD-операції через `await db.SaveChangesAsync()` та `ToListAsync()` для не блокуючого UI.


# Корисні ресурси для курсової з C# / .NET / EF Core / ООП / UI

### 📖 Офіційна документація та довідники

1. **Microsoft Learn / .NET / EF Core**  
    Офіційна документація по EF Core: робота з моделями, міграціями, провайдерами, API.  
    [Microsoft Learn (англ.)](https://learn.microsoft.com/en-us/ef/core/)  
    [Microsoft Learn (укр/рос.)](https://learn.microsoft.com/ru-ru/ef/)
    
2. **Metanit (рос.)**  
    Дуже докладний посібник з EF Core: моделі, Fluent API, міграції, CRUD-приклади.  
    [Metanit EF Core](https://metanit.com/sharp/efcore/)
    
3. **DotNetTutorials (англ.)**  
    Серія статей з EF Core, від бази до продвинутих тем.  
    [DotNetTutorials EF Core](https://dotnettutorials.net/lesson/entity-framework-core/)
    
4. **ItProger (укр.)**  
    Курс “Уроки C# для чайників” українською: змінні, типи, класи, методи.  
    [ItProger C#](https://itproger.com/ua/course/csharp)
    
5. **ITVDN (укр.)**
    
    - [C# Стартовий](https://itvdn.com/ua/video/csharp-starter-ua)
        
    - [Алгоритми та структури даних на C#](https://itvdn.com/ua/video/algorithms-and-data-structures-in-c-sharp)
        

---

### 🎥 Відео-курси та YouTube-канали

- [C# Стартовий (CodeUA)](https://www.youtube.com/watch?v=-GAN4uNimZo)
    
- [Уроки C# для початківців (Школа програмування)](https://www.youtube.com/watch?pp=0gcJCfwAo7VqN5tD&v=KBHwRw6S448)
    
- [C# Українською (канал)](https://www.youtube.com/channel/UCuwjoDSXsac04UvC5j_TrFw)
    
- [Теорія. Урок 1 — Вступ](https://www.youtube.com/watch?v=JhuA4w-5BvY)
    
- [Курс C# Стартовий. Урок 3. Змінні та типи](https://www.youtube.com/watch?v=SaFYwee3uss)
    
- [Getting Started with EF Core (англ.)](https://www.youtube.com/watch?v=SryQxUeChMc)
    

---

### 💬 Спільноти / форуми / блоги

- **Stack Overflow (укр/рос/англ)** — питання по C# / EF Core.
    
- **GitHub** — готові приклади проєктів і архітектурні рішення.
    
- **Telegram / Discord / Slack спільноти українських .NET-розробників** — можна отримати швидкий фідбек.
    
- **IT-блоги (dou.ua, habr.com)** — статті з практики, гайди та кейси.
    

---