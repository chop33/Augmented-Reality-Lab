using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject[] cubes;

    private Vector3 headPosition;
    private Vector3 gazeDirection;
    private RaycastHit hitInfo;
    private Renderer rend1;
    private Renderer rend2;
    private Renderer rend3;
    private Renderer mapRend1;
    private Renderer mapRend2;
    private Renderer mapRend3;

    private void Start()
    {
        rend1 = cubes[0].transform.Find("Cube").GetComponent<Renderer>();
        rend2 = cubes[1].transform.Find("Cube").GetComponent<Renderer>();
        rend3 = cubes[2].transform.Find("Cube").GetComponent<Renderer>();

        mapRend1 = cubes[0].transform.Find("Cube")
            .transform.Find("Target Location Indicator (Red Sphere)").GetComponent<Renderer>();
        mapRend2 = cubes[1].transform.Find("Cube")
            .transform.Find("Target Location Indicator (Red Sphere)").GetComponent<Renderer>();
        mapRend3 = cubes[2].transform.Find("Cube")
            .transform.Find("Target Location Indicator (Red Sphere)").GetComponent<Renderer>();
    }

    private void Update()
    {
        headPosition = mainCamera.transform.position + Vector3.down;
        gazeDirection = mainCamera.transform.forward;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 1f))
        {
            if (hitInfo.collider.gameObject.CompareTag("Cubes"))
            {
                if (hitInfo.collider.gameObject.name.Equals("Cube 1"))
                {
                    rend1.enabled = true;
                    mapRend1.enabled = false;

                    cubes[1].SetActive(true);
                    StartCoroutine(Deactivate(cubes[0]));
                }
                else if (hitInfo.collider.gameObject.name.Equals("Cube 2"))
                {
                    rend2.enabled = true;
                    mapRend2.enabled = false;

                    cubes[2].SetActive(true);
                    StartCoroutine(Deactivate(cubes[1]));
                }
                else if (hitInfo.collider.gameObject.name.Equals("Cube 3"))
                {
                    rend3.enabled = true;
                    mapRend3.enabled = false;

                    StartCoroutine(Deactivate(cubes[2]));
                }
            }
        }
    }

    IEnumerator Deactivate(GameObject cube)
    {
        yield return new WaitForSeconds(3);
        cube.SetActive(false);
    }


    //public GameObject[] learningPhaseCubes;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("MainCamera"))
    //    {
    //        if (gameObject.name.Equals("Cube 1"))
    //        {
    //            learningPhaseCubes[1].SetActive(true);
    //        }
    //        else if (gameObject.name.Equals("Cube 2"))
    //        {
    //            learningPhaseCubes[2].SetActive(true);
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("MainCamera"))
    //    {
    //        if (gameObject.name.Equals("Cube 1"))
    //        {
    //            learningPhaseCubes[0].SetActive(false);
    //        }
    //        else if (gameObject.name.Equals("Cube 2"))
    //        {
    //            learningPhaseCubes[1].SetActive(false);
    //        }
    //        else if (gameObject.name.Equals("Cube 3"))
    //        {
    //            learningPhaseCubes[2].SetActive(false);
    //        }
    //    }
    //}
}
