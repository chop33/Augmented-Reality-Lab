
using UnityEngine;

public class ArrowBehavior : MonoBehaviour {

    public GameObject mainCamera;

    private Vector3 diff;

    void Update()
    {
        diff = mainCamera.transform.forward;
        diff.y = 0.0f;
        transform.position = mainCamera.transform.position + diff.normalized * .7f;
        transform.LookAt(mainCamera.transform.position);
        transform.Rotate(-90, 0, 0);
    }
}
