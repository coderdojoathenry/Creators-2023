using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
  public float MoveSpeed = 10.0f;
  private ShipControls _controls;

  private void Awake()
  {
    _controls = new ShipControls();
  }

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 moveInput = _controls.Ship.Move.ReadValue<Vector2>();

    transform.position = transform.position +
                         new Vector3(moveInput.y * MoveSpeed * Time.deltaTime,
                                     0,
                                     -moveInput.x * MoveSpeed * Time.deltaTime);
  }

  private void OnEnable()
  {
    _controls.Enable();
  }

  private void OnDisable()
  {
    _controls.Disable();
  }
}
