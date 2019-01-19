using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JakubPawłowskiLab2Zad1
{
    public class Ladder : Unit
    {
        public Ladder()
        {
            HpMax = 50;
            hp = HpMax;
            Attack = 0;
            Attack_range = 0;
            Defence = 20;
        }
    }
}
