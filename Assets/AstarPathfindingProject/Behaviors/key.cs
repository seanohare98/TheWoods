using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public float rotSpeed = 100f;
    private bool tookKey = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,Time.deltaTime * rotSpeed, Space.Self);
    }

    private void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.tag == "MainCamera")
        {
            Destroy(gameObject);
            tookKey = true;
        }
    }

    public bool getKeyState()
    {
        return tookKey;
    }
}
