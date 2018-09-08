using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;
using System.IO;

public class TapScript : MonoBehaviour {

    public RawImage egocentricMap;
    public RawImage allocentricMap;
    public GameObject[] strips;
    public GameObject targetCube;

    private float[] angles = {40, 80, 120, 160, 200, 240, 280, 320};
    private bool alloMap = true;
    private int stripsCount = 0;
    private int anglesCount = 0;
    private Vector3 direction;
    private bool finishedTrial = true;
    private bool positioned = false;
    private GestureRecognizer recognizer;

    const float DELAY = 0.5f;

    private void Start()
    {
        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap | GestureSettings.DoubleTap);
        recognizer.TappedEvent += MyTapEventHandler;
        recognizer.StartCapturingGestures();
    }

    private void OnDestroy()
    {
        recognizer.TappedEvent -= MyTapEventHandler;
    }

    private void MyTapEventHandler(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        if (tapCount == 1)
        {
            Invoke("Advance", DELAY);
        }
        else if (tapCount == 2)
        {
            CancelInvoke("Advance");
            MapSwitch();
        }
    }

    /*private void Advance()
    {

        if (finishedTrial)
        {
            Randomize(angles);
            finishedTrial = false;
        }

        if (!positioned)
        {
            if (stripsCount < strips.Length)
            {
                if (anglesCount < angles.Length)
                {
                    setPosition(stripsCount, anglesCount);
                    StartCoroutine(Appear());
                    positioned = true;
                }
            }
        }
        else
        {
            WriteToFile();
            positioned = false;
            ++anglesCount;

            if (anglesCount == angles.Length)
            {
                anglesCount = 0;
                ++stripsCount;
                strips[stripsCount].SetActive(true);
                strips[stripsCount - 1].SetActive(false);
                finishedTrial = true;
            }
        }
        
    }

    IEnumerator Appear()
    {
        targetCube.SetActive(true);
        yield return new WaitForSeconds(3);
        targetCube.SetActive(false);
    }*/

    private void WriteToFile()
    {
        float userAngle = Vector3.Angle(Camera.main.transform.forward, strips[stripsCount].transform.forward);

        string path = Path.Combine(Application.persistentDataPath, "Test1.txt");
        using (TextWriter writer = File.CreateText(path))
        {
            writer.WriteLine("Strip Number: " + stripsCount + " Cube Angle: "
                + angles[anglesCount] + " Actual Angle: " + userAngle);
        }
    }

    private void MapSwitch()
    {
        if (alloMap)
        {
            allocentricMap.enabled = false;
            egocentricMap.enabled = true;
        }
        else
        {
            egocentricMap.enabled = false;
            allocentricMap.enabled = true;
        }
        alloMap = !alloMap;
    }

    private void Randomize(float[] trials)
    {

        for (int i = trials.Length - 1; i > 0; --i)
        {
            int random = Random.Range(0, i);
            float tmp = trials[i];
            trials[i] = trials[random];
            trials[random] = tmp;
        }

    }

    private void setPosition(int stripsCount, int anglesCount)
    {
        direction = Quaternion.AngleAxis(angles[anglesCount], Vector3.up)
            * strips[stripsCount].transform.forward;
        direction.Normalize();
        direction = direction * 2f;

        targetCube.transform.position = strips[stripsCount].transform.position
            + targetCube.transform.TransformDirection(direction);
    }
}
