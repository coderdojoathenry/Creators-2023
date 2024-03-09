using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvController : MonoBehaviour
{
  public GameObject[] EnvPrefabs;
  public float Spacing = 100.0f;
  public float Speed = 50.0f;
  public int Count = 6;

  private Vector3 _spawnPoint;
  private GameObject _lastGo;

  // Start is called before the first frame update
  void Start()
  {
    // Calculate the spawn point based on spacing and count
    _spawnPoint = Vector3.right * Count * Spacing;

    // Preload
    Preload();
  }

  // Update is called once per frame
  void Update()
  {
    if (_lastGo == null)
      return;

    float distToLast = Vector3.Magnitude(_lastGo.transform.position -
                                         _spawnPoint);
    if (distToLast >= Spacing)
    {
      _lastGo = CreatePrefab(_spawnPoint);
    }
  }

  private void Preload()
  {
    for (int i = 0; i < Count; i++)
    {
      Vector3 pos = Vector3.right * i * Spacing;
      _lastGo = CreatePrefab(pos);
    }
  }

  private GameObject CreatePrefab(Vector3 position)
  {
    // Pick a random prefab
    int numPrefabs = EnvPrefabs.Length;
    GameObject prefab = EnvPrefabs[Random.Range(0, numPrefabs)];

    // Create an instance of it
    Quaternion rotation = Quaternion.Euler(0, -90, 0);
    GameObject go = Instantiate(prefab, position,
                                rotation, transform);

    // Add DestroyAfterDistance to it
    DestroyAfterDistance dad = go.AddComponent<DestroyAfterDistance>();
    dad.Distance = 700.0f;

    // Add MoveWithEnvironment to it
    MoveWithEnvironment mwe = go.AddComponent<MoveWithEnvironment>();
    mwe.EnvController = this;

    // Return it
    return go;
  }
}
