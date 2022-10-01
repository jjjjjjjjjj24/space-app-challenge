using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform camera;
    private float newX = 0;
    private float newY = 0;
    void Awake(){

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") / 1000; //Value will be .0001 per frame
        float y = Input.GetAxisRaw("Vertical") / 1000;
        newX = newX + x;
        newY = newY + y;
        Vector3 newPos = new Vector3(newX, newY, -10);
        camera.position = newPos;
        float outX = newX * 637; //X value to be released on output: With random multiplier
        float outY = newY * 483; //Y value to be released on output: With random multiplier
        if(Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
            Debug.Log(string.Format("Current Position: {0}, {1}", outX.ToString(), outY.ToString()));
        
    }
}
