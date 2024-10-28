using System;

namespace StudentApp
{
    public abstract class Person
    {
        public abstract string Name { get; }
        public abstract string GetInfo();
    }

    public class Student : Person
    {
        private string _name;
        public override string Name => _name;
        public int Age { get; set; }

        public Student(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя не может быть пустым", nameof(name));
            }
            _name = name;
            Age = 0; // Возраст по умолчанию
        }

        public Student(string name, int age)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя не может быть пустым", nameof(name));
            }
            if (age < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(age), "Возраст не может быть отрицательным");
            }
            _name = name;
            Age = age;
        }

        public override string GetInfo()
        {
            return $"Имя: {Name}, Возраст: {Age}";
        }

        public void BecomeOlder()
        {
            Age++;
        }

        public override string ToString()
        {
            return GetInfo();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Создание объекта класса Student с некорректным именем
                Student student1 = new Student(""); // Это вызовет исключение
                Console.WriteLine(student1);
            }
            catch (ArgumentException ex) when (ex.ParamName == "name")
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Завершение блока Main.");
            }

            try
            {
                // Создание объекта класса Student с отрицательным возрастом
                Student student2 = new Student("Иван", -5); // Это вызовет исключение
                Console.WriteLine(student2);
            }
            catch (ArgumentOutOfRangeException ex) when (ex.ParamName == "age")
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Завершение блока Main.");
            }
        }
    }
}