using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    // The force which is added when the player jumps
    // This can be changed in the Inspector window
    public Vector2 jumpForce = new Vector2(0, 300);
    Rigidbody2D rb;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(jumpForce);
        }
    }
}
