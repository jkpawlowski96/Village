using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JakubPawłowskiLab2Zad1
{
    /// <summary>
    /// Universal unit of attackers and defenders
    /// </summary>
    public  class Unit
    {
        //health-points
        public int hp;
        /// <summary>
        /// Max hp value
        /// </summary>
        public int HpMax { get; set; }
        //Attack in close distance-skill
        public int Attack { get; set; }
        //Atack in far distance-skill
        public int Attack_range { get; set; }
        //Defence-skill
        public double Defence { get; set; }
        //unit on the wall
        public bool on_the_wall=false;
        

        public void Strike(Unit target)
        {   //unit hit target        
            target.hp -= (int)(Attack / target.Defence);
            //unit get hit from target in revenge
            hp -= (int)(target.Attack / Defence);
        }
        public void Shoot(Unit target)
        {   
            //unit shoot target
            target.hp -=(int) (Attack_range / target.Defence);
        }
        public virtual void Strike(List<Unit> them)
        {

        }
        

    }
}
