using UnityEngine;

public class PianoKey : MonoBehaviour
{
    public AudioClip pianoSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Tocar()
    {
        audioSource.PlayOneShot(pianoSound);
    }
}

    
