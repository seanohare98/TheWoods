using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject spawnRabbit;
	public Transform[] spawnPt;
	public int numRabbits = 2;

    // Start is called before the first frame update
    void Start()
    {
	 StartCoroutine(spawnRabbits());  
    }

    IEnumerator spawnRabbits()
    {
    	int pt;
    	for (int i = 0; i < numRabbits; i++)
    	{
    		pt = (int)Random.Range(0.0f, 2.99f);
    		var instanceRabbit = Instantiate(spawnRabbit, spawnPt[pt].position, spawnPt[pt].rotation);
    		yield return new WaitForSeconds(0.5f);
    	
    	}
    }
}
