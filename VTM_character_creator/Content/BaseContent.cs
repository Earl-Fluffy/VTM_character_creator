using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTM_character_creator.Content.Advantages;
using VTM_character_creator.Content.PlayerSpecs;
using VTM_character_creator.Content.Vampire;

namespace VTM_character_creator.Content
{
    class BaseContent
    {
        private Dictionary<string, Clan> clans;
        private Dictionary<string, Discipline> disciplines;
        private Dictionary<string, AdvantageCategory> advantages;

        private Dictionary<string, PlayerSpecs.Attribute> attributes;
        private Dictionary<string, Skill> skills;
        private Dictionary<string, DisciplineFamily> disciplineTypes;
        private Dictionary<string, PredatorType> predatorTypes;
        private Dictionary<string, CharacterCreation> characterCreations;

        public BaseContent(string fileLocation)
        {
            attributes = new Dictionary<string, PlayerSpecs.Attribute>();
            skills = new Dictionary<string, Skill>();
            disciplineTypes = new Dictionary<string, DisciplineFamily>();
            clans = new Dictionary<string, Clan>();
            disciplines = new Dictionary<string, Discipline>();
            advantages = new Dictionary<string, AdvantageCategory>();
            characterCreations = new Dictionary<string, CharacterCreation>();
            predatorTypes = new Dictionary<string, PredatorType>();

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
                bool advantageUnique = advantage["Unique"].ToString() == "1";
                string advantageDescription = advantage["Description"].ToString();
                LinkedList<Advantage> advantageChoice = new LinkedList<Advantage>();
                LinkedList<Advantage> advantageSubChoice = new LinkedList<Advantage>();

                foreach(JObject choice in advantage["Choice"])
                {
                    string choiceName = choice["Name"].ToString();
                    uint choiceCost = Convert.ToUInt32(choice["Cost"].ToString());
                    string choiceDescription = choice["Description"].ToString();
                    bool choicePositive = true;
                    if (choice.ContainsKey("Positive"))
                    {
                        choicePositive = choice["Positive"].ToString() == "1";
                    }
                    advantageChoice.AddLast(new Advantage(choiceName, choiceDescription, choiceCost, choicePositive));
                }
                foreach(JObject subChoice in advantage["SubChoices"])
                {
                    string choiceName = subChoice["Name"].ToString();
                    uint choiceCost = Convert.ToUInt32(subChoice["Cost"].ToString());
                    string choiceDescription = subChoice["Description"].ToString();
                    bool choicePositive = true;
                    if (subChoice.ContainsKey("Positive"))
                    {
                        choicePositive = subChoice["Positive"].ToString() == "1";
                    }
                    advantageSubChoice.AddLast(new Advantage(choiceName, choiceDescription, choiceCost, choicePositive));
                }
                advantages.Add(advantageName, new AdvantageCategory(advantageName, advantageDescription, advantageUnique,advantageChoice,advantageSubChoice));
            }

