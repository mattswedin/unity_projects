using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShoot : MonoBehaviour
{
    [SerializeField] float pullDown = .5f;
    [SerializeField] Vector3 stoppingPoint = new Vector3(0, -5, 0);
    [SerializeField] Vector3 releasedPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Vector3.Distance(transform.position, stoppingPoint) > 6.017f)
        {
            transform.position -= new Vector3 (0, pullDown, 0);
        }

        if (!(Input.GetKey(KeyCode.DownArrow)))
        {
            transform.position = releasedPosition;
        }
    }
}
