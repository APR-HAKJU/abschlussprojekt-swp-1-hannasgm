using UnityEngine;

public class Hinweisfeld : MonoBehaviour
{
    public GameObject textToShow; //Hinweistext Objekt einfügen
    public bool toggleOnClick = true; // Hinweis bei Klick einschalten
    public float automatischAusblenden = 0; // 0 = nicht automatisch ausblenden bzw. Zeit in Sekunden bis zum Ausblenden

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        if (textToShow != null)
            textToShow.SetActive(false); // Hinweis anfangs ausblenden
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // linksklick
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) //Raycast auf Objekt schießen
            {
                if (hit.transform == transform)
                {

                    if (toggleOnClick)
                    {
                        bool newState = !textToShow.activeSelf;
                        textToShow.SetActive(newState); //nach linksklick auf aktiv setzen damit sichtbar

                        if (newState && automatischAusblenden > 0f)
                            Invoke(nameof(HideText), automatischAusblenden); //Hinweis nach Zeitablauf ausblenden
                    }
                }
            }
        }
    }

    void HideText()
    {
        if (textToShow != null)
            textToShow.SetActive(false);
    }
}