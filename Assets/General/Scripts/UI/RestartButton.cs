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
	public class RestartButton : MonoBehaviour
	{
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(Action);
        }

        void Action()
        {
            SceneManager.LoadScene(gameObject.scene.name);
        }
	}
}