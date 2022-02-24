using System.Diagnostics;


do
{
    Console.Clear(); //очистка консоли для красивости

    Process[] processArray = Process.GetProcesses(); //массив процессов
    processArray = SortArrayProcess(processArray); //сортировка массива по Process.ID для красоты

    Console.WriteLine("{0, 6}|{1, -40}|{2, -12}", "ID", "Name", "Memory"); //заголовок таблицы

    foreach (Process process in processArray) //вывод массив процессов на консоль
    {
        Console.WriteLine("{0, 6}|{1, -40}|{2, -12}", process.Id, process.ProcessName, process.PagedMemorySize64); // ID, имя, занятая память
    }

    Console.WriteLine("Введите exit для выхода.");
    Console.Write("Введите имя или ID процесса для закрытия процесса: ");
    string typing = Console.ReadLine();

    if (typing == "exit") // если введен выход, то выход из программы
    {
        break;
    }

    if (Int32.TryParse(typing, out int idProcess)) //если из ввода успешно парсится int, то предполагается, что введен id процесса для завершения
    {
        try //попытка получить процесс по id и завершить его
        {
            Process processByID = Process.GetProcessById(idProcess);
            processByID.Kill();
            Console.WriteLine("Процесс {0} с ID {1} завершен.", processByID.ProcessName, processByID.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine("Не удалось завершить процесс по причине {0}", e.Message);
        }
        finally
        {
            Console.ReadLine(); //в любом случае ридлайн, т.к. нужно не сразу перезапустить цикл, а там то в начале очистка консоли
        }
        continue; // дальнейший код не нужен, т.к. была попытка завершить процесс по ID 
    }
    else //если из ввода не парсится int
    {
        try //попытка завершить процесс по имени
        {
            Process[] processByName = Process.GetProcessesByName(typing);
            foreach (var process in processByName) // завершаем все процессы с указанным именем
            {
                process.Kill();
                Console.WriteLine("Процесс {0} с ID {1} завершен.", process.ProcessName, process.Id);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Не удалось завершить процесс по причине {0}", e.Message);
        }
        finally
        {
            Console.ReadLine(); //в любом случае ридлайн, т.к. нужно не сразу перезапустить цикл, а то там в начале очистка консоли
        }
    }



} while (true);

Process[] SortArrayProcess(Process[] processArray) //сортировка массива
{
    bool sort;
    do
    {
        sort = false;
        for (int i = 1; i < processArray.Length; i++)
        {
            if (processArray[i - 1].Id > processArray[i].Id)
            {
                Process temp = processArray[i - 1];
                processArray[i - 1] = processArray[i];
                processArray[i] = temp;
                sort = true;
            }
        }
    } while (sort);

    return processArray;
}