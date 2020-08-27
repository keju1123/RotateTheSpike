using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnSwipe : MonoBehaviour
{
    public Transform myRotation;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        myRotation = gameObject.transform;
    }


    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch0 = Input.GetTouch(0);

            // APPLY ROTATION
            if (touch0.phase == TouchPhase.Moved)
            {
                myRotation.transform.Rotate(0f, 0f, touch0.deltaPosition.x*moveSpeed*Time.deltaTime);
            }

        }
    }
}
