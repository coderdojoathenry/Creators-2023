using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
  public float MoveSpeed = 10.0f;
  public float TiltSpeed = 10.0f;
  public float TiltLimit = 10.0f;

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
    float tiltTarget = 0.0f;

    if (moveInput.x < 0)
      tiltTarget = TiltLimit;
    else if (moveInput.x > 0)
      tiltTarget = -TiltLimit;

    transform.position = transform.position +
                         new Vector3(moveInput.y * MoveSpeed * Time.deltaTime,
                                     0,
                                     -moveInput.x * MoveSpeed * Time.deltaTime);

    Quaternion targetRotation = Quaternion.Euler(tiltTarget, 0, 0);
    float rotationDiff = Quaternion.Angle(targetRotation,
                                          transform.rotation);
    float timeToRotate = rotationDiff / TiltSpeed;
    float rotationProportion = Time.deltaTime / timeToRotate;

    transform.rotation = Quaternion.Slerp(transform.rotation,
                                          targetRotation,
                                          rotationProportion);
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
