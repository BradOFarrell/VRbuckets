using UnityEngine;

public class TrickshotTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the character entered the trigger
        TrickshotTracker tracker = other.GetComponent<TrickshotTracker>();
        if (tracker != null)
        {
            tracker.setTrickshotBonus(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the character entered the trigger
        TrickshotTracker tracker = other.GetComponent<TrickshotTracker>();
        if (tracker != null)
        {
            tracker.setTrickshotBonus(true);
        }
    }
}