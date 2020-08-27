using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
 bool MaintainWidth = true;
 float DefaultWidth;
 void Start()
 {     
     DefaultWidth = Camera.main.orthographicSize *  0.5f;
     if (MaintainWidth)
     {
         Camera.main.orthographicSize = DefaultWidth / Camera.main.aspect;
     }
 }

}
