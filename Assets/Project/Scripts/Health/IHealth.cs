
public delegate void OnChangeHealth (object sender);
public delegate void OnDead(object sender);

public interface IHealth
{
    public event OnChangeHealth OnChangeHealthEvent;
    public event OnDead OnDeadEvent;
    
    public bool IsDead { get;}
    public int MaxValue { get; }
    public int Value { get; }

    public void AddHealth(object sender, int add);
    public void DeleteHealth(object sender, int delete);
    public void Kill(object sender);
}
