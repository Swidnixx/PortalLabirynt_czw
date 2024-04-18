using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public float speed = 10;
    public AudioClip sfx;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Picked();
        }
    }

    protected virtual void Picked()
    {
        SoundManager.Instance.PlaySFX(sfx);
        Destroy(gameObject);
    }
}
