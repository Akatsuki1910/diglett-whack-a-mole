using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HammerTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI KeyText;
    [SerializeField] private Transform TrackingSpace;

    void Start()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;
        rb.angularDrag = 0;
        rb.drag = 0;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    private void Update()
    {
        Vector3 localPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        Vector3 lpos = TrackingSpace.TransformPoint(localPos);
        
        Quaternion localRot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
        // Vector3 lrot = TrackingSpace.TransformDirection(localRot.eulerAngles);
        
        
        transform.position = lpos;
        transform.rotation = TrackingSpace.rotation * localRot;
    }

    private void OnCollisionExit(Collision collision)
    {
        KeyText.text = "hazureta" + collision.gameObject.tag;
        GetComponent<Renderer>().material.color = Color.blue;
    }

    private void OnCollisionEnter(Collision collision)
    {
        KeyText.text = "hit" + collision.gameObject.tag;
        GetComponent<Renderer>().material.color = Color.red;

        if (collision.gameObject.tag == "Mole")
        {
            Destroy(collision.gameObject);
        }
    }
}