using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlay : MonoBehaviour
{
    [SerializeField] ParticleSystem m_ParticleSystem, heroDeath;
    [SerializeField] GameObject hero;

    private void OnTriggerEnter(Collider other)
    {
        if (m_ParticleSystem != null && !m_ParticleSystem.isPlaying) m_ParticleSystem.GetComponent<ParticleSystem>().Play();
        GetComponent<Animator>().enabled = false;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        if (gameObject.name.Contains("Death"))
        {
            StartCoroutine(DeathCoroutine());
            //hero = other.GetComponent<GameObject>();
        }
    }

    IEnumerator DeathCoroutine()
    {
        heroDeath.Play();
        hero.GetComponent<Rigidbody>().drag = 10;
        hero.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1);
        Destroy(hero);
    }
}