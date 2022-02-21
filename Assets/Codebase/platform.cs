using UnityEngine;

public class platform : MonoBehaviour
{

    #region Veriables

    public SpriteRenderer SpriteRenderers;
    public Sprite Sprites;
    public Transform _Transformplatform;
    public bool _isMashinGun;
    public GameObject _bulletPrefab;
    private Transform _ballTransform;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        _ballTransform = FindObjectOfType<Ball>().transform;
    }

    private void Update()
    {
        MovePlatform();
    }

    #endregion

    #region Public methods

    public void ChangeMagnitPlatform()
    {
        SpriteRenderers.sprite = Sprites;
    }
    public void ScalePlatformUp()
    {
        Vector3 localChangeScale = new Vector3(1, 0, 0);
        _Transformplatform.localScale += localChangeScale;

    }
    public void ScalePlatformDown()
    {
        Vector3 localChangeScale = new Vector3(0.5f, 0, 0);
        _Transformplatform.localScale -= localChangeScale;
    }

    #endregion

    #region Privet Methods
    private void MovePlatform()
    {
        if (GameManager.Instanse.NeedAutoPlay)
        {
            MovePlatformWithBall();
        }
        else
        {
            if (_isMashinGun && Input.GetMouseButtonDown(0))
            {
                GameObject _bullet = Instantiate(_bulletPrefab, _Transformplatform.position, Quaternion.identity);
                Bullet component = _bullet.gameObject.GetComponent<Bullet>();
                component.StartBullet();
            }

            MovePlatformWithmouse();
        }
    }

    private void MovePlatformWithmouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 currentPosition = transform.position;
        currentPosition.x = worldPosition.x;
        transform.position = currentPosition;
    }

    private void MovePlatformWithBall()
    {
        Vector3 ballworldPosition = _ballTransform.position;
        Vector3 currentPosition = transform.position;
        currentPosition.x = ballworldPosition.x;
        transform.position = currentPosition;
    }

    #endregion
}
