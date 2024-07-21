using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    GameObject rightController;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            GameObject go = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere));
            go.transform.position = rightController.transform.position;
            go.transform.localScale *= 0.1f;
            go.gameObject.tag = "Mole";
            Collider c = go.gameObject.GetComponent<Collider>();
            c.isTrigger = false;

            // 球体に衝突スクリプトを追加
            // go.AddComponent<MoleCollisionHandler>();
        }
    }
}
