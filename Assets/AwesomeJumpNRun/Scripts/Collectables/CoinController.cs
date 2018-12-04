using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    [SerializeField]
    private CoinData coinData;


    private void OnTriggerEnter()
    {
        Debug.Log(coinData.Value); //To Get the Value of the Coin
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime); //This doesnt work idk why, trieed for 1h to fix, it just doesnt want to rotate, but I give up. If it doesnt want to move it shouldnt
        Destroy(this.gameObject); //maybe Inactive instead of destroy?
    }

}
