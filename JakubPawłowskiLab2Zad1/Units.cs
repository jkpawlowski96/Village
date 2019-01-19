using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JakubPawłowskiLab2Zad1
{   
    /// <summary>
    /// Class to counting units
    /// </summary>
    public class Units
    {
        //numbers of specyfic units
        public int swordman, archer, pikeman, ladder, catapult, healer, repairer;
        //number units located on the wall
        public int on_the_wall;

        /// <summary>
        /// Count units from the list and create a Units object
        /// </summary>
        /// <param name="list">List of units to count</param>
        /// <returns></returns>
        public Units(List<Unit> list)
        {
            //counting
            foreach (Unit unit in list)
            {
                //fit to type of unit
                if (unit is Swordman)
                {
                    swordman++;
                    //located on the wall
                    if (unit.on_the_wall) on_the_wall++;
                }
                if (unit is Archer)
                    archer++;
                if (unit is Pikeman)
                {
                    pikeman++;
                    //located on the wall
                    if (unit.on_the_wall) on_the_wall++;
                }
                if (unit is Ladder)
                    ladder++;
                if (unit is Catapult)
                    catapult++;
                if (unit is Healer)
                    healer++;
                if (unit is Repairer)
                    repairer++;
            }
        }
    }
}
