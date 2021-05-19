using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public float rotSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,Time.deltaTime * rotSpeed, Space.Self);
    }

    private void OnCollisionEnter(Collision otherObj)
    {
        Debug.Log("sdfdsfs");
        if (otherObj.transform.gameObject.tag == "MainCamera")
        {
            Debug.Log("ssdsssssss");
            Destroy(gameObject, 0.3f);
        }
    }
}
