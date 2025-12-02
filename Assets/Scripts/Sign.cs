using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Sign : MonoBehaviour
{
    [Header("Dialogue UI")]
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public string dialogue;

    [Header("Press E Prompt")]
    public GameObject ePrompt;   // <-- Assign your "E" popup here

    private bool playerInRange;

    void Start()
    {
        if (ePrompt != null)
            ePrompt.SetActive(false);  // Hide at start
    }

    void Update()
    {
        if (!playerInRange)
            return;

        // Show/Hide dialogue on E key
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }
            else
            {
                dialogueBox.SetActive(true);
                dialogueText.text = dialogue;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (ePrompt != null)
                ePrompt.SetActive(true); // Show "E"
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (ePrompt != null)
                ePrompt.SetActive(false); // Hide "E"

            if (dialogueBox != null)
                dialogueBox.SetActive(false);
        }
    }
}
