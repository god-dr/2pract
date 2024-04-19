namespace GarageConsoleApp;

/// <summary>
/// Класс Program
/// здесь описываем логику приложения
/// вызываем нужные методы пишем обработчики и тд
/// </summary>
public class Program 
{
    public static void Main(string[] args)
    {
        // Вызовем метод для получения данных о водителях
        DatabaseRequests.GetDriverQuery();
        Console.WriteLine();
        // Добавим нового водителя в БД
        DatabaseRequests.AddDriverQuery("Денис", "Иванов", DateTime.Parse("1997.01.12"));
        // Вызовем метод для получения данных о водителях
        DatabaseRequests.GetDriverQuery();
        
        // Вызовем метод для получения данных о типах автомобилей
        DatabaseRequests.GetTypeCarQuery();
        Console.WriteLine();
        // Добавим новый тип автомобиля в БД
        DatabaseRequests.AddTypeCarQuery("Воздушный");
        // Вызовем метод для получения данных о типах автомобилей
        DatabaseRequests.GetTypeCarQuery();

        DatabaseRequests.AddCarQuery(1,"mersedes","B888BB70",25);
        DatabaseRequests.GetCarQuery();
        
        DatabaseRequests.AddRouteQuery(1,1,1, 20);
        DatabaseRequests.GetRouteQuery();
        
        DatabaseRequests.AddItineraryQuery("Томск-Тайга");
        DatabaseRequests.GetItineraryQuery();
    }
}