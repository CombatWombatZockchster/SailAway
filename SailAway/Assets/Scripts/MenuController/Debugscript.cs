using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debugscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     StaticGameState.winGame();
     // StaticGameState.loseGame();
     SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
