using System;
using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    //Gun variables
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 150f;

    //FX and other variables
    public Camera fpscamera;
    public ParticleSystem muzzleflash;
    public GameObject impactEffect;
    public Transform BulletSpawnPoint;

    //Bullet trail
    [SerializeField]
    private TrailRenderer BulletTrail;

    //Bullet spread
    [SerializeField]
    private Vector3 BulletSpreadVariance = new Vector3(0.1f, 0.1f, 0.1f);

    //Next possible shoot time
    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        //Shoot when mouse1 pressed and shoot delay is over, reset timer
        //Pistol shoot mode
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            PistolShoot();
        }
        //Shoot when mouse2 pressed and shoot delay is over, reset timer
        //Pistol shoot mode
        if (Input.GetButton("Fire2") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            ShotgunShoot();
        }

    }

    //Pistol shoot
    void PistolShoot()
    {
        //Play shoot FX
        muzzleflash.Play();

        //Raycast
        RaycastHit hit;

        //Bullet raycast
        if (Physics.Raycast(fpscamera.transform.position, fpscamera.transform.forward, out hit, range))
        {
            //Get hit object
            UnityEngine.Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            //If its a target send damage to it
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            //Impact FX
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

            //Trail FX
            TrailRenderer trail = Instantiate(BulletTrail, BulletSpawnPoint.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));
        }

    }

    void ShotgunShoot()
    {
        //Play shoot FX
        muzzleflash.Play();

        //Raycast
        RaycastHit hit;

        //10 bullets
        for (int i = 0; i < 9; i++)
        {
            //Direction
            Vector3 direction = fpscamera.transform.forward;

            //Add spread
            direction += new Vector3(
                UnityEngine.Random.Range(-BulletSpreadVariance.x, BulletSpreadVariance.x),
                UnityEngine.Random.Range(-BulletSpreadVariance.y, BulletSpreadVariance.y),
                UnityEngine.Random.Range(-BulletSpreadVariance.z, BulletSpreadVariance.z)
                );

            direction.Normalize();

            //Bullet raycast
            if (Physics.Raycast(fpscamera.transform.position, direction, out hit, range))
            {
                //Get hit object
                UnityEngine.Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();

                //If its a target send damage to it
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                //Impact FX
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);

                //Trail FX
                TrailRenderer trail = Instantiate(BulletTrail, BulletSpawnPoint.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, hit));
            }
        }
    }

    //Make bullet trail
    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        Trail.transform.position = Hit.point;

        Destroy(Trail.gameObject, Trail.time);
    }
}