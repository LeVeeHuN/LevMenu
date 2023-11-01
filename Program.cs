namespace LevMenu
{
    public class LevMenu
    {
        private string[] options;
        private int currentSelection;

        public int LastSelection { get { return currentSelection; } }

        public LevMenu(string[] options)
        {
            this.options = options;
            this.currentSelection = 0;
        }

        public LevMenu(List<string> options)
        {
            this.currentSelection = 0;
            this.options = new string[options.Count];
            for (int i = 0; i < options.Count; i++)
            {
                this.options[i] = options[i];
            }
        }

        public int? SelectionDialogue()
        {
            bool refresh = true;
            bool isCursorVisible = Console.CursorVisible;
            Console.CursorVisible = false;
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();
            while (pressedKey.Key != ConsoleKey.Escape)
            {
                if (refresh)
                {
                    Console.Clear();
                    for (int i = 0; i < options.Length; i++)
                    {
                        if (currentSelection == i)
                        {
                            Console.WriteLine("[*] " + options[i]);
                        }
                        else
                        {
                            Console.WriteLine("[ ] " + options[i]);
                        }
                    }
                }
                refresh = false;
                pressedKey = Console.ReadKey(false);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (currentSelection < options.Length - 1)
                        {
                            currentSelection++;
                            refresh = true;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (currentSelection > 0)
                        {
                            currentSelection--;
                            refresh = true;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.CursorVisible = isCursorVisible;
                        return currentSelection;
                }
            }
            Console.Clear();
            Console.CursorVisible = isCursorVisible;
            return null;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Hi :)
        }
    }
}