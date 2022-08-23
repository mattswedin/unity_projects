using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Frog")]
    [SerializeField] AudioClip ribbet;
    [SerializeField] [Range(0, 1f)] float ribbetVolume;

    [Header("Effects")]
    [SerializeField] AudioClip appearVanish;
    [SerializeField][Range(0, 1f)] float appearVanishVolume;
    [SerializeField] AudioClip textAppear;
    [SerializeField][Range(0, 1f)] float textAppearVolume;


    AudioSource audioSource;

    void Awake()
    {
       audioSource = GetComponent<AudioSource>(); 
    }

    public void PlayRandomRibbet()
    {
        audioSource.pitch = Random.Range(.5f, 1f);
        audioSource.PlayOneShot(ribbet, ribbetVolume);
    }

    public void PlayAppearVanish() 
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(appearVanish, appearVanishVolume);
    }

    public void PlayTextAppear() 
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(textAppear, textAppearVolume);
    }
}
