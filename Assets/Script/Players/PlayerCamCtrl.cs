using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamCtrl : MonoBehaviour
{

    [SerializeField] Camera playercamera;
    private const float Speed_h = 100f;
    private const float Speed_v = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw ("Mouse X"));
        transform.Rotate(Vector3.right * Input.GetAxisRaw ("Mouse Y"));
        transform.Translate(Vector3.forward * 6f * Input.GetAxis("Mouse ScrollWheel"));
    }

    void FixedUpdate() {
    }
}
