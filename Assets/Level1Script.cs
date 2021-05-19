using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Script : MonoBehaviour
{
	int dialogueOption;
	public GameObject textContainer;
	Text displayText;
	Animator anim;
	Color tempColor;

    // Start is called before the first frame update
    void Start()
    {
        dialogueOption = 0;
        displayText = GetComponent<Text>();
        anim = GetComponent<Animator>();
        tempColor = GetComponent<Renderer>().material.color;
        tempColor.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void AnimationCompleteHandler()
    {
    	dialogueOption++;


 		if (dialogueOption == 1) 
 		{
 			displayText.text = "Find the item";
 			anim.Play("fadeIn", -1, 0f);
 		}
 		if (dialogueOption == 2)
 		{
 			displayText.fontSize = 25;
 			displayText.text = "And return back to the start";
 			anim.Play("fadeIn", -1, 0f);
 		}
 		else if(dialogueOption == 3)
 		{
 			textContainer.SetActive(false);
 		}
    }

}
