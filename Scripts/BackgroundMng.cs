using UnityEngine;

public class BackgroundMng : MonoBehaviour
{
    private Vector2 moveDir = Vector2.left;
    private GameHandler gameHandler;
    [SerializeField] private GameObject img1, img2;

    void Start()
    {
        gameHandler = new GameHandler();
    }

    void Update()
    {
        

        if (gameHandler.getGameStarted())
        {
            transform.Translate(moveDir * gameHandler.getObstacleMoveSpeed() * Time.deltaTime);
        }

        if(img1.transform.position.x < -30.24f)
        {
            img1.transform.position = new Vector3(26.67f, transform.position.y, transform.position.z);
        }
        
        if (img2.transform.position.x < -30.24f)
        {
            img2.transform.position = new Vector3(26.67f, transform.position.y, transform.position.z);
        }

    }
}
