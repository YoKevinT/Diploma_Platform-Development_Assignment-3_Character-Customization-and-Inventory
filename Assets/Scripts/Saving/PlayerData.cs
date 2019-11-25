using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    public int skin;
    public int hair;
    public int mouth;
    public int eyes;
    public int armour;
    public int clothes;
    public string charName;
    public string[] statArray;
    public string[] selectedClass;

    public PlayerData(CustomisationSet customisationset)
    {
        skin = customisationset.skinIndex;
        hair = customisationset.hairIndex;
        mouth = customisationset.mouthIndex;
        eyes = customisationset.eyesIndex;
        armour = customisationset.armourIndex;
        clothes = customisationset.clothesIndex;
        charName = customisationset.charName;
        statArray = customisationset.statArray;
        selectedClass = customisationset.selectedClass;
    }
}