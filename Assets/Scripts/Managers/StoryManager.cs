using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    // UIManager
    private UIManager uiManager;

    // Story UI
    [Header("Story UI")]
    public GameObject storyUI;

    // Intro UI
    [Header("Intro UI")]
    public GameObject intro;
    public float speed = 1;
    private RectTransform introTransform;

    private void Awake()
    {
        // References
        uiManager = GameObject.FindObjectOfType<UIManager>();

        intro.SetActive(true);
        if (intro != null)
            introTransform = intro.GetComponent<RectTransform>();
    }

    private void Start()
    {
        // Handles zooming in of UI
        if (uiManager != null)
        {
            StartCoroutine(uiManager.UIZoomIn(introTransform, speed));
        }
    }

    private void Update()
    {
        // Disable Story UI when pressed space
        if (storyUI.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                storyUI.SetActive(false);
        }
    }
}
