using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    [Header("Ship Controls")]
    public RectTransform controller;
    public float angle = 1;
    public Vector3 forwardScale;
    public Vector3 backwardScale;
    public float speed = 1;

    [Header("Stick")]
    public Image shipStick;
    public Sprite forwardStick;
    public Sprite backwardStick;

    private Vector3 originalScale;
    private Quaternion originalRotation;

    private void Awake()
    {
        // Store original to a variable
        if (controller != null)
        {
            originalRotation = controller.rotation;
            originalScale = controller.localScale;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Controller Rotation

        // Rotate the controller
        if (Input.GetButton("Horizontal"))
        {
            float x = Input.GetAxis("Horizontal");
            // Rotate left
            if (x < 0)
            {
                float newRotation = Mathf.MoveTowards(controller.rotation.z, 35f, Time.deltaTime * angle * 10000f);
                controller.rotation = Quaternion.Euler(new Vector3(controller.rotation.x, controller.rotation.y, newRotation));
            }

            // Rotate right
            if (x > 0)
            {
                float newRotation = Mathf.MoveTowards(controller.rotation.z, -40f, Time.deltaTime * angle * 10000f);
                controller.rotation = Quaternion.Euler(new Vector3(controller.rotation.x, controller.rotation.y, newRotation));
            }
        }
        else
        {
            // Reset rotation
            controller.rotation = originalRotation;
        }

        #endregion

        #region Controller Foward and Backward

        if (Input.GetButton("Vertical"))
        {
            // If player pressed W
            float y = Input.GetAxis("Vertical");
            if (y > 0)
            {
                controller.localScale = Vector3.MoveTowards(controller.localScale, forwardScale, Time.deltaTime * speed);
            }

            // If player pressed S
            if (y < 0)
            {
                controller.localScale = Vector3.MoveTowards(controller.localScale, backwardScale, Time.deltaTime * speed);
            }
        }
        else
        {
            // Reset scale
            controller.localScale = originalScale;
        }

        #endregion

        #region Stick Controls

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            shipStick.sprite = forwardStick;
        }
        else
        {
            shipStick.sprite = backwardStick;
        }

        #endregion
    }
}
