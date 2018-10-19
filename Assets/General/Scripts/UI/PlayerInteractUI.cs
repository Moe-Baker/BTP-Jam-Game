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
	public class PlayerInteractUI : MonoBehaviour
	{
        PlayerInteract interact;

        public GameObject menu;

        public Text label;

        void Start()
        {
            interact = FindObjectOfType<PlayerInteract>();
        }

        void Update()
        {
            if (interact.Target == null)
                menu.SetActive(false);
            else
            {
                menu.SetActive(true);
                label.text = interact.Target.text;
            }
        }
	}
}