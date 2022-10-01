using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    public GameObject display;

    [Header("Info")]
    public string objectName;
    public string description;
    public Sprite image;

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
        Debug.Log("Name: " + objectName);
    }
}
