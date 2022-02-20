using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Veriables
    public Rigidbody2D Rb; 
    public float Speed;
    public Vector2 Direction;
    public Transform PlatformTransform;
    public AudioClip _Clip;
    private bool _isStarted;
    public bool _isMagnite;
    public Transform ballScale;
    private Vector3 _magnitPositiont;
    private float _deltaX;
    private float _deltaY = 0.57f;
    public bool _isExplosiv;
    public GameObject _explosivBlock;
    public float _radius;
    public LayerMask _Layer;
    

    #endregion
    #region Unity lifecycle

    private void Start()
    {
        if (GameManager.Instanse.NeedAutoPlay)
        {
            StartBall();
        }
    }

    private void Update()
    {
        if (_isStarted)
            return;
        
        MoveBallIfMagnite();
        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    #endregion
    #region public methods


    public void ScaleUp()
    {
        Vector3 localChangeScale = new Vector3(1, 1, 0);
        ballScale.transform.localScale += localChangeScale;
    }
    public void ScaleDown()
    {
        Vector3 localChangeScale = new Vector3(0.5f, 0.5f, 0);
        ballScale.transform.localScale -= localChangeScale;
    }

    public void Restart()
    {
       
    }

    #endregion
    #region Private methods
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position,Direction);
    }
    private void OnCollisionEnter2D(Collision2D col)

    {
        calculationDeltaX(col);
        if (_isExplosiv)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, _radius,_Layer);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.gameObject == gameObject)
                {
                    continue;
                }
                else if (collider.gameObject.CompareTag(Tags.Invis))
                {
                    Destroy(collider.gameObject);
                }
                else if (collider.gameObject.CompareTag(Tags.Double))
                {
                    DoubleBlock component = collider.gameObject.GetComponent<DoubleBlock>();
                    component.SeekAndDestroy();
                }
                else if (collider.gameObject.CompareTag(Tags.Explosiv))
                {
                    ExplosivBlock component = collider.gameObject.GetComponent<ExplosivBlock>();
                    component.SeekAndDestroy();
                }
                else if(collider.gameObject.CompareTag(Tags.Block))
                {
                    Block block = collider.gameObject.GetComponent<Block>();
                    block.SeekAndDestroy();
                }
                else
                {
                    return;
                }
            }
        }
    }

    private void calculationDeltaX(Collision2D col)
    {
        AudioManager.Instanse.PlayOnShot(_Clip);

        if (col.gameObject.CompareTag(Tags.Platform))
        {
            _deltaX = transform.position.x - PlatformTransform.position.x;
        }
    }

    private void MoveballWithPlatform()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = PlatformTransform.position.x;
        transform.position = currentPosition;
    }

    private void MoveBallIfMagnite()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = PlatformTransform.position.x + _deltaX;
        currentPosition.y = PlatformTransform.position.y + _deltaY;
        transform.position = currentPosition;
       
    }
    public void StartBall()
    {
        Rb.velocity = Direction.normalized * Speed;
        _isStarted = true;
    }

    private void Magnite()
    {

        Rb.velocity = Vector2.zero;
        _isStarted = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    #endregion



   
}