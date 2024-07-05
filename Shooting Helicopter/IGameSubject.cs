public interface IGameSubject
{
    void Subscribe(IGameObserver observer);
    void Unsubscribe(IGameObserver observer);
    void NotifyScoreUpdate(int newScore);
    void NotifyHealthUpdate(int newHealth);
    void NotifyGameOver();
}
