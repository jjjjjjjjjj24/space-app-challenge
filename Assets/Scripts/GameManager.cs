using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region SINGLETON

    private static GameManager _gameManager;
    public static GameManager Instance
    {
        get
        {
            if (_gameManager == null)
                _gameManager = GameObject.FindObjectOfType<GameManager>();

            return _gameManager;
        }
    }
    #endregion

    public delegate void OnLoadScenes();
    public event OnLoadScenes onLoadScenesCallback;

    public void LoadSceneAsync(string scene)
    {
        // Calls all subscribed functions to the delegate
        if (onLoadScenesCallback != null)
            onLoadScenesCallback.Invoke();

        SceneManager.LoadSceneAsync(scene);
    }

    public void LoadScene(string scene)
    {
        // Calls all subscribed functions to the delegate
        if (onLoadScenesCallback != null)
            onLoadScenesCallback.Invoke();

        SceneManager.LoadScene(scene);
    }

    public void UnloadSceneAsync(string name)
    {
        // Calls all subscribed functions to the delegate
        if (onLoadScenesCallback != null)
            onLoadScenesCallback.Invoke();

        SceneManager.UnloadSceneAsync(name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
