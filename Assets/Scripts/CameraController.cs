using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform Hero;
    Vector3 diff;

    void Start()
    {
        diff = transform.position - Hero.position;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Hero.position + diff, 0.5f);
    }
}
