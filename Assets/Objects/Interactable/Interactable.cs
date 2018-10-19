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
	public class Interactable : MonoBehaviour
	{
        public string text = "Interact";

        public event Action OnInteraction;

        public bool active = true;

		public void Interact()
        {
            if (OnInteraction != null) OnInteraction();
        }
    }

    [RequireComponent(typeof(Interactable))]
    public abstract class Interaction : MonoBehaviour
    {
        void Start()
        {
            GetComponent<Interactable>().OnInteraction += Action;
        }

        protected virtual void Action()
        {
            
        }
    }
}