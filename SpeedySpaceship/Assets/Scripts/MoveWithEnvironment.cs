using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithEnvironment : MonoBehaviour
{
  public EnvController EnvController;

  // Update is called once per frame
  void Update()
  {
    if (EnvController == null)
      return;

    transform.position = transform.position +
      (Vector3.left * EnvController.Speed * Time.deltaTime);
  }
}
