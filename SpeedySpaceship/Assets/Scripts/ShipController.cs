using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipController : MonoBehaviour
{
  public float MoveSpeed = 10.0f;
  public float TiltSpeed = 10.0f;
  public float TiltLimit = 10.0f;

  public GameObject StandardShip;
  public GameObject InvulnerableShip;

  public Vector2 Bounds;

  public GameObject MissilePrefab;
  public Transform MissileSpawnPoint;
  public float FireRate = 1.0f;

  private ShipControls _controls;
  private float _minTimeBetweenShots;
  private float _lastShotTime = -10.0f;
  private bool _shootingDisabled = false;

  private AudioSource _audioSource;
  private Collider _collider;

  private void Awake()
  {
    _controls = new ShipControls();
  }

  // Start is called before the first frame update
  void Start()
  {
    _minTimeBetweenShots = 1.0f / FireRate;
    _audioSource = GetComponent<AudioSource>();
    _collider = GetComponent<Collider>();
  }

  // Update is called once per frame
  void Update()
  {
    // Movement
    Vector2 moveInput = _controls.Ship.Move.ReadValue<Vector2>();
    float tiltTarget = 0.0f;

    if (moveInput.x < 0)
      tiltTarget = TiltLimit;
    else if (moveInput.x > 0)
      tiltTarget = -TiltLimit;

    Vector3 newPos = transform.position +
                         new Vector3(moveInput.y * MoveSpeed * Time.deltaTime,
                                     0,
                                     -moveInput.x * MoveSpeed * Time.deltaTime);
    if (newPos.x > Bounds.x)
      newPos = new Vector3(Bounds.x, newPos.y, newPos.z);

    if (newPos.x < -Bounds.x)
      newPos = new Vector3(-Bounds.x, newPos.y, newPos.z);

    if (newPos.z > Bounds.y)
      newPos = new Vector3(newPos.x, newPos.y, Bounds.y);

    if (newPos.z < -Bounds.y)
      newPos = new Vector3(newPos.x, newPos.y, -Bounds.y);

    transform.position = newPos;

    Quaternion targetRotation = Quaternion.Euler(tiltTarget, 0, 0);
    float rotationDiff = Quaternion.Angle(targetRotation,
                                          transform.rotation);
    float timeToRotate = rotationDiff / TiltSpeed;
    float rotationProportion = Time.deltaTime / timeToRotate;

    transform.rotation = Quaternion.Slerp(transform.rotation,
                                          targetRotation,
                                          rotationProportion);

    // Shooting
    if (_shootingDisabled == false &&
        _controls.Ship.Shoot.WasPerformedThisFrame())
    {
      Shoot();
    }
  }

  private void Shoot()
  {
    if (Time.time - _lastShotTime < _minTimeBetweenShots)
      return;

    // Create a missile at the missile spawn point
    Instantiate(MissilePrefab,
                MissileSpawnPoint.position,
                MissileSpawnPoint.rotation);

    _lastShotTime = Time.time;

    if (_audioSource != null)
      _audioSource.Play();
  }

  private void OnEnable()
  {
    _controls.Enable();
  }

  private void OnDisable()
  {
    _controls.Disable();
  }

  private void OnTriggerEnter(Collider other)
  {
    SetModeInvulnerable();
  }

  private void OnCollisionEnter(Collision collision)
  {
    SetModeInvulnerable();
  }

  private void SetMode(bool isInvulnerable)
  {
    // Set the ship models on/off
    StandardShip.SetActive(!isInvulnerable);
    InvulnerableShip.SetActive(isInvulnerable);

    // Set shooting on/off
    _shootingDisabled = isInvulnerable;

    // Set contact on/off
    _collider.enabled = !isInvulnerable;
  }

  public void SetModeNormal()
  {
    SetMode(false);
  }

  public void SetModeInvulnerable()
  {
    SetMode(true);

    Invoke("SetModeNormal", 2.0f);
  }

}
