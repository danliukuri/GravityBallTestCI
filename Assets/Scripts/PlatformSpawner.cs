using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    #region Fields
    [SerializeField] protected GameObject objectToSpawn;

    [SerializeField] float spawnRare;
    [SerializeField] float minPlatformScaleX;
    [SerializeField] float maxPlatformScaleX;
    float platformScaleY = 1f;
    float platformScaleZ = 1f;
    #endregion

    #region Methods
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        GameObject gameObject = PoolManager.GetGameObject(objectToSpawn.name, transform.position);
        gameObject.transform.localScale = new Vector3(Random.Range(minPlatformScaleX, maxPlatformScaleX), platformScaleY, platformScaleZ);
        yield return new WaitForSeconds(spawnRare);
        StartCoroutine(Spawn());
    }
    #endregion
}