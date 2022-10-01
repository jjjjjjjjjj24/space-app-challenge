using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class SpaceObjectDisplay : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI header;
    public TextMeshProUGUI description;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayDescription(string name, string description, Sprite image)
    {
        // Display the name
        header.text = name;

        // Display the description
        this.description.text = description;

        // Display the image
        this.image.sprite = image;
    }
}
