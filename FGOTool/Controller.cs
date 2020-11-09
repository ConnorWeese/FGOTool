using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace FGOTool
{
    class Controller
    {
        //public method to initialize a controller
        public Controller()
        {
            
        }

        //temporary method for getting servant data off the mongo database
        public Servant getServant(String name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("nicknames", name.ToLower()); //creates a filter for the servant name/nickname

            //create a client and subsequent variables to access the servantInfo collection
            var client = new MongoClient("mongodb+srv://generaluser:BIPUY9Wfb2gqwPwK@cluster0.kgl8p.mongodb.net/FGOTool?retryWrites=true&w=majority");
            var database = client.GetDatabase("servants");
            var collection = database.GetCollection<BsonDocument>("servantInfo");

            try
            {
                var document = collection.Find(filter).First(); //try to get the first document with that servant name

                return toServant(document); //return the servant
            }
            catch
            {
                return null;
            }
        }

        //method to convert the Bson Document into a servant
        private Servant toServant(BsonDocument document)
        {
            String servantName = "";
            int servantStars = 0;
            Dictionary<String, int> servantStats = new Dictionary<String, int>();
            Dictionary<String, int> servantAscMats = new Dictionary<String, int>();
            Dictionary<String, int> servantSkillMats = new Dictionary<String, int>();
            List<int> bondPoints = new List<int>();

            //iterate over all the elements of the document
            foreach(BsonElement element in document)
            {
                switch (element.Name)
                {
                    //servant's name
                    case "name":
                        if (element.Value.IsString) //if the value is actually a string
                        {
                            servantName = element.Value.AsString;
                        }
                        break;
                    //servant's stars
                    case "stars":
                        if (element.Value.IsInt32)  //if the value is actually an integer
                        {
                            servantStars = element.Value.AsInt32;
                        }
                        break;
                    //servant's base hp
                    case "baseHP":
                        if (element.Value.IsInt32)  //if the value is actually an integer
                        {
                            servantStats.Add("Base HP", element.Value.AsInt32);
                        }
                        break;
                    //servant's max hp
                    case "maxHP":
                        if (element.Value.IsInt32)  //if the value is actually an integer
                        {
                            servantStats.Add("Max HP", element.Value.AsInt32);
                        }
                        break;
                    //servant's grailed hp
                    case "grailHP":
                        if (element.Value.IsInt32)  //if the value is actually an integer
                        {
                            servantStats.Add("Grail HP", element.Value.AsInt32);
                        }
                        break;
                    //servant's base attack
                    case "baseATK":
                        if (element.Value.IsInt32)  //if the value is actually an integer
                        {
                            servantStats.Add("Base ATK", element.Value.AsInt32);
                        }
                        break;
                    //servant's max attack
                    case "maxATK":
                        if (element.Value.IsInt32)  //if the value is actually an integer
                        {
                            servantStats.Add("Max ATK", element.Value.AsInt32);
                        }
                        break;
                    //servant's grailed attack
                    case "grailATK":
                        if (element.Value.IsInt32)  //if the value is actually an integer
                        {
                            servantStats.Add("Grail ATK", element.Value.AsInt32);
                        }
                        break;
                    //servant's ascension mats
                    case "ascensionMats":
                        if (element.Value.IsBsonDocument)   //if the value is actually a Bson Document
                        {
                            foreach (BsonElement material in element.Value.AsBsonDocument)
                            {
                                servantAscMats.Add(material.Name, material.Value.AsInt32);
                            }
                        }
                        break;
                    //servant's skill mats
                    case "skillMats":
                        if (element.Value.IsBsonDocument)   //if the value is actually a Bson Document
                        {
                            foreach (BsonElement material in element.Value.AsBsonDocument)
                            {
                                servantSkillMats.Add(material.Name, material.Value.AsInt32);
                            }
                        }
                        break;
                    //servant's bond points for each bond level
                    case "bondPoints":
                        if (element.Value.IsBsonArray)  //if the value is actually a Bson Array
                        {
                            foreach (BsonValue point in element.Value.AsBsonArray)
                            {
                                bondPoints.Add(point.AsInt32);
                            }
                        }
                        break;
                }
            }

            return new Servant(servantName, servantStars, servantStats, servantAscMats, servantSkillMats, bondPoints);
        }

        public void addUshi()
        {
            var ushiDoc = new BsonDocument
            {
                { "name", "Ushiwakamaru"},
                { "nicknames", new BsonArray
                    {
                       "ushiwakamaru", "ushi", "ushiwaka"
                    }
                },
                { "stars", 3 },
                { "baseHP", 1628 },
                { "maxHP", 9028 },
                { "grailHP", 12240 },
                { "baseATK", 1314 },
                { "maxATK", 7076 },
                { "grailATK", 9576 },
                { "ascensionMats", new BsonDocument
                    {
                        { "QP", 1330000 } , { "Rider Piece", 12 }, { "Proof of Hero", 15 }, { "Rider Monument", 12 }, { "Meteor Horseshoe", 7 }, { "Ghost Lantern", 11 }, { "Octuplet Crystals", 8 }
                    }
                },
                { "skillMats", new BsonDocument
                    {
                        { "QP", 40800000 }, { "Gem of Rider", 36 }, { "Magic Gem of Rider", 36 }, { "Meteor Horseshoe", 33 }, { "Secret Gem of Rider", 36 }, { "Proof of Hero", 90 }, { "Eternal Gear", 48 },
                        { "Octuplet Crystals", 48 }, { "Crystallized Lore", 3 }
                    }
                },
                { "bondPoints", new BsonArray
                    {
                        2000, 3000, 4000, 5000, 6000, 190000, 208000, 252000, 310000, 360000
                    }
                }
            };

            /*var database = client.GetDatabase("servants");
            var collection = database.GetCollection<BsonDocument>("servantInfo");
            collection.InsertOne(ushiDoc);*/
        }
    }
}
