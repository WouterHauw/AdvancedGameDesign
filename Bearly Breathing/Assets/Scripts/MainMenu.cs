using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _toBeAddedText;

    // Use this for initialization
    private void Start()
    {
        _toBeAddedText.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("2DScene");
    }

    public void ClickUnfinishedButton()
    {
        StartCoroutine("FadeInAndOutText");
    }

    private IEnumerator FadeInAndOutText()
    {
        _toBeAddedText.SetActive(true);
        yield return new WaitForSeconds(2);
        _toBeAddedText.SetActive(false);
    }
}