using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JakubPawłowskiLab2Zad1
{
    public class Swordman : Unit
    {
       public Swordman(bool arg_on_the_wall = false)
        {
            HpMax = 120;
            hp = HpMax;
            Attack = 50;
            Attack_range = 0;
            Defence = 1.5;
            on_the_wall = arg_on_the_wall;
        }
        /// <summary>
        /// Strike unit in close combat
        /// </summary>
        /// <param name="them"></param>
        public override void Strike(List<Unit>them)
        {
            //somebody
            bool somebody = false;
            if (them.Count() == 0) return;
            foreach (Unit unit in them.OfType<Swordman>())
                if (unit.on_the_wall) somebody = true;
            foreach (Unit unit in them.OfType<Pikeman>())
                if (unit.on_the_wall) somebody = true;
            foreach (Unit unit in them.OfType<Archer>())
                if (unit.on_the_wall) somebody = true;
            if (!somebody) return;
            //random target id of defender on the wall
            int target_id = new Random().Next(them.Count());
            while (!them[target_id].on_the_wall)
                target_id = new Random().Next(them.Count());
            Unit target = them[target_id];
            //attacker strike defender
            Strike(target);
            //if dead remove
            if (target.hp <= 0)
                them.RemoveAt(target_id);
        }
        /// <summary>
        /// Getting on the wall
        /// </summary>
        /// <param name="succed"></param>
        public void CLimb(bool succed)
        {
            if (succed)
                on_the_wall = true;
        }
    }
}
