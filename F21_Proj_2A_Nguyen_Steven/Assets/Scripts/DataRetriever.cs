using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRetriever : MonoBehaviour
{
    //All of these attributes were taken from my CharacterAttributes but was turned into booleans for the Singleton Pattern. 
        public bool SName = false;
        public bool SStrength = false;
        public bool SConstitution = false;
        public bool SDexterity = false;
        public bool SIntelligence = false;
        public bool SCharisma = false;
        public bool SWisdom = false;
        //public bool SRace = false;
        //public bool SClass = false;
        //public bool SAlignment = false;
       //public bool SCurrentEXP = false;
       // public bool SMaxEXP = false;
       // public bool SCurrentHP= false;
       // public bool SMaxHP = false;
       // public bool SArmor = false;
       // public bool SWalking = false;
       // public bool SRunning = false;
       // public bool SJumpHeight = false;
          public bool easyModeButton = false;
          public bool mediumModeButton = false;
          public bool hardModeButton = false; 

       

    public static DataRetriever Instance = null;



    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    
}
