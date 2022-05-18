using System;
using Pong.Core.Configurations;
using Pong.Core.Enums;
using Pong.Core.Views.Base;
using UnityEngine;

namespace Pong.Core.Views
{
    [RequireComponent(typeof(AudioSource))]
    public class BallView : View
    {
        private Vector3 _screenSize;
        private AudioSource _audioSource;
        private PongConfig _pongConfig;

        public void Init(PongConfig pongConfig)
        {
            if (IsViewInitialized)
            {
                return;
            }
            
            SpriteRenderer.sprite = pongConfig.assetsConfig.ballSprite;

            _pongConfig = pongConfig;

            _audioSource = GetComponent<AudioSource>();
            
            IsViewInitialized = true;
        }

        public void UpdateView(Vector3 position)
        {
            transform.position = position;
        }

        public void PlaySound(SoundType soundType)
        {
            switch (soundType)
            {
                case SoundType.Wall:
                    _audioSource.clip = _pongConfig.soundsConfig.hitWall;
                    break;
                case SoundType.Paddle:
                    _audioSource.clip = _pongConfig.soundsConfig.hitPaddle;
                    break;
                case SoundType.Result:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(soundType), soundType, null);
            }
            
            _audioSource.Play();
        }
    }
}
