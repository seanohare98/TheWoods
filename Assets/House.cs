using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
{
    public key levelKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.tag == "MainCamera")
        {
            if (levelKey.getKeyState() == true)
            {
                if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    SceneManager.LoadScene(0);
                }
                else 
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }
}
