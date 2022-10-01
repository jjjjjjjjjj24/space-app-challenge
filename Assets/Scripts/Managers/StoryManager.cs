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
    [Header("Display UI")]
    public GameObject storyDisplayUI;
    public float speed = 1;
    private RectTransform introTransform;

    [Header("Parts to Find")]
    public Parts[] parts;
    public bool hasFoundAllParts = false;

    [System.Serializable]
    public class Parts
    {
        public string name;
        public bool hasFound;
    }

    private void Awake()
    {
        // References
        uiManager = GameObject.FindObjectOfType<UIManager>();

        if (storyDisplayUI != null)
        {
            storyDisplayUI.SetActive(true);
            introTransform = storyDisplayUI.GetComponent<RectTransform>();
        }
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
        #region Story UI

        // Disable Story UI when pressed space
        if (storyUI.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                storyUI.SetActive(false);
        }

        #endregion

        #region Parts

        // Check if any parts is found
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].hasFound == true)
            {
                // Disable game object
            }
        }

        // Check if all parts are found
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].hasFound == false)
            {
                hasFoundAllParts = false;
                break;
            }

            hasFoundAllParts = true;
        }

        #endregion

        #region When Player Found all parts

        // If found all parts load ending scene
        if (hasFoundAllParts == true)
        {
            GameManager.Instance.LoadSceneAsync("Ending");
        }

        #endregion
    }

    public void HasFoundPart(GameObject gameObject, SpaceObjectData data)
    {
        // Check in the list that the part has been found
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].name == data.header)
            {
                // Check the bool of the part found
                parts[i].hasFound = true;

                // Disable gameobject
                Destroy(gameObject);
            }
        }
    }
}
