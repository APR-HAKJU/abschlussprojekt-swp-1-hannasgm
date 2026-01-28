using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] private Transform holdPosition;
    private GameObject heldObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
                TryPickup();
            else
                Drop();
        }
    }

    void TryPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
        {
            if (hit.collider.CompareTag("Moveable"))
            {
                heldObject = hit.collider.gameObject;
                Rigidbody rb = heldObject.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.isKinematic = true;

                heldObject.transform.parent = holdPosition;
                heldObject.transform.localPosition = Vector3.zero;

                Debug.Log("Aufgehoben!");
            }
        }
    }

    void Drop()
    {
        heldObject.transform.parent = null;

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;

        Debug.Log("Abgelegt!");
        heldObject = null;
    }
}
