using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamCtrl : MonoBehaviour
{
    public float camPostition {get;set;}= 0;
    public GameObject target;
    public Camera FirstCamera;
    public Camera ThirdCamera;
    private float targetDistance;
    private const float speedTurnHori = 40f;
    private const float speedTurnVerti = 40f;
    // Start is called before the first frame update

    private float rotX = 0;
    private float rotY = 0;

    public float minTurnVertic = -90.0f;
    public float maxTurnVertic = 90.0f;

    public float minZoom = 2f;
    public float maxZoom = 50f;
    private float zoomSpeed = 5f;
    private float zoomCam = 0;

    public delegate void CameraControllerDelegate();
    private CameraControllerDelegate CameraController;

    void Start()
    {
        targetDistance = Vector3.Distance(transform.position, target.transform.position);
        Debug.Log(targetDistance);
        CameraController = FirstCameraController;
        SwitchCamera();
    }

    public void SwitchCamera() {
        if (FirstCamera.enabled) {
            FirstCamera.enabled = false;
            ThirdCamera.enabled = true;
        } else {
            ThirdCamera.enabled = false;
            FirstCamera.enabled = true;
        }
    }

    public void FirstCameraController() {
        rotY += Input.GetAxis("Mouse X") * speedTurnHori;
        rotX += Input.GetAxis("Mouse Y") * speedTurnVerti;
        
        rotX = Mathf.Clamp(rotX, minTurnVertic, maxTurnVertic);

        target.transform.eulerAngles =new Vector3 (0, rotY, 0);
        transform.eulerAngles = new Vector3(-rotX, rotY, 0);
    }

    public void ThirdCameraController() {
        rotY += Input.GetAxis("Mouse X") * speedTurnHori;
        rotX += Input.GetAxis("Mouse Y") * speedTurnVerti;
        
        rotX = Mathf.Clamp(rotX, minTurnVertic, maxTurnVertic);

        target.transform.eulerAngles =new Vector3 (0, rotY, 0);
        ThirdCamera.transform.eulerAngles = new Vector3(-rotX, 0, 0);
    }

    public void zoom(float delta) {
        float zoomReal = ThirdCamera.transform.localPosition.z * zoomCam * delta;

        zoomReal = Mathf.Clamp(zoomReal, maxZoom, minZoom);
        Vector3 distanceActorCamera = target.Position - ThirdCamera.Position;
        ThirdCamera.transform.Translate(target.Position + distanceActorCamera.Normalized * zoomReal);
    }

    // Update is called once per frame
    void Update()
    {
        float deltaScroll = Input.GetAxis("Mouse ScrollWheel");
        if (0f != deltaScroll) {
            zoom(deltaScroll);
        }
        CameraController();
    }
}
