using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBreadcrumbs : MonoBehaviour
{
    public Rigidbody prefabBullet; 
	public float shootForce;
	public Transform shootPosition;
    public int numofBread = 999;
    public changeText ui;

    // Start is called before the first frame update
    void Start()
    {
        ui.updateBreadText(numofBread.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f")) 
        {
            if (numofBread > 0) 
            {
                Rigidbody instanceBullet = (Rigidbody)Instantiate(prefabBullet, transform.position + Vector3.up * 2.0F, shootPosition.rotation);
                instanceBullet.GetComponent<Rigidbody>().AddForce(shootPosition .forward * shootForce);
                numofBread -= 1;
                ui.updateBreadText(numofBread.ToString());
            }
		}
	}
}
