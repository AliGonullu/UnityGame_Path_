using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    private GameHandler gameHandler;

    void Start()
    {
        gameHandler = new GameHandler();
        InvokeRepeating("SpawnObstacle", 2, 1.4f);
    }

    void SpawnObstacle()
    {
        if (gameHandler.getGameStarted())
        {
            int idx = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[idx], new Vector3(20, 0, 0), Quaternion.identity);
        }
    }
}
