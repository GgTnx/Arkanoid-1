using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    #region Veriables

    public GameObject _kuskiPrefab;
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

  

    private void OnCollisionEnter2D(Collision2D col)
    {
        SeekAndDestroy();
    }

 

    #endregion

    public void SeekAndDestroy()
    {
        AudioManager.Instanse.PlayOnShot(AudioClip);
        GameManager.Instanse.AddScore(Score);
        CreatePickUpIsNeeded();
        DestroyObject();
        CrushBlock?.Invoke();
    }
    public void DestroyObject()
    {
        GameObject instantiate = Instantiate(_kuskiPrefab, transform.position, Quaternion.identity);
        Kuski kuski = instantiate.GetComponent<Kuski>();
        kuski.PoletKuskovright();
        GameObject instantiate1 = Instantiate(_kuskiPrefab, transform.position, Quaternion.identity);
        Kuski kuski1 = instantiate1.GetComponent<Kuski>();
        kuski1.PoletKuskovLeft();
        Destroy(gameObject); 
    }
    private void CreatePickUpIsNeeded()
    {
        float randomChance = Random.Range(0.1f, 100f);
        if (randomChance <= _pickUpChance)
        {
            
            Instantiate(_scoreUpPickUpPrefab, transform.position, Quaternion.identity);
        }
   
    }
    


}


