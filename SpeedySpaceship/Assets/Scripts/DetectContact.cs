using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectContact : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    Debug.Log("OnTriggerEnter " + gameObject.name);
  }

  private void OnCollisionEnter(Collision collision)
  {
    Debug.Log("OnCollisionEnter " + gameObject.name);
  }
}
