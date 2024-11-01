using UnityEngine;

public class IgnoreSpecificCollision : MonoBehaviour
{
    public GameObject objectToIgnore;  // Assign the specific object in the Inspector

    private void Start()
    {
        if (objectToIgnore != null)
        {
            Collider characterCollider = GetComponent<Collider>();
            Collider targetCollider = objectToIgnore.GetComponent<Collider>();

            if (characterCollider != null && targetCollider != null)
            {
                Physics.IgnoreCollision(characterCollider, targetCollider);
            }
            else
            {
                Debug.LogWarning("One of the colliders is missing.");
            }
        }
        else
        {
            Debug.LogWarning("Object to ignore is not assigned.");
        }
    }
}
