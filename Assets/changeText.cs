using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changeText : MonoBehaviour
{
    public TMP_Text breadText;
    public TMP_Text stoneText;
    public Image arrowImage;
    public TMP_Text distanceText;

    private float lastAngle = 0.0f;

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
        breadText.text = s;
    }

    public void updateStoneText(string s) 
    {
        stoneText.text = s;
    }

    public void updateDistanceText(string s) 
    {
        distanceText.text = s;
    }

    public void rotateArrow(float angle) 
    {
        arrowImage.transform.Rotate(0.0f,0.0f,angle-lastAngle,Space.Self);
        lastAngle = angle;
    }

}
