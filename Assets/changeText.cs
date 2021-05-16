using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeText : MonoBehaviour
{
    public TMP_Text breadText;
    public TMP_Text stoneText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateBreadText(string s) 
    {
        breadText.text = "Bread: " + s;
    }

    public void updateStoneText(string s) 
    {
        stoneText.text = "Stone: " + s;
    }

}
