using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
  public int Lives = 3;
  public GameObject[] LifeIcons;

  public EnvController EnvController;
  public GameObject Player;

  public TMP_Text ScoreText;
  public GameObject GameOver;
  public TMP_Text FinalScore;

  public int ScorePerSecond = 10;

  public float GameOverDelay = 2.0f;
  public SceneChange SceneChange;

  private float _score = 0;
  private float _finalScore = -1;

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    if (LifeIcons != null)
    {
      for (int i = 0; i < LifeIcons.Length; i++)
      {
        LifeIcons[i].SetActive(i < Lives);
      }
    }

    if (Lives < 1)
    {
      DoGameOver();
    }

    _score += Time.deltaTime * ScorePerSecond;

    if (ScoreText != null)
    {
      ScoreText.text = _score.ToString("0");
    }
  }

  public void LoseLife()
  {
    Lives--;
  }

  private void DoGameOver()
  {
    // Beacuse score keeps increasing, even after
    // game over, we need to record the final score one time
    if (_finalScore < 0)
      _finalScore = _score;

    // Stop the environment moving and disable the player
    if (EnvController != null)
      EnvController.Speed = 0;
    if (Player != null)
      Player.SetActive(false);

    // Hide the score and show the game over
    ScoreText.gameObject.SetActive(false);
    GameOver.SetActive(true);
    FinalScore.text = string.Format("Final Score: {0}", _finalScore.ToString("0"));

    // Change to the start screen
    if (SceneChange != null)
      SceneChange.Invoke("Run", GameOverDelay);
  }

  public void IncreaseScore(int scoreInc)
  {
    _score += scoreInc;
  }
}
