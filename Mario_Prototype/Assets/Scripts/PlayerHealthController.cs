using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int maxHealth;
    public int currentHealth;

    public float invincibilityLength;
    private float invincabilityCounter;

    public SpriteRenderer theSR;
    public GameObject deathObject;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(invincabilityCounter > 0)
        {
            invincabilityCounter -= Time.deltaTime;
            if(invincabilityCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r,theSR.color.g,theSR.color.b, 1f);
            }
        }

        
    }

    public void DealDamage(int damage = 1)
    {
        if(invincabilityCounter <= 0)
        {
            currentHealth -= damage;
            Debug.Log("Player Damaged");

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                AudioManager.instance.PlaySFX(8);
                Instantiate(deathObject, transform.position, transform.rotation);
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincabilityCounter = invincibilityLength;
                theSR.color = new Color(theSR.color.r,theSR.color.g,theSR.color.b,.5f);

                PlayerController.instance.KnockBack();
            }

            UIController.instance.UpdateHealthUI();
        }
    }

}
