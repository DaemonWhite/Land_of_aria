using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private const float Speed = 2f;
    private const float SpeedShift = 6f;
    private bool isJumping = false;
    [SerializeField] Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.AddForce(Vector3.up * 50f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collision) {
        Debug.Log("Une collision detecter");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            Debug.Log("Sole collision detecter");
        }
    }

    void jump() {
        if (Input.GetAxis("Jump") > 0f && !isJumping )
        {
            rigidbody.AddForce(Vector3.up * 6f, ForceMode.VelocityChange);
            isJumping = true;
        }
    }

    void FixedUpdate() {
        float translation_z = Speed * Time.fixedDeltaTime;
        float translation_y = translation_z;
        float translation_x = translation_z + 1f;

        translation_z *= Input.GetAxis("Vertical");
        translation_y *= Input.GetAxis("Horizontal");
        jump();

        transform.Translate(Vector3.forward * translation_z);
        transform.Translate(Vector3.right * translation_y);
    }
}
