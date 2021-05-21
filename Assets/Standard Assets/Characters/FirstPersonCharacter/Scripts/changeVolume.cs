using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeVolume : MonoBehaviour
{
    public AudioSource k;

    static private float bgmVolume = 1.0f;
    static private float gameVolume = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        k.Play();
    }

    // Update is called once per frame
    void Update()
    {
        k.volume = bgmVolume;        
    }

    public void changeBgmVol(float v)
    {
        bgmVolume = v;
    }

    public void changeSEVol(float v)
    {
        gameVolume = v;
    }

    public float getSEVol()
    {
        return gameVolume;
    }
}
