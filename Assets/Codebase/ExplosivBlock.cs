using UnityEngine;

public class ExplosivBlock : MonoBehaviour
{
    #region Veriables

    private int _Score = 30;
    public AudioClip AudioClip;
    public float _radius;
    public LayerMask _Layer;

    #endregion

    #region Privet Methods

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        SeekAndDestroy();
    }

    #endregion

    #region Public Methods

    public void SeekAndDestroy()
    {
        AudioManager.Instanse.PlayOnShot(AudioClip);
        GameManager.Instanse.AddScore(_Score);
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, _radius, _Layer);
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
            else

            {
                Block block = collider.gameObject.GetComponent<Block>();
                block.SeekAndDestroy();
            }
        }

        Destroy(gameObject);
    }

    #endregion
}