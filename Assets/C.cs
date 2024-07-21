using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class C : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI KeyText;
    
    private static int count = 0;
    
    void Start()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        // rb.useGravity = false;
        rb.angularDrag = 0;
        rb.drag = 0;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
    
    void Update()
    {
        transform.Rotate(Vector3.up * 90 * Time.deltaTime);
        // Vector3 pos = transform.position;
        // pos.y = (float)Math.Sin(count/120.0 * Math.PI * 2);
        // transform.position = pos;

        count++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        KeyText.text = "hit";
        Debug.Log(collision.gameObject.tag);
    }
}
