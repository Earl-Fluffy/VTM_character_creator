using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTM_character_creator.Content.PlayerSpecs;
using VTM_character_creator.Content.Vampire;

namespace VTM_character_creator.Content
{
    class BaseContent
    {
        private Dictionary<string, Clan> clans;
        private Dictionary<string, Discipline> disciplines;
        private Dictionary<string, Advantage> advantages;

        private Dictionary<string, PlayerSpecs.Attribute> attributes;
        private Dictionary<string, Skill> skills;
        private Dictionary<string, DisciplineFamily> disciplineTypes;

        private Dictionary<string, CharacterCreation> characterCreations;

        public BaseContent(string fileLocation)
        {
            attributes = new Dictionary<string, PlayerSpecs.Attribute>();
            skills = new Dictionary<string, Skill>();
            disciplineTypes = new Dictionary<string, DisciplineFamily>();
            clans = new Dictionary<string, Clan>();
            disciplines = new Dictionary<string, Discipline>();
            advantages = new Dictionary<string, Advantage>();
            characterCreations = new Dictionary<string, CharacterCreation>();
            string json = System.IO.File.ReadAllText(fileLocation);
            JObject parsedJson = JObject.Parse(json);
            
            foreach(var o in parsedJson)
            {
                Console.WriteLine(o);
            }


            //example attributes
            attributes.Add("Strength", new PlayerSpecs.Attribute("Strength", "force", 5));
            attributes.Add("Dexterity", new PlayerSpecs.Attribute("Dexterity", "dex", 5));
            attributes.Add("Stamina", new PlayerSpecs.Attribute("Stamina", "endurance", 5));

            //example skills
            skills.Add("Athletics", new Skill("Athletics", "ability to run", 5));
            skills.Add("Stealth", new Skill("Stealth", "ability to hide", 5));
            skills.Add("Firearms", new Skill("Firearms", "ability to fire", 5));

            //example discplineTypes
            disciplineTypes.Add("Potence", new DisciplineFamily("Potence", "pure power", 5));
            disciplineTypes.Add("Presence", new DisciplineFamily("Presence", "allure", 5));
            disciplineTypes.Add("Protean", new DisciplineFamily("Protean", "Transformations", 5));

            //example clan
            clans.Add("TestClan", new Clan("TestClan", new LinkedList<DisciplineFamily>(new DisciplineFamily[] { disciplineTypes["Potence"], disciplineTypes["Presence"] }), new BaneCompulsion("bane descr","compulsion descr")));


            //example disciplines
            disciplines.Add("Daunt", new Discipline(disciplineTypes["Presence"], "Daunt", "fluff text", "euh be daunting", 1, new Dice.Roll(attributes["Strength"], skills["Athletics"]), null));

            //example advantages
            advantages.Add("Stunning", new Advantage("Stunning",4,true,new LinkedList<Advantage>(),null,"be stunning"));
        }
    }
}
