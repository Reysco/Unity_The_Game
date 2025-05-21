using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGreenKey : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(100f, 0f, 0f) * Time.deltaTime);
    }
}
