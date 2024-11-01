using Normal.Realtime;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class HoopTrigger : MonoBehaviour
{
    [SerializeField]
    public Realtime realTime;
    public GameObject ball;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {
            ball.GetComponent<ForceDrop>().Drop();
            ball.GetComponent<HoopTracker>().TriggerHoop();
        }
    }
}