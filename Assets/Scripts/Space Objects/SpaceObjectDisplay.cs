using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class SpaceObjectDisplay : MonoBehaviour
{
    [Header("Object Information")]
    public Image image;
    public TextMeshProUGUI header;
    public TextMeshProUGUI description;

    [Header("Capture Images")]
    public GameObject captureImagesButton;
    public Image capturedImageDisplay;

    private int index;
    private Sprite[] capturedImages;

    [Header("Display Congratulations")]
    public GameObject congratulationsDisplay;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayDescription(SpaceObjectData data)
    {
        // Display the name
        header.text = data.header;

        // Display the description
        this.description.text = data.body;

        // Display the image
        this.image.sprite = data.image;

        // Display images in the scene
        if (data.type == ObjectType.Telescope)
        {
            if (data.capturedImages.Length > 0)
            {
                captureImagesButton.SetActive(true);
                capturedImages = data.capturedImages;
                capturedImageDisplay.sprite = capturedImages[0]; // displays the first picture
                index = 0;
            } 
            else
            {
                Debug.Log("No Captured Images on " + data.header);
            }

        }

        // Do not display button if it is a part
        if (data.type == ObjectType.Part)
        {
            captureImagesButton.SetActive(false);

            // Display congratulations
            StartCoroutine(DisplayCongratulations());
        }
    }

    // For Left and Right Buttons
    public void ScrollLeft()
    {
        index = (index - 1 < 0) ? capturedImages.Length - 1 : index - 1;
        capturedImageDisplay.sprite = capturedImages[index];
    }

    public void ScrollRight()
    {
        index = index + 1 % capturedImages.Length;
        capturedImageDisplay.sprite = capturedImages[index];
    }

    private IEnumerator DisplayCongratulations()
    {
        congratulationsDisplay.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        congratulationsDisplay.SetActive(false);
    }
}
