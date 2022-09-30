using System;

public interface ICard 
{
    public event Action<ICard> onClick;
    public event Action<ICard> onOpen;

    void Open();
    
    void Close();

    void Kill();

    bool IsSame(ICard other);

}
