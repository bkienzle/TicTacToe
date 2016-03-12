using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        public string Name { get; set; }
        public int WinRecord { get; set; }
        public int LossRecord { get; set; }
        public int TieRecord { get; set; }

        public void setName()
        {
            Console.Write("Please enter your name: ");
            Name = Console.ReadLine();
            if (Name.Length > 32) Name = Name.Substring(0, 32);
            if (Name == "") Name = "Scrub";
        }
        public void ShowRecord()
        {
            Console.WriteLine();
            Console.WriteLine("{0}, your current record is: Wins: {1} Losses: {2} Ties: {3}", Name, WinRecord, LossRecord, TieRecord);
        }
    }
}
