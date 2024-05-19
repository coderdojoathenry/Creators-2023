using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyController : MonoBehaviour
{
  public GameObject MissilePrefab;
  public Transform MissileSpawnPoint;
  public float FireEvery;

  // Start is called before the first frame update
  void Start()
  {
    Shoot();      
  }

  private void Shoot()
  {
    if (MissilePrefab == null)
      return;

    Instantiate(MissilePrefab,
                MissileSpawnPoint.position,
                MissileSpawnPoint.rotation);

    Invoke("Shoot", FireEvery);
  }
}
