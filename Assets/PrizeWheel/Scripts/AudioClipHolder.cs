using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PrizeWheel
{
    [Serializable]
    public class AudioClipHolder
    {
        [Tooltip("Sound of audio clip")]
        [SerializeField]
        private AudioClip sound;

        [Tooltip("Volume of audio clip")]
        [Range(0, 1)]
        [SerializeField]
        private float volume;

        /// <summary>
        /// Sound of audio clip
        /// </summary>
        public AudioClip Sound { get { return sound; } }

        /// <summary>
        /// Volume of audio clip
        /// </summary>
        public float Volume { get { return volume; } }
    }
}