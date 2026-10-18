using UnityEngine;
using EightBallPool.Physics;

namespace EightBallPool.Cue
{
    [RequireComponent(typeof(AimController))]
    [RequireComponent(typeof(PowerController))]
    [RequireComponent(typeof(SpinController))]
    public class CueController : MonoBehaviour
    {
        public CueBallController cueBall;
        
        private AimController aimController;
        private PowerController powerController;

        private void Awake()
        {
            aimController = GetComponent<AimController>();
            powerController = GetComponent<PowerController>();
        }

        private void Start()
        {
            if (cueBall != null)
            {
                aimController.cueBall = cueBall.transform;
                GetComponent<SpinController>().cueBallController = cueBall;
            }
        }

        private void Update()
        {
            if (cueBall == null) return;

            // Wait for all balls to stop before allowing shot
            // (Placeholder logic: checking only cue ball for now)
            if (cueBall.GetComponent<Rigidbody>().linearVelocity.magnitude > 0.05f)
            {
                aimController.EnableAiming(false);
                return;
            }

            aimController.EnableAiming(true);

            // Handle Shooting Input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                powerController.StartCharging();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                float power = powerController.ReleasePower();
                if (power > 0)
                {
                    Vector3 direction = aimController.GetAimDirection();
                    cueBall.ApplyStrikeForce(direction, power);
                    
                    // Hide cue line immediately
                    aimController.EnableAiming(false);
                }
            }
        }
    }
}
