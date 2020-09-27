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
        private Dictionary<String, int> ServantMatCount;    //dictionary for storing the number of materials used on a servant
        private List<int> BondPoints;   //number of bond points per bond level of the servant

        //public method for initializing a servant from database
        public Servant(String name, int stars, Dictionary<String, int> stats, Dictionary<String, int> ascMats, Dictionary<String, int> skillMats, List<int> bond)
        {
            this.ServantName = name;
            this.ServantStars = stars;
            this.ServantStats = stats;
            this.ServantAscMats = ascMats;
            this.ServantSkillMats = skillMats;
            this.ServantMatCount = new Dictionary<String, int>();
            this.BondPoints = bond;
            fillMatCount(); //populate ServantMatCount
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

        //private method for populating ServantMatCount after initializing a servant
        private void fillMatCount()
        {
            foreach(String key in ServantAscMats.Keys)
            {
                if (!ServantMatCount.ContainsKey(key))
                {
                    ServantMatCount.Add(key, 0);
                }
            }
            foreach (String key in ServantSkillMats.Keys)
            {
                if (!ServantMatCount.ContainsKey(key))
                {
                    ServantMatCount.Add(key, 0);
                }
            }
        }

        //public method to update the number of materials in ServantMatCount
        public bool updateMatCount(String material, int num)
        {
            if (ServantMatCount.ContainsKey(material))
            {
                ServantMatCount[material] += num;   //add num to the existing number in ServantMatCount, this may have to change based on how the UI is implemented
                return true;
            }
            else
            {
                return false;
            }
        }

        //public method override to return a string representation of a servant for storing in the user profile
        public override string ToString()
        {
            /*      File Pattern
             * Servants
             * name,mat:count,mat:count,mat:count,...,mat:count|name,mat:count,...
             * 
             * the | will be added by user when saving to file
             */
            
            String result = getName();

            foreach(String material in ServantMatCount.Keys)
            {
                result += "," + material + ":" + ServantMatCount[material];
            }

            return result;
        }
    }
}
