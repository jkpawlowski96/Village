using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JakubPawłowskiLab2Zad1
{
    public partial class FormMain : Form
    {     
        //COSTS OF ACTIONS IN RESOURCES
        const int COST_UPGRADE_WOOD_IN_IRON = 50;
        const int COST_UPGRADE_FOOD_IN_WOOD = 50;
        const int COST_UPGRADE_ROCKIRON_IN_WOOD = 30;
        const int COST_UPGRADE_ROCKIRON_IN_IRON = 30;
        const int COST_UPGRADE_HOUSE_IN_WOOD = 30;
        const int COST_UPGRADE_HOUSE_IN_ROCK = 15;
        const int COST_UPGRADE_HOUSE_IN_IRON = 5;
        const int COST_UPGRADE_WALL_IN_ROCK = 100;
        //COSTS OF SWORDMAN
        const int COST_CREATE_SWORDMAN_IN_FOOD = 20;
        const int COST_CREATE_SWORDMAN_IN_IRON = 10;
        //COSTS OF ARCHER
        const int COST_CREATE_ARCHER_IN_FOOD = 10;
        const int COST_CREATE_ARCHER_IN_WOOD = 10;
        //COSTS OF PIKEMAN
        const int COST_CREATE_PIKEMAN_IN_WOOD = 20;
        const int COST_CREATE_PIKEMAN_IN_FOOD = 15;
        //COSTS OF HEALER
        const int COST_CREATE_HEALER_IN_FOOD = 200;
        //COSTS OF CATAPULT
        const int COST_CREATE_CATAPULT_IN_WOOD = 100;
        const int COST_CREATE_CATAPULT_IN_ROCK = 50;
        //COSTS OF REPAIRER
        const int COST_CREATE_REPAIRER_IN_IRON = 20;
        const int COST_CREATE_REPAIRER_IN_FOOD = 20;
        //number of enemy wave
        int wave;
        //game running/paused
        bool play=true;
        //level of resources earning
        int levelResourcesWood;
        int levelResourcesFood;
        int levelResourcesRockIron;
        int levelResourcesHouses;
        int levelResourcesWall;
        //number of reasources to spend
        int numberResourcesWood;
        int numberResourcesFood;
        int numberResourcesRock;
        int numberResourcesIron;
        int numberResourcesVillagers;
        //numbers of defenders units
        Units defenders;
        //numbers of attackers units
        Units attackers;
        //list of attacking units
        List<Unit> att_list;
        //list of defending units
        List<Unit> def_list;
        /// <summary>
        /// Window initialization
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            //lists of units
            def_list = new List<Unit>();
            att_list = new List<Unit>();
            //resources level earning initialization
            levelResourcesWood =
            levelResourcesFood =
            levelResourcesRockIron = 
            levelResourcesHouses=
            levelResourcesWall=1;
            //start wave of enemies
            wave = 0;
            //number of resources initiakization
            numberResourcesWood = 150;
            numberResourcesFood = 200;
            numberResourcesRock = 100;
            numberResourcesIron = 50;
            numberResourcesVillagers = 10;
            //constant costs initialization
            labelSwordmanCost.Text = "Iron: "+COST_CREATE_SWORDMAN_IN_IRON + " Food: "+COST_CREATE_SWORDMAN_IN_FOOD;
            labelArcherCost.Text = "Wood: "+COST_CREATE_ARCHER_IN_WOOD + " Food: "+COST_CREATE_ARCHER_IN_FOOD;
            labelPikemanCost.Text = "Wood: " + COST_CREATE_PIKEMAN_IN_WOOD + " Food: " + COST_CREATE_PIKEMAN_IN_FOOD;
            labelHealerCost.Text = "Food: " + COST_CREATE_HEALER_IN_FOOD + " Villagers: 5";
            labelCatapultCost.Text = "Wood: " + COST_CREATE_CATAPULT_IN_WOOD + " Rock: " + COST_CREATE_CATAPULT_IN_ROCK;
            labelRepairerCost.Text = "Iron: " + COST_CREATE_REPAIRER_IN_IRON + " Food: " + COST_CREATE_REPAIRER_IN_FOOD;
            //refresh informations
            RefreshNumbers();
            RefreshLevelResources();
            RefreshCosts();
        }
        /// <summary>
        /// Funcion to refresh info about numberResources and units
        /// </summary>
        void RefreshNumbers()
        {   
            //counting units from lists
            attackers = new Units(att_list);
            defenders = new Units(def_list);
            //numbers resources
            labelResourcesFood.Text = "Food: " + numberResourcesFood.ToString();
            labelResourcesWood.Text = "Wood: " + numberResourcesWood.ToString();
            labelResourcesRock.Text = "Rock: " + numberResourcesRock.ToString();
            labelResourcesIron.Text = "Iron: " + numberResourcesIron.ToString();
            labelResourcesVillagers.Text = "Villagers: " + numberResourcesVillagers.ToString();   
            //numbers of def units
            labelDefSwordmen.Text = "Swordmen: " + defenders.swordman.ToString()+" +";
            labelDefArchers.Text = "Archers: " + defenders.archer.ToString() + " +";
            labelDefPikemen.Text = "Pikemen: " + defenders.pikeman.ToString() + " +";
            labelDefHealers.Text = "Healers: " + defenders.healer.ToString() + " +";
            labelDefRepairers.Text = "Repairer: " + defenders.repairer.ToString() + " +";
            labelDefCatapults.Text = "Catapult: " + defenders.catapult.ToString() + " +";
            //numbers of att units
            #region display numbers of attackers units
            if (attackers.swordman == 0)
            {
                labelAttSwordmen.Text = "";
                pictureAttSwordman.Hide();
            }
            else
            {
                labelAttSwordmen.Text = attackers.swordman.ToString();
                pictureAttSwordman.Show();
            }
            if (attackers.archer == 0)
            {
                labelAttArchers.Text = "";
                pictureAttArcher.Hide();
            }
            else
            {
                labelAttArchers.Text = attackers.archer.ToString();
                pictureAttArcher.Show();
            }
            if (attackers.pikeman == 0)
            {
                labelAttPikemen.Text = "";
                pictureAttPikeman.Hide();
            }
            else
            {
                labelAttPikemen.Text = attackers.pikeman.ToString();
                pictureAttPikeman.Show();
            }
            if (attackers.ladder == 0)
            {
                labelAttLadders.Text = "";
                pictureAttLadder.Hide();
            }
            else
            {
                labelAttLadders.Text = attackers.ladder.ToString();
                pictureAttLadder.Show();
            }
            if (attackers.catapult == 0)
            {
                labelAttCatapults.Text = "";
                pictureAttCatapult.Hide();
            }
            else
            {
                labelAttCatapults.Text = attackers.catapult.ToString();
                pictureAttCatapult.Show();
            }
            #endregion
            //hp of defenders status
            #region hp bar count and display
            List<Unit> units;
            //swordmen
            units = new List<Unit>();
            foreach (Swordman unit in def_list.OfType<Swordman>())           
                units.Add(unit);
            HpSwordmen.Value = CountHp(units);
            //archers
            units = new List<Unit>();
            foreach (Archer unit in def_list.OfType<Archer>())
                units.Add(unit);
            HpArchers.Value = CountHp(units);
            //Pikemen
            units = new List<Unit>();
            foreach (Pikeman unit in def_list.OfType<Pikeman>())
                units.Add(unit);
            HpPikemen.Value = CountHp(units);
            //Catapults
            units = new List<Unit>();
            foreach (Catapult unit in def_list.OfType<Catapult>())
                units.Add(unit);
            HpCatapults.Value = CountHp(units);
            //Healers
            units = new List<Unit>();
            foreach (Healer unit in def_list.OfType<Healer>())
                units.Add(unit);
            HpHealers.Value = CountHp(units);
            //Repairers
            units = new List<Unit>();
            foreach (Repairer unit in def_list.OfType<Repairer>())
                units.Add(unit);
            HpRepairers.Value = CountHp(units);
            #endregion
        }
        /// <summary>
        /// Count Hp percent of specyficed type units
        /// </summary>
        /// <param name="units">list of units the same type</param>
        /// <returns>real hp in scale 0-100</returns>
        int CountHp(List<Unit> units)
        {   
            //no units
            if (units.Count() == 0) return 0;
            //sum of all max hp 
            int hp_sum_max = units.Count() * units[0].HpMax;
            //counting hp
            int hp_sum=0;
            foreach(Unit unit in units)
            {
                hp_sum += unit.hp;
            }
            //return percent of max hp
            return (int)100*hp_sum / hp_sum_max;
        }
        /// <summary>
        /// Funcion to refresh info about levelResources
        /// </summary>
        void RefreshLevelResources()
        {   
            //display level of resources
            labelResourcesFoodLevel.Text = levelResourcesFood.ToString();
            labelResourcesWoodLevel.Text = levelResourcesWood.ToString();
            labelResourcesRockIronLevel.Text = levelResourcesRockIron.ToString();
            labelResourcesHousesLevel.Text = levelResourcesHouses.ToString();
            labelResourcesWallLevel.Text = levelResourcesWall.ToString(); 
        }
        /// <summary>
        /// Funcion to refresh info about  costs
        /// </summary>
        void RefreshCosts()
        {
            //display costs of ugprades
            labelResourcesFoodUpgradeCost.Text = "Wood: " + (levelResourcesFood * COST_UPGRADE_FOOD_IN_WOOD).ToString();
            labelResourcesWoodUpgradeCost.Text = "Iron: " + (levelResourcesWood * COST_UPGRADE_WOOD_IN_IRON).ToString();
            labelResourcesRockIronUpgradeCost.Text = "Iron: " + (levelResourcesRockIron * COST_UPGRADE_ROCKIRON_IN_IRON).ToString()
                                                  + " Wood: " + (levelResourcesRockIron * COST_UPGRADE_ROCKIRON_IN_WOOD).ToString();
            labelResourcesHousesUpgradeCost.Text = "Wood: " + (levelResourcesHouses * COST_UPGRADE_HOUSE_IN_WOOD).ToString()
                                                + " Iron: " + (levelResourcesHouses * COST_UPGRADE_HOUSE_IN_IRON).ToString()
                                                + " Rock: " + (levelResourcesHouses * COST_UPGRADE_HOUSE_IN_ROCK).ToString();
            labelResourcesWallUpgradeCost.Text = "Rock: " + (levelResourcesWall * COST_UPGRADE_WALL_IN_ROCK).ToString();
        }
        /// <summary>
        /// Funcion to generate probability answer
        /// </summary>
        /// <param name="chance_to_succes">
        /// Percent chance to return true
        /// </param>
        /// <returns>
        /// true-succed
        /// false-failed
        /// </returns>
        bool Probability(double chance_to_succes)
        {
            Random rand = new Random();
            double chance = rand.Next(1, 101);
            //compare to parametr
            if (chance <= chance_to_succes) // probability
            {   //succes
                return true;
            }
            else
            {   //failure
                return false;
            }
        }       
        /// <summary>
        /// Funcion to generate attackers
        /// </summary>
        void GenerateAttackers()
        {
            //level1 units
            for (int i = 0; i < wave; i+=2)
            {
                att_list.Add(new Swordman());
                att_list.Add(new Archer());               
            }
            //level 2 units 
            for (int i = 1; i <wave ; i+=3)
            {             
                att_list.Add(new Pikeman());
                att_list.Add(new Ladder());
            }
            //level 3 units
            for (int i = 3; i < wave; i+=3)
            {
                att_list.Add(new Catapult());              
            }
        }    
        /// <summary>
        /// Funcion to check status of game
        /// </summary>
        void CheckStatus()
        {   //the wall must be protected
            if (defenders.swordman+defenders.archer+defenders.pikeman<=0&&
                attackers.pikeman+attackers.swordman>0)
            //nobody on the wall
            {
                //game over
                play = false;
                MessageBox.Show("You lose");
                Close();
            }
            //the wall is still protected
        }
        /// <summary>
        /// Round of Attackers
        /// </summary>
        void Attack()
        {   
            //first line of attackers
            #region att get on the wall
            foreach (Swordman unit in att_list.OfType<Swordman>())
                unit.CLimb(Probability(attackers.ladder/levelResourcesWall));
                         
            foreach (Pikeman unit in att_list.OfType<Pikeman>())
                unit.CLimb(Probability(attackers.ladder/levelResourcesWall));

            #endregion
            //attackers on the wall
            #region att on the wall strike def on the wall
            foreach (Unit unit in att_list)
                if (unit.on_the_wall)
                    unit.Strike(def_list);
            #endregion
            //range units turn
            #region att shoot def on the wall
            foreach (Archer unit in att_list.OfType<Archer>())
                unit.Shoot(def_list);       
            foreach (Catapult unit in att_list.OfType<Catapult>())
                unit.Shoot(def_list);              
            #endregion         
        }
        /// <summary>
        /// Round of Defenders
        /// </summary>
        void Defend()
        {
            //range turn
            #region def  shoot att
            foreach (Catapult unit in def_list.OfType<Catapult>())
                unit.Shoot(att_list);
            foreach (Archer unit in def_list.OfType<Archer>())
                unit.Shoot(att_list);
            #endregion
            //first line units 
            #region def on the wall strike att on the wall
            if (attackers.on_the_wall > 0)
            {
                //first line
                foreach (Pikeman unit in def_list.OfType<Pikeman>())
                {
                    if (attackers.on_the_wall == 0) break;
                    unit.Strike(att_list);
                    attackers = new Units(att_list);
                }
                //second line
                foreach (Swordman unit in def_list.OfType<Swordman>())
                {
                    if (attackers.on_the_wall == 0) break;
                    unit.Strike(att_list);
                    attackers = new Units(att_list);
                }
            }
            #endregion
            //time to fix damages
            #region fixing
            foreach (Healer unit in def_list.OfType<Healer>())
                unit.Heal(def_list);
            foreach (Repairer unit in def_list.OfType<Repairer>())
                unit.Repair(def_list);
            #endregion
        }
        /// <summary>
        /// Timer of fight rounds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerFight_Tick(object sender, EventArgs e)
        {
            if (play)
            {   //rounds of combat
                Defend();                             
                Attack();
                //refresh changes
                RefreshNumbers();
                CheckStatus();
                //only swordmen and pikemen can get on the wall
                if (attackers.swordman + attackers.pikeman <= 0)
                //lack of danger
                {
                    att_list = new List<Unit>();
                    RefreshNumbers();
                    timerFight.Enabled = false;
                    timerWave.Enabled = true;
                }
                //still fighting
            }
        }
        /// <summary>
        /// Upgrade Food level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResourcesFoodUpgrade_Click(object sender, EventArgs e)
        {
            if (numberResourcesWood     >= COST_UPGRADE_FOOD_IN_WOOD * levelResourcesFood&&
                numberResourcesVillagers >= 1)
            {
                //payment
                numberResourcesWood -= COST_UPGRADE_FOOD_IN_WOOD * levelResourcesFood;
                numberResourcesVillagers--;
                //upgrade food resources level
                levelResourcesFood++;
                //refresh level Resources
                RefreshLevelResources();
                //refresh number Resources 
                RefreshNumbers();
                //refresh costs
                RefreshCosts();
            }
        }
        /// <summary>
        /// Upgrade Wood level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResourcesWoodUpgrade_Click(object sender, EventArgs e)
        {
            if (numberResourcesIron     >= COST_UPGRADE_WOOD_IN_IRON * levelResourcesWood&&
                numberResourcesVillagers >= 1)
            {
                //payment
                numberResourcesIron -= COST_UPGRADE_WOOD_IN_IRON * levelResourcesWood;
                numberResourcesVillagers--;
                //upgrade wood resources level
                levelResourcesWood++;
                //refresh level Resources
                RefreshLevelResources();
                //refresh number Resources 
                RefreshNumbers();
                //refresh costs
                RefreshCosts();
            }
        }
        /// <summary>
        /// Upgrade RockIron level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResourcesRockIronUpgrade_Click(object sender, EventArgs e)
        {
            if (numberResourcesIron >= COST_UPGRADE_ROCKIRON_IN_IRON * levelResourcesRockIron&&
                numberResourcesWood >= COST_UPGRADE_ROCKIRON_IN_WOOD * levelResourcesRockIron&&
                numberResourcesVillagers >= 1)
            {
                //payment
                numberResourcesIron -= COST_UPGRADE_ROCKIRON_IN_IRON * levelResourcesRockIron;
                numberResourcesWood -= COST_UPGRADE_ROCKIRON_IN_WOOD * levelResourcesRockIron;
                numberResourcesVillagers--;
                //upgrade rock resources level
                levelResourcesRockIron++;
                //refresh level Resources
                RefreshLevelResources();
                //refresh number Resources 
                RefreshNumbers();
                //refresh costs
                RefreshCosts();
            }
        }
        /// <summary>
        /// Upgrade House level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResourcesHousesUpgrade_Click(object sender, EventArgs e)
        {
            if ((numberResourcesWood >= COST_UPGRADE_HOUSE_IN_WOOD * levelResourcesHouses)&&
               (numberResourcesIron >= COST_UPGRADE_HOUSE_IN_IRON * levelResourcesHouses)&&
               (numberResourcesRock >= COST_UPGRADE_HOUSE_IN_ROCK * levelResourcesHouses))
            {
                //payment
                numberResourcesWood -= COST_UPGRADE_HOUSE_IN_WOOD * levelResourcesHouses;
                numberResourcesIron -= COST_UPGRADE_HOUSE_IN_IRON * levelResourcesHouses;
                numberResourcesRock -= COST_UPGRADE_HOUSE_IN_ROCK * levelResourcesHouses;
                //upgrade houses resources level
                levelResourcesHouses++;
                //refresh level Resources
                RefreshLevelResources();
                //refresh number Resources 
                RefreshNumbers();
                //refresh costs
                RefreshCosts();
            }
        }
        /// <summary>
        /// Natural resources growth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerNaturalResourcesGrowth_Tick(object sender, EventArgs e)
        {   
            //growth
            numberResourcesFood += levelResourcesFood;
            numberResourcesWood += levelResourcesWood;
            numberResourcesRock += levelResourcesRockIron;
            numberResourcesIron += levelResourcesRockIron;
            //recover damages
            #region fixing
            foreach (Healer unit in def_list.OfType<Healer>())
                unit.Heal(def_list);
            foreach (Repairer unit in def_list.OfType<Repairer>())
                unit.Repair(def_list);
            #endregion
            //refresh numbers
            RefreshNumbers();
        }
        /// <summary>
        /// Human resources growth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerHumanResourcesGrowth_Tick(object sender, EventArgs e)
        {
            //growth
            numberResourcesVillagers += levelResourcesHouses;   
        }
        /// <summary>
        /// Next wave of attackers timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerWave_Tick(object sender, EventArgs e)
        {
            if (progressBarNewWave.Value != 30)
            //bar is not loaded
            {   
                //progres bar step
                progressBarNewWave.Value++;
            }
            else
            //bar is full
            {   
                //reste progres bar
                progressBarNewWave.Value = 0;    
                //new wave
                wave++;
                //Gnerate attackers
                GenerateAttackers();                               
                //Wave number label
                labelWave.Text = "Wave: " + wave.ToString();
                //Fight mode
                timerFight.Enabled = true;
                timerWave.Enabled = false;
            }
        }
        /// <summary>
        /// Upgrade Wall level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResourcesWallUpgrade_Click(object sender, EventArgs e)
        {
            if (numberResourcesRock >= COST_UPGRADE_WALL_IN_ROCK * levelResourcesWall)                
            {
                //payment
                numberResourcesRock -= COST_UPGRADE_WALL_IN_ROCK * levelResourcesWall;                
                //upgrade wall resources level
                levelResourcesWall++;
                //refresh level Resources
                RefreshLevelResources();
                //refresh number Resources 
                RefreshNumbers();
                //refresh costs
                RefreshCosts();
            }
        }
        /// <summary>
        /// Play or pause -game time 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            //game was running
            if (play)
            {
                //game pause
                play = false;
                buttonPlayPause.Text = "Play";
                //timers stop
                timerNaturalResourcesGrowth.Stop();
                timerHumanResourcesGrowth.Stop();
                timerWave.Stop();
                timerFight.Stop();
            }
            //game was paused
            else
            {
                //game return
                play = true;
                buttonPlayPause.Text = "Pause";
                //timers start
                timerNaturalResourcesGrowth.Start();
                timerHumanResourcesGrowth.Start();
                timerWave.Start();
                timerFight.Start();
            }
        }
        /// <summary>
        /// Createor of DefSwordman
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDefSwordmen_Click(object sender, EventArgs e)
        {
            if (numberResourcesIron >= COST_CREATE_SWORDMAN_IN_IRON &&
                numberResourcesFood >= COST_CREATE_SWORDMAN_IN_FOOD &&
                numberResourcesVillagers >= 1)
            {
                //payment
                numberResourcesIron -= COST_CREATE_SWORDMAN_IN_IRON;
                numberResourcesFood -= COST_CREATE_SWORDMAN_IN_FOOD;
                numberResourcesVillagers--;
                //add new Swordman
                def_list.Add(new Swordman(true));
                //refresh number Resources 
                RefreshNumbers();
            }
        }
        /// <summary>
        /// Creator of DefArcher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDefArchers_Click(object sender, EventArgs e)
        {
            if (numberResourcesWood >= COST_CREATE_ARCHER_IN_WOOD &&
                numberResourcesFood >= COST_CREATE_ARCHER_IN_FOOD &&
                numberResourcesVillagers >= 1)
            {
                //payment
                numberResourcesWood -= COST_CREATE_ARCHER_IN_WOOD;
                numberResourcesFood -= COST_CREATE_ARCHER_IN_FOOD;
                numberResourcesVillagers--;
                //add new archer
                def_list.Add(new Archer(true));
                //refresh number Resources 
                RefreshNumbers();
            }
        }
        /// <summary>
        /// Creator of DefCatapult
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDefCatapults_Click(object sender, EventArgs e)
        {
            if (numberResourcesWood >= COST_CREATE_CATAPULT_IN_WOOD &&
                numberResourcesRock >= COST_CREATE_CATAPULT_IN_ROCK)               
            {
                //payment
                numberResourcesWood -= COST_CREATE_CATAPULT_IN_WOOD;
                numberResourcesRock -= COST_CREATE_CATAPULT_IN_ROCK;            
                //add new catapult
                def_list.Add(new Catapult());
                //refresh number Resources 
                RefreshNumbers();
            }
        }
        /// <summary>
        /// Creator of DefRepairer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDefRepairers_Click(object sender, EventArgs e)
        {
            if (numberResourcesIron >= COST_CREATE_REPAIRER_IN_IRON &&
                numberResourcesFood >= COST_CREATE_REPAIRER_IN_FOOD&&
                numberResourcesVillagers>=1)
            {
                //payment
                numberResourcesIron -= COST_CREATE_REPAIRER_IN_IRON;
                numberResourcesFood -= COST_CREATE_REPAIRER_IN_FOOD;
                numberResourcesVillagers--;
                //add new repairer
                def_list.Add(new Repairer());
                //refresh number Resources 
                RefreshNumbers();
            }
        }
        /// <summary>
        /// creator of DefHealer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDefHealers_Click(object sender, EventArgs e)
        {
            if (numberResourcesFood >= COST_CREATE_HEALER_IN_FOOD &&
                numberResourcesVillagers >= 5)
            {
                //payment              
                numberResourcesFood -= COST_CREATE_HEALER_IN_FOOD;
                numberResourcesVillagers-=5;
                //add new healer
                def_list.Add(new Healer());
                //refresh number Resources 
                RefreshNumbers();
            }
        }
        /// <summary>
        /// Creator of DefPikeman
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDefPikemen_Click(object sender, EventArgs e)
        {
            if (numberResourcesWood >= COST_CREATE_PIKEMAN_IN_WOOD &&
                numberResourcesFood >= COST_CREATE_PIKEMAN_IN_FOOD &&
                numberResourcesVillagers >= 1)
            {
                //payment
                numberResourcesWood -= COST_CREATE_PIKEMAN_IN_WOOD;
                numberResourcesFood -= COST_CREATE_PIKEMAN_IN_FOOD;
                numberResourcesVillagers--;
                //add new pikeman
                def_list.Add(new Pikeman(true));
                //refresh number Resources 
                RefreshNumbers();
            }
        }
        /// <summary>
        /// Display information about game 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instrukcja w pliku tekstowym -instrukcja");
        }

    }
}
