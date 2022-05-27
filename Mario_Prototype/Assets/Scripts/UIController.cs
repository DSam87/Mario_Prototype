using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Image heart1, heart2, heart3;
    public Sprite heartFull, heartEmpty;

    public Text currentGemText;
    public Text maxGemText;



    private void Awake() 
    {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {

        Pickup[] pickupObjects = FindObjectsOfType<Pickup>();
        int maxGemsInt = 0;
        for (int i = 0; i < pickupObjects.Length ; i++)
        {
            if(pickupObjects[i].isGem)
            {
                maxGemsInt++;
            }
        }
        maxGemText.text = "/" + maxGemsInt.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthUI()
    {
        Debug.Log("Health UI Update");

        switch (PlayerHealthController.instance.currentHealth)
        {
            case 3: 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
            break;
            case 2: 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
            break;
            case 1: 
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
            break;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;            
            break;
        }
    }

    public void UpdateGemUI()
    {
        currentGemText.text = (LevelManager.instance.gemsCollected).ToString();
    }
}
