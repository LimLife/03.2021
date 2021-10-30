

using System;

public static class EventHandler
{
    public static event Action<object, int> Hit;

    public static event Action<int> Score;

    public static event Action<object, float> BuffChange;

    public static void TakeDamge(object sender, int damge)
    {
        Hit?.Invoke(sender, damge);
    }
    public static void ScoreRank(int score)
    {
        Score?.Invoke(score);
    }
    public static void BuffCharacter(object sender, float buff)
    {
        BuffChange?.Invoke(sender, buff);
    }
}
