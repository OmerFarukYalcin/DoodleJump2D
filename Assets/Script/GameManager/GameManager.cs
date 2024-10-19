using UnityEngine;
using TMPro;

namespace DoodleJump
{
    public class GameManager : MonoBehaviour
    {
        // Reference to the UI Text component that will display the score.
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Update()
        {
            // Update the score text with the current score from the PlayerController.
            // Assumes PlayerController.score is a static variable.
            scoreText.text = $"Score: {PlayerController.score}";
        }
    }
}
