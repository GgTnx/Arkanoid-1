using UnityEngine;

public class PauseManager : SingletoneMonobehaveor<PauseManager>
{
    #region Properties

    public bool IsPaused { get; private set; } = false;

    #endregion
    #region Unity lifecycle

    void Update()
    {
        if (IsEscapePressed())
        {
            TogglePause();
        }
    }
 
    #endregion

    #region Private methods
    private bool IsEscapePressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    private void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
    }

    #endregion
}
