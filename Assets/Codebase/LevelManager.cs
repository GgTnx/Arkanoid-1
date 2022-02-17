using System;
using UnityEngine;

public class LevelManager : SingletoneMonobehaveor<LevelManager>
{
    #region Variables

    public int _blockCount;

    #endregion
    #region Event

    public event Action OnGameOver;

    #endregion
    #region Unity lifecycle

    private void Start()
    {
        Block[] blocks = FindObjectsOfType<Block>();
        _blockCount = blocks.Length;
        Block.CrushBlock += OnCrushBlock;
    }
    private void OnDisable()
    {
        Block.CrushBlock -= OnCrushBlock;
    }

    #endregion
    #region Privet methods

    private void OnCrushBlock()
    {
        _blockCount--;
        if(_blockCount<=0)
            OnGameOver?.Invoke();
    }
    #endregion

 
    

}
