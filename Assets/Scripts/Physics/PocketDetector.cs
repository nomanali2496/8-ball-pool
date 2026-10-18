using UnityEngine;
using EightBallPool.Game; // Assuming Game module has GameManager

namespace EightBallPool.Physics
{
    [RequireComponent(typeof(Collider))]
    public class PocketDetector : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BallPhysics ball))
            {
                // Stop physics
                ball.Rb.linearVelocity = Vector3.zero;
                ball.Rb.angularVelocity = Vector3.zero;
                ball.Rb.isKinematic = true;

                // Move ball below table or disable it visually (animation can be handled elsewhere)
                ball.gameObject.SetActive(false);

                // Notify Rules/Game manager
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.OnBallPotted(ball);
                }
            }
        }
    }
}
