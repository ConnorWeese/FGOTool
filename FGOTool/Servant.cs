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
        private Dictionary<String, String> ServantStats;    //dictionary for storing the stats of a servant
        private Dictionary<String, int> ServantAscMats; //dictionary for storing the number of ascention materials a servant needs
        private Dictionary<String, int> ServantSkillMats;   //dictionary for storing the number of skill materials a servant needs

        //public class for initializing a new servant
        public Servant(String name)
        {
            this.ServantName = name;    //will have to change once I implement how names are input
            this.ServantStats = new Dictionary<String, String>();
            this.ServantAscMats = new Dictionary<String, int>();
            this.ServantSkillMats = new Dictionary<String, int>();
        }

        //public method for initializing a servant from a user's profile
        public Servant(String[] info)
        {
            //to be filled once class User is completed and how to store servant info is decided
        }

        //public method to get the name of a servant
        public String getName()
        {
            return this.ServantName;
        }

        //public method to return the stats of a servant
        public Dictionary<String, String> getStats()
        {
            Dictionary<String, String> result = this.ServantStats;  //make a copy of the servant stats and return that
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
