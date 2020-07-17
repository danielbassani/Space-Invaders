using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float delay = 0f;
    private AudioSource explosionSound;

    private void Start()
    {
        explosionSound = this.GetComponent<AudioSource>();
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        explosionSound.PlayOneShot(explosionSound.clip);
    }
}
