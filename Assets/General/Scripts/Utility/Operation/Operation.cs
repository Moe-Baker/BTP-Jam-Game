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
	public class Operation : MonoBehaviour
	{
		public interface Interface
        {
            void Execute();
        }

        public static void Execute(GameObject gameObject)
        {
            var targets = gameObject.GetComponents<Interface>();

            foreach (var target in targets)
                Execute(target);
        }
        public static void Execute(Interface target)
        {
            target.Execute();
        }
	}
}