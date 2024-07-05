public interface IGameObserver
{
    void UpdateScore(int newScore);
    void UpdateHealth(int newHealth);
    void GameOver();
}
