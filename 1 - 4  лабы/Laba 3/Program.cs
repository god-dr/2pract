/*public class Worker
 1 задание
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public double Rate { get; set; }
    public int Days { get; set; }

    public Worker(string name, string surname, double rate, int days)
    {
        Name = name;
        Surname = surname;
        Rate = rate;
        Days = days;
    }

    public double GetSalary()
    {
        return Rate * Days;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Worker worker = new Worker("Иван", "Иванов", 10.5, 20);
        Console.WriteLine($"Зарплата работника {worker.Name} {worker.Surname}: {worker.GetSalary()}");

        
       
    }
}

*/
/*using System;
2 задание
public class Worker
{
    private string name;
    private string surname;
    private double rate;
    private int days;

    public Worker(string name, string surname, double rate, int days)
    {
        this.name = name;
        this.surname = surname;
        this.rate = rate;
        this.days = days;
    }

    public string GetName()
    {
        return name;
    }

    public string GetSurname()
    {
        return surname;
    }

    public double GetRate()
    {
        return rate;
    }

    public int GetDays()
    {
        return days;
    }

    public double GetSalary()
    {
        return rate * days;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Worker worker = new Worker("Иван", "Иванов", 10.5, 20);
        Console.WriteLine($"Зарплата работника {worker.GetName()} {worker.GetSurname()}: {worker.GetSalary()}");

        // Пример использования геттеров
        // worker.SetRate(12.5);
        // worker.SetDays(25);
        // Console.WriteLine($"Новая зарплата работника {worker.GetName()} {worker.GetSurname()}: {worker.GetSalary()}");
    }
}
*/

/*using System;
3 задание
public class Calculation
{
    private string calculationLine;

    public void SetCalculationLine(string line)
    {
        calculationLine = line;
    }

    public void SetLastSymbolCalculationLine(char symbol)
    {
        calculationLine += symbol;
    }

    public string GetCalculationLine()
    {
        return calculationLine;
    }

    public char GetLastSymbol()
    {
        if (string.IsNullOrEmpty(calculationLine))
        {
            throw new InvalidOperationException("Calculation line is empty.");
        }
        return calculationLine[calculationLine.Length - 1];
    }

    public void DeleteLastSymbol()
    {
        if (!string.IsNullOrEmpty(calculationLine))
        {
            calculationLine = calculationLine.Remove(calculationLine.Length - 1);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculation calculation = new Calculation();
        calculation.SetCalculationLine("2 + 2");
        Console.WriteLine("Calculation line: " + calculation.GetCalculationLine());

        calculation.SetLastSymbolCalculationLine('=');
        Console.WriteLine("Calculation line after adding last symbol: " + calculation.GetCalculationLine());

        Console.WriteLine("Last symbol: " + calculation.GetLastSymbol());

        calculation.DeleteLastSymbol();
        Console.WriteLine("Calculation line after deleting last symbol: " + calculation.GetCalculationLine());
    }
}
*/