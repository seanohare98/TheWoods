using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breadcrumb : MonoBehaviour
{
    // Start is called before the first frame update
    public changeVolume cV; 
    void Start()
    {
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
            GetComponent<AudioSource>().Play();
            // Debug.Log("hit");
        }
    }
}
