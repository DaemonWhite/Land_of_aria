using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    private const float Speed = 2f;
    private const float SpeedShift = 6f;
    private bool isJumping = false;

    private float moveOn = 1;
    [SerializeField] Rigidbody rigidbody;
    // Start is called before the first frame update

    public int enableMove {get; set;} = 0;

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

    public void rotatePlayer(float rotY) {
        transform.eulerAngles = new Vector3(0, rotY, 0);
    }

    void FixedUpdate() {
        Vector3 translation = new Vector3(0,0,0);
        translation.z = Input.GetAxis("Vertical");
        translation.x = Input.GetAxis("Horizontal");

        jump();

        // transform.Rotate(Vector3.right * Input.GetAxisRaw ("Mouse X"));
        transform.Translate(translation *  Speed * Time.fixedDeltaTime * moveOn);
    }
}
