using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject loadingScreen;

    private void Awake()
    {
        if (loadingScreen != null)
            loadingScreen.SetActive(false);

        // Subscribe the LoadingScreen() to the delegate on GameManager
        GameManager.Instance.onLoadScenesCallback += LoadingScreen;
    }
    
    private void LoadingScreen()
    {
        if (loadingScreen != null)
            loadingScreen.SetActive(true);
    }

    public IEnumerator UIZoomIn(RectTransform transform, float speed)
    {
        // Store the original transform
        Vector3 orig = transform.localScale;

        transform.localScale = new Vector3(0, 0, 1);
        while (transform.localScale.sqrMagnitude < orig.sqrMagnitude)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, orig, Time.deltaTime * speed);
            yield return null;
        }
    }
}
