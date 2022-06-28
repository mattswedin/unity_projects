using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [Header("Player Only")]
    [SerializeField] bool isPlayer = false;
    Rigidbody2D playerRB;
    [SerializeField] float suckPower = 2f;
    [SerializeField] float stunTime = 30f;
    [SerializeField] float stunMovement = .01f;

    void Start() {

        if (isPlayer){
            playerRB = GetComponent<Rigidbody2D>();
        }

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer)
        {
            if (other.tag == "lightningBolt" && isPlayer)
            {
                StartCoroutine(Vibrate());
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
            }
            else if (other.tag == "dustSuck" && isPlayer)
            {
                playerRB.velocity += new Vector2(0f, suckPower);
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
            }
            else
            {
                TakeDamage(damageDealer.GetDamage());
                damageDealer.Hit();
            }
        }
       
    }

    IEnumerator Vibrate()
    {
        Vector3 ogPosition = transform.position;

        Player playerScript = FindObjectOfType<Player>();
        playerScript.stunned = true;
        for (int i = 0; i < stunTime; i++){
            if (transform.position.x > ogPosition.x){
                transform.position = ogPosition;
                transform.position += new Vector3(-stunMovement, 0f);
            }
            else
            {
                transform.position = ogPosition;
                transform.position += new Vector3(stunMovement, 0f);
            }
            Debug.Log(ogPosition);
            yield return new WaitForSeconds(.01f);
        }
        transform.position = ogPosition;
        playerScript.stunned = false;

    }

    void OnTriggerExit2D(Collider2D other) {
        if (isPlayer)
        {
            playerRB.velocity = Vector2.zero;
        }
    }

    void TakeDamage(int damageTaken) 
    {
        health -= damageTaken;
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
