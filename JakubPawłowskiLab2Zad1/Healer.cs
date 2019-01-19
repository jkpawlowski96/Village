using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JakubPawłowskiLab2Zad1
{
    /// <summary>
    /// Healer- defensive unit, can increase hp of units
    /// </summary>
    public class Healer : Unit
    {
       public Healer()
        {
            HpMax = 30;
            hp = HpMax;
            Attack = 0;
            Attack_range = 0;
            Defence = 1;
        }
        /// <summary>
        /// Heal units
        /// </summary>
        /// <param name="them"></param>
        public void Heal(List<Unit> them)
        {   
            //random alive target id of
            int target_id = new Random().Next(them.Count());
            //is anyone to heal
            bool someone_to_heal=false;
            foreach (Unit unit in them)
                if ((!(unit is Catapult)) &&unit.hp < unit.HpMax) someone_to_heal = true;
            if (!someone_to_heal) return;
            //non mashine or non healthfull one
            while (them[target_id] is Catapult || them[target_id].hp>=them[target_id].HpMax)
                target_id = new Random().Next(them.Count());
            Unit target = them[target_id];
            //heal
            target.hp += 5;
            //max value
            if (target.hp > target.HpMax) target.hp = HpMax;
        }
    }
}
