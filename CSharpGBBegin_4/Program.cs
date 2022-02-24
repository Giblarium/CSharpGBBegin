// See https://aka.ms/new-console-template for more information


//Quest1(); //Объединение строк
//Quest2(); //на входе строка, вывести сумму
//Quest3(); //время года
//Quest4(); //число фибоначи

#region Quest1
void Quest1()
{
    string[,] name = new string[4, 3]
        {
            {"Ильчук", "Дмитрий", "Сергеевич"},
            {"Смирнов", "Максим", "Львович"},
            {"Макаров", "Денис", "Иванович"},
            {"Петров", "Александр", "Тимофеевич"}
        };


    for (int i = 0; i <= name.GetUpperBound(0); i++)
    {
        string firstName = name[i, 0];
        string lastName = name[i, 1];
        string patronymic = name[i, 2];

        string fullName = GetFullName(firstName, lastName, patronymic);

        Console.WriteLine(fullName);
    }

    EndQuest();


    string GetFullName(string firstName, string lastName, string patronymic)
    {
        return firstName + " " + lastName + " " + patronymic;
    }
}



#endregion

#region Quest2


void Quest2()
{
    string str = "";

    //заполнение строки случайными числами
    Random random = new();
    int countNumbers = random.Next(5, 30);
    for (int i = 0; i < countNumbers; i++)
    {
        str += random.Next(-1000, 1000).ToString() + " ";
    }

    ////ввод строки с клавиатуры
    //Console.Write("Введите строку для суммирования: ");
    //str = Console.ReadLine();

    str = str.Trim();
    Console.WriteLine("Строка для суммирования: " + str);

    
    //разбивка строки на подстроки и если подстрока число, то заполняется list
    int startIndex = 0;
    int number;
    List<int> numbers = new List<int>();

    while (true)
    {
        int subStrLenght = str.IndexOf(' ', startIndex) - startIndex;
        if (Int32.TryParse(str.Substring(startIndex, subStrLenght), out number))
        {
            numbers.Add(number);
        }
        else
        {
            Console.WriteLine("Не число " + str.Substring(startIndex, subStrLenght));
        }

        startIndex += subStrLenght + 1;

        if (str.IndexOf(' ', startIndex) == -1) //если индекс не найден, то запись в list последнего числа и выход из цикла
        {
            if (Int32.TryParse(str.Substring(startIndex, str.Length - startIndex), out number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Не число " + str.Substring(startIndex, subStrLenght - 1));
            }
            break;
        }
    }
    


    //суммирование элементов в list
    int sum = 0;
    foreach (var num in numbers)
    {
        sum += num;
    }
    Console.WriteLine("\nСумма чисел равна: {0}", sum);


    EndQuest();
}

#endregion

#region Quest3
void Quest3()
{
    Console.Write("Введите номер месяца: ");

    Seasons season = GetSeason(Console.ReadLine(), out int numberMonth);

    string nameSeason = GetNameSeason(season);

    if (season == Seasons.Error) // если введен не номер месяца, выводится сообщение об ошибке
    {
        Console.WriteLine(nameSeason);
    }
    else //иначе, выводится ответ на задачу
    {
        Console.WriteLine("Месяц {0} относится к сезону {1}", numberMonth, nameSeason);
    }



    EndQuest();
}

string GetNameSeason(Seasons season)
{
    switch (season)
    {
        case Seasons.Winter:
            return "Зима";
        case Seasons.Spring:
            return "Весна";
        case Seasons.Summer:
            return "Лето";
        case Seasons.Autumn:
            return "Осень";
        default:
            return "Введен не номер месяца!";
    }
}

Seasons GetSeason(string strNumberMonth, out int numberMonth)
{
    Int32.TryParse(strNumberMonth, out numberMonth);

    switch (numberMonth)
    {
        case 12:
        case 1:
        case 2:
            return Seasons.Winter;
        case 3:
        case 4:
        case 5:
            return Seasons.Spring;
        case 6:
        case 7:
        case 8:
            return Seasons.Summer;
        case 9:
        case 10:
        case 11:
            return Seasons.Autumn;
        default: //если введен не номер месяца, дальнейший код выдаст сообщение об ошибке в консоль
            return Seasons.Error;
    }
}
#endregion

#region Quest4
void Quest4()
{
    Console.Write("Введите порядковый номер: ");
    if (!Int32.TryParse(Console.ReadLine(), out int count)) // запрос у номера числа в последовательности и проверка строки на содержание числа
    {
        Console.WriteLine("Не число");
        return;
    }
    decimal fibonachchi = GetFibonachchi(count); // первоначальный вызов функции. Передается необходимый номер числа в последовательности 

    Console.WriteLine("Число №{0} в последовательности Фибоначчи: {1}", count, fibonachchi);

    EndQuest();
}


static decimal GetFibonachchi(decimal count, decimal first = 1m, decimal two = 1m, int current = 3) //необязательный параметр current отображает текущий шаг и позволяет выйти из рекурсии. first и two при первоначальном вызове функции 
{
    if (count == 1 || count == 2) //если нужно вывести первое или второе число из последовательности
    {
        return 1;
    }

    decimal sum = first + two; //суммирование элементов
    first = two; // второй элемент становится первым
    two = sum; // сумма становится вторым элементом
    

    if (current == count) //если текущий шаг равен нужному номеру последовательности, возврат суммы
    {
        return sum;
    }
    current++;//увеличение шага для суммирования

    return GetFibonachchi(count, first, two, current); //повторный вызов функции



}
#endregion

void EndQuest() //ожидание ввода и очистка консоли
{
    Console.ReadLine();
    Console.Clear();
}


internal enum Seasons
{
    Winter,
    Spring,
    Summer,
    Autumn,
    Error //Seasons GetSeason(string strNumberMonth, out int numberMonth) ругалась на то, что в switch не все пути кода возвращают значение. Пришлось добавить в перечисление новый "сезон" - ошибку.
}

