using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
   public class Demo:MonoBehaviour
   {
       public GameObject[] targets;
       public Dropdown nameSound;
       public Slider volumeSlider;
       public Dropdown typeSound;
       public Dropdown gameobjectDropDown;
       public Toggle loop;
       public Toggle MoveWithObjectToggle;
       public Button playButton;
       public Text countSound;
       public Dropdown playableSounds;
       public Button stopButton;
       public Button perfomanceButton;
       private float volume;
       private bool is2DSound;
       private bool isLooped;
       private bool moveWithObject;
       private GameObject selectedtarget;
       private string soundname;
       private SoundManager soundManager;
       void Start()
       {
           soundManager = FindObjectOfType<SoundManager>();
           SoundManager.SoundsChangePlayingCountEvent += OnChangeCountSoindPlaying;
           nameSound.onValueChanged.AddListener(delegate
           {
               OnNameSoundChange();
           });
           volumeSlider.onValueChanged.AddListener(delegate
           {
               OnChangeVolume();
           });
           typeSound.onValueChanged.AddListener(delegate
           {
               OnChangeTypeSound();
           });
           gameobjectDropDown.onValueChanged.AddListener(delegate
           {
               OnchangeGameobject();
           });
           loop.onValueChanged.AddListener(delegate
           {
               OnChangeLoopToggle();
           });
           MoveWithObjectToggle.onValueChanged.AddListener(delegate
           {
               OnChangeMoweWithObjectToggle();
           });
           playButton.onClick.AddListener(delegate
           {
               OnClickPlayButton();
           });
           stopButton.onClick.AddListener(delegate
           {
               OnClickStopButton();
           });
           perfomanceButton.onClick.AddListener(delegate
           {
               PerfomanceTest();
           });
            OnNameSoundChange();
           OnChangeVolume();
           OnChangeTypeSound();
           OnchangeGameobject();
           OnChangeLoopToggle();
           OnChangeMoweWithObjectToggle();
       }

        public void OnNameSoundChange()
       {
           switch (nameSound.value )
           {
                case 0: soundname = "Garage Foley - 1"; break;
                case 1: soundname = "Garage Foley - 2"; break;
                case 2: soundname = "Garage Foley - 3"; break;
                case 3: soundname = "Garage Foley - 4"; break;
                case 4: soundname = "Garage Foley - 5"; break;
                case 5: soundname = "Garage Foley - 6"; break;
                case 6: soundname = "Garage Foley - 7"; break;
                case 7: soundname = "Garage Foley - 8"; break;
                case 8: soundname = "Garage Foley - 9"; break;
                case 9: soundname = "Garage Foley - 10"; break;
            }
       }

        public void OnChangeCountSoindPlaying()
        {
            countSound.text = "Всего воспроизводится: "+soundManager.GetCountSoundsPlaying;
        }
       public void OnChangeVolume()
       {
           volume = volumeSlider.value;
       }

       public void OnChangeTypeSound()
       {
           switch (typeSound.value)
           {
               case 0:
                   is2DSound = true; break;
               case 1:
                   is2DSound = false;break;
           }
       }

       public void OnchangeGameobject()
       {
           switch (gameobjectDropDown.value)
           {
               case 0:
                   selectedtarget = targets[0]; break;
               case 1:
                   selectedtarget = targets[1]; break;
            }
       }

       public void OnChangeLoopToggle()
       {
           isLooped = loop.isOn;
       }
       public void OnChangeMoweWithObjectToggle()
       {
           moveWithObject = MoveWithObjectToggle.isOn;
       }

       public void OnClickPlayButton()
       {
           if (is2DSound)
           {
               soundManager.PlaySound(soundname, volume, isLooped);
           }
           else
           {
               soundManager.Play3DSound(soundname,selectedtarget,moveWithObject,volume,isLooped);
           }
           UpdateSoundList();
        }

       private IEnumerable<string> soundList;

       public void OnClickStopButton()
       {
           soundManager.StopSound(playableSounds.value);
           UpdateSoundList();
       }

       public void UpdateSoundList()
       {
           soundList = soundManager.GetPlayableSounds();
            playableSounds.options.Clear();
            foreach (var sound in soundList)
            {
                playableSounds.options.Add(new Dropdown.OptionData(sound));
            }

            if (playableSounds.options.Count > 0)
            {
                playableSounds.captionText.text = playableSounds.options[0].text;
            }            
       }

       public void PerfomanceTest()
       {
           for (int i = 0; i < 300; i++)
           {
               if (is2DSound)
               {
                   soundManager.PlaySound(soundname, volume, isLooped);
               }
               else
               {
                   soundManager.Play3DSound(soundname, selectedtarget, moveWithObject, volume, isLooped);
               }
           }
           UpdateSoundList();
        }
    }
}
