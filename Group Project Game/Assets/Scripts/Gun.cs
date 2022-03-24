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
    public float bullets = 6f;

    //FX and other variables
    public Camera fpscamera;
    public ParticleSystem muzzleflash;
    public GameObject impactEffect;
    public Transform BulletSpawnPoint;
    public GameObject shotgun;
    public GameObject pistol;
    public GameObject sniper;
    public GameObject vector;

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

    //Animator
    private Animator m_Animator;
    private bool shootAnim;

    void Start()
    {
        sniper.SetActive(false);
        vector.SetActive(false);
        shotgun.SetActive(false);
        pistol.SetActive(true);
        m_Animator = gameObject.GetComponent<Animator>();
        // The GameObject cannot jump
        shootAnim = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Get gun selected

        //Pistol (Medium damage, Medium fire rate)
        if (Input.GetKeyDown("1"))
        {
            bullets = 6f;
            gunChosen = 0;
            //Weapon swap time
            nextTimeToFire = Time.time + 1f;
            //Gun stats
            damage = 4f;
            range = 100f;
            fireRate = 0.7f;
            sniper.SetActive(false);
            vector.SetActive(false);
            shotgun.SetActive(false);
            pistol.SetActive(true);
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
            fireRate = 0.4f;
            sniper.SetActive(true);
            vector.SetActive(false);
            shotgun.SetActive(false);
            pistol.SetActive(false);
        }
        //Shotgun (Large Damage, Medium fire rate, Scattered shots)
        if (Input.GetKeyDown("3"))
        {
            bullets = 3f;
            gunChosen = 1;
            //Weapon swap time
            nextTimeToFire = Time.time + 1f;
            //Gun stats
            damage = 2.5f;
            range = 100f;
            fireRate = 1.7f;
            BulletSpreadVariance = new Vector3(0.1f, 0.1f, 0.1f);
            sniper.SetActive(false);
            vector.SetActive(false);
            shotgun.SetActive(true);
            pistol.SetActive(false);
        }
        //Fast Fire Rate Weapon (Low damage, High fire rate)
        if (Input.GetKeyDown("4"))
        {
            bullets = 20f;
            gunChosen = 2;
            //Weapon swap time
            nextTimeToFire = Time.time + 1f;
            //Gun stats
            damage = 7f;
            range = 100f;
            fireRate = 15f;
            sniper.SetActive(false);
            vector.SetActive(true);
            shotgun.SetActive(false);
            pistol.SetActive(false);
        }    

        //Ran out of ammo, add delay to next fire time
        if (bullets == 0 && gunChosen == 0)
        {
            nextTimeToFire = Time.time + 2f;
            bullets = 6f;
        }
        if (bullets == 0 && gunChosen == 1)
        {
            nextTimeToFire = Time.time + 2f;
            bullets = 3f;
        }
        if (bullets == 0 && gunChosen == 2)
        {
            nextTimeToFire = Time.time + 1f;
            bullets = 20f;
        }


        if (Input.GetKeyDown(KeyCode.R) && gunChosen == 0)
        {
            nextTimeToFire = Time.time + 2f;
            bullets = 6f;
        }
        if (Input.GetKeyDown(KeyCode.R) && gunChosen == 1)
        {
            nextTimeToFire = Time.time + 2f;
            bullets = 3f;
        }
        if (Input.GetKeyDown(KeyCode.R) && gunChosen == 2)
        {
            nextTimeToFire = Time.time + 1f;
            bullets = 20f;
        }


        shootAnim = false;

        //Shoot when mouse1 pressed and shoot delay is over, reset timer
        //Pistol shoot mode
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && gunChosen == 0)
        {
            nextTimeToFire = 0f;
            bullets--;
            NormalShoot();
            shootAnim = true;
            AkSoundEngine.PostEvent("Play_Weapon_3", gameObject);
        }
        //Shoot when mouse1 pressed and shoot delay is over, reset timer
        //Sniper shoot mode
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && gunChosen == 3)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            NormalShoot();
            shootAnim = true;
        }
        //Shoot when mouse1 pressed and shoot delay is over, reset timer
        //Shotgun shoot mode
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && gunChosen == 1)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            bullets--;
            ScatterShot();
            shootAnim = true;
        }
        //Shoot when mouse1 pressed and shoot delay is over, reset timer
        //AR shoot mode
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && gunChosen == 2)
        {
            bullets--;
            nextTimeToFire = Time.time + 1f / fireRate;
            NormalShoot();
            shootAnim = true;
        }

        if (shootAnim == false)
            m_Animator.SetBool("Shoot", false);

        if (shootAnim == true)
            m_Animator.SetBool("Shoot", true);
    }

    //normal shoot mode
    void NormalShoot()
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

    //Shotgun scatter shot
    void ScatterShot()
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