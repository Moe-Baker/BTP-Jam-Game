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
	public class PlayerEnergy : MonoBehaviour
	{
        [SerializeField]
        protected float value = 100;
        public float Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = Mathf.Clamp(value, 0f, maxValue);
            }
        }

        public float maxValue = 100f;

        public float depletionSpeed;

        public float Rate { get { return value / maxValue; } }

        Player player;
        public void Init(Player player)
        {
            this.player = player;

            blink = FindObjectOfType<Blink>();

            game = FindObjectOfType<Game>();
        }

        Game game;

        Blink blink;

        public void Process()
        {
            if(game.State == GameState.Playing)
                value = Mathf.MoveTowards(value, 0f, depletionSpeed * Time.deltaTime);

            blink.range = Mathf.InverseLerp(maxValue, 0f, value);
        }
	}
}