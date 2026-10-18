using UnityEngine;
using EightBallPool.Physics;

namespace EightBallPool.Cue
{
    public class SpinController : MonoBehaviour
    {
        [Header("References")]
        public CueBallController cueBallController;

        // Visual UI for spin could be added here later
        public Vector2 CurrentSpin { get; private set; } = Vector2.zero;

        private void Update()
        {
            // Simple prototype input for spin (WASD)
            // Can be mapped to UI Joystick later
            float spinX = 0f;
            float spinY = 0f;

            if (Input.GetKey(KeyCode.W)) spinY = 1f; // Top spin
            if (Input.GetKey(KeyCode.S)) spinY = -1f; // Back spin
            if (Input.GetKey(KeyCode.A)) spinX = -1f; // Left English
            if (Input.GetKey(KeyCode.D)) spinX = 1f; // Right English

            if (spinX != 0 || spinY != 0)
            {
                CurrentSpin = new Vector2(spinX, spinY);
            }
            else
            {
                // Reset or keep last spin? Let's keep it 0 if not pressing
                CurrentSpin = Vector2.zero;
            }
            
            if (cueBallController != null)
            {
                cueBallController.SetSpin(CurrentSpin);
            }
        }
    }
}
