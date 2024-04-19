/*using System;
1 задание
class Student
{
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string GroupNumber { get; set; }
    public int[] Grades { get; set; }

    public Student(string lastName, DateTime dateOfBirth, string groupNumber, int[] grades)
    {
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        GroupNumber = groupNumber;
        Grades = grades;
    }

    public void ChangeLastName(string newLastName)
    {
        LastName = newLastName;
    }

    public void ChangeDateOfBirth(DateTime newDateOfBirth)
    {
        DateOfBirth = newDateOfBirth;
    }

    public void ChangeGroupNumber(string newGroupNumber)
    {
        GroupNumber = newGroupNumber;
    }

    public static void findInfo(string name, DateTime dateOfBirth, Student[] students)
    {
        Student student = Array.Find(students, s => s.LastName == name && s.DateOfBirth == dateOfBirth);

        if (student != null)
        {
            Console.WriteLine("\nинформация о студенте:");
            student.printInfo();
        }
        else
        {
            Console.WriteLine("\nСтудент с указанными данными не найден.");
        }
    }

    public void printInfo()
    {
        Console.WriteLine($"Фамилия: {LastName}");
        Console.WriteLine($"Дата рождения: {DateOfBirth.ToShortDateString()}");
        Console.WriteLine($"Hомер группы: {GroupNumber}");
        Console.WriteLine("Успеваемость:");

        for (int i = 0; i < Grades.Length; i++)
        {
            Console.WriteLine($"Предмет {i + 1}: {Grades[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[]
        {
            new Student("Иванов", new DateTime(2005, 10, 17), "Группа 622", new int[] { 4, 5, 3, 4, 5 }),
            new Student("Петров", new DateTime(2006, 2, 23), "Группа 622", new int[] { 5, 4, 4, 3, 5 }),
            new Student("Сидоров", new DateTime(2005, 7, 10), "Группа 722", new int[] { 3, 4, 5, 5, 4 })
        };

        Student.findInfo("Петров", new DateTime(2006, 2, 23), students);
        Student.findInfo("Иванов", new DateTime(2006, 1, 1), students);

        students[0].ChangeLastName("Иванов");
        students[0].ChangeDateOfBirth(new DateTime(2006, 1, 10));
        students[0].ChangeGroupNumber("Группа 722");

        Student.findInfo("Иванов", new DateTime(2006, 1, 10), students);

        Console.WriteLine("Введите имя студента: ");
        string studentName = Console.ReadLine();

        Console.WriteLine("Введите дату рождения студента (в формате dd.MM.уууу):");
        DateTime studentDateOfBirth;
        while (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.уyyу", null, System.Globalization.DateTimeStyles.None, out studentDateOfBirth))
        {
            Console.WriteLine("Неверный формат даты. Пожалуйста, введите дату в формате dd.MM.уууу:");
        }
        Student.findInfo(studentName, studentDateOfBirth, students);
    }
}
*/
/*using System;
2 заднание
class Train
{
    public string Destination { get; set; }
    public int TrainNumber { get; set; }
    public DateTime DepartureTime { get; set; }

    public Train(string destination, int trainNumber, DateTime departureTime)
    {
        Destination = destination;
        TrainNumber = trainNumber;
        DepartureTime = departureTime;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Номер поезда: {TrainNumber}");
        Console.WriteLine($"Пункт назначения: {Destination}");
        Console.WriteLine($"Время отправления: {DepartureTime.ToString("dd.MM.yyyy HH:mm")}");
    }
}

class Program
{
    static void Main()
    {
        Train[] trains = {
            new Train("Москва", 107, new DateTime(2024, 2, 15, 9, 0, 0)),
            new Train("Санкт-Петербург", 111, new DateTime(2024, 2, 15, 11, 30, 0)),
            new Train("Новосибирск", 169, new DateTime(2024, 2, 15, 14, 52,0))
        };

        Console.WriteLine("Введите номер поезда:");
        int trainNumber;
        while (!int.TryParse(Console.ReadLine(), out trainNumber))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число:");
        }

        Train foundTrain = null;
        foreach (var train in trains)
        {
            if (train.TrainNumber == trainNumber)
            {
                foundTrain = train;
                break;
            }
        }

        if (foundTrain != null)
        {
            foundTrain.PrintInfo();
        }
        else
        {
            Console.WriteLine("Поезд с указанным номером не найден.");
        }
    }
}
*/
/*using System;
3 задание
class NumberPair
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }

    public NumberPair(int firstNumber, int secondNumber)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
    }

    public void ChangeNumbers(int firstNumber, int secondNumber)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
    }

    public void PrintNumbers()
    {
        Console.WriteLine($"\nПервое число: {FirstNumber}");
        Console.WriteLine($"Второе число: {SecondNumber}");
    }

    public int GetSum()
    {
        return FirstNumber + SecondNumber;
    }

    public int GetMax()
    {
        return Math.Max(FirstNumber, SecondNumber);
    }
}

class Program
{
    static void Main()
    {
        NumberPair numbers = new NumberPair(10, 20);
        numbers.PrintNumbers();
        numbers.ChangeNumbers(30, 40);
        numbers.PrintNumbers();
        Console.WriteLine($"\nСумма значений чисел: {numbers.GetSum()}");
        Console.WriteLine($"\nНаибольшее значение: {numbers.GetMax()}");
    }
}
*/
/*using System;
4 задание
class Counter
{
    private int _value;

    public int Value
    {
        get { return _value; }
    }

    public Counter()
    {
        _value = 0;
    }

    public Counter(int startValue)
    {
        _value = startValue;
    }

    public void Increment()
    {
        _value++;
    }

    public void Decrement()
    {
        _value--;
    }
}

class Program
{
    static void Main()
    {
        Counter counter1 = new Counter();
        
        counter1.Increment();
        counter1.Increment();
        counter1.Increment();
        
        Console.WriteLine("Текущее значение счетчика 1: " + counter1.Value);

        Counter counter2 = new Counter(10);
        
        counter2.Decrement();
        counter2.Decrement();
        counter2.Decrement();
        counter2.Decrement();
        
        Console.WriteLine("Текущее значение счетчика 2: " + counter2.Value);
    }
}
*/
/*using System;
5 задание
class NewClass
{
    public string Property1 { get; set; }
    public int Property2 { get; set; }

    public NewClass(string property1, int property2)
    {
        Property1 = property1;
        Property2 = property2;
    }

    public NewClass()
    {
        Property1 = "Default";
        Property2 = 0;
    }

    ~NewClass()
    {
        Console.WriteLine("Объект NewClass удален.");
    }
}

class Program
{
    static void Main()
    {
        NewClass obj1 = new NewClass("asdasd", 123);
        Console.WriteLine("Свойство1: " + obj1.Property1);
        Console.WriteLine("Свойство2: " + obj1.Property2);
        
        NewClass obj2 = new NewClass();
        Console.WriteLine("Свойство1: " + obj2.Property1);
        Console.WriteLine("Свойство2: " + obj2.Property2);

        obj1 = null;
        obj2 = null;
        GC.Collect();
    }
}
*/