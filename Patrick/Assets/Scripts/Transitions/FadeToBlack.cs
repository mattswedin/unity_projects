using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField] float durationOfColor = 2f;
    [SerializeField] float speedOfFade = 1f;
    [SerializeField] Image black;

    private void Awake()
    {
        black.gameObject.SetActive(true);
    }

    public void FadeInBlack()
    {
        black.CrossFadeAlpha(1, speedOfFade, false);

    }

    public void FadeOutBlack()
    {
        black.CrossFadeAlpha(0, speedOfFade, false);
    }

    public void CutToBlack()
    {
        black.CrossFadeAlpha(1, 0, false);
    }
}
