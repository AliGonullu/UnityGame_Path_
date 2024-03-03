using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private PlayerHandler player;
    private int maxPoint = 3;

    private void Start()
    {
        player = GetComponentInParent<PlayerHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            ObstacleMovement obstacle = collision.gameObject.GetComponent<ObstacleMovement>();
            float pointXRef = player.transform.position.x + 1;

            obstacle.gainedScore = (int)(maxPoint*1.5f / Mathf.Abs(pointXRef - obstacle.transform.position.x));
            obstacle.gainedScore = Mathf.Clamp(obstacle.gainedScore, 1, maxPoint);                     
            
            Destroy(collision.gameObject);

            player.gameHandler.setScore(player.gameHandler.getScore() + obstacle.gainedScore);
            player.scoreText.SetText("Score : " + player.gameHandler.getScore().ToString());

            switch (obstacle.gainedScore)
            {
                case 1:
                    player.pointText.color = Color.white;                    
                    break;
                case 2:
                    player.pointText.color = new Color(255, 165, 0);                    
                    break;
                case 3:
                    player.pointText.color = Color.red;                    
                    break;            
            }
            player.pointText.SetText(obstacle.gainedScore.ToString());
        }
    }
}
