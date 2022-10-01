using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject loadingScreen;

    private void Awake()
    {
        loadingScreen.SetActive(false);

        // Subscribe the LoadingScreen() to the delegate on GameManager
        GameManager.Instance.onLoadScenesCallback += LoadingScreen;
    }
    
    private void LoadingScreen()
    {
        loadingScreen.SetActive(true);
    }
}
