using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var exit = false;
            var phoneBook = new Dictionary<string, string>();
            var group = new Dictionary<string, Dictionary<string, string>>();


            do
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Добавить");
                Console.WriteLine("2. Редактировать");
                Console.WriteLine("3. Удалить");
                Console.WriteLine("4. Найти");
                Console.WriteLine("5. Добавить номера в группу");
                Console.WriteLine("6. Показать всё");
                Console.WriteLine("7. Показать группы");
                Console.WriteLine("8. Удалить группу");
                Console.WriteLine("9. Удалить номер из группы");
                Console.WriteLine("10. Редактировать номер в группе");
                Console.WriteLine("0. Выход");
                var select = Console.ReadLine();
                switch (select)
                {
                    case "1": // 1. Добавить
                        AddRecord(group, phoneBook);
                        break;
                    case "2": // 2. Редактировать
                        Edit(phoneBook);
                        break;
                    case "3": // 3. Удалить
                        Delete(phoneBook);
                        break;
                    case "4": // 4. Найти
                        Find(phoneBook);
                        break;
                    case "5": // 5. Добавить номера в группу
                        AddtoGroup(group, phoneBook);
                        break;
                    case "6": // 6. Показать всё
                        Console.WriteLine("Все контакты");
                        PrintDictionary(phoneBook);
                        break;
                    case "7": // 7. Показать группы
                        Console.WriteLine("Группы");
                        PrintDictionary(group);
                        break;
                    case "8": // 8. Удалить группу
                        DeleteGroup(group);
                        break;
                    case "9": // 9. Удалить номер из группы
                        Deleteperson(group);
                        break;
                    case "10": // 10. Редактировать номер в группе
                        EditGroup(group);
                        break;

                    case "0": // 0. Выход
                        exit = true;
                        break;
                    default: // Неправильный ввод
                        Console.WriteLine("Повторите ввод");
                        Console.WriteLine();
                        break;
                }
            } while (!exit);
            Console.WriteLine("До свидания...");
        }
        static string inputname()
        {
            Console.Write("Введите имя - ");
            return Console.ReadLine();
        }
        static string inputphone()
        {
            Console.Write("Введите номер телефона - ");
            return Console.ReadLine();
        }
        static string inputgroup()
        {
            Console.WriteLine("Введите название группы");
            return Console.ReadLine();
        }

        static void AddtoGroup(Dictionary<string, Dictionary<string, string>> dictionary, Dictionary<string, string> phoneBook)
        {
            string groupname = inputgroup();
            string name = inputname();
            string phone = inputphone();
            var newperson = new Dictionary<string, string>();
            if (!phoneBook.ContainsKey(phone)) // записывает имя и телефон в телефонную книгу
            {
                phoneBook.Add(phone, name);
            }
            else  // проверяем наличие телефона в группе defualt
            {
                foreach (var element in dictionary)
                {
                    if (element.Value.ContainsKey(phone))
                    {
                        Console.WriteLine("Такой номер уже существует, попробуйте еще раз");
                        Console.WriteLine();
                        return;
                    }
                }
            }
            if (groupname == "")//Если строку группа оставили пустой , то создается группа defualt
            {
                if (dictionary.ContainsKey("default"))
                {
                    dictionary["default"].Add(phone, name);
                    return;
                }
                newperson.Add(phone, name);
                dictionary.Add("default", newperson);
                return;
            }
            //Если Группа создана , то записываем в телефонную книгу
            if (dictionary.ContainsKey(groupname))           //TryGetValue Получает значение, связанное с заданным ключом ,возвращает true или false .
            {                                                //Используйте TryGetValue метод, если код часто пытается получить доступ к ключам,
                                                             //которые отсутствуют в словаре. Использование этого метода является более эффективным,
                                                             //чем перехват KeyNotFoundException вызываемых Item[] свойством.

                dictionary[groupname].Add(phone, name);
                return;
            }
            //Если Группа не создана , то создаем группу и записываем в телефонную книгу
            newperson.Add(phone, name);
            dictionary.Add(groupname, newperson);
        }

        static void DeleteGroup(Dictionary<string, Dictionary<string, string>> dictionary)
        {
            string groupname = inputgroup();
            if (dictionary.ContainsKey(groupname))
            {
                dictionary.Remove(groupname);
            }
            else
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        static void Deleteperson(Dictionary<string, Dictionary<string, string>> dictionary)
        {
            var flag = false;
            string groupname = inputgroup();
            string name = inputphone();
            foreach (var element in dictionary[groupname])
            {
                if (element.Value == name)
                {
                    dictionary[groupname].Remove(element.Key);
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        static void Delete(Dictionary<string, string> dictionary)
        {
            var flag = false;
            var name = inputname();
            foreach (var element in dictionary)
            {
                if (element.Value == name)
                {
                    dictionary.Remove(element.Key);
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        static void EditGroup(Dictionary<string, Dictionary<string, string>> dictionary)
        {            
            string groupname = inputgroup();
            if (dictionary.ContainsKey(groupname))
            {
                string name = inputname();
                foreach (var element in dictionary[groupname])
                {
                    if (element.Value == name)
                    {
                        var phone = inputphone();
                        dictionary[groupname].Remove(element.Key);
                        dictionary[groupname].Add(phone, name);                       
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        static void Edit(Dictionary<string, string> dictionary)
        {
            var flag = false;
            var name = inputname();
            foreach (var element in dictionary)
            {
                if (element.Value == name)
                {
                    var phone = inputphone();
                    dictionary.Remove(element.Key);
                    dictionary.Add(phone, name);
                    //flag = true;
                    return;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        static void Find(Dictionary<string, string> dictionary)
        {
            bool flag = false;
            string name = inputname();

            foreach (var element in dictionary)
            {
                if (element.Value == name)
                {
                    Console.WriteLine($"{element.Value} - {element.Key}");
                    flag = true;
                }
            }

            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }
        static void AddRecord(Dictionary<string, Dictionary<string, string>> group, Dictionary<string, string> dictionary)
        {
            var newperson = new Dictionary<string, string>();
            var name = inputname();
            var phone = inputphone();
            if (!dictionary.ContainsKey(phone))
            {
                dictionary.Add(phone, name);
                /////добавляем в группу Defualt//////
                if (group.ContainsKey("default"))
                {
                    group["default"].Add(phone, name);
                    return;
                }
                newperson.Add(phone, name);
                group.Add("default", newperson);
                ////////////////////////////////////
            }
            else
            {
                Console.WriteLine("Такой номер уже существует, попробуйте еще раз");
                Console.WriteLine();
            }
        }

        static void PrintDictionary(Dictionary<string, string> dictionary)
        {
            foreach (var element in dictionary)
            {
                Console.WriteLine($"{element.Key} - {element.Value}");
            }
            Console.WriteLine();
        }
        static void PrintDictionary(Dictionary<string, Dictionary<string, string>> group)
        {
            foreach (var element in group)
            {
                Console.WriteLine($" {element.Key} : ");
                Console.WriteLine("----------------------------------");
                PrintDictionary(element.Value);
                Console.WriteLine();
            }
        }
    }
}