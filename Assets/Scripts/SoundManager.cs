using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // 유니티 화면에 강제로 창 보여주기
public class Sound
{
    public string soundName;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // SoundManager클래스를 어디서든 쉽게 참조 변경이 가능하게 instance 변수로 만듦

    [Header("사운드 등록")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSounds;

    [Header("브금 플레이어")]
    [SerializeField] AudioSource bgmPlayer;

    [Header("효과음 플레이어")]
    [SerializeField] AudioSource[] sfxPlayer;

    public void PlaySoundEffect(string _soundName)
    {
        for(int i=0; i < sfxSounds.Length; i++) // 반복문을 통해 사운드에 등록된 갯수만큼 함
        {
            if(_soundName == sfxSounds[i].soundName) // 파라미터로 넘어온 _soundName과 동일한 것을 찾음
            {
                for(int x = 0; x < sfxPlayer.Length; x++) // 재생되지 않은 것들 중의 반복문을 돌려서
                {
                    if (!sfxPlayer[x].isPlaying) // !을 붙여서 x번째의 MP3 플레이어가 재생중이지 않다면
                    {
                        sfxPlayer[x].clip = sfxSounds[i].clip; // 재생중이지 않은 x번째 MP3 플레이어에 전 조건문에서 찾아낸 i번째 MP3를 넣어줌
                        sfxPlayer[x].Play();
                        return; // 함수 끝
                    }
                }
                Debug.Log("모든 효과음 플레이어가 사용중입니다!!");
                return; // return을 안 시키면 for문을 계속 돌게 됨
            }
        }
        Debug.Log("등록된 효과음이 없습니다.");
    }


    void Start()
    {
        instance = this; // 클래스를 변수로 만든 instance를 자기자신으로 만듦
        PlayRandomBGM();   
    }

    public void PlayRandomBGM()
    {
        int random = Random.Range(0, 2); // int(정수) 타입이여서 0,1을 하면 0만 포함이 됨, 실수타입은 0,1
        bgmPlayer.clip = bgmSounds[random].clip;
        bgmPlayer.Play();
    }
}
