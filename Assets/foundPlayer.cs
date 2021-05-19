using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foundPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeFoundBgm()
    {
        GetComponent<AudioSource>().Play();
        Debug.Log("sdfsdfsdfdsfsdfsdfdsfdsfdsfdsf");
        // GetComponent<AudioSource>().clip = chasing;
        // GetComponent<AudioSource>().Play();
    }
}
