using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _PipePrefab;
    [SerializeField] private GameObject _Container;
    [SerializeField] private float _spawnTime = 2f;
    void Start ()
    {
        StartCoroutine(spawnPipeRoutine());
    }

    IEnumerator spawnPipeRoutine()
    {
        while(true) {
            float randomHeight = Random.Range(-1.5f,2.6f);
            GameObject pipe = Instantiate(_PipePrefab, new Vector2(transform.position.x, randomHeight), Quaternion.identity);
            pipe.transform.SetParent(_Container.transform);
            yield return new WaitForSeconds(_spawnTime);
        }
        
    }
}
