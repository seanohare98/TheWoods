using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabitController : MonoBehaviour
{
    public float rotationDamping = 6.0f;
    public float eatingTime = 2.0f;

    private UnityEngine.AI.NavMeshAgent agent;
    private Animator thisAnim;
    private int count = 0;

    void Start ()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        thisAnim = GetComponent<Animator>();
    }
    void Update () 
    {
        EatBread();
        AwayFromPlayer();
    }

    private void EatBread() 
    {
        GameObject[] breads;  
        bool haveAction = false;
        breads = GameObject.FindGameObjectsWithTag("Bread");
        
        foreach (GameObject bread in breads) 
        {
            Vector3 heading = bread.transform.position - transform.position;
            // If closer than 7, change to idle state to simulate eating the bread
            if (heading.sqrMagnitude <= 1) 
            {
                Quaternion rotation = Quaternion.LookRotation(bread.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
                haveAction = true;
                count += 1;
                thisAnim.SetBool ("Eating", true);
                if (count >= eatingTime * 100) 
                {          //  The time that bread will be eaten * fps
                    count = 0;
                    Destroy(bread);
                    thisAnim.SetBool ("Eating", false);
                }
                break;
            }
            // If closer than 40, rabbit should automatically walk and eat the bread
            else if (heading.sqrMagnitude <= 40) 
            {
                Quaternion rotation = Quaternion.LookRotation(bread.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
                haveAction = true;
                break;
            }
            
        }
        if (!haveAction) 
        {
            thisAnim.SetBool ("Search", true);
        }
    }

    private void AwayFromPlayer() 
    {
        GameObject player;  
        Vector3 heading;

        player = GameObject.FindGameObjectWithTag("MainCamera");
        heading = player.transform.position - transform.position;
        thisAnim.SetFloat ("PlayerDistance", heading.sqrMagnitude);
    } 
}
