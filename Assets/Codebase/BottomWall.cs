
using UnityEngine;

public class BottomWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Tags.Ball))
        {
            Ball[] balls = FindObjectsOfType<Ball>();
            if (balls.Length == 1)
            {
                Ball ball = col.gameObject.GetComponent<Ball>();
                ball.Restart();
                GameManager.Instanse.RemoveLives(); // и вернуть на стартовую позицию
            }
            else
            {
                Destroy(col.gameObject);
            }
        }
        
       
    }
}
