using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMusic : MonoBehaviour
{
    public AudioSource bgm;
    public AudioClip original;
    public AudioClip chasing;

    // Start is called before the first frame update
    void Start()
    {
        bgm.clip = original;
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void change2Found()
    {
        bgm.clip = chasing;
        bgm.Play();
    }

    public void change2Original()
    {
        bgm.clip = original;
        bgm.Play();
    }
}
