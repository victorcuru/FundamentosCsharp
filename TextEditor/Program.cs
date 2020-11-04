using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Abrir");
            Console.WriteLine("2 - Criar novo arquivo");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;

                case 1: Open(); break;

                case 2: Edit(); break;
                
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Clear();

            Console.WriteLine("Qual o nome do arquivo que deseja abrir?");

            string name = Console.ReadLine();

            using(var file = new StreamReader(name))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);

            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }
        static void Edit()
        {
            Console.Clear();

            Console.WriteLine("Digite seu texto abaixo ou tecle ESC para sair");

            Console.WriteLine("-------------------------");

            string text = "";

            do 
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);
            Menu();
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Digite um nome para o arquivo");
            var name = Console.ReadLine();

            using(var file = new StreamWriter(name))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {name} salvo com sucesso!!!");

            Console.ReadLine();

            Menu();

        }
    }
}
