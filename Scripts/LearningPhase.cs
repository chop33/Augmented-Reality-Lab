using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningPhase : MonoBehaviour {

    public GameObject cubes;

    private GameObject[] learningPhaseCubes;
    private int numberOfCubes = 3;
    private int cubeNumber;
    private TriggerScript triggerScript;
    private bool haveEntered = false;
    private bool haveExited = false;
    //private Renderer rend;
    //private Renderer mapRend;

	// Use this for initialization
	void Start () {
        cubeNumber = 0;
        
        learningPhaseCubes = new GameObject[numberOfCubes];

        for (int i = 0; i < numberOfCubes; ++ i)
        {
            learningPhaseCubes[i] = cubes.transform.GetChild(i).gameObject;
        }
        //rend = learningPhaseCubes[cubeNumber].transform.Find("Cube").GetComponent<Renderer>();
        //mapRend = learningPhaseCubes[cubeNumber].transform.Find("Cube").
        //transform.Find("Target Location Indicator (Red Sphere)").GetComponent<Renderer>();
        Activation(cubeNumber, true);
        triggerScript = learningPhaseCubes[cubeNumber].GetComponent<TriggerScript>();
        //rend.enabled = false;
        //mapRend.enabled = true;
	}

    //void triggerDetection()
    //{
    //    for (int i = 0; i < numberOfCubes; ++ i)
    //    {
    //        triggerScript = learningPhaseCubes[i].GetComponent<TriggerScript>();
    //        if (triggerScript.entered)
    //        {
    //            if (i < (numberOfCubes - 1))
    //            {
    //                Activation(cubeNumber + 1, true);
    //            }
    //        }
    //    }
    //}

    //void OnCollisionEnter(Collision other)
    //{
    //    //rend.enabled = true;
    //    if (cubeNumber < (numberOfCubes - 1))
    //    {
    //        Activation(cubeNumber + 1, true);
    //    }
    //}

    //private void OnCollisionExit(Collision other)
    //{
    //    Activation(cubeNumber, false);
    //    ++cubeNumber;
    //}

    private void Activation(int cubeNumber, bool active)
    {
        learningPhaseCubes[cubeNumber].SetActive(active);
    }
}
