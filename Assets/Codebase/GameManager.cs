using System;
using UnityEngine;

public class GameManager : SingletoneMonobehaveor<GameManager>
{
  #region Variables
[Header("Lives Settings")]
  [SerializeField] private int _maxlives=5;
  [SerializeField] private int _startlives =3;
  [Header("Autoplay")]
  [SerializeField] private bool _needAutoPlay;
  private int _currentLives;

  private bool _isGameOver;
 [SerializeField] private float _autoPlayTimeScale=5f;

  #endregion

  #region Event

  public event Action OnLivesChanged;

  #endregion
 
  #region Properties
  public int Score { get; private set; }
  public int CurrentLives
  {
    get => _currentLives;
     set
    {
      _currentLives = value;
    }
  }
  public int MaxLives =>_maxlives;

  public bool NeedAutoPlay => _needAutoPlay;

  #endregion

  #region Unity lifecycle

  protected override void Awake()
  {
    base.Awake();
    CurrentLives = _startlives;
  }

  private void Start()
  {
    LevelManager.Instanse.OnGameOver += GameOver;
   
  }

  private void Update()
  {
    UpdateTimeScale();
  }


  private void OnDestroy()
  {
    LevelManager.Instanse.OnGameOver -= GameOver;
   }

  #endregion

  #region Public methods

  public void Reload()
  {
    Score = 0;
    
  }

  public void AddScore (int score)     ////// разобраться тут м ГамеОвером 
  {
    Score += score;
    _isGameOver = false;
  }

  public void RemoveLives()
  {
    if (CurrentLives <= 0)
    {
      return;
    }
    CurrentLives--;
    OnLivesChanged?.Invoke();

    if (CurrentLives <= 0)
    {
      // доделать ГамеОвер
    }
  }

  public void AddLives()
  {
    if (CurrentLives >= _maxlives)
    {
      return;
    }
    CurrentLives++;
    OnLivesChanged?.Invoke();


  }

  #endregion

  #region privet methods

  private void UpdateTimeScale()
  {
    if (PauseManager.Instanse.IsPaused)
    {
      return;
    }
    Time.timeScale = _needAutoPlay ? _autoPlayTimeScale : 1;
  }

  private void GameOver()
  {
    if(_isGameOver)
      return;
    
    _isGameOver = true;
    Debug.Log($"GameOver");
  }


  #endregion
}
