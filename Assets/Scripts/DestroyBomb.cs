using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    public float delay = 0f;
    public Transform transform;
    public GameObject explosionPrefab;

    private void Start()
    {
        StartCoroutine("SpawnExplosion");
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

    IEnumerator SpawnExplosion()
    {
        yield return new WaitForSeconds(1.22f);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}
