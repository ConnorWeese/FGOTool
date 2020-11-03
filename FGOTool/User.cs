using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGOTool
{
    class User
    {
        private List<Servant> myServants;
        private Dictionary<String, int> myMaterials;

        //public method for initializing a new user
        public User()
        {
            this.myServants = new List<Servant>();
            this.myMaterials = new Dictionary<String, int>();
        }

        //public method for initializing a user from file
        public User(List<String> materials, List<String> servants)
        {
            this.myServants = new List<Servant>();  //initialize the list of servants
            this.myMaterials = new Dictionary<String, int>();   //initialize the dictionary of materials

            readMaterials(materials);   //populate the dictionary of materials from the list of strings
            
        }

        //public method for checking if a user already has a specific servant
        public bool hasServant(Servant servant)
        {
            if (this.myServants.Contains(servant))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public method for adding a servant to a users servant list
        public bool addServant(Servant servant)
        {
            if (!hasServant(servant))
            {
                this.myServants.Add(servant);   //add the new servant to the servant list

                //update the user's materials after adding a new servant with potentially new materials needed
                foreach(var mat in servant.getAscMats())
                {
                    addMaterial(mat.Key);
                }
                foreach(var mat in servant.getSkillMats())
                {
                    addMaterial(mat.Key);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        //public method for getting a servant based on a name
        public Servant getServant(String name)
        {
            foreach(Servant servant in this.myServants) //iterate over all servants in the list
            {
                if(servant.getName() == name)   //if a servant's name matches the requested name
                {
                    return servant; //return the servant
                }
            }

            return null;    //if no matching servant is found, return null
        }

        //public method for checking if a user has a certain material
        public bool hasMaterial(String material)
        {
            if (this.myMaterials.ContainsKey(material))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public method for adding a material without an ammount to users material dictionary
        public bool addMaterial(String material)
        {
            if (!hasMaterial(material))
            {
                this.myMaterials.Add(material, 0);
                return true;
            }
            else
            {
                return false;
            }
        }

        //public method for adding a material with an ammount to a users material dictionary
        public bool addMaterial(String material, int ammount)
        {
            if (!hasMaterial(material))
            {
                this.myMaterials.Add(material, ammount);
                return true;
            }
            else
            {
                return false;
            }
        }

        //public method for updating the ammount of a material in a users material dictionary
        public bool updateMaterial(String material, int ammount)
        {
            if (!hasMaterial(material))
            {
                return false;
            }
            else
            {
                this.myMaterials[material] = ammount;
                return true;
            }
        }

        //private method to populate the dictionary of materials from the given list of strings
        private void readMaterials(List<String> materials)
        {
            foreach(var mat in materials)
            {
                var items = mat.Split(':');
                this.myMaterials.Add(items[0], Int32.Parse(items[1]));
            }
        }
    }
}
