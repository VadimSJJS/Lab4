using Lab4.Data;
using Lab4.Models;
using System.Data.SqlTypes;

namespace Lab4.Data
{
    public class DbInitializer
    {
        private static Random random = new Random();
        private static List<string> Names = new()
        {
            "Аспирин", 
            "Парацетамол", 
            "Ибупрофен",
            "Амоксициллин", 
            "Валериана", 
            "Цетиризин",
            "Лоратадин", 
            "Дексаметазон", 
            "Ранитидин",
            "Метформин", 
            "Ацетилцистеин", 
            "Фенилэфрин",
            "Анальгин", 
            "Диазепам", 
            "Левофлоксацин",
            "Кларитромицин", 
            "Атенолол", 
            "Мидазолам",
            "Рамиприл", 
            "Сертралин"
        };
        private static List<string> ShortDecsriptions = new()
        {
            "Аспирин",
            "Парацетамол",
            "Ибупрофен",
            "Амоксициллин",
            "Валериана",
            "Цетиризин",
            "Лоратадин",
            "Дексаметазон",
            "Ранитидин",
            "Метформин",
            "Ацетилцистеин",
            "Фенилэфрин",
            "Анальгин",
            "Диазепам",
            "Левофлоксацин",
            "Кларитромицин",
            "Атенолол",
            "Мидазолам",
            "Рамиприл",
            "Сертралин",
        };
        private static List<string> ActiveSubstance = new()
        {
            "Аспирин",
            "Парацетамол",
            "Ибупрофен",
            "Амоксициллин",
            "Валериана",
            "Цетиризин",
            "Лоратадин",
            "Дексаметазон",
            "Ранитидин",
            "Метформин",
            "Ацетилцистеин",
            "Фенилэфрин",
            "Анальгин",
            "Диазепам",
            "Левофлоксацин",
            "Кларитромицин",
            "Атенолол",
            "Мидазолам",
            "Рамиприл",
            "Сертралин"
        };
        private static List<string> StorageLocations = new()
        {
            "Аспирин",
            "Парацетамол",
            "ИбупрофенC.",
            "АмоксициллинC.",
            "Валериана.",
            "Цетиризинот",
            "ЛоратадинC.",
            "Дексамет.",
            "РанитидинC.",
            "Метформин.",
            "Ацетилцистеин",
            "Фенилэфрин",
            "Анальгин",
            "Диазепам",
            "Левофлоксацин",
            "Кларитромицин",
            "Атенолол",
            "Мидазолам",
            "Рамиприл",
            "Сертралин"
        };
        private static List<string> NameProducers = new()
        {
            "«Bayer»",
            "Фармстандарт",
            "Хемофарм",
            "Производитель 4",
            "Производитель 5",
            "Производитель 6",
            "Производитель 7",
            "Производитель 8",
            "Производитель 9",
            "Производитель 10",
            "Производитель 11",
            "Производитель 12",
            "Производитель 13",
            "Производитель 14",
            "Производитель 15",
            "Производитель 16",
            "Производитель 17",
            "Производитель 18",
            "Производитель 19",
            "Производитель 20",
        };
        private static List<string> Countries = new()
        {
            "США",
            "Германия",
            "Россия",
            "Великобритания",
            "Исландия",
            "Россия",
            "Германия",
            "США",
            "Беларусь",
            "Германия",
            "США",
            "Исландия",
            "Великобритания",
            "Беларусь",
            "Германия",
            "Исландия",
            "Беларусь",
            "Исландия",
            "США",
            "Германия",
        };

        public static void Initialize(PharmacyContext db)
        {
            db.Database.EnsureCreated();
                    
            if (!db.Producers.Any())
            {
                for (int i = 0; i < 20; i++)
                {
                    string NameProducer = NameProducers[random.Next(0, NameProducers.Count)];
                    string Country = Countries[random.Next(0, Countries.Count)];
                    db.Add(new Producer() { Name = NameProducer, Country = Country });
                }
                db.SaveChanges();
            }

            if (!db.Medicines.Any())
            {
                for (int i = 0; i < 20; i++)
                {
                    string Name = Names[random.Next(0, Names.Count)];
                    string ShortDecsription = ShortDecsriptions[random.Next(0, ShortDecsriptions.Count)];
                    string ActiveSubstances = ActiveSubstance[random.Next(0, ActiveSubstance.Count)];
                    int ProducerId = random.Next(1, 21);
                    string UnitOfMeasurement = "Количество вещества " + random.Next(1, 21);
                    int Count = Math.Abs(random.Next()) % 20;
                    string StorageLocation = StorageLocations[random.Next(0, StorageLocations.Count)];
                    db.Add(new Medicine() { Name = Name, ShortDescription = ShortDecsription, ActiveSubstance = ActiveSubstances, ProducerId = ProducerId, UnitOfMeasurement = UnitOfMeasurement, Count = Count, StorageLocation = StorageLocation });
                }
                db.SaveChanges();
            }

            if (!db.Outgoings.Any())
            {
                for (int i = 0; i < 20; i++)
                {
                    int MedicineId = random.Next(1, 21);
                    DateTime ImplemetionDate = DateTime.Now.AddYears(-random.Next(0, 100));
                    int Count = Math.Abs(random.Next()) % 20;
                    decimal SellingPrice = (decimal)random.NextDouble() * 10000;
                    db.Add(new Outgoing() { MedicineId = MedicineId, ImplementationDate = ImplemetionDate, Count = Count, SellingPrice = SellingPrice });
                }
                db.SaveChanges();
            }
        }
    }
}
