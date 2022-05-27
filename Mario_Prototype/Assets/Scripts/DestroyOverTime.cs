using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
