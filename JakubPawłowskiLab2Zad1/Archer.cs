using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JakubPawłowskiLab2Zad1
{
    /// <summary>
    /// Archer- short range offensive unit
    /// </summary>
    public class Archer : Unit
    {
        public Archer(bool arg_on_the_wall=false)
        {
            HpMax = 80;
            hp = HpMax;
            Attack = 10;
            Attack_range = 50;
            Defence = 1.2;
            on_the_wall = arg_on_the_wall;
        }
        /// <summary>
        /// Range atack
        /// </summary>
        /// <param name="them"></param>
        public void Shoot(List<Unit> them)
        {   if (them.Count() == 0) return;
            //random target id of attackers
            int target_id = new Random().Next(them.Count());
            Unit target = them[target_id];
            //defender strike attacker
            Shoot(target);
            //if dead remove
            if (target.hp <= 0)
                them.RemoveAt(target_id);
        }
    }
}
