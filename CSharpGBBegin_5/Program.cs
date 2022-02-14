using Newtonsoft.Json;

string toDoFile = "todo.json";


Quest1(); //ввод с клавиатуры и сохранение в текстовый файл
Quest2(); //дописывание времени запуска в файл
Quest3(); //запись в бинарный файл
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
    string directory = Environment.CurrentDirectory;

    string str = "";

    for (int i = 0; i < directory.Length; i++)
    {
        if (directory[i] == '\\')
        {
            list.Add(str);
            str = "";
        }
        else
        {
            str += directory[i];
        }
    }
    string path = String.Empty;
    StreamWriter sw = new StreamWriter("dir.txt");
    foreach (var item in list)
    {
        path = Path.Combine(path, item);
        IEnumerable<string> directoryList = Directory.EnumerateDirectories(path + "\\");
        sw.WriteLine($"Список папок в директории {path}");
        foreach (var dir in directoryList)
        {
            sw.WriteLine(dir);
        }

    }
    sw.Close();


    EndQuest();
}
#endregion

#region Quest5
void Quest5()
{
    

    List<ToDo> toDoList = new List<ToDo>(){};

    //первоначальная загрузка задач из файл, если он существует
    if (File.Exists(toDoFile))
    {
        toDoList.Clear();
        StreamReader sr = new StreamReader(toDoFile);
        while (!sr.EndOfStream)
        {
            string str = sr.ReadLine();
            ToDo temp = JsonConvert.DeserializeObject<ToDo>(str); //конвертация json в класс
            toDoList.Add(temp);
        }
        sr.Close();
    }

    //меню
    do
    {
        Console.WriteLine("Текущие задачи:");
        for (int i = 0; i < toDoList.Count; i++)
        {
            Console.WriteLine("{0, 2}.{1}", i + 1, toDoList[i].ToString());
        }
        Console.WriteLine("Введите номер задачи, для изменения статуса о выполнении.");
        Console.WriteLine("Введите описание задачи, для создания новой задачи");
        Console.WriteLine("Введите exit, для выхода и сохранения");
        string typing = Console.ReadLine().Trim();

        if (Int32.TryParse(typing, out int result))
        {
            if (--result < toDoList.Count) //уменьшение result, для работы машинного кода
            {
                toDoList[result].IsDone = !toDoList[result].IsDone; // меняем статус задачи
            }
        }
        else if (typing == "exit") //выход из программы
        {
            Save(toDoList);
            break;
        }
        else if (typing == "") //если ничего не введено, то и ничего не делаем
        {
            continue; 
        } 
        else //добавление новой задачи
        {
            toDoList.Add(new ToDo(typing)); 
            Console.WriteLine("Добавлена задача {0}. Для продожения нажмите Enter", typing);
            Console.ReadLine();
        }



        Save(toDoList);

        Console.Clear();

    } while (true);

    EndQuest();
}


/// <summary>
/// сохранение задач в файл
/// </summary>
void Save(List<ToDo> toDoList) 
{
    File.Delete(toDoFile); 
    for (int i = 0; i < toDoList.Count; i++)
    {
        string writing = JsonConvert.SerializeObject(toDoList[i]);
        File.AppendAllText(toDoFile, writing + "\n");
    }

}


#endregion

void EndQuest()
{
    Console.ReadLine();
    Console.Clear();
}

public class ToDo
{
    private string _title;
    private bool _isDone;

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public bool IsDone
    {
        get { return _isDone; }
        set { _isDone = value; }
    }

    public ToDo(string title, bool isDone = false)
    {
        Title = title;
        IsDone = isDone;
    }

    public override string? ToString() //красивый вывод
    {
        string isDone = "";
        if (this.IsDone)
        {
            isDone = "[x]";
        }
        return $"{isDone, 3} {Title}";
    }


}