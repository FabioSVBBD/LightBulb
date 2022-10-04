//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SoundManager : MonoBehaviour
//{
//    private static SoundManager instance = null;
//    public static SoundManager Instance
//    {
//        get { return instance; }
//    }


//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    //void Awake()
//    //{
//    //    if(instance != null && instance != this)
//    //    {
//    //        Destroy(this.gameObject);
//    //        return;
//    //    }
//    //    else
//    //    {
//    //        instance = this;
//    //    }

//    //    DontDestroyOnLoad(this.gameObject)
//    //}


//    void Awake()
//    {
//        if (instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject)
//        }
//    }

//    public void PlaySound(AudioClip clip)
//    {

//    }

//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    [SerializeField] private AudioSource _musicSource, _effectsSource; 


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

}
