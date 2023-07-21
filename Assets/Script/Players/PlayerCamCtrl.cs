using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamCtrl : MonoBehaviour
{
    public GameObject target;
    private float targetDistance;
    private const float speedTurnHori = 100f;
    private const float speedTurnVerti = 100f;
    // Start is called before the first frame update

    private float rotX;

    public float minTurnVertic = -90.0f;
    public float maxTurnVertic = 90.0f;
    void Start()
    {
         targetDistance = Vector3.Distance(transform.position, target.transform.position);
         Debug.Log(targetDistance);
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse X") * speedTurnHori;
        rotX += Input.GetAxis("Mouse Y") * speedTurnVerti;
        
        rotX = Mathf.Clamp(rotX, minTurnVertic, maxTurnVertic);

        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }

    void FixedUpdate() {
    }
}
