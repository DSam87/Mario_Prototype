using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public bool isGem;
    public bool isHealth;
    private bool isCollected;

    // Start is called before the first frame update
    void Start()
    {
        isCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !isCollected)
        {
            if(isGem)
            {
                LevelManager.instance.gemsCollected++;
                isCollected = true;
                Destroy(gameObject);
            }

            if(isHealth)
            {
                if(!(PlayerHealthController.instance.currentHealth == PlayerHealthController.instance.maxHealth))
                {
                    PlayerHealthController.instance.currentHealth++;
                    isCollected = true;
                    UIController.instance.UpdateHealthUI();
                    Destroy(gameObject);
                }
            }
        }    
    }
}