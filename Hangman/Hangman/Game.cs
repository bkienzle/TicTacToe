using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Game
    {
        public void DrawBoard()
        {
            string head = "O";
            string body = "|";
            string leftArm = "/"; //this is my left, not the hangee's left.
            string rightArm = @"\";
            string leftLeg = "/";
            string rightLeg = @"\";
            Console.WriteLine();
            Console.WriteLine(new string(' ', 10) +                             ",____.");
            Console.WriteLine(new string(' ', 10) +                             "|    |");
            Console.WriteLine(new string(' ', 10) + head +                       "    |");
            Console.WriteLine(new string(' ', 9) + leftArm + body + rightArm +   "   |");
            Console.WriteLine(new string(' ', 10) + body +                       "    |");
            Console.WriteLine(new string(' ', 9) + leftLeg + " " + rightLeg +    "   |");
            Console.WriteLine(new string(' ', 10) +                             "     |");
            Console.WriteLine(new string(' ', 8) +                           "-------^--");
            Console.WriteLine();
        }
    }
}
