using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 3f; // tempo para granada explodir
    public float radius = 5f; //raio da explosao
    public float force = 700f; // força da explosao
    

    float countdown; // contagem regressiva
    bool hasExploded = false; // se a agranada ja explodiu
    

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && hasExploded == false)
        {
            //BOOM
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Debug.Log("BOOM");

        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);

    }
}
