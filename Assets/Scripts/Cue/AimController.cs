using UnityEngine;
using EightBallPool.Physics;

namespace EightBallPool.Cue
{
    public class AimController : MonoBehaviour
    {
        [Header("References")]
        public Transform cueBall;
        public LineRenderer predictionLine;
        
        [Header("Settings")]
        public float aimSensitivity = 2f;
        public LayerMask obstacleLayer; // Include Balls and Cushions
        public int predictionSteps = 2; // How many bounces to predict
        
        private float currentYRotation = 0f;

        private void Awake()
        {
            if (predictionLine == null)
            {
                predictionLine = gameObject.AddComponent<LineRenderer>();
                predictionLine.startWidth = 0.05f;
                predictionLine.endWidth = 0.05f;
                // Basic material if none is provided
                predictionLine.material = new Material(Shader.Find("Sprites/Default"));
                predictionLine.startColor = Color.white;
                predictionLine.endColor = new Color(1f, 1f, 1f, 0f);
            }
        }

        private void Update()
        {
            if (cueBall == null) return;

            HandleAimInput();
            DrawPredictionLine();
            
            // Align the cue stick visually
            transform.position = cueBall.position;
            transform.rotation = Quaternion.Euler(0, currentYRotation, 0);
        }

        private void HandleAimInput()
        {
            // Horizontal aiming with mouse or keyboard
            float horizontalInput = Input.GetAxis("Mouse X") * aimSensitivity;
            // Also support arrow keys for easier debugging
            horizontalInput += Input.GetAxis("Horizontal") * aimSensitivity;

            currentYRotation += horizontalInput;
        }

        private void DrawPredictionLine()
        {
            Vector3 startPos = cueBall.position;
            Vector3 direction = transform.forward;
            
            predictionLine.positionCount = 1;
            predictionLine.SetPosition(0, startPos);

            Vector3 currentPos = startPos;
            Vector3 currentDir = direction;

            for (int i = 0; i < predictionSteps; i++)
            {
                // SphereCast simulates the ball's radius (approx 0.25f based on our scale)
                if (UnityEngine.Physics.SphereCast(currentPos, 0.25f, currentDir, out RaycastHit hit, 20f, obstacleLayer))
                {
                    predictionLine.positionCount++;
                    predictionLine.SetPosition(i + 1, hit.point);
                    
                    // Reflect direction for the next bounce line
                    currentDir = Vector3.Reflect(currentDir, hit.normal);
                    currentPos = hit.point + currentDir * 0.01f; // Slight offset to prevent self-collision
                    
                    // If we hit another ball, maybe draw a secondary circle (ghost ball)
                    if (hit.collider.GetComponent<BallPhysics>() != null)
                    {
                        // Stop prediction after hitting a ball (or show where the hit ball will go)
                        break;
                    }
                }
                else
                {
                    predictionLine.positionCount++;
                    predictionLine.SetPosition(i + 1, currentPos + currentDir * 10f);
                    break;
                }
            }
        }

        public Vector3 GetAimDirection()
        {
            return transform.forward;
        }

        public void EnableAiming(bool enable)
        {
            enabled = enable;
            if (predictionLine != null) predictionLine.enabled = enable;
        }
    }
}
