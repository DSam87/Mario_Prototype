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

    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject levelCompleteText;
    public GameObject levelCompleteMenu;
    public GameObject levelCompleteRestartLevelButton, levelCompleteNextLevelButton;

    private void Awake() 
    {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();

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
        if(shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if(shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r,fadeScreen.color.g,fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
        
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


    public void FadeToBlack()
    {

        shouldFadeFromBlack = false;
        shouldFadeToBlack = true;  
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
