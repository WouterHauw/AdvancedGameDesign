using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    [SerializeField] private GameObject toBeAddedText;
   
    // Use this for initialization
    void Start () {
        toBeAddedText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("2DScene");
    }

    public void ClickUnfinishedButton()
    {
        StartCoroutine("FadeInAndOutText");
    }

    IEnumerator FadeInAndOutText()
    {
        toBeAddedText.SetActive(true);
        yield return new WaitForSeconds(2);
        toBeAddedText.SetActive(false);
    }


}
