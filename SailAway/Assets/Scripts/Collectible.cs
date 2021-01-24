using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    //public ReactiveProperty<int> counter = new ReactiveProperty<int>(0);
    static int counter = 0;
    int numColls = 0;

    static AudioSource source;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Awake()
    {
        if (source == null)
            source = gameObject.AddComponent<AudioSource>();//singleton to reduce number of sound sources in scene
    }

    void Start()
    {
        counter = 0;

        if(numColls == 0)
            numColls = GameObject.FindObjectsOfType<Collectible>().Length;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            IncrementCounter();
            Debug.Log("Du hast " + counter + " von " + numColls + " Kiste(n) gesammelt");
            DestroyGameObject();
        }
    }

    public void IncrementCounter()
    {
        counter++;

        if (source == null)
            source = gameObject.AddComponent<AudioSource>();//singleton to reduce number of sound sources in scene

        source.PlayOneShot(clip);

        if (counter >= numColls)
            StartCoroutine(winGame());      
    }


    void DestroyGameObject()
    {
        if (counter < numColls) Destroy(gameObject);
        else
        {
            //NOTE: dont do this shit

            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;


            for (int i = 0; i < transform.childCount; i++)
            {
                Renderer r = transform.GetChild(i).GetComponent<Renderer>();
                Collider c = transform.GetChild(i).GetComponent<Collider>();

                if (r != null) r.enabled = false; 
                if (c != null) c.enabled = false; 
            }
        }
    }

    IEnumerator winGame()
    {
        Debug.Log("tried to end game. waiting for " + clip.length);
        yield return new WaitForSecondsRealtime(clip.length);
        Debug.Log("finished waitng");

        StaticGameState.winGame();
        SceneManager.LoadScene(0);
    }
}