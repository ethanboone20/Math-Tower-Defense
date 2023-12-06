using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private Transform target;

    public float speed = 70f;
    public int damage = 50;
    public float explosionRadius = 0f;
    public float slowAmount = 0f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Slow(Transform enemy, float slowAmount)
    {
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();

        if (enemyMovement != null)
        {
            enemyMovement.speed = enemyMovement.startSpeed * (1f - slowAmount);
        }
    }

    void Explode()
    {
        Collider[] hitTargets = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in hitTargets)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();

        if (enemyMovement != null)
        {
            enemyMovement.TakeDamage(damage);
            Slow(enemy, slowAmount);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
