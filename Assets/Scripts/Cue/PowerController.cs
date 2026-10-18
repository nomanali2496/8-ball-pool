using UnityEngine;

namespace EightBallPool.Cue
{
    public class PowerController : MonoBehaviour
    {
        [Header("Power Settings")]
        public float maxPower = 30f;
        public float powerChargeRate = 15f;
        
        public float CurrentPower { get; private set; } = 0f;
        public bool IsCharging { get; private set; } = false;

        private void Update()
        {
            if (IsCharging)
            {
                // Charge power using spacebar hold for simplicity right now
                // Can be replaced with touch drag later
                if (Input.GetKey(KeyCode.Space))
                {
                    CurrentPower += powerChargeRate * Time.deltaTime;
                    CurrentPower = Mathf.Clamp(CurrentPower, 0, maxPower);

                    // Update Premium UI
                    EightBallPool.UI.GameUI ui = FindFirstObjectByType<EightBallPool.UI.GameUI>();
                    if (ui != null)
                    {
                        ui.UpdatePowerBar(CurrentPower / maxPower);
                    }
                }
            }
        }

        public void StartCharging()
        {
            IsCharging = true;
            CurrentPower = 0f;
            
            EightBallPool.UI.GameUI ui = FindFirstObjectByType<EightBallPool.UI.GameUI>();
            if (ui != null) ui.UpdatePowerBar(0f);
        }

        public float ReleasePower()
        {
            IsCharging = false;
            float releasedPower = CurrentPower;
            CurrentPower = 0f;
            
            EightBallPool.UI.GameUI ui = FindFirstObjectByType<EightBallPool.UI.GameUI>();
            if (ui != null) ui.UpdatePowerBar(0f);
            
            return releasedPower;
        }
    }
}
