using UnityEngine;
using System.Collections;

public class Stripes : MonoBehaviour {

    public float speed;
    private Transform[] stripes;

    void Start()
    {
        //Check if speed is set
        if (speed == 0)
        {
            speed = 1;
        }

        //Initalize stripes
        stripes = new Transform[8];
        for(int i = 0; i < 8; i++)
        {
            stripes[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        //Check the moving direction
        //right
        if((speed / Mathf.Abs(speed)) == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                //Move stripes
                stripes[i].Translate(new Vector3(speed * Time.deltaTime, 0, 0));

                //Check if stripe is out of camera
                if (stripes[i].position.x >= 4f)
                {
                    float rest = stripes[i].position.x - 4f;
                    stripes[i].position = new Vector3(-10.72f + rest, transform.position.y, 0);
                }
            }
        }
        //left
        else if((speed / Mathf.Abs(speed)) == -1)
        {
            for (int i = 0; i < 8; i++)
            {
                //Move stripes
                stripes[i].Translate(new Vector3(speed * Time.deltaTime, 0, 0));

                //Check if stripe is out of camera
                if (stripes[i].position.x <= -4f)
                {
                    float rest = stripes[i].position.x + 4f;
                    stripes[i].position = new Vector3(10.72f + rest, transform.position.y, 0);
                }
            }
        }
    }
}
