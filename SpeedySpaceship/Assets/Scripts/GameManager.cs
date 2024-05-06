using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  public int Lives = 3;
  public GameObject[] LifeIcons;

  public TMP_Text ScoreText;
  public GameObject GameOver;

  public int ScorePerSecond = 10;

  public float GameOverDelay = 2.0f;
  public SceneChange SceneChange;

  private float _score = 0;

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

    _score += ScorePerSecond * Time.deltaTime;

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
    ScoreText.gameObject.SetActive(false);
    GameOver.SetActive(true);

    if (SceneChange != null)
      SceneChange.Invoke("Run", GameOverDelay);
  }
}
