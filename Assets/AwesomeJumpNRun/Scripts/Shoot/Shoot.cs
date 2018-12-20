using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;
    [SerializeField] private GameObject shoot;
    [SerializeField] private float shootDelaySec;
    [SerializeField] private AudioSource shootSond;

    private Transform shootHolder;
    private bool canShoot = true;

    protected virtual void Start()
    {
        shootHolder = GameObject.FindGameObjectWithTag("BulletHolder").transform;
    }

    protected void OnShoot()
    {
        if (canShoot)
        {
            PlayShootSound();
            Instantiate(shoot, shootPosition.position, shootPosition.rotation, shootHolder);
            StartCoroutine(ShootDelay());
        }
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelaySec);
        canShoot = true;
    }

    private void PlayShootSound()
    {
        if (shootSond != null)
        {
            shootSond.Play();
        }
    }
}