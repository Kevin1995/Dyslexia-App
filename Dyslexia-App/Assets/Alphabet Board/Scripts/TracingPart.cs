using UnityEngine;
using System.Collections;

//Tracing Part script
public class TracingPart : MonoBehaviour {

	public int [] order;//the order of tracing points in the tracing part
	public bool succeded;//if the tracing part is succeeded or done
	public int priority;//the priority of the tracing part
    public int clearPointOne;
    public int clearPointTwo;
    public GameObject LetterOne;
    public GameObject LetterTwo;
    public GameObject LetterThree;
    public GameObject LetterFour;
    public bool letterOneDone;
    public bool letterTwoDone;
    public bool letterThreeDone;

    public void Start()
    {
        letterOneDone = true;
        letterTwoDone = true;
        letterThreeDone = true;
    }

    public void Update()
    {
        if (letterOneDone)
        {
            if (succeded == true && clearPointOne == priority)
            {
                LetterOne.SetActive(false);
                LetterTwo.SetActive(true);
                ClearCurrentLines();
                letterOneDone = false;
            }
        }

        if (letterTwoDone)
        {
            if (succeded == true && clearPointTwo == priority)
            {
                LetterTwo.SetActive(false);
                LetterThree.SetActive(true);
                ClearCurrentLines();
                letterTwoDone = false;
            }
        }
    }

    public void ClearCurrentLines()
    {
        GameObject[] linerenderers = GameObject.FindGameObjectsWithTag("LineRenderer");

        foreach (var line in linerenderers)
        {
            line.SetActive(false);
        }
    }
}
