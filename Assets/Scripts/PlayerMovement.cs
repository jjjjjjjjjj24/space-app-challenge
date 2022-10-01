using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;
    public TextMeshProUGUI XVal;
    public TextMeshProUGUI YVal;
    private float newX = 0;
    private float newY = 0;

    void Awake()
    {

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
        newX = cam.position.x + x;
        newY = cam.position.y + y;
        
        Vector3 newPos = new Vector3(newX, newY, -10);
        cam.position = newPos;

        // Add component for display: X and Y Coordinates.
        float outX = newX * 345f;
        float outY = newY * 345f;
        if(Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical")){
            XVal.text = outX.ToString("F3");
            YVal.text = outY.ToString("F3");
        }
            // Debug.Log(string.Format("Current Position: {0}, {1}", outX.ToString(), outY.ToString()));
    }
}
