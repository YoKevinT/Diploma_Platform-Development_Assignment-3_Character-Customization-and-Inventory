using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100, curHealth = 100;
    public Slider healthBar;
    public Canvas myCanvas;

    // Use this for initialization
    private void Start()
    {
        myCanvas = transform.Find("Canvas").GetComponent<Canvas>();
        healthBar = myCanvas.transform.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
        myCanvas.transform.LookAt(Camera.main.transform);
    }
}