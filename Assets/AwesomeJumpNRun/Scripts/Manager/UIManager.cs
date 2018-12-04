using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameTime;
    [SerializeField] private GameTime gameTimeHandler;
    [SerializeField] private TextMeshProUGUI health;

    private HealthSO healthSO;
	// Update is called once per frame
	private void FixedUpdate () {
	    gameTime.text = (gameTimeHandler.CurrentGameTime / 60) + ":" + (gameTimeHandler.CurrentGameTime % 60).ToString("00");
        if (healthSO != null)
        {
            health.text = healthSO.AcctualHealth + "/" + healthSO.MaxHealth + "LP";
        }
    }

    public void setHealthSO(HealthSO healthSO)
    {
        this.healthSO = healthSO;
    }
}
