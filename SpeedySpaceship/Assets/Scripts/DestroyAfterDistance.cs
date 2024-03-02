using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDistance : MonoBehaviour
{
  public float Distance = 10.0f;

  private Vector3 _initPos;

  // Start is called before the first frame update
  void Start()
  {
    _initPos = transform.position;      
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 offset = _initPos - transform.position;
    float offsetDist = offset.magnitude;

    if (offsetDist >= Distance)
    {
      Destroy(gameObject);
    }
  }
}
