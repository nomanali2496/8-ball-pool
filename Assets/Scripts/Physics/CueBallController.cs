using UnityEngine;

namespace EightBallPool.Physics
{
    [RequireComponent(typeof(BallPhysics))]
    public class CueBallController : MonoBehaviour
    {
        private BallPhysics ballPhysics;

        [Header("Spin Settings")]
        public float spinMultiplier = 2f;
        
        // Spin applied to the shot (-1 to 1)
        // X = Left/Right (Side spin)
        // Y = Top/Back (Draw/Follow)
        private Vector2 appliedSpin; 

        private void Awake()
        {
            ballPhysics = GetComponent<BallPhysics>();
        }

        public void SetSpin(Vector2 spin)
        {
            // Clamp spin values
            appliedSpin.x = Mathf.Clamp(spin.x, -1f, 1f);
            appliedSpin.y = Mathf.Clamp(spin.y, -1f, 1f);
        }

        public void ApplyStrikeForce(Vector3 hitDirection, float power)
        {
            Rigidbody rb = ballPhysics.Rb;
            
            // Apply main forward force
            rb.AddForce(hitDirection * power, ForceMode.Impulse);

            // Apply spin (torque)
            // Top/Back spin (Y) rotates around the local right axis
            // Side spin (X) rotates around the local up axis
            Vector3 torque = (transform.right * appliedSpin.y + transform.up * appliedSpin.x) * power * spinMultiplier;
            rb.AddTorque(torque, ForceMode.Impulse);

            // Reset spin after shot
            appliedSpin = Vector2.zero;
        }

        private void FixedUpdate()
        {
            // Implement Magnus effect (curve) for side spin over time if velocity is high enough
            // This is optional and adds advanced realism
            if (ballPhysics.Rb.linearVelocity.magnitude > 0.5f && Mathf.Abs(ballPhysics.Rb.angularVelocity.y) > 1f)
            {
                // Simple Magnus effect approximation
                Vector3 magnusForce = Vector3.Cross(ballPhysics.Rb.angularVelocity, ballPhysics.Rb.linearVelocity) * 0.005f;
                ballPhysics.Rb.AddForce(magnusForce, ForceMode.Force);
            }
        }
    }
}
