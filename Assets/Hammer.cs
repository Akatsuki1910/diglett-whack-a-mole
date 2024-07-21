using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hammer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI KeyText;
    private static int count = 0;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        
        SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.radius = 0.1f;
        // sphereCollider.isTrigger = true;

        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;
        rb.angularDrag = 0;
        rb.drag = 0;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    // private void OnTriggerEnter(Collider collision)
    private void OnCollisionEnter(Collision collision)
    {
        KeyText.text = "hit";
        // 衝突対象が特定のオブジェクトである場合
        if (collision.gameObject.CompareTag("Mole"))
        {
            // スコアを更新
            count++;
            KeyText.text = "Score: " + count;

            Renderer ballRenderer = collision.gameObject.GetComponent<Renderer>();
            if (ballRenderer != null)
            {
                ballRenderer.material.color = Color.blue;
            }
        }
    }
}
