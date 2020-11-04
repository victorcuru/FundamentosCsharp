using System;
using System.Text;
using System.IO;

namespace EditorHtml
{
    public class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("------------");
            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            do {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("-------------");
            
            Viewer.Show(file.ToString());
        }
        public static void Save(string text)
        {
            Console.Clear();

            Console.WriteLine(" Deseja salvar o arquivo?");
            Console.WriteLine("-----------------------------");

            Console.WriteLine("Defina um nome para o arquivo ou pressione 0 para cancelar a operação: ");
            var name = Console.ReadLine();
            
            if(name == "0")
                Menu.Show();

            using(var file = new StreamWriter(name))
            {
                file.Write(text);
            }

            Console.Write("\n");
            Console.WriteLine($"Arquivo {name} salvo com sucesso!!!");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Menu.Show();
        }

    }
}