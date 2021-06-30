using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    private Animator fadeSystem;
    public AudioClip soundToPlay;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
            AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        }
    }

    public IEnumerator loadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        yield return new WaitForSeconds(1f);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
