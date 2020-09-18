using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGOTool
{
    class Servant
    {
        //private members of the servant class
        private String ServantName; //name of the servant
        private int ServantStars;   //number of stars of the servant
        private Dictionary<String, int> ServantStats;    //dictionary for storing the stats of a servant
        private Dictionary<String, int> ServantAscMats; //dictionary for storing the number of ascention materials a servant needs
        private Dictionary<String, int> ServantSkillMats;   //dictionary for storing the number of skill materials a servant needs
        private List<int> BondPoints;   //number of bond points per bond level of the servant

        //public class for initializing a new servant
        public Servant(String name)
        {
            this.ServantName = name;    //will have to change once I implement how names are input
            this.ServantStars = 0;
            this.ServantStats = new Dictionary<String, int>();
            this.ServantAscMats = new Dictionary<String, int>();
            this.ServantSkillMats = new Dictionary<String, int>();
            this.BondPoints = new List<int>();
        }

        //public method for initializing a servant from database
        public Servant(String name, int stars, Dictionary<String, int> stats, Dictionary<String, int> ascMats, Dictionary<String, int> skillMats, List<int> bond)
        {
            this.ServantName = name;
            this.ServantStars = stars;
            this.ServantStats = stats;
            this.ServantAscMats = ascMats;
            this.ServantSkillMats = skillMats;
            this.BondPoints = bond;
        }

        //public method to get the name of a servant
        public String getName()
        {
            return this.ServantName;
        }

        //public method to return the stats of a servant
        public Dictionary<String, int> getStats()
        {
            Dictionary<String, int> result = this.ServantStats;  //make a copy of the servant stats and return that
            return result;
        }

        //public method to return the ascention materials of a servant
        public Dictionary<String, int> getAscMats()
        {
            Dictionary<String, int> result = this.ServantAscMats;
            return result;
        }

        //public method to return the skill materials of a servant
        public Dictionary<String, int> getSkillMats()
        {
            Dictionary<String, int> result = this.ServantSkillMats;
            return result;
        }

        //private method that will populate the dictionaries of a servant if the servant is being initialized by name and not from user
        private void getServantData()
        {
            //to be implemtned when I decide if I want to store all data of all servants in an sql server, or grab the information from gamepress.gg
        }

        //public method override to return a string representation of a servant for storing in the user profile
        public override string ToString()
        {
            //to be completed once string representation is decided on
            return base.ToString(); //placeholder
        }
    }
}
