using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour
{
	private WritingHandler writingHandler;
	public Animator winDialog;
	public GameObject menu;
	
	void Start ()
	{
		//Setting up the writingHandler reference
		GameObject letters = HierrachyManager.FindActiveGameObjectWithName ("Letters");
		if (letters != null)
			writingHandler = letters.GetComponent<WritingHandler> ();
	}
	
	//Load the next number
	public void LoadTheNextLetter (object ob)
	{
		if (writingHandler == null) {
			return;
		}
		
		writingHandler.LoadNextLetter ();
	}
	
	//Load the previous/number
	public void LoadThePreviousLetter (object ob)
	{
		if (writingHandler == null) {
			return;
		}
		
		writingHandler.LoadPreviousLetter ();
		
	}
	
	//Load the current Letter
	public void LoadLetter (Object ob)
	{
		if (ob == null) {
			return;
		}
		
		WritingHandler.currentLetterIndex = int.Parse (ob.name.Split ('-') [1]);
		Application.LoadLevel ("AlphabetWriting");
	}
	
	//Erase the current Letter
	public void EraseLetter (Object ob)
	{
		if (writingHandler == null) {
			return;
		}
		writingHandler.RefreshProcess ();
		
	}
	
	//Close win dialog
	public void CloseWinDialog (Object ob)
	{
		writingHandler.letters [WritingHandler.currentLetterIndex].SetActive (true);
		menu.SetActive (true);
		GameObject [] linesRenderes = GameObject.FindGameObjectsWithTag ("LineRenderer");
		foreach (GameObject line in linesRenderes) {
			line.GetComponent<LineRenderer> ().enabled = true;
		}
		
		GameObject [] circlePoint = GameObject.FindGameObjectsWithTag ("CirclePoint");
		foreach (GameObject cp in circlePoint) {
			cp.GetComponent<MeshRenderer> ().enabled = true;
		}
		winDialog.SetBool ("isFadingIn", false);
	}
	
	//Load alphabet menu
	public void LoadAlphabetMenu (Object ob)
	{
		Application.LoadLevel ("AlphabetMenu");
	}
}