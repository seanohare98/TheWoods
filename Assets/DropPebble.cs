using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPebble : MonoBehaviour
{
	public Rigidbody prefabBullet; 
	public float shootForce;
	public Transform shootPosition;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2")) 
        {
			Rigidbody instanceBullet = (Rigidbody)Instantiate(prefabBullet, transform.position + Vector3.up * 2.0F, shootPosition.rotation);
			instanceBullet.GetComponent<Rigidbody>().AddForce(shootPosition .forward * shootForce);
		}
	}
}