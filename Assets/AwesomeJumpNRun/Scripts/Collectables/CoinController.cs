using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private CoinData coinData;

    private bool collected;

    private void Update()
    {
        if (collected)
        {
            transform.Rotate(new Vector3(0, 30, 0) * 20 * Time.deltaTime);
            transform.Translate(new Vector3(0, 1, 0) * 2 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<CoinCollectedHandler>().CoinGotCollected(coinData.Value);
        StartCoroutine(lateDestroy());
    }

    private IEnumerator lateDestroy()
    {
        collected = true;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}