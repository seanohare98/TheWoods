using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
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
 			displayText.text = "Press F to drop bread crumbs";
 			anim.Play("fadeIn", -1, 0f);
 		}
 		else if (dialogueOption == 2)
 		{

	 		displayText.text = "Right-Click to drop pebbles";
 			anim.Play("fadeIn", -1, 0f);

 		}
 		else if (dialogueOption == 3)
 		{
	 		displayText.text = "Animals will eat your crumbs";
 			anim.Play("fadeIn", -1, 0f);

 		}
 		else if (dialogueOption == 4)
 		{
	 		displayText.text = "The Witch will follow your pebbles";	
 			anim.Play("fadeIn", -1, 0f);

 		}
 		else if (dialogueOption == 5)
 		{
	 		displayText.text = "Left-Click to toggle your flashlight";	
 			anim.Play("fadeIn", -1, 0f);

 		}
 		else if (dialogueOption == 6)
 		{
	 		displayText.text = "Good Luck";	
 			anim.Play("fadeIn", -1, 0f);

 		}
 		else if(dialogueOption == 7)
 		{
 			textContainer.SetActive(false);
 		}
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(10);
    }
}
