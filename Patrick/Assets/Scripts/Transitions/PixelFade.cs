using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelFade : MonoBehaviour
{
    int numberOfRows;
    int numberOfPixelsPerRow;
    int numberOfPixels;
    [SerializeField] float timeBetweenPixels = -4;

    void Start() 
    {
        numberOfRows = gameObject.transform.childCount;
        numberOfPixelsPerRow = gameObject.transform.GetChild(0).transform.childCount;
        numberOfPixels = numberOfRows * numberOfPixelsPerRow;

        // ArrayList[] rows = new List<List> (new List<List>[numberOfRows]);
        // List<int> pixelsPerRow = new List<int>(new int[numberOfPixelsPerRow]);
        // for (int i = 0; i < numberOfRows; i++)
        // {
        //     numberOfRows[i].Add(pixelsPerRow);
        // }
    }
    
    public IEnumerator FadetoBlack() 
    {
        int pixelCount = 0;

        while (pixelCount < numberOfPixels) 
        {
            int randomRow = UnityEngine.Random.Range(0, numberOfRows);
            int randomPixel = UnityEngine.Random.Range(0, numberOfPixelsPerRow);

            GameObject pixelObj = gameObject.transform.GetChild(randomRow).transform.GetChild(randomPixel).gameObject;

            if (!pixelObj.activeSelf)
            {
                pixelCount += 1;
                pixelObj.SetActive(true);
            }
            yield return new WaitForSeconds(timeBetweenPixels);
        }
    }
}
