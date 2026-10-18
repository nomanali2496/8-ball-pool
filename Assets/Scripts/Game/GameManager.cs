using UnityEngine;
using EightBallPool.Physics;

namespace EightBallPool.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void OnBallPotted(BallPhysics ball)
        {
            Debug.Log($"Ball potted: {ball.ballNumber}");
            // Handle rules later
        }
    }
}
