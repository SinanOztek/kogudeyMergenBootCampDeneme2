using System.Collections;
using System.Collections.Generic;
using UnityEngine;





    [RequireComponent(typeof(AudioSource))]
    public class sounds : MonoBehaviour
    {
        public static sounds Instance;

        private AudioSource source;
        private void Awake()
        {
            Singleton();

            source = this.gameObject.GetComponent<AudioSource>();
        }

        public void PlayAudio(AudioClip clip)
        {
            source.PlayOneShot(clip);
        }

        private void Singleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

