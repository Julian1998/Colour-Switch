using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    // The force which is added when the player jumps
    // This can be changed in the Inspector window
    private Vector2 jumpForce = new Vector2(0, 400);
    Rigidbody2D rb;

	//GameController GameObject
	private GameController gc;

    //The 4 colors name as string to compare with obstacles' tag
    private string[] colorsName;

    //The active color
    private string activeColor;

	//The jump counter
	private int jumps;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();

        //Set colors
        colorsName = new string[4];
        colorsName[0] = "cyan";
        colorsName[1] = "pink";
        colorsName[2] = "yellow";
        colorsName[3] = "purple";

		activeColor = "";
		jumps = 0;
    }

    void Update()
    {
        // Jump
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(jumpForce);
			jumps++;
        }

		//If this is the first jump, jump higher
		if (jumps == 1) {
			jumpForce.y = 300;
		}
    }

    //Method for switching the Player's color
    void switchColor(int color)
    {
        activeColor = colorsName[color];
    }

    //Method to dectect Collision
    void OnTriggerEnter2D(Collider2D other)
	{
		//If the detected trigger is a start -> increase points
		if (other.tag == "star") {
			gc.SendMessage ("increasePoints");
			//Destroy star
			Destroy(other.gameObject);
		}
        //If the detected trigger has an other color then the Player -> Game Over
        else if(other.tag != activeColor)
        {
            // Destroy(this.gameObject);
            transform.position = new Vector3(0f, -3.25f, 0f);
			jumps = 0;
			jumpForce.y = 400;
        }
    }
}
