using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{

    public string currentLevel, nextLevel, overWorld;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void CurrentLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void OverWorld()
    {
        SceneManager.LoadScene(overWorld);
    }
    
}
