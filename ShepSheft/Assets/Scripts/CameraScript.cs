using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    void Update ()
    {
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0));
    }
}
