using UnityEngine;
using System.Collections;

public class PlayerAimShoot : MonoBehaviour {
    
    public GameObject p1Bullet;
    public GameObject p1Gun;

    public GameObject p2Bullet;
    public GameObject p2Gun;
    
    public float bulletSpeed = 500f;
    public float fireRate = 5f;
    
    private float p1Timer = 0f;
    private float p2Timer = 0f;

    public float gun1minRot = 0f;
    public float gun1maxRot = 60f;
    public float gun2minRot = 0f;
    public float gun2maxRot = 60f;
    public float rotSpd = 1f;
    
    void Update() 
    {
        float shootTime = 1f / fireRate;

        if (Input.GetAxis ("Player1Shoot") > 0) 
        {
            if (p1Timer > shootTime) 
            {
                shoot(p1Bullet, p1Gun);
                p1Timer = 0;
            }
       
        }
        
        moveAim (Input.GetAxis("AimMove1"), p1Gun, gun1minRot, gun1maxRot);
        
        
        if (Input.GetAxis ("Player2Shoot") > 0) 
        {
            if (p2Timer > shootTime) 
            {
                shoot(p2Bullet, p2Gun);
                p2Timer = 0;
            }
        }
        
        moveAim (-Input.GetAxis("AimMove2"), p2Gun, gun2minRot, gun2maxRot);
        
        p1Timer += Time.deltaTime;
        p2Timer += Time.deltaTime;  
    }
    
    private void shoot(GameObject bullet, GameObject gun) 
    {
        //print (gunPoint.InverseTransformDirection (Vector3.forward));
        GameObject o = (GameObject) Instantiate(bullet, gun.transform.position, Quaternion.identity);
        o.rigidbody.AddForce(gun.transform.TransformDirection(Vector3.up) * bulletSpeed, ForceMode.Force);
        o.transform.Rotate(gun.transform.eulerAngles);
        
    }

    private void moveAim(float axis, GameObject gun, float minRot, float maxRot) 
    {
        Quaternion gunRotation = gun.transform.localRotation;

        Vector3 euler1 = gunRotation.eulerAngles;
        euler1.z += axis * Time.deltaTime * rotSpd;

        euler1.z = Mathf.Clamp(euler1.z, minRot, maxRot);
        
        gun.transform.localRotation = Quaternion.Euler(euler1);
    }
    
}

