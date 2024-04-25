using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvController : MonoBehaviour
{
  public GameObject[] EnvPrefabs;
  public float Spacing = 100.0f;
  public float Speed = 50.0f;
  public int Count = 6;

  public float ChanceOfObstacle = 0.2f;
  public GameObject[] ObstaclePrefabs;

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

  void FixedUpdate()
  {
    if (_lastGo == null)
      return;

    float distToLast = Vector3.Magnitude(_lastGo.transform.position -
                                         _spawnPoint);
    if (distToLast >= Spacing)
    {
      Vector3 spawnAt = _lastGo.transform.position + Vector3.right * Spacing;

      _lastGo = CreatePrefab(spawnAt);
    }
  }

  private void Preload()
  {
    for (int i = 0; i < Count; i++)
    {
      Vector3 pos = Vector3.right * i * Spacing;
      _lastGo = CreatePrefab(pos, false);
    }
  }

  private GameObject CreatePrefab(Vector3 position, bool createObstacles = true)
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
    dad.Distance = 1000.0f;

    // Add MoveWithEnvironment to it
    MoveWithEnvironment mwe = go.AddComponent<MoveWithEnvironment>();
    mwe.EnvController = this;

    // Create obstacle?
    if (createObstacles && Random.value <= ChanceOfObstacle)
    {
      // Create an obstacle as a child of this piece of env
      CreateObstacle(position, go.transform);
    }

    // Return it
    return go;
  }

  private void CreateObstacle(Vector3 position, Transform transform)
  {
    // Pick a random prefab
    int numPrefabs = ObstaclePrefabs.Length;
    GameObject prefab = ObstaclePrefabs[Random.Range(0, numPrefabs)];

    // Create an instance of it
    Quaternion rotation = Quaternion.Euler(0, -90, 0);
    GameObject go = Instantiate(prefab, position,
                                rotation, transform);

  }
}
