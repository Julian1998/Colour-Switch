using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//The Points-text canvas
	public Text pointsText;

	//Points
	private int points;

    //The 4 colors
    private Color[] colors;

    //Player GameObject
    public GameObject player;
    private SpriteRenderer sr;
    private string activeColor;

	//store random int for switches
	private int random;

    void Start () {
        //Set "Portrait" screen resolution
        Screen.SetResolution(480, 852, false, 60);

        //If there is no Player set
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        //Set colors
        colors = new Color[4];
		colors[0] = new Color(245 / 255f, 222 / 255f, 22 /255f, 1f); //yellow
        colors[1] = new Color(244 / 255f, 5 / 255f, 132 / 255f, 1f); //pink
		colors[2] = new Color(48 / 255f, 228 / 255f, 242 / 255f, 1f); //cyan
        colors[3] = new Color(143 / 255f, 16 / 255f, 253 / 255f, 1f); //purple

        //Choose and set a random start color to player
        sr = player.GetComponent<SpriteRenderer>();
		random = Random.Range(0, 4);
		sr.color = colors[random];
		player.GetComponent<Player>().SendMessage("switchColor", random);

		//Set points to 0
		points = 0;
		pointsText.text = points.ToString();
    }

	void increasePoints() {
		points++;
		pointsText.text = points.ToString();
	}

	void switchColor(bool[] colorBools) {
		//Choose a random, possible, color
		random = Random.Range(0, 4);

		while (!colorBools [random]) {
			random = Random.Range (0, 4);
		}

		sr.color = colors[random];
		player.GetComponent<Player>().SendMessage("switchColor", random);
	}
}
