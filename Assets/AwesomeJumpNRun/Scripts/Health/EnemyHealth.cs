using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    public GameObject remains;
    protected override void Die()
    {
        Instantiate(remains, transform.position, transform.rotation);
        base.Die();
        Destroy(gameObject);
    }
}
