//Quest1(); //ввод с клавиатуры и сохранение в текстовый файл
//Quest2(); //дописывание времени запуска в файл
//Quest3(); //запись в бинарный файл
Quest4(); //Древо каталогов
Quest5(); //список задач

#region Quest1
void Quest1()
{
    Console.Write("Введите текст: ");
    string typing = Console.ReadLine();

    File.WriteAllText("quest1.txt", typing);

    Console.Write("Данные записаны!");

    EndQuest();
}
#endregion

#region Quest2
void Quest2()
{
    DateTime dateTime = DateTime.Now;

    File.AppendAllText("startup.txt", dateTime.ToString());

    Console.WriteLine("Время запуска программы {0} записано в файл.", dateTime.ToString());


    EndQuest();
}
#endregion

#region Quest3


void Quest3()
{
    List<byte> list = new List<byte>();
    byte num = 0;
    do
    {
        list.Add(num);
        Console.Write("Введите байт для записи, другой текст для выхода: ");
    } while (Byte.TryParse(Console.ReadLine(), out num));

    list.Remove(0);

    byte[] bytes = list.ToArray();

    File.WriteAllBytes("bytes.bin", bytes);

    Console.Write("Данные записаны!");


    EndQuest();
}
#endregion

#region Quest4
void Quest4()
{
    List<string> list = new List<string> { };
    string currentDirectory = Environment.CurrentDirectory;

    string str = "";

    for (int i = 0; i < currentDirectory.Length; i++)
    {
        if (currentDirectory[i] == '\\')
        {
            list.Add(str);
            str = "";
        }
        else
        {
            str += currentDirectory[i];
        }
    }

    foreach (var item in list)
    {
        IEnumerable<string> directoryList = Directory.EnumerateDirectories(item + "\\");
    }



    EndQuest();
}
#endregion

#region Quest5
void Quest5()
{


    EndQuest();
}
#endregion

void EndQuest()
{
    Console.ReadLine();
    Console.Clear();
}