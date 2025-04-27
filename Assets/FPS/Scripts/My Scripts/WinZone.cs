using System.Collections;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace AG3787 
{
    public class WinZone : MonoBehaviour
    {
        
        public string WinSceneName = "WinScene";
        public AudioClip VictorySound;
        public CanvasGroup EndGameFadeCanvasGroup;

        public float FadeDurationMultiplier = 1f;
        public bool fadeout;
  

        void Update()
        {
            if (fadeout == true)
            {
                EndGameFadeCanvasGroup.gameObject.SetActive(true);

                if (EndGameFadeCanvasGroup.alpha < 1)
                {
                    EndGameFadeCanvasGroup.alpha += FadeDurationMultiplier* Time.deltaTime;
                }
                else
                    fadeout = false;
            }
        }

        public IEnumerator ChangeScene()
        {
            FadeOut();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(WinSceneName);
        }

        private void OnTriggerEnter(Collider other)
        {
            var Enemies = FindObjectsByType<BallBase>(FindObjectsSortMode.None);
            foreach (BallBase ball in Enemies)
            {
                ball.CanMove = false;
            }

            // play a sound on win
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = VictorySound;
            audioSource.playOnAwake = false;
            audioSource.outputAudioMixerGroup = AudioUtility.GetAudioGroup(AudioUtility.AudioGroups.HUDVictory);
            audioSource.PlayScheduled(AudioSettings.dspTime);

            // Start Courutine to change scene
            StartCoroutine(ChangeScene());
          
        }

        // set fade out to true
        private void FadeOut()
        {
            fadeout = true;
        }
    }
}

