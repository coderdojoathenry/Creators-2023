using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
  public Vector3 Direction = Vector3.forward;
  public float Speed = 10.0f;

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 offset = Direction.normalized * Speed * Time.deltaTime;
    transform.position = transform.position + offset;
  }
}
