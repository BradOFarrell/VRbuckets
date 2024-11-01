using UnityEngine;

public class TrickshotTracker : MonoBehaviour
{
    public bool trickshotBonus = false;

    public void setTrickshotBonus(bool value)
    {
        trickshotBonus = value;
    }

    public bool getTrickshotBonus()
    {
        return trickshotBonus;
    }
}