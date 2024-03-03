using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private Vector2 moveDir = Vector2.left;
    private GameHandler gameHandler;
    public int gainedScore = 1;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameHandler = new GameHandler();
    }

    void Update()
    {

        if (gameHandler.getGameStarted()){
            transform.Translate(gameHandler.getObstacleMoveSpeed() * moveDir * Time.deltaTime);
            if (animator != null)
            {
                animator.SetBool("playerInRange", (Mathf.Abs(gameHandler.getPlayerPosX() - transform.position.x) < 5.5f));
            }            
        }
        
        if(transform.position.x < -15)
        {
            Destroy(gameObject);    
        }
    }

    private void OnDestroy()
    {
        gameHandler.setObstacleMoveSpeed(
            Mathf.Clamp(gameHandler.getObstacleMoveSpeed() + 0.1f, 0.0f, 18.0f));
    }

}
