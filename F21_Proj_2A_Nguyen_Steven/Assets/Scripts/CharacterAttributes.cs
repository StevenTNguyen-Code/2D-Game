using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttributes : MonoBehaviour
{
    protected class CharacterInfo
    {
        public string Name;
        public float Strength;
        public float Constitution;
        public float Dexterity;
        public float Intelligence;
        public float Charisma;
        public float Wisdom;
        public string Race;
        public string Class;
        public string Alignment;
        public int CurrentEXP;
        public int MaxEXP;
        public int CurrentHP;
        public int MaxHP;
        public int Armor;
        public int Walking;
        public int Running;
        public int JumpHeight;

        public bool easyMode;
        public bool mediumMode;
        public bool hardMode; 
         
        public List<string> items = new List<string>() { }; 


    }

    
}
