using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    public GameObject UIDisplay;
    private SpaceObjectDisplay display;

    [Header("Info")]
    public SpaceObjectData data;

    private void Awake()
    {
        display = UIDisplay?.GetComponent<SpaceObjectDisplay>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When the object is clicked
    private void OnMouseDown()
    {
        Debug.Log("Clicked: " + data.header);
        if (display != null)
        {
            display.gameObject.SetActive(true);
            display.DisplayDescription(data.header, data.body, data.image);
        }
    }
}
