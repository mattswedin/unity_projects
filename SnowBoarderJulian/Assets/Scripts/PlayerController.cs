using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float normalSpeed = 30f;
    [SerializeField] float speedSpeed = 40f;
    GameObject finishLine;
    FinishLine finishLineScript;

    GameObject death;
    CrashDetector deathscript;
    // Start is called before the first frame update
    void Start()
    {
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        // death = GameObject.Find("Patree");
        // deathscript = death.GetComponent<CrashDetector>();
        finishLine = GameObject.Find("FinishLine");
        finishLineScript = finishLine.GetComponent<FinishLine>();
        rb2d = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
    
        if (!finishLineScript.GameEnd && !FindObjectOfType<CrashDetector>().dead)
        {
            PatreeSpin();
            RespondToBoost();
        }
        
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = speedSpeed;
        } else if (!(Input.GetKey(KeyCode.Space)))
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    void PatreeSpin()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }

    }
}
