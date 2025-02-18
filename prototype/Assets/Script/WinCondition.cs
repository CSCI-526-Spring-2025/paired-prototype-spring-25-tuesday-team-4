using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public GameObject winPanel; // Assign this in Unity

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false); // Hide the panel at the start
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player reaches the flag
        {
            Debug.Log("Winner!");
            if (winPanel != null)
                winPanel.SetActive(true); // Show the win message
            
            Time.timeScale = 0f; // Pause the game (optional)
        }
    }
}
