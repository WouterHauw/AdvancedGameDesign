using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}