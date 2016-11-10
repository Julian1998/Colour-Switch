using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	//Public variable to store a reference to the player game object
	public GameObject player;

	//Private variable to store the player's position in pixel
	private Vector2 screenPos;

	//Private variable to store the camera component
	private Camera camera;

	// Use this for initialization
	void Start () {
		camera = gameObject.GetComponent<Camera> ();
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		//Calculate players screen position to pixel
		screenPos = camera.WorldToScreenPoint(player.transform.position);

		//If the player is above the half of the Screen's height - move the Camera
		if (screenPos.y >= Screen.height/2) {
			// Set the position of the camera's transform to be the same as the player's
			transform.position = player.transform.position + new Vector3(0, 0, -10);
		}

		//If the player felt under the Screen's height
		if (screenPos.y <= 0) {
			//Reset Camera
			gameObject.transform.position = new Vector3(0, 0, -10);

			//Reset Player
			player.SendMessage("gameOver");
		}
	}
}
