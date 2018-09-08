
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    public int HEIGHT = 10;


    public GameObject mainCamera;

	// Update is called once per frame
	void Update () {
        transform.position = new Vector3
            (mainCamera.transform.position.x, HEIGHT, mainCamera.transform.position.z);
        transform.rotation = Quaternion.Euler
            (90, transform.eulerAngles.y, transform.eulerAngles.z);
	}
}
