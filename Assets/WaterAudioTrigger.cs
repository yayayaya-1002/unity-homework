using UnityEngine;

public class WaterAudioTrigger : MonoBehaviour
{
    [Header("绑定当前物体上的Audio Source组件")]
    public AudioSource audioSource;
    [Header("拖入你的流水声音频文件")]
    public AudioClip waterAudioClip;

    // 防止多次重复播放音效
    private bool isPlaying = false;

    // 玩家走进触发区域执行
    private void OnTriggerEnter(Collider other)
    {
        // 只有标签为Player的物体进入才触发
        if (other.CompareTag("Player") && !isPlaying)
        {
            audioSource.clip = waterAudioClip;
            audioSource.Play();
            isPlaying = true;
        }
    }

    // 玩家离开触发区域停止音效
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
            isPlaying = false;
        }
    }
}