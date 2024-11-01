using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TopTrigger : MonoBehaviour
{
    public GameObject ball;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {
            ball.GetComponent<HoopTracker>().TriggerTop();
        }
    }
}
