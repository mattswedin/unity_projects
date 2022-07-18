using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 8f;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 minBounds;
    Vector2 maxBounds;
    public bool stunned = false;

    static Player instance;

    Shooter shooter;

    [Header("Power Up")]
    [SerializeField] GameObject powerUpEffect;
    [SerializeField] float poweredUpTime = 15f;
    [SerializeField] float poweredUpSpeed = 2f;
    [SerializeField] bool isPoweredUp = false;

    

    void Awake() 
    {
        ManageSingleton();
        shooter = GetComponent<Shooter>();
    }

    void Start() 
    {
        InitBounds();
    }
    
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene == SceneManager.GetSceneByName("GameOver") ||
            currentScene == SceneManager.GetSceneByName("YouWon"))
        {
            Destroy(instance);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if(isPoweredUp && powerUpEffect != null)
        {
            powerUpEffect.SetActive(true);
        }
        else
        {
            powerUpEffect.SetActive(false);
        }

        if (!stunned)
        {
            Move();
        }   
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    void Move()
    {
        Vector2 delta;
        if(isPoweredUp)
        {
            delta = rawInput * moveSpeed * poweredUpSpeed * Time.deltaTime;
        }
        else
        {
            delta = rawInput * moveSpeed * Time.deltaTime;
        }
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;

    }

    void OnMove(InputValue value) 
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue button) 
    {
        if (!stunned)
        {
            shooter.isFiring = button.isPressed;
        }
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    //Power Up

    public bool getPoweredUp() 
    {
        return isPoweredUp;
    }

    public float getPoweredUpTime()
    {
        return poweredUpTime;
    }

    public void setPoweredUp(bool state)
    {
        isPoweredUp = state;
    }

    

}
