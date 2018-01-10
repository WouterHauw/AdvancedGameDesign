using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public Image heart;
    public int heartX;
    public int heartY;
    public int heartWidth;
    public int currentHearts;

    // Use this for initialization
    void Start()
    {
        heartX = -90;
        heartY = -20;
        heartWidth = 30;
    }


    public void setHealthSlider()
    {
        Vector3 position = new Vector3(heartX, heartY, 1);

        while (currentHearts < GameManager.Instance.health)
        {
            Image heartImage = Instantiate(heart, position, Quaternion.identity) as Image;
            heartImage.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            position.x -= heartWidth;
            heartX -= heartWidth;
            currentHearts++;
        }

        while (currentHearts > GameManager.Instance.health)
        {
            var Hearts = GameObject.FindGameObjectsWithTag("Heart");
            var heartToDestroy = Hearts[(currentHearts - 1)];
            Destroy(heartToDestroy);
            heartX += heartWidth;
            currentHearts--;
        }
    }
}