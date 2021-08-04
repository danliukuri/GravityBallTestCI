using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields
    [SerializeField] Material redMaterial;
    [SerializeField] Material blueMaterial;

    MeshRenderer meshRenderer;
    ConstantForce constantGravity;
    bool isGrounted;
    #endregion

    #region Methods
    void Awake()
    {
        constantGravity = GetComponent<ConstantForce>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounted = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounted = false;
    }

    void Update()
    {
        if(InputHandler.IsPlayerJump() && Time.timeScale > 0f && isGrounted)
        {
            constantGravity.enabled = !constantGravity.enabled;
            meshRenderer.material = constantGravity.enabled ? redMaterial : blueMaterial;
            ScoreCounter.Score++;
        }
    }
    #endregion
}