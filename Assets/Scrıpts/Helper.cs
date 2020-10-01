using UnityEngine.EventSystems;
public static class Helper
{
    public static bool IsIdle()
    {
        return GameManager.main.currentState == GameStates.Idle;
    }

    public static bool IsPlaying()
    {
        return GameManager.main.currentState == GameStates.Playing;
    }

    public static bool IsWin()
    {
        return GameManager.main.currentState == GameStates.Win;
    }

    public static bool IsFail()
    {
        return GameManager.main.currentState == GameStates.Fail;
    }

    public static bool IsNotOnUI()
    {
        return EventSystem.current.currentSelectedGameObject == null;
    }
}

