using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeVolume : MonoBehaviour
{
    public AudioSource k;

    private float volume = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        k.Play();
    }

    // Update is called once per frame
    void Update()
    {
        k.volume = volume;
    }

    public void changeVol(float v)
    {
        volume = v;
    }

    public float getVol()
    {
        return volume;
    }
}
