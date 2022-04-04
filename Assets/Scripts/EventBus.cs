using System;

public static class EventBus
{
    public static event Action Generate;
    public static event Action NewGame;
    public static event Action LoadLastGame;

    public static void Dispose()
    {
        Generate = null;
    }

    public static void StartNewGame()
    {
        NewGame?.Invoke();
        Generate?.Invoke();
    }

    public static void StartLastGame()
    {
        LoadLastGame?.Invoke();
        Generate?.Invoke();
    }
}
