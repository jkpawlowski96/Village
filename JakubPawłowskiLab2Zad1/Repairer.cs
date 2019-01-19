using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JakubPawłowskiLab2Zad1
{
    /// <summary>
    /// Reapairer- defensive unit, can fix catapults and wall
    /// </summary>
    public class Repairer :  Unit
    {
        public Repairer()
        {
            HpMax = 30;
            hp = HpMax;
            Attack = 10;
            Attack_range = 0;
            Defence = 1;
        }
        /// <summary>
        /// Repair mechanical units
        /// </summary>
        /// <param name="them"></param>
        public void Repair(List<Unit> them)
        {   
            //list of mashines
            List<Catapult> mashines = new List<Catapult>();
            foreach (Catapult cat in them.OfType<Catapult>())
                if(cat.hp<cat.HpMax)mashines.Add(cat);
            //samothing to repair
            if (mashines.Count() == 0) return;
            //random construction target id of
            int target_id = new Random().Next(mashines.Count());
            Unit target = mashines[target_id];
            //fix
            target.hp += 50;
            //max value
            if (target.hp > target.HpMax) target.hp = target.HpMax;      
        }
    }
}
