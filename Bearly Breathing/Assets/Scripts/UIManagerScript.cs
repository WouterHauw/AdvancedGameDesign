using Boo.Lang;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    public List<GameObject> hearts;
    public int activeHearts;

    private void Start()
    {     
        hearts = new List<GameObject>();
        var children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            foreach (Transform images in transform.GetChild(i))
            {
                hearts.Add(images.gameObject);
            }
        }
           
    }

    public void SetHealthSlider()
    {
        if (GameManager.Instance.health <= 0)
        {
            foreach (var heart in hearts)
            {
                heart.SetActive(false);
            }
            return;
        }
        while(activeHearts < GameManager.Instance.health)
        {
            hearts[activeHearts].SetActive(true);
            activeHearts++;
        }
        while (activeHearts < GameManager.Instance.health & activeHearts != 0)
        {
           hearts[activeHearts-1].SetActive(false);
            activeHearts--;
        }
       
    }
}