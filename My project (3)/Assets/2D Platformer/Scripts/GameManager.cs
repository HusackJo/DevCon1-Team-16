using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int coinsCounter = 0;

        public GameObject playerGameObject;
        private PlayerController player;
        public GameObject deathPlayerPrefab;
        public Text coinText;
        public GameObject menuCanvas;


        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            menuCanvas = GameObject.Find("CanvasMenu");
        }

        void Update()
        {
            coinText.text = coinsCounter.ToString();
            if(player.deathState == true)
            {
                playerGameObject.SetActive(false);
                GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
                player.deathState = false;
                Invoke("ReloadLevel", 3);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (menuCanvas.activeSelf)
                {
                    menuCanvas.SetActive(false);
                }
                else
                {
                    menuCanvas.SetActive(true);
                }
            }
        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
