using UnityEngine;

public class DeactivateOnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SetActive(false);
    }
}