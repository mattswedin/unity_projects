using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int coinPoints = 100;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameSession>().AddToScore(coinPoints);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
