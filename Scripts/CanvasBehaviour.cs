using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBehaviour : MonoBehaviour, IInputClickHandler
{

    public float setHeight;

    public float distance;

    public GameObject mainCamera;

    public RawImage egocentricImage;

    public RawImage allocentricImage;

    private Vector3 diff;

    private bool egocentricActive;

    void Start()
    {
        egocentricActive = true;
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * distance;
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    void LateUpdate()
    {
        diff = mainCamera.transform.forward;
        diff.y = 0.0f;
        transform.position = new Vector3(0.0f, setHeight, 0.0f) + mainCamera.transform.position
            + diff.normalized * distance;

        //diff = transform.position - mainCamera.transform.position;
        //diff.y = 0.0f;
        //transform.position = new Vector3(0.0f, setHeight, 0.0f)
        //+ mainCamera.transform.position + diff.normalized * distance;
        transform.LookAt(2 * transform.position - mainCamera.transform.position);
        transform.Rotate(20, 0, 0);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        //if (egocentricActive)
        //{
            //allocentricImage.enabled = true;
            //egocentricImage.enabled = false;
            //Debug.Log("First part's working");
        //}
        //else
        //{
            //egocentricImage.enabled = true;
            //allocentricImage.enabled = false;
        //}
        //egocentricActive = !egocentricActive;
    }
}