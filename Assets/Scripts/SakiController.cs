using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SakiController : MonoBehaviour
{
    public CharMove charMove;

    void OnTriggerEnter(Collider other)
    {
        if (charMove.isAttacking)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("attack!");
                Destroy(other.gameObject);
            }
        }
    }
}