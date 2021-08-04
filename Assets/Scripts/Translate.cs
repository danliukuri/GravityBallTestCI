using UnityEngine;

public class Translate : MonoBehaviour
{
    [SerializeField] Vector3 translation;
	
	void FixedUpdate()
    {
        transform.Translate(translation);
	}
}