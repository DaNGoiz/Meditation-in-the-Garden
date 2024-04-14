using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    private AudioSource audioSource; // 用于播放音乐的AudioSource组件

    void Start()
    {
        // 获取附加在同一GameObject上的AudioSource组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("MusicSwitcher requires an AudioSource component on the same GameObject.");
        }
    }

    // 由按钮调用的公共方法，用于切换音乐
    public void SwitchMusic(AudioClip newClip)
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not attached to the GameObject.");
            return;
        }
        
        if (newClip == null)
        {
            Debug.LogError("No audio clip specified.");
            return;
        }

        // 设置AudioSource的音频剪辑为新的剪辑，并播放
        audioSource.clip = newClip;
        audioSource.Play();
    }
}
