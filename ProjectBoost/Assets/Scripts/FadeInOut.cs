using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] float durationOfColor = 2f;
    [SerializeField] float speedOfFade = 1f;
    Image image;

    void Awake() 
    {
        image = GetComponent<Image>();
    }

    public void FadeInBlack()
    {
        image.CrossFadeAlpha(1, speedOfFade, false);
        
    }

    public void FadeOutBlack()
    {
        image.CrossFadeAlpha(0, speedOfFade, false);
    }
}
