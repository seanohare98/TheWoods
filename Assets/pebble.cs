using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pebble : MonoBehaviour
{
    public AudioClip pebbleFallSound;
    public AudioClip pebbleFallRockSound;
    public changeVolume cV; 
    // private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        // audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().volume = cV.getSEVol();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.transform.gameObject.tag == "Plane")
        {
            GetComponent<AudioSource>().clip = pebbleFallSound;
            GetComponent<AudioSource>().Play();
        }
        else if (otherObj.transform.gameObject.tag == "Rock")
        {
            GetComponent<AudioSource>().clip = pebbleFallRockSound;
            GetComponent<AudioSource>().Play();
        }
    }
}
