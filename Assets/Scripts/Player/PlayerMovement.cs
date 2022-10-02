using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;
    public TextMeshProUGUI XVal;
    public TextMeshProUGUI YVal;
    public float playerSpeed;
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
        float x = Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime; //Value will be .0001 per frame
        float y = Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime;
        newX = cam.position.x + x;
        newY = cam.position.y - y;
        
        Vector3 newPos = new Vector3(newX, newY, -10);
        cam.position = newPos;

        // Add component for display: X and Y Coordinates.
        float outX = newX * 125f;
        float outY = newY * 125f;

        if (XVal != null && YVal != null)
        {
            XVal.text = outX.ToString("F2");
            YVal.text = outY.ToString("F2");
        }
        
        // Debug.Log(string.Format("Current Position: {0}, {1}", outX.ToString(), outY.ToString()));
    }
}
