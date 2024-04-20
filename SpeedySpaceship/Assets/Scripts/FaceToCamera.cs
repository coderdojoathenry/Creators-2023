using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FaceToCamera : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    transform.LookAt(Camera.main.transform);
    transform.Rotate(0, 180, 0);
  }
}
