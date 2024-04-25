using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
  public GameObject DestroyPrefab;

  private void OnTriggerEnter(Collider other)
  {

    if (DestroyPrefab != null)
    {
      Instantiate(DestroyPrefab, transform.position,
                                 transform.rotation,
                                 other.transform);
    }

    Destroy(gameObject);
  }
}
