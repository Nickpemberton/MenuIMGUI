using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : Attributes
{
    #region Struct

    [Serializable]
    public struct StatBlock
    {
        public string name;
        public int statValue;
        public int tempStatValue;
        public int levelTempStatValue;
    }
    
    #endregion

    #region Variables

    public StatBlock[] characterStats = new StatBlock[6];
    public CharacterClass characterClass = CharacterClass.None;
    public CharacterRace characterRace = CharacterRace.None;



    #endregion

}

public enum CharacterClass
{
        None,
        Barbarian,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Sorcerer
}

public enum CharacterRace
{
    None,
    Dragonborn,
    Dwarf,
    Elf,
    HalfElf,
    Human,
    HalfOrc, 
    Halfling
}
