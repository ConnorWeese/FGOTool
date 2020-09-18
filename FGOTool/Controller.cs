using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public String getInfo()
        {
            var client = new MongoClient("mongodb+srv://generaluser:BIPUY9Wfb2gqwPwK@cluster0.kgl8p.mongodb.net/FGOTool?retryWrites=true&w=majority");
            var database = client.GetDatabase("sample_airbnb");
            var collection = database.GetCollection<BsonDocument>("listingsAndReviews");
            var document = collection.Find(new BsonDocument()).FirstOrDefault();
            return document.ToString();
        }

        public void addUshi()
        {
            var ushiDoc = new BsonDocument
            {
                { "name", "Ushiwakamaru"},
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

            var client = new MongoClient("mongodb+srv://caweese:12Daishouri@cluster0.kgl8p.mongodb.net/FGOTool?retryWrites=true&w=majority");
            var database = client.GetDatabase("servants");
            var collection = database.GetCollection<BsonDocument>("servantInfo");
            collection.InsertOne(ushiDoc);
        }
    }
}
