using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
  public GameObject DestroyPrefab;

  private void OnTriggerEnter(Collider other)
  {
    DoDestroy(other.transform);
  }

  private void OnCollisionEnter(Collision collision)
  {
    DoDestroy(collision.gameObject.transform);
  }

  private void DoDestroy(Transform otherTransform)
  {
    if (DestroyPrefab != null)
    {
      Instantiate(DestroyPrefab, transform.position,
                                 transform.rotation,
                                 otherTransform);
    }

    Destroy(gameObject);
  }
}
