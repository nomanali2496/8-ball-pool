using UnityEngine;

namespace EightBallPool.Physics
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallPhysics : MonoBehaviour
    {
        [Header("Ball Properties")]
        public int ballNumber;
        public bool isCueBall = false;

        [Header("Physics Settings")]
        public float stopVelocityThreshold = 0.05f;
        
        public Rigidbody Rb { get; private set; }

        private void Awake()
        {
            Rb = GetComponent<Rigidbody>();
            
            // Standardize mass and drag for pool balls
            Rb.mass = 0.17f; // ~170 grams
            Rb.linearDamping = 0.6f; // Rolling friction on felt
            Rb.angularDamping = 0.8f;
            Rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            Rb.interpolation = RigidbodyInterpolation.Interpolate;
        }

        private void FixedUpdate()
        {
            // Stop the ball completely if moving very slowly to prevent infinite micro-rolling
            if (Rb.linearVelocity.sqrMagnitude > 0f && Rb.linearVelocity.sqrMagnitude < (stopVelocityThreshold * stopVelocityThreshold))
            {
                Rb.linearVelocity = Vector3.zero;
                Rb.angularVelocity = Vector3.zero;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Realistic collision handling (sound effects, spark particles, etc.)
            float hitForce = collision.relativeVelocity.magnitude;
            
            // Optional: Detect collision with other balls for ball-to-ball rules
            if (collision.gameObject.CompareTag("Ball"))
            {
                // Logic for ball hitting ball
            }
        }
    }
}
