using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private CharacterController cc;
    float pushPower = 2f;
    void Start()
    {
        cc = GetComponent<CharacterController>();

    }
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * 100f * Time.deltaTime);
        //Move関数では、重力は自分で設定する必要がある
        cc.Move(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * 5.0f);
        //ジャンプしない場合はSimpleMove  重力設定あり
        // cc.SimpleMove(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * 500.0f);
        //charadtercontrollerで動かす場合は、MoveかSimpleMove　ジャンプする場合がほとんどなので、だいたいはMove
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb == null || rb.isKinematic)
        {
            return;
        }
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        rb.velocity = pushDir * pushPower;
    }
}

