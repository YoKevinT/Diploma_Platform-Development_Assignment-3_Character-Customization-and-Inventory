using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro RPG/Player/Check Point
[AddComponentMenu("Intro PRG/RPG/Player/Check Point")]
public class CheckPoint : MonoBehaviour
{
    #region Variables
    //[Header("Check Point Elements")]
    [Header("Check Point Elements")]
    //GameObject for our currentCheck
    public Transform curCheckPoint;
    //[Header("Character Health")]
    [Header("Character Health")]
    //character Health script that holds the players health
    public HealthBar health;
    #endregion
    #region Start
    private void Start()
    {
        //the character handler is the component attached to our player
        #region Check if we have Key
        //if we have a save key called SpawnPoint
        //then our checkpoint is equal to the game object that is named after our save file
        //our transform.position is equal to that of the checkpoint
        #endregion
    }
    #endregion
    #region Update
    private void Update()
    {
        //if our characters health is less than or equal to 0
        if (health.curHealth <= 0)
        {
            //our transform.position is equal to that of the checkpoint
            transform.position = curCheckPoint.position;
            //our characters health is equal to full health
            health.curHealth = health.maxHealth;
            //character is alive
            //characters controller is active
        }
    }
    #endregion
    #region OnTriggerEnter
    void OnTriggerEnter(Collider other) //Collider other
    {

        //if our other objects tag when compared is CheckPoint
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            //our checkpoint is equal to the other object
            curCheckPoint = other.transform;
            //save our SpawnPoint as the name of that object
            Player player = this.GetComponent<Player>();
            player.SaveFunction();
        }
    }
    #endregion
}