using UnityEngine;

public class SphereScript : MonoBehaviour
{
    void Start()
    {
        // Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        // rb.isKinematic = false;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
