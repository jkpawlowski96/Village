using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JakubPawłowskiLab2Zad1
{
    /// <summary>
    /// Catapult- far range offensive unit
    /// </summary>
    public class Catapult : Unit
    {
        public Catapult()
        {
            HpMax = 500;
            hp = HpMax;
            Attack = 0;
            Attack_range = 10;
            Defence = 0.8;
        }
        /// <summary>
        /// Range atack
        /// </summary>
        /// <param name="them"></param>
        public void Shoot(List<Unit> them)
        {          
                //emitation of dispersion
                for (int shoots = 5; shoots > 0; shoots--)
                {
                    if (them.Count() == 0) return;
                    //random target id of defender
                    int target_id = new Random().Next(them.Count());
                    Unit target = them[target_id];
                    //attacker strike defender
                    Shoot(target);
                    //if dead remove
                    if (target.hp <= 0)
                        them.RemoveAt(target_id);
                }
        }
    }
}
