using UnityEngine;
using UnityEngine.UI;

namespace EightBallPool.UI
{
    public class GameUI : MonoBehaviour
    {
        [Header("Player Profiles")]
        public Text player1Name;
        public Text player1Level;
        public Text player2Name;
        public Text player2Level;
        
        [Header("Gameplay HUD")]
        public Slider powerSlider;
        public Image turnIndicator; // Color changes based on turn
        public Text timerText;
        
        [Header("Spin UI (Optional Visual)")]
        public RectTransform spinCrosshair;

        public void UpdatePowerBar(float fillAmount)
        {
            if (powerSlider != null)
            {
                powerSlider.value = Mathf.Clamp01(fillAmount);
                
                // Color gradient from green to red based on power
                Image fillImage = powerSlider.fillRect.GetComponent<Image>();
                if (fillImage != null)
                {
                    fillImage.color = Color.Lerp(Color.green, Color.red, fillAmount);
                }
            }
        }

        public void SetTurn(bool isPlayer1)
        {
            if (turnIndicator != null)
            {
                turnIndicator.color = isPlayer1 ? new Color(0.2f, 0.6f, 1f) : new Color(1f, 0.3f, 0.3f);
            }
        }

        public void UpdateTimer(int seconds)
        {
            if (timerText != null)
            {
                timerText.text = seconds.ToString();
                timerText.color = seconds <= 5 ? Color.red : Color.white;
            }
        }
    }
}
