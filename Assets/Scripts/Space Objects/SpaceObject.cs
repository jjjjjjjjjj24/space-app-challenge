using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    // Managers
    private StoryManager storyManager;

    public GameObject UIDisplay;
    private SpaceObjectDisplay display;
    private SpriteRenderer spriteRenderer;

    [Header("Info")]
    public SpaceObjectData data;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        storyManager = GameObject.FindObjectOfType<StoryManager>();

        if (UIDisplay != null)
            display = UIDisplay.GetComponent<SpaceObjectDisplay>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (data != null)
            spriteRenderer.sprite = data.image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When the object is clicked
    private void OnMouseDown()
    {
        if (display != null)
        {
            display.gameObject.SetActive(true);
            display.DisplayDescription(data.header, data.body, data.image);
        }

        if (storyManager != null)
        {
            // Calls the has found part
            // will only destroy the gameobject if the name matches the data in the story manager
            storyManager.HasFoundPart(gameObject, data);
        }
    }
}
