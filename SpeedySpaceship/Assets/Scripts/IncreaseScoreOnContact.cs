using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScoreOnContact : MonoBehaviour
{
  public int Score;
  private GameManager _gm;

  // Start is called before the first frame update
  void Start()
  {
    _gm = FindObjectOfType<GameManager>();   
  }

  private void OnCollisionEnter(Collision collision)
  {
    IncreaseScore();
  }

  private void IncreaseScore()
  {
    if (_gm != null)
      _gm.IncreaseScore(Score);
  }


}
