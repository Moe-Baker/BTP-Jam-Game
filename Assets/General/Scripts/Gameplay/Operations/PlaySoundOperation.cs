using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Game
{
	public class PlaySoundOperation : MonoBehaviour, Operation.Interface
	{
        public AudioSource source;

        public AudioClip clip;

        void Reset()
        {
            source = GetComponentInChildren<AudioSource>();
        }

        public void Execute()
        {
            source.PlayOneShot(clip);
        }
	}
}