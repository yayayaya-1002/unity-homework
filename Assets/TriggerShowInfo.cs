using UnityEngine;
using UnityEngine.UI;

public class TriggerShowInfo : MonoBehaviour
{
    [Header("要显示的课文UI面板")]
    public GameObject infoPanel;
    [Header("音频播放组件")]
    public AudioSource audioSource;

    //玩家进入触发区域
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoPanel.SetActive(true);
            if(audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    //玩家离开触发区域
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            infoPanel.SetActive(false);
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
    }
}