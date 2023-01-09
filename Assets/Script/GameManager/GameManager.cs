using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DoodleJump
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
        void Update()
        {
            scoreText.text = "Score: " + PlayerController.score;
        }
    }
}
