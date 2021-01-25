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
        checkSource();
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

            checkSource();
            source.PlayOneShot(clip);
        }
    }

    public void IncrementCounter()
    {
        counter++;

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
                GameObject child = transform.GetChild(i).gameObject;
                Renderer r = child.GetComponent<Renderer>();
                Collider c = child.GetComponent<Collider>();
                Light l = child.GetComponent<Light>();

                if (r != null) r.enabled = false; 
                if (c != null) c.enabled = false; 
                if (l != null) l.enabled = false; 
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

    void checkSource()
    {
        if (source == null)
        { 
            source = gameObject.AddComponent<AudioSource>();//singleton to reduce number of sound sources in scene
            source.volume = 1.0f;
            source.spatialBlend = 0.0f;
        }
    }
}