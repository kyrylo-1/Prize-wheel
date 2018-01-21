using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PrizeWheel
{
    public class TickerBehaviour : MonoBehaviour
    {
        [SerializeField] private string tagForPeg = "Peg";
        [SerializeField] private AudioSource auSource;  
        [SerializeField] AudioClipHolder auClipPeg;

        private const string STR_SECTOR = "Sector";

        void Start()
        {
            auSource.enabled = false;
            StartCoroutine(EnableAu());
        }

        private IEnumerator EnableAu()
        {
            yield return new WaitForSeconds(0.5F);
            auSource.enabled = true;
        }

        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.CompareTag(tagForPeg))
            {
                auSource.PlayOneShot(auClipPeg.Sound, auClipPeg.Volume);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.name.StartsWith(STR_SECTOR))
            {

            }
        }
    }
}