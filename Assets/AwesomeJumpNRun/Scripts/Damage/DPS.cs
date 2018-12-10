using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPS : AbstractDamage {
    [SerializeField] private float sDelay;

    Health healthOther;

    private IEnumerator DoDamage()
    {
        Debug.Log("did Damage");
        healthOther.TakeDamage(DamageAmount, DamageType);
        yield return new WaitForSeconds(sDelay);
        if(healthOther != null)
        {
            StartCoroutine(DoDamage());
        }
    }

    private void OnCollisionEnter(Collision obj)
    {
        healthOther = obj.collider.GetComponentInChildren<Health>();
        if (healthOther != null)
        {
            StartCoroutine(DoDamage());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (healthOther.Equals(collision.collider.GetComponentInChildren<Health>()))
        {
            healthOther = null;
        }
    }
}
