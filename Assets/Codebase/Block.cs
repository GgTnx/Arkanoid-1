using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    #region Veriables

    public AudioClip AudioClip;
    public int Score = 5;
    [SerializeField] private GameObject _scoreUpPickUpPrefab;
    [Range(1f,100f)]
    [SerializeField] private float _pickUpChance;
    

    #endregion
    #region Event

    public static event Action CrushBlock;

    #endregion
    #region privat methods

    private void CreatePickUpIsNeeded()
    {
        float randomChance = Random.Range(0.1f, 100f);
        if (_pickUpChance>=_pickUpChance)
        {
            Instantiate(_scoreUpPickUpPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        AudioManager.Instanse.PlayOnShot(AudioClip);
        GameManager.Instanse.AddScore(Score);
        Destroy(gameObject);
        CreatePickUpIsNeeded();
        CrushBlock?.Invoke();
    }

  

    #endregion


}


