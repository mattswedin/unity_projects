using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] List<AudioClip> shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Enemy")]
    [SerializeField] AudioClip vacuum;
    [SerializeField][Range(0f, 1f)] float vacuumVolume = 1f;

    public void PlayShootingClipPlayer() 
    {
        System.Random random = new System.Random();
        int randomNum = random.Next(0, shootingClip.Count);
        if(shootingClip != null) 
        {

            AudioSource.PlayClipAtPoint(shootingClip[randomNum], 
                                        Camera.main.transform.position, 
                                        shootingVolume);
        }
    }

    public void PlayVacuumClip() 
    {
        if (vacuum != null) 
        {
            AudioSource.PlayClipAtPoint(vacuum, 
                                        Camera.main.transform.position, 
                                        vacuumVolume);
        }
    }
}
