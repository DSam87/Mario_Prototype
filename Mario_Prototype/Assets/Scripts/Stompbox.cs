using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stompbox : MonoBehaviour
{

    public GameObject deathEffect;
    public GameObject collectible;
    [Range(0,100)] public float chanceToDrop;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
            AudioManager.instance.PlaySFX(3);
            Debug.Log("Hit enemy");
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, transform.position, transform.rotation);
            PlayerController.instance.Bounce();

            float dropSelectNumber = Random.Range(0, 100f);
            if(dropSelectNumber <= chanceToDrop)
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
        }
    }
}
