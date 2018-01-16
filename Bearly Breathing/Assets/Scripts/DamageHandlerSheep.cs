using UnityEngine;
using UnityEngine.Audio;

public class DamageHandlerSheep : MonoBehaviour
{
    public AudioClip[] clips;

    public float health = 10;
    public float maxPitch = 1.05f;


    public float minPitch = .95f;
    public AudioMixerGroup output;


    // Use this for initialization
    private void Start()
    {
        InvokeRepeating("PlaySound", Time.deltaTime, 5.0f);
    }

     private void PlaySound()
    {
        var randomClip = Random.Range(0, clips.Length);

        var source = gameObject.AddComponent<AudioSource>();

        source.clip = clips[randomClip];

        source.outputAudioMixerGroup = output;

        source.pitch = Random.Range(minPitch, maxPitch);

        source.Play();

        Destroy(source, clips[randomClip].length);
    }
}