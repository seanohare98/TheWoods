using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject spawnRabbit;
	public float timeToSpawn = 20.0f;
	public float y = 0f;

    // Start is called before the first frame update
    void Start()
    {
	 	StartCoroutine(spawnRabbits());  
    }

    IEnumerator spawnRabbits()
    {
    	float pt;
		int side;
		while(true)
		{
			pt = Random.Range(0f, 53f);
			side = Random.Range(0,2);
			if (side == 1)
			{
				pt *= 1;
			}
			var instanceRabbit = Instantiate(spawnRabbit, new Vector3( 53f, y, pt), spawnRabbit.transform.rotation);
    		yield return new WaitForSeconds(timeToSpawn);
		}
    }
}
