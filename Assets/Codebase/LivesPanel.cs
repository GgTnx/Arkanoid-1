using System.Collections.Generic;
using UnityEngine;

public class LivesPanel : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _liveCellPrefab;
    [SerializeField] private Transform _cellsParrent;
    private readonly List<GameObject> _cells = new List<GameObject>();

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        GameManager.Instanse.OnLivesChanged += UpdateCells;
        InstantiateCells();
        UpdateCells();
    }


    private void OnDisable()
    {
        GameManager.Instanse.OnLivesChanged -= UpdateCells;
    }

    #endregion


    #region privet methods

    private void InstantiateCells()
    {
        for (int i = 0; i < GameManager.Instanse.MaxLives; i++)
        {
            GameObject cell = Instantiate(_liveCellPrefab, _cellsParrent);
            _cells.Add(cell);
        }
    }


    private void UpdateCells()
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            GameObject cell = _cells[i];
            bool isActive = GameManager.Instanse.CurrentLives > i;
            cell.SetActive(isActive);
        }
    }

    #endregion
}