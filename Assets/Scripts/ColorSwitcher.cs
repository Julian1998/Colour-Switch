using UnityEngine;
using System.Collections;

public class ColorSwitcher : MonoBehaviour {

	//bools for colors
	private bool[] colors;
	public bool yellow;
	public bool pink;
	public bool cyan;
	public bool purple;

	//GameController GameObject
	private GameController gc;

	void Start() {
		//Store colors
		colors = new bool[4];
		colors [0] = yellow;
		colors [1] = pink;
		colors [2] = cyan;
		colors [3] = purple;

		//If all colors are set to false -> unendless while, so set all to true
		if (!colors [0] && !colors [1] && !colors [2] && !colors [3]) {
			for (int i = 0; i < 4; i++) {
				colors [i] = true;
			}
		}

		//GameController reference
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Change color
		gc.SendMessage("switchColor", colors);

		//Destroy switcher
		Destroy (this.gameObject);
	}
}
