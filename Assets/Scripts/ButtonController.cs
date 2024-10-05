using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class ButtonController : MonoBehaviour
{
    private const string GAMESCENE = "GameScene";
    [SerializeField] private Button playBtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] private Button devilBtn;

    [SerializeField] private AudioSource devilSoundContainer;
    [SerializeField] private AudioClip devilSoundSource;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI devilText;
    [SerializeField][Range(0,10)] private float shakeMagnitude = 50f;

    private string[] replics = new[] { "AHAHAHHAHAHAHAHAHAHA", "Tickle me", "I will choose you" };

    private void Start()
    {
        playBtn.onClick.AddListener(OnPlayButton);
        quitBtn.onClick.AddListener(OnQuitButton);
        devilBtn.onClick.AddListener(OnDevilButton);
    }

    void OnPlayButton()
    {
        SceneManager.LoadScene(GAMESCENE);
    }

    void OnQuitButton()
    {
        Application.Quit();
    }

    void OnDevilButton()
    {
        devilSoundContainer.PlayOneShot(devilSoundSource);
        devilText.text = replics[Random.Range(0, replics.Length)];
        StartCoroutine(ShakeText());
    }

    IEnumerator ShakeText()
    {
        var elapsedTime = 0f;
        var durationTime = 0.3f;

        var originalPosition = devilText.transform.position;

        while (elapsedTime < durationTime)
        {
            devilText.transform.position = originalPosition + new Vector3(Random.Range(-shakeMagnitude, shakeMagnitude),
                Random.Range(-shakeMagnitude, shakeMagnitude), 0);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        devilText.transform.position = originalPosition;
    }
}