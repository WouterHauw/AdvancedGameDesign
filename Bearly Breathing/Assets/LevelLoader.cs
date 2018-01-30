using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _loadingScreen;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchrously(sceneIndex));
    }

    private IEnumerator LoadAsynchrously(int sceneindex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);

        _loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            _slider.value = progress;

            yield return null;
        }
        _loadingScreen.SetActive(false);

    }
}
