using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
  public float TimeToLive = 1.0f;

  // Start is called before the first frame update
  void Start()
  {
    Invoke("DestroyGameObject", TimeToLive);      
  }

  private void DestroyGameObject()
  {
    Destroy(gameObject);
  }
}
