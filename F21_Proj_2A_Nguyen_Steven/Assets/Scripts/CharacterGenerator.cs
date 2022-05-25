using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;
using System.Globalization;
using Random = System.Random;
using UnityEngine.EventSystems;
using System.Collections; 

public class CharacterGenerator : CharacterAttributes, IPointerDownHandler, IPointerUpHandler
{
    public Text JumpingHeightOutput;
    public Text WalkingOutput;
    public Text RunningOutput;

    public Text JsonOutput; 

    //Lists for our Races and Classes. 
    List<string> charList = new List<string>() { "Select Character", "Dragonborn", "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human", "Tiefling" };
    List<string> charListdesc = new List<string>() {
        "Character Description",
        "Your draconic heritage manifests in a variety of traits you share with other dragonborn.",
        "Your dwarf character has an assortment of in abilities, part and parcel of dwarven nature.",
        "Your elf character has a variety of natural abilities, the result of thousands of years of elven refinement.",
        "Your gnome character has certain characteristics in common with all other gnomes.",
        "Your half-elf character has some qualities in common with elves and some that are unique to half-elves.",
        "Your half-orc character has certain traits deriving from your orc ancestry.",
        "Your halfling character has a number of traits in common with all other halflings.",
        "It's hard to make generalizations about humans, but your human character has these traits.",
        "Tieflings share certain racial traits as a result of their infernal descent." };
    List<string> classList = new List<string>() { "Select Class", "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
    List<string> classListdesc = new List<string>() {
        "Class Description",
        "In battle, you fight with primal ferocity. For some barbarians, rage is a means to an end�that end being violence.",
        "Whether singing folk ballads in taverns or elaborate compositions in royal courts, bards use their gifts to hold audiences spellbound.",
        "Clerics act as conduits of divine power.",
        "Druids venerate the forces of nature themselves. Druids holds certain plants and animals to be sacred, and most druids are devoted to one of the many nature deities",
        "Different fighters choose different approaches to perfecting their fighting prowess, but they all end up perfecting it.",
        "Coming from monasteries, monks are masters of martial arts combat and meditators with the ki living forces.",
        "Paladins are the ideal of the knight in shining armor; they uphold ideals of justice, virtue, and order and use righteous might to meet their ends.",
        "Acting as a bulwark between civilization and the terrors of the wilderness, rangers study, track, and hunt their favored enemies.",
        "Rogues have many features in common, including their emphasis on perfecting their skills, their precise and deadly approach to combat, and their increasingly quick reflexes.",
        "An event in your past, or in the life of a parent or ancestor, left an indelible mark on you, infusing you with arcane magic. As a sorcerer the power of your magic relies on your ability to project your will into the world.",
        "You struck a bargain with an otherworldly being of your choice: the Archfey, the Fiend, or the Great Old One who has imbued you with mystical powers, granted you knowledge of occult lore, bestowed arcane research and magic on you and thus has given you facility with spells",
        "The study of wizardry is ancient, stretching back to the earliest mortal discoveries of magic. As a student of arcane magic, you have a spellbook containing spells that show glimmerings of your true power which is a catalyst for your mastery over certain spells."};
    

    

    public TMP_Dropdown dropDownClass; //Good
    public TextMeshProUGUI classDescription; //Good

    public TMP_Dropdown dropDownRace; //Good
    public TextMeshProUGUI raceDescription;  //Good

    public TextMeshProUGUI totalAvgDie; //Good

    

    CharacterInfo CA = new CharacterInfo(); //Object to help us reference the Character Attributes and set their values. //Good

    Random rand = new Random(); //Good


   


    //Used to help create our lists. 
    void Start()
    {
        PopulateList();
    }

    //populates the dropdown list
    void PopulateList()
    {

        JumpingHeightOutput = GameObject.Find("JumpingHeightValue").GetComponent<Text>();
        WalkingOutput = GameObject.Find("WalkingValue").GetComponent<Text>();
        RunningOutput = GameObject.Find("RunningValue").GetComponent<Text>();
        JsonOutput = GameObject.Find("TextforJson").GetComponent<Text>(); 

        dropDownRace.AddOptions(charList);
        dropDownClass.AddOptions(classList);
        

    }

  

    //Helps the user develop a Character Name. 
    public void nameChooser(string playerName)
    {
        CA.Name = playerName;

        if(CA.Name.Length != 0) //If the name is set, then it's true for Singleton for Playing the game. 
        {
            DataRetriever.Instance.SName = true; 
            
        }
        if(CA.Name.Length == 0) 
        {
            Destroy(gameObject); 
        }  
        //Debug.Log("charName = " + CA.Name);
    }

    //To help determine the Strength Ability. 
    public void StrengthChanged(string values)
    {
        
        CA.Strength = float.Parse(values) + 2;

        if(CA.Strength != 0.0)
        {
            DataRetriever.Instance.SStrength = true; 
            //Debug.Log(DataRetriever.Instance.SStrength); 
        }
        if(CA.Strength == 0.0)
        {
            Destroy(gameObject); 
        } 

        //Debug.Log("ability_Strength = " + CA.Strength);
    }

    //To help determine the Dexterity Ability.
    public void DexterityChanged(string values)
    {
        CA.Dexterity = float.Parse(values) + 2;

        if(CA.Dexterity != 0.0)
        {
            DataRetriever.Instance.SDexterity = true; 
        }
        if(CA.Dexterity == 0.0)
        {
            Destroy(gameObject); 
        }
        //Debug.Log("ability_Dexterity = " + CA.Dexterity);
    }

    //To help determine the Constitution Ability. 
    public void ConstitutionChanged(string values)
    {
        CA.Constitution = float.Parse(values) + 2;

        if(CA.Constitution != 0.0)
        {
            DataRetriever.Instance.SConstitution = true; 
        }
        if(CA.Constitution == 0.0)
        {
            Destroy(gameObject); 
        }
        //Debug.Log("ability_Constitution = " + CA.Constitution);
    }

    //To help determine the Intelligence Ability.
    public void IntelligenceChanged(string values)
    {
        CA.Intelligence = float.Parse(values) + 2;

        if(CA.Intelligence != 0.0)
        {
            DataRetriever.Instance.SIntelligence = true; 
        }
        if(CA.Intelligence == 0.0)
        {
            Destroy(gameObject); 
        }
        //Debug.Log("ability_Intelligence = " + CA.Intelligence);
    }

    //To help determine the Wisdom Ability
    public void WisdomChanged(string values)
    {
        CA.Wisdom = float.Parse(values) + 2;

        if(CA.Wisdom != 0.0)
        {
            DataRetriever.Instance.SWisdom = true; 
        }
        if(CA.Wisdom == 0.0)
        {
            Destroy(gameObject); 
        }
        //Debug.Log("ability_Wisdom = " + CA.Wisdom);
    }

    //To help determine the Charisma Ability.  
    public void CharismaChanged(string values)
    {
        CA.Charisma = float.Parse(values) + 2;

        if(CA.Charisma != 0.0)
        {
            DataRetriever.Instance.SCharisma = true; 
        }
        if(CA.Charisma == 0.0)
        {
            Destroy(gameObject); 
        }
        //Debug.Log("ability_Charisma = " + CA.Charisma);
    }

    //Used to help us show the user the Races and their descriptions. 
    public void DropdownRaceDesc(int indexes)
    {
        raceDescription.text = charListdesc[indexes];
        if (indexes > 0)
        {
            CA.Race = charList[indexes];
        }

        //Debug.Log("charRace = " + CA.Race);
    }

    //Used to help us show the user the Classes and their descriptions.
    public void DropdownClassDesc(int indexes)
    {
        classDescription.text = classListdesc[indexes];
        if (indexes > 0)
        {
            CA.Class = classList[indexes];
        }
        //Debug.Log("charClass = " + CA.Class);


    }

    //Used to help determine what the Alignment Value is. 
    public void assignAlignment(string value)
    {
        CA.Alignment = value;

        /* if(CA.Alignment.Length != 0)
        {
            DataRetriever.Instance.SAlignment = true; 
            
        }
        if(CA.Alignment.Length == 0)
        {
            Destroy(gameObject); 
        }  */

    } 


    //Used to help determine the current Experience Points. 
    public void ExperiencePointsCurrentChanged(string value)
    {
        CA.CurrentEXP = int.Parse(value);

        /*if(CA.CurrentEXP != 0)
        {
            DataRetriever.Instance.SCurrentEXP = true; 
        }
        if(CA.CurrentEXP == 0)
        {
            Destroy(gameObject); 
        } */
        //Debug.Log("expCurrent = " + CA.CurrentEXP);
    }

    //Used to help determine the max Experience Points.
    public void ExperiencePointsMaxChanged(string value)
    {
        CA.MaxEXP = int.Parse(value);

        /*if(CA.MaxEXP != 0)
        {
            DataRetriever.Instance.SMaxEXP = true; 
        }
        if(CA.MaxEXP == 0)
        {
            Destroy(gameObject); 
        } */
        //Debug.Log("expMax = " + CA.MaxEXP);
    }

    //Used to help determine the current Hit Points. 
    public void HitPointsCurrentChanged(string value)
    {
        CA.CurrentHP = int.Parse(value);

        /*if(CA.CurrentHP != 0)
        {
            DataRetriever.Instance.SCurrentHP = true; 
        }
        if(CA.CurrentHP == 0)
        {
            Destroy(gameObject); 
        } */


        
        //Debug.Log("hpCurrent = " + CA.CurrentHP);
    }

    //Used to help determine the max Hit Points.
    public void HitPointsMaxChanged(string value)
    {
        CA.MaxHP = int.Parse(value);

        /*if(CA.MaxHP != 0)
        {
            DataRetriever.Instance.SMaxHP = true; 
        }
        if(CA.MaxHP == 0)
        {
            Destroy(gameObject); 
        } */
        //Debug.Log("hpMax = " + CA.MaxHP);
    }

    //Used to determine the Armor value. 
    public void ArmorClassChanged(string value)
    {
        int intversionofarmor = int.Parse(value);

        if(intversionofarmor >=1 && intversionofarmor <=100)
        {
            CA.Armor = int.Parse(value);
        }

        
        //Debug.Log("armorClass = " + CA.Armor);
    }

    //Used to determine the Walking Speed. 
    public void SpeedWalkingChanged(float walkingSpeed)
    {

        string stringversionofvalue = walkingSpeed.ToString(); //String version of the value. 
        
        WalkingOutput.text = stringversionofvalue;
    
        CA.Walking = (int)walkingSpeed;

        //Debug.Log("sWalking = " + CA.Walking);
    }

    //Used to determine the Running Speed. 
    public void SpeedRunningChanged(float runningSpeed)
    {

        string stringversionofvalue = runningSpeed.ToString(); //String version of the value. 

        RunningOutput.text = stringversionofvalue;

        CA.Running = (int)runningSpeed;

        //Debug.Log("sRunning = " + CA.Running);
    }

    //Used to determine the Jumping Height.
    public void SpeedJumpChanged(float jumpingSpeed)
    {
        string stringversionofvalue = jumpingSpeed.ToString(); //String version of the value. 

        JumpingHeightOutput.text = stringversionofvalue;

        CA.JumpHeight = (int)jumpingSpeed;

        //Debug.Log("sJumpHeight = " + CA.JumpHeight);


    }

    public void OnPointerDown(PointerEventData eventdata)
    {
        DataRetriever.Instance.easyModeButton = true; 
    }
    public void OnPointerUp(PointerEventData eventdata)
    {
        DataRetriever.Instance.easyModeButton = false;  
    }


    //Dice Rolling
    public void DiceRoller()
    {
        int randomnumberholder; //For random numbers. 
        int firstnumber;
        int secondnumber; 
        int thirdnumber;
        firstnumber = secondnumber = thirdnumber = 000;
        int[] arr = new int[5]; //Create an array of 5 spots for 5 rolls. 
        int total = 0;

        //Used to fill up our Array to then later find our 3 values. 
        for (int i = 0; i < 5; i++)
        {
            randomnumberholder = rand.Next(0, 9);
            arr[i] = randomnumberholder;
            //Debug.Log(arr[i]);
        }

        //Find our 3 values. 
        for (int i = 0; i < 5; i++)
        {
            if (arr[i] > firstnumber)
            {
                thirdnumber = secondnumber;
                secondnumber = firstnumber;
                firstnumber = arr[i];
            }
            else if (arr[i] > secondnumber)
            {
                thirdnumber = secondnumber;
                secondnumber = arr[i];
            }
            else if (arr[i] > thirdnumber)
            {
                thirdnumber = arr[i];
            }
        }
        total = firstnumber + secondnumber + thirdnumber;
        totalAvgDie.text = total.ToString();
        //Debug.Log("totalAvgDie = " + totalAvgDie.text);
    }

    public void ExitButton()
    {
        Application.Quit(); 


    }

    //Used to create the Json for our UI
    public void Json()
    {
        string json = JsonUtility.ToJson(CA);
        JsonOutput.text = json; 

        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
        Debug.Log(Application.dataPath);

    }

    public void JsonCopy()
    {
        TextEditor jsonoutput = new TextEditor();
        jsonoutput.text = JsonOutput.text;
        jsonoutput.SelectAll();
        jsonoutput.Copy();

    }

}