            JArray loadedPredatorTypes = (JArray)parsedJson["PredatorTypes"];
            foreach(JObject predatorType in loadedPredatorTypes)
            {
                string predatorTypeName = predatorType["Name"].ToString();
                string predatorTypeDescription = predatorType["Description"].ToString();
                LinkedList<LinkedList<(Skill, string)>> predatorTypeBonusSpecialities = new LinkedList<LinkedList<(Skill,string)>>();
                LinkedList<LinkedList<(DisciplineFamily, Clan)>> predatorTypeBonusDisciplineLevel = new LinkedList<LinkedList<(DisciplineFamily, Clan)>>();
                LinkedList<(uint, LinkedList<(AdvantageCategory, Advantage, string)>)> predatorTypeBonusFlaws= new LinkedList<(uint, LinkedList<(AdvantageCategory, Advantage, string)>)>();
                LinkedList<(uint, LinkedList<(AdvantageCategory, Advantage, string)>)> predatorTypeBonusAdvantages = new LinkedList<(uint, LinkedList<(AdvantageCategory, Advantage, string)>)>();
                int predatorTypeBonusHumanity = 0;
                int predatorTypeBonusPotency = 0;

                if (predatorType.ContainsKey("BonusSpecialities"))
                {
                    foreach(JArray bonusSpecialities in predatorType["BonusSpecialities"])
                    {
                        LinkedList<(Skill, string)> specialityChoice = new LinkedList<(Skill, string)>();
                        foreach(JObject choice in bonusSpecialities)
                        {
                            specialityChoice.AddLast((skills[choice["Skill"].ToString()], choice["Name"].ToString()));
                        }
                        predatorTypeBonusSpecialities.AddLast(specialityChoice);
                    }
                }
                if (predatorType.ContainsKey("BonusDiscipline"))
                {
                    foreach(JArray bonusDisciplines in predatorType["BonusDiscipline"])
                    {
                        LinkedList<(DisciplineFamily, Clan)> disciplineChoice = new LinkedList<(DisciplineFamily, Clan)>();
                        foreach(JObject choice in bonusDisciplines)
                        {
                            DisciplineFamily choiceName = disciplineTypes[ choice["Name"].ToString()];
                            Clan choiceRequiredClan = null;
                            if (choice.ContainsKey("RequiredClan"))
                            {
                                choiceRequiredClan = clans[choice["RequiredClan"].ToString()];
                            }
                            disciplineChoice.AddLast((choiceName, choiceRequiredClan));
                        }
                        predatorTypeBonusDisciplineLevel.AddLast(disciplineChoice);
                    }
                }
                if (predatorType.ContainsKey("Humanity"))
                {
                    predatorTypeBonusHumanity = Convert.ToInt32(predatorType["Humanity"].ToString());
                }
                if (predatorType.ContainsKey("Potency"))
                {
                    predatorTypeBonusPotency = Convert.ToInt32(predatorType["Potency"].ToString());
                }
                if (predatorType.ContainsKey("BonusAdvantages"))
                {
                    foreach(JObject advantageChoice in predatorType["BonusAdvantages"])
                    {
                        uint cost = Convert.ToUInt32(advantageChoice["Cost"].ToString());
                        LinkedList<(AdvantageCategory, Advantage, string)> advantagesToAdd = new LinkedList<(AdvantageCategory, Advantage, string)>();
                        foreach(JObject advantage in advantageChoice["Advantages"])
                        {
                            AdvantageCategory advantageCategory = advantages[advantage["Category"].ToString()];
                            advantagesToAdd.AddLast((advantageCategory, advantageCategory.GetChoiceFromString(advantage["Advantage"].ToString()), advantage["Addition"].ToString()));
                        }
                        predatorTypeBonusAdvantages.AddLast((cost, advantagesToAdd));
                    }
                }
                if (predatorType.ContainsKey("BonusFlaws"))
                {
                    foreach (JObject advantageChoice in predatorType["BonusFlaws"])
                    {
                        uint cost = Convert.ToUInt32(advantageChoice["Cost"].ToString());
                        LinkedList<(AdvantageCategory, Advantage, string)> advantagesToAdd = new LinkedList<(AdvantageCategory, Advantage, string)>();
                        foreach (JObject advantage in advantageChoice["Advantages"])
                        {
                            AdvantageCategory advantageCategory = advantages[advantage["Category"].ToString()];
                            advantagesToAdd.AddLast((advantageCategory, advantageCategory.GetChoiceFromString(advantage["Advantage"].ToString()), advantage["Addition"].ToString()));
                        }
                        predatorTypeBonusFlaws.AddLast((cost, advantagesToAdd));
                    }
                }

                predatorTypes.Add(predatorTypeName, new PredatorType(predatorTypeBonusSpecialities, predatorTypeBonusDisciplineLevel, predatorTypeBonusFlaws, predatorTypeBonusAdvantages, predatorTypeName, predatorTypeDescription, predatorTypeBonusHumanity, predatorTypeBonusPotency));
            }
        }
    }
}
