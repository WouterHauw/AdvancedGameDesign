using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DamageHandlerSheep : MonoBehaviour
{
   
    public float health = 10    ;
    public AudioClip[] clips;
    public AudioMixerGroup output;

  

    public float minPitch = .95f;
    public float maxPitch = 1.05f;





    // Use this for initialization
    void Start()
    {
       
        InvokeRepeating("PlaySound", Time.deltaTime, 5.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
        
     
           // Destroy(gameObject);
        }

    }

    void PlaySound()
    {
        int randomClip = Random.Range(0, clips.Length);

        AudioSource source = gameObject.AddComponent<AudioSource>();

        source.clip = clips[randomClip];

        source.outputAudioMixerGroup = output;

        source.pitch = Random.Range(minPitch, maxPitch);

        source.Play();

        Destroy(source, clips[randomClip].length);

    }
}
