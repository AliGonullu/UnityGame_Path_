
public class GameHandler
{
    private static bool gameStarted = false;
    private static int score = 0, playerLifeCounter = 3;
    private static float obstacleMoveSpeed = 4.17f, playerPosX;

    public bool getGameStarted()
    {
        return gameStarted;
    }
    public void setGameStarted(bool _gameStarted)
    {
        gameStarted = _gameStarted;
    }

    public int getScore()
    {
        return score;
    }
    public void setScore(int _score)
    {
        score = _score;
    }

    public int getPlayerLife()
    {
        return playerLifeCounter;
    }
    public void setPlayerLife(int _playerLifeCounter)
    {
        playerLifeCounter = _playerLifeCounter;
    }

    public float getObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }
    public void setObstacleMoveSpeed(float _obstacleMoveSpeed)
    {
        obstacleMoveSpeed = _obstacleMoveSpeed;
    }

    public float getPlayerPosX()
    {
        return playerPosX;
    }
    public void setPlayerPosX(float _playerPosX)
    {
        playerPosX = _playerPosX;
    }

    public void restartGameStats()
    {
        gameStarted = false;
        score = 0;
        playerLifeCounter = 3;
        obstacleMoveSpeed = 5.0f;
    }

}
