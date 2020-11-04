using System;
using System.Text.RegularExpressions;
using System.IO;


namespace EditorHtml
{
    public class Viewer
    {
        public static void Show(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("------------");
            Replace(text);
            Console.WriteLine("------------");
            Editor.Save(text);
        }

        public static void Replace(string text)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            
            var words = text.Split(' ');

            for (int i=0; i < words.Length; i++)
            {
                if(strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            (
                                (words[i].LastIndexOf('<') - 1) -
                                words[i].IndexOf('>')
                            )
                        )
                    );
                } else {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }
        }
        public static void Open()
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
            Menu.Show();
        }
    }
}