using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnContact : MonoBehaviour
{
  public UnityEvent OnContactEvent;

  private void OnTriggerEnter(Collider other)
  {
    if (OnContactEvent != null)
      OnContactEvent.Invoke();
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (OnContactEvent != null)
      OnContactEvent.Invoke();
  }

}
