using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Scene currentScene;
    private float jumpForce = 16.0f;
    private bool grounded = false;
    public TextMeshProUGUI scoreText, pointText;    
    public GameHandler gameHandler;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private LayerMask groundLayer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameHandler = new GameHandler();
        animator = GetComponent<Animator>();
        currentScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        gameHandler.setPlayerPosX(transform.position.x);
        if (gameHandler.getGameStarted())
        {
            Jump();
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("clicked");
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameHandler.setGameStarted(true);
                animator.SetBool("gameStarted", true);
            }               
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Obstacle"))
        {
            Destroy(collision.gameObject);
            gameHandler.setPlayerLife(gameHandler.getPlayerLife() - 1);
            CheckHealth();
            if (gameHandler.getPlayerLife() <= 0)
            {
                SceneManager.LoadScene(currentScene.name);
                gameHandler.restartGameStats();
            }
        }        
    }

    private void Jump()
    {
        var collideGround = Physics2D.OverlapCircle(transform.position + new Vector3(0, -2, 0), 0.3f, groundLayer);
        grounded = collideGround != null;
        animator.SetBool("isGrounded", grounded);
        if (grounded && Input.GetMouseButtonDown(1))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.velocity.Normalize();
        }
    }

    public void CheckHealth()
    {
        switch (gameHandler.getPlayerLife())
        {
            case 0:
                hearts[0].SetActive(false);
                hearts[1].SetActive(false);
                hearts[2].SetActive(false);
                break;
            case 1:
                hearts[0].SetActive(true);
                hearts[1].SetActive(false);
                hearts[2].SetActive(false);
                break;
            case 2:
                hearts[0].SetActive(true);
                hearts[1].SetActive(true);
                hearts[2].SetActive(false);
                break;
            case 3:
                hearts[0].SetActive(true);
                hearts[1].SetActive(true);
                hearts[2].SetActive(true);
                break;
        }
    }
}
