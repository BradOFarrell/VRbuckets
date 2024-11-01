using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BottomTrigger : MonoBehaviour
{
    public GameObject ball;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {
            ball.GetComponent<ForceDrop>().Drop();
            ball.GetComponent<HoopTracker>().TriggerBottom();
        }
    }
}
