using System;
using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    //Gun variables
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    private float bullets = 1f;

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

    //Gun selected
    private int gunChosen = 0;

    //IMPORTANT: WILL BE ADDING STUFF SO GUNS WILL BE UNLOCKED IN LATER LEVELS OR WHATEVER, AKA SNIPER ON LVL2 SHOTGUN LVL4 ETC. MINIGUN MODE COULD BE USED IN FINAL BOSS FIGHT??

    // Update is called once per frame
    void Update()
    {
        //Get gun selected

        //Pistol (Medium damage, Medium fire rate)
        if (Input.GetKeyDown("1"))
        {
            bullets = 1f;
            gunChosen = 0;
            //Weapon swap time
            nextTimeToFire = Time.time + 1f;
            //Gun stats
            damage = 10f;
            range = 100f;
            fireRate = 0.7f;
        }
        //Sniper (High Damage, Low fire rate)
        if (Input.GetKeyDown("2"))
        {
            bullets = 1f;
            gunChosen = 3;
            //Weapon swap time
            nextTimeToFire = Time.time + 1f;
            //Gun stats
            damage = 30f;
            range = 100f;
            fireRate = 0.3f;
        }
        //Shotgun (Large Damage, Medium fire rate, Scattered shots)
        if (Input.GetKeyDown("3"))
        {
            bullets = 1f;
            gunChosen = 1;
            //Weapon swap time
            nextTimeToFire = Time.time + 1f;
            //Gun stats
            damage = 3f;
            range = 100f;
            fireRate = 1f;
            BulletSpreadVariance = new Vector3(0.1f, 0.1f, 0.1f);
        }
        //Fast Fire Rate Weapon (Low damage, High fire rate)
        if (Input.GetKeyDown("4"))
        {
            bullets = 20f;
            gunChosen = 2;
            //Weapon swap time
            nextTimeToFire = Time.time + 1f;
            //Gun stats
            damage = 0.5f;
            range = 100f;
            fireRate = 25f;
        }    

        //Ran out of ammo, add delay to next fire time
        if (bullets == 0)
        {
            nextTimeToFire = Time.time + 1f;
            bullets = 20f;
        }

        //Shoot when mouse1 pressed and shoot delay is over, reset timer
        //Pistol shoot mode
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && gunChosen == 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            PistolShoot();
            AkSoundEngine.PostEvent("Play_Weapon1", gameObject);
        }
        //Shoot when mouse1 pressed and shoot delay is over, reset timer
        //Sniper shoot mode
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && gunChosen == 3)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            PistolShoot();
        }
        //Shoot when mouse1 pressed and shoot delay is over, reset timer
        //Shotgun shoot mode
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && gunChosen == 1)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            ShotgunShoot();
        }
        //Shoot when mouse1 pressed and shoot delay is over, reset timer
        //AR shoot mode
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && gunChosen == 2)
        {
            bullets--;
            nextTimeToFire = Time.time + 1f / fireRate;
            PistolShoot();
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

            //Impact FX using pooling
            GameObject bullet = ParticlePool.SharedInstance.GetPooledObject(); 
            if (bullet != null) 
            { 
                bullet.transform.position = hit.point; 
                bullet.transform.rotation = Quaternion.LookRotation(hit.normal); 
                bullet.SetActive(true); 
            }
            StartCoroutine(DespawnBullet(bullet));

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

                //Impact FX using pooling
                GameObject bullet = ParticlePool.SharedInstance.GetPooledObject();
                if (bullet != null)
                {
                    bullet.transform.position = hit.point;
                    bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
                    bullet.SetActive(true);
                }
                StartCoroutine(DespawnBullet(bullet));

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

    IEnumerator DespawnBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2);
        bullet.SetActive(false);
    }
}