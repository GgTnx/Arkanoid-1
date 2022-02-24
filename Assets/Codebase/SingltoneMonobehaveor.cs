using UnityEngine;

public class SingletoneMonobehaveor<T> : MonoBehaviour
{
    #region Veriables

    private static T _instance;

    #endregion

    #region Properties

    public static T Instanse => _instance;

    #endregion

    #region Unity lifecycle

    protected virtual void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);

            return;
        }

        _instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }

    #endregion
}