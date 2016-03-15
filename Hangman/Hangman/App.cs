using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class App
    {
        public void Start()
        {
            Player human = new Player();
            Game hangman = new Game();
            human.GetName();

            Console.Clear();
            human.ShowRecord();
            hangman.DrawBoard();

            Console.ReadKey();

        }
    }
}
