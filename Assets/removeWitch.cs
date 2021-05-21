using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeWitch : MonoBehaviour
{
    public GameObject witch;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Difficulty", 1) == 0)
        {
            Destroy(witch);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
