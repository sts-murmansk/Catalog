namespace Api.Data.Seed;

public class InitialData
{
  public static IEnumerable<Book> Books => new List<Book>
    {
      new()
      {
        Id = new Guid("10000001-0000-0000-0000-000000000001"),
        Title = "Война и мир",
        Name = "Лев Толстой",
        Description = "Эпический роман-эпопея Льва Толстого, описывающий русское общество в эпоху войн против Наполеона в 1805—1820 годах.",
        ImageUrl = "http://storage.drive/books/voina-i-mir.png",
        Price = 1200.00M,
        Category = new List<string> { "Классическая литература", "Исторический роман" }
      },

      new()
      {
        Id = new Guid("10000001-0000-0000-0000-000000000002"),
        Title = "Мастер и Маргарита",
        Name = "Михаил Булгаков",
        Description = "Фантастический роман о визите дьявола в атеистическую Москву 1930-х годов, переплетающийся с историей Понтия Пилата.",
        ImageUrl = "http://storage.drive/books/master-i-margarita.png",
        Price = 950.00M,
        Category = new List<string> { "Фантастика", "Сатира" }
      },

      new()
      {
        Id = new Guid("10000001-0000-0000-0000-000000000003"),
        Title = "Преступление и наказание",
        Name = "Фёдор Достоевский",
        Description = "Психологический роман о моральных и психологических терзаниях студента Раскольникова после убийства старухи-процентщицы.",
        ImageUrl = "http://storage.drive/books/prestuplenie-i-nakazanie.png",
        Price = 850.00M,
        Category = new List<string> { "Классическая литература", "Психологический роман" }
      },

      new()
      {
        Id = new Guid("10000001-0000-0000-0000-000000000004"),
        Title = "Евгений Онегин",
        Name = "Александр Пушкин",
        Description = "Роман в стихах, повествующий о жизни молодого дворянина Евгения Онегина в Петербурге и российской провинции 1820-х годов.",
        ImageUrl = "http://storage.drive/books/evgenii-onegin.png",
        Price = 750.00M,
        Category = new List<string> { "Поэзия", "Классическая литература" }
      },

      new()
      {
        Id = new Guid("10000001-0000-0000-0000-000000000005"),
        Title = "Анна Каренина",
        Name = "Лев Толстой",
        Description = "Роман о трагической любви замужней дамы Анны Карениной и молодого офицера Вронского на фоне счастливой семейной жизни Константина Лёвина.",
        ImageUrl = "http://storage.drive/books/anna-karenina.png",
        Price = 1100.00M,
        Category = new List<string> { "Классическая литература", "Любовный роман" }
      },

      new()
      {
        Id = new Guid("10000001-0000-0000-0000-000000000006"),
        Title = "Идиот",
        Name = "Фёдор Достоевский",
        Description = "Роман о добром и чистом душой князе Мышкине, возвращающемся в Россию после лечения в швейцарской клинике.",
        ImageUrl = "http://storage.drive/books/idiot.png",
        Price = 900.00M,
        Category = new List<string> { "Классическая литература", "Философский роман" }
      },

      new()
      {
        Id = new Guid("10000001-0000-0000-0000-000000000007"),
        Title = "Тихий Дон",
        Name = "Михаил Шолохов",
        Description = "Эпический роман о судьбе донского казачества в годы Первой мировой и Гражданской войн.",
        ImageUrl = "http://storage.drive/books/tihii-don.png",
        Price = 1300.00M,
        Category = new List<string> { "Историческая проза", "Военная литература" }
      },

      new()
      {
        Id = new Guid("10000001-0000-0000-0000-000000000008"),
        Title = "Собачье сердце",
        Name = "Михаил Булгаков",
        Description = "Сатирическая повесть о собаке, превращённой в человека в результате медицинского эксперимента.",
        ImageUrl = "http://storage.drive/books/sobachie-serdce.png",
        Price = 700.00M,
        Category = new List<string> { "Сатира", "Фантастика" }
      },

      new()
      {
        Id = new Guid("10000001-0000-0000-0000-000000000009"),
        Title = "Отцы и дети",
        Name = "Иван Тургенев",
        Description = "Роман о борьбе поколений, сосредоточенный вокруг нигилиста Базарова и его взаимоотношений с аристократическим обществом.",
        ImageUrl = "http://storage.drive/books/otcy-i-deti.png",
        Price = 800.00M,
        Category = new List<string> { "Классическая литература", "Социальный роман" }
      },

      new()
      {
        Id = new Guid("10000001-0000-0000-0000-000000000010"),
        Title = "Мёртвые души",
        Name = "Николай Гоголь",
        Description = "Сатирический роман о похождениях Чичикова, скупающего \"мёртвые души\" – умерших крепостных, числящихся живыми.",
        ImageUrl = "http://storage.drive/books/mertvye-dushi.png",
        Price = 850.00M,
        Category = new List<string> { "Классическая литература", "Сатира" }
      }
    };

}
