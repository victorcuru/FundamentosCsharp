using System;

namespace EditorHtml
{
    public class Menu
    {
        public static void Show()
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            DrawScreen();
            WriteOptions();

            var op = short.Parse(Console.ReadLine());

            HandleMenuOption(op);

        }
        public static void DrawScreen()
        {   
            void Columns()
            {
                Console.Write("+");

                for(int i = 0; i <= 30; i++) 
                    Console.Write("-");
                
                Console.Write("+");

                Console.Write("\n");
            }

            void Lines()
            {
                for(int lines = 0; lines <= 10; lines++)
                {   
                    Console.Write("|");

                    for(int i = 0; i <= 30; i++)
                        Console.Write(" ");
                    
                    Console.Write("|");
                    Console.Write("\n");
                }
            }

            Columns();
            Lines();
            Columns();
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("=============");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Selecione uma opção abaixo");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Abrir");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");
        }

        public static void HandleMenuOption(short op)
        {
            switch(op){
                case 1: Editor.Show(); break;
                case 2: Viewer.Open(); break;
                case 0: {
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                }
                default: Show(); break;
            }
        }
    }
}