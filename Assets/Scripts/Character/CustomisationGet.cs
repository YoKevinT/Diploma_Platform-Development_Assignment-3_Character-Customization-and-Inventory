using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//you will need to change Scenes
using UnityEngine.SceneManagement;
public class CustomisationGet : MonoBehaviour
{
    #region Variables
    //[Header("Character")]
    [Header("Character")]
    //public variable for the Skinned Mesh Renderer which is our character reference
    public Renderer character;
    #endregion

    #region Start
    private void Start()
    {
        //our character reference connected to the Skinned Mesh Renderer via finding the Mesh
        character = GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<SkinnedMeshRenderer>();
        //Run the function LoadTexture	
        LoadTexture();

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
    #endregion

    #region LoadTexture Function
    void LoadTexture()
    {
        PlayerData playerdata = PlayerSave.LoadData();
        SetTexture("Skin",playerdata.skin);
        SetTexture("Hair", playerdata.hair);
        SetTexture("Mouth", playerdata.mouth);
        SetTexture("Eyes", playerdata.eyes);
        SetTexture("Clothes", playerdata.clothes);
        SetTexture("Armour", playerdata.armour);
        // Get a gameComponent text that shows it up
        //playerdata.charName;
        //playerdata.selectedClass);
        //playerdata.selectedClass);
        //Bad example down
        //character.GetComponentInParent<Transform>().name = playerdata.charName;

        ///
        //check to see if our save file for this character
        //if it doesn't then load the CustomSet level
        //if it does have a save file then load and SetTexture Skin, Hair, Mouth and Eyes from PlayerPrefs
        //grab the gameObject in scene that is our character and set its Object name to the Characters name
    }
    #endregion
    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing
    void SetTexture(string type, int index)
    {
        //we need variables that exist only within this function
        //these are int material index and Texture2D array of textures
        Texture2D tex = null;
        int matIndex = 0;
        //inside a switch statement that is swapped by the string name of our material
        switch (type)
        {
            //case skin
            //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
            case "Skin":
                tex = Resources.Load("Character/Skin_" + index) as Texture2D;
                //material index element number is 1
                matIndex = 1;
                break;
            //case hair
            case "Hair":
                tex = Resources.Load("Character/Hair_" + index) as Texture2D;
                //hair is 4
                matIndex = 4;
                break;
            //case mouth
            case "Mouth":
                tex = Resources.Load("Character/Mouth_" + index) as Texture2D;
                //mouth is 3
                matIndex = 3;
                break;
            //case eyes
            case "Eyes":
                tex = Resources.Load("Character/Eyes_" + index) as Texture2D;
                //eyes are 2
                matIndex = 2;
                break;
            //case armour
            case "Clothes":
                tex = Resources.Load("Character/Clothes_" + index) as Texture2D;
                //eyes are 6
                matIndex = 6;
                break;
            //case eyes
            case "Armour":
                tex = Resources.Load("Character/Armour_" + index) as Texture2D;
                //eyes are 5
                matIndex = 5;
                break;
        }
        //Material array is equal to our characters material list
        Material[] mats = character.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mats[matIndex].mainTexture = tex;
        //our characters materials are equal to the material array
        character.materials = mats;
    }
        #endregion
}