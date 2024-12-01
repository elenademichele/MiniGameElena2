using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomComponentGame : MonoBehaviour
{
    public GameObject[] componentImages; // Array di immagini dei componenti
    public TMP_InputField inputField;    // Campo di input per inserire il nome
    public Button submitButton;          // Bottone per inviare la risposta
    public TextMeshProUGUI feedbackText; // Testo per feedback

    private GameObject currentImage;     // L'immagine attuale mostrata
    private string currentAnswer;        // La risposta corretta per l'immagine

    void Start()
    {
        // Verifica che l'array non sia vuoto
        if (componentImages == null || componentImages.Length == 0)
        {
            Debug.LogError("L'array componentImages è vuoto. Aggiungi immagini tramite l'Inspector.");
            return;
        }
        
        // Nasconde tutte le immagini all'inizio
        foreach (GameObject image in componentImages)
        {
            if (image != null)
            {
                image.SetActive(false);
            }
        }

        // Associa il bottone alla funzione
        submitButton.onClick.AddListener(CheckAnswer);

        // Mostra la prima immagine
        ShowRandomImage();
    }

    void ShowRandomImage()
    {
        // Nasconde l'immagine attuale, se presente
        if (currentImage != null)
        {
            currentImage.SetActive(false);
        }

        // Seleziona un'immagine a caso
        int randomIndex = Random.Range(0, componentImages.Length);
        //randomIndex=0;
        currentImage = componentImages[randomIndex];
        // Controlla che l'immagine selezionata non sia null
        if (currentImage == null)
        {
            Debug.LogError("L'immagine selezionata è null. Controlla l'array componentImages.");
            //return;
        }

        // Mostra l'immagine selezionata
        currentImage.SetActive(true);

        // Imposta la risposta corretta (usa il nome dell'oggetto come risposta)
        currentAnswer = currentImage.name.ToLower();

        // Pulisci il feedback e il campo di input
        feedbackText.text = "Inserisci il nome della componente!";
        inputField.text = "";
    }

    void CheckAnswer()
    {
        // Legge l'input dell'utente
        string userAnswer = inputField.text.Trim().ToLower();

        // Verifica che l'utente abbia inserito qualcosa
        if (string.IsNullOrEmpty(userAnswer))
        {
            feedbackText.text = "Inserisci una risposta!";
            return;
        }

        // Controlla se la risposta è corretta
        if (userAnswer == currentAnswer)
        {
            feedbackText.text = "Corretto! Ecco un'altra componente.";
            ShowRandomImage(); // Mostra un'altra immagine
        }
        else
        {
            feedbackText.text = "[" + userAnswer + " "+ currentAnswer + "] Sbagliato! Riprova.";
        }
    }
}
