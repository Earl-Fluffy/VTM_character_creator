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
            if (!System.IO.File.Exists(fileLocation))
            {
                return;//If file does not exist, stop creating
            }
            string json = System.IO.File.ReadAllText(fileLocation);
            JObject parsedJson = JObject.Parse(json);
            

            JArray loadedAttributes = (JArray)parsedJson["Attributes"];
            foreach(JObject attribute in loadedAttributes)
            {
                string attributeName = attribute["Name"].ToString();
                string attributeDescription = attribute["Description"].ToString();
                uint attributeMaxLevel = Convert.ToUInt32(attribute["MaxLevel"].ToString());
                attributes.Add(attributeName, new PlayerSpecs.Attribute(attributeName, attributeDescription, attributeMaxLevel));
            }


            JArray loadedSkills = (JArray)parsedJson["Skills"];
            foreach (JObject skill in loadedSkills)
            {
                string attributeName = skill["Name"].ToString();
                string attributeDescription = skill["Description"].ToString();
                uint attributeMaxLevel = Convert.ToUInt32(skill["MaxLevel"].ToString());
                bool attributeSeciality = false;
                if (skill.ContainsKey("FreeSpeciality") && skill["FreeSpeciality"].ToString() == "1")
                {
                    attributeSeciality = true;
                }
                skills.Add(attributeName, new PlayerSpecs.Skill(attributeName, attributeDescription, attributeMaxLevel,attributeSeciality));
            }

            JArray loadedDisciplineTypes = (JArray)parsedJson["DisciplineTypes"];
            foreach (JObject disciplineType in loadedDisciplineTypes)
            {
                string attributeName = disciplineType["Name"].ToString();
                string attributeDescription = disciplineType["Description"].ToString();
                uint attributeMaxLevel = Convert.ToUInt32(disciplineType["MaxLevel"].ToString());
                disciplineTypes.Add(attributeName, new PlayerSpecs.DisciplineFamily(attributeName, attributeDescription, attributeMaxLevel));
            }

            JArray loadedClans = (JArray)parsedJson["Clans"];
            foreach (JObject clan in loadedClans)
            {
                string clanName = clan["Name"].ToString();
                LinkedList<DisciplineFamily> clanDisciplines = new LinkedList<DisciplineFamily>();
                foreach(string discipline in clan["Disciplines"])
                {
                    clanDisciplines.AddLast(disciplineTypes[discipline]);
                }
                string clanBane = clan["Bane"].ToString();
                string clanCompulsion = clan["Compulsion"].ToString();
                clans.Add(clanName, new Clan(clanName, clanDisciplines, new BaneCompulsion(clanBane, clanCompulsion)));
            }

            JArray loadedDisciplines = (JArray)parsedJson["Disciplines"];
            foreach (JObject discipline in loadedDisciplines)
            {
                string disciplineName = discipline["Name"].ToString();
                string disciplineType = discipline["DisciplineType"].ToString();
                string disciplineFluff = discipline["FluffText"].ToString();
                string disciplineSystem = discipline["System"].ToString();
                uint disciplineLevel = Convert.ToUInt32(discipline["Level"].ToString());
                uint disciplineCost = Convert.ToUInt32(discipline["Cost"].ToString());
                string disciplineDuration = discipline["Duration"].ToString();

                Dice.Roll playerRoll = null;
                Dice.Roll opposingRoll = null;

                if (discipline.ContainsKey("PlayerRoll"))
                {
                    LinkedList<string> specs = new LinkedList<string>();
                    foreach(string spec in discipline["PlayerRoll"])
                    {
                        specs.AddLast(spec);
                    }
                    if(specs.Count() == 2)
                    {
                        playerRoll = new Dice.Roll(specs.First(), specs.Last());
                    }
                }
                if (discipline.ContainsKey("OpposingRoll"))
                {
                    LinkedList<string> specs = new LinkedList<string>();
                    foreach (string spec in discipline["OpposingRoll"])
                    {
                        specs.AddLast(spec);
                    }
                    if (specs.Count() == 2)
                    {
                        opposingRoll = new Dice.Roll(specs.First(), specs.Last());
                    }
                }
                disciplines.Add(disciplineName, new Discipline(disciplineTypes[disciplineType], disciplineName, disciplineFluff, disciplineSystem, disciplineLevel, playerRoll, opposingRoll, disciplineCost, disciplineDuration));
            }

            JArray loadedAdvantages = (JArray)parsedJson["Advantages"];
            foreach (JObject advantage in loadedAdvantages)
            {
                string advantageName = advantage["Name"].ToString();
                uint advantageCost = Convert.ToUInt32(advantage["Cost"].ToString());
                string advantageCategory = advantage["Category"].ToString();
                string advantageDescription = advantage["Description"].ToString();
                advantages.Add(advantageName, new Advantage(advantageName, advantageCost, true, null, advantageCategory, advantageDescription));
            }
        }
    }
}
