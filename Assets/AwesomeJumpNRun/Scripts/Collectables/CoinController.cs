using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    [SerializeField]
    private CoinData coinData;

    private bool collected;

    private void Update()
    {
        if (collected)
        {
            transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter()
    {
        Debug.Log(coinData.Value); //To Get the Value of the Coin
        StartCoroutine(lateDestroy());
    }

    private IEnumerator lateDestroy()
    {
        collected = true;
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
