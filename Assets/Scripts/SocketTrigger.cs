using UnityEngine;
using TMPro;

public class SocketTrigger : MonoBehaviour
{
    [SerializeField] private GameObject textDisplay;
    [SerializeField] private string requiredObjectName = "rightObject";

    void Start()
    {
        if (textDisplay != null)
        {
            textDisplay.GetComponent<TextMeshProUGUI>().text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Überprüfung über Namen
        if (other.name == requiredObjectName)
        {
            Debug.Log("Korrekt! Objekt erkannt: " + other.gameObject.name);
            ShowSuccess();
            return;
        }

        Debug.Log("Falsches Objekt!");
    }

    private void ShowSuccess()
    {
        if (textDisplay != null)
        {
            textDisplay.GetComponent<TextMeshProUGUI>().text = "Hier ist deine Rechenaufgabe um den Rätsel zu entkommen: Was ist 2²?";
        }
        else
        {
            Debug.LogWarning("Kein TextMeshProUGUI zugewiesen!");
        }
    }
}
