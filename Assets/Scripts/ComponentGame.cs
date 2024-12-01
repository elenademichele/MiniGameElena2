using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComponentGame : MonoBehaviour
{
    public List<GameObject> components; // Lista di prefab dei componenti
    public TMP_InputField inputField;   // Campo per l'input
    public Button submitButton;         // Bottone per inviare
    public TextMeshProUGUI feedbackText; // Testo per il feedback

    private GameObject currentComponent; // Componente attuale visualizzato
    private string correctAnswer;        // Risposta corretta

    private int prevIndex; //contiene l'ultima immagine

    void Start() 
    {
        // Assegna il listener al botton
        submitButton.onClick.AddListener(CheckAnswer);
        prevIndex=-1;
        // Mostra il primo componente
        ShowRandomComponent();
        feedbackText.text = "Inserisci il nome della componente! ";
    }

    void ShowRandomComponent()
    {
        int randomIndex;

        // Cancella il feedback e l'input
        feedbackText.text = "";
        inputField.text = "";

        // Se esiste già un componente, lo rimuove
        if (currentComponent != null)
        {
            Destroy(currentComponent);
        }

        // Scegli un componente casuale dalla lista
        do
          randomIndex = Random.Range(0, components.Count);
        while (randomIndex == prevIndex);

        GameObject prefab = components[randomIndex];
        prevIndex = randomIndex;
        // Instanzia il componente al centro dello schermo
        currentComponent = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        correctAnswer = prefab.name.ToLower(); // La risposta corretta è il nome del prefab
    }

    void CheckAnswer()
    {
        // Leggi l'input dell'utente
        string userInput = inputField.text.Trim().ToLower();

        // Controlla se la risposta è corretta
        if (userInput == correctAnswer)
        {
                        ShowRandomComponent(); // Mostra un altro componente
            feedbackText.text = "Corretto!";
        }
        else
        {
            feedbackText.text = "Sbagliato! Riprova.";
        }
    }
}
