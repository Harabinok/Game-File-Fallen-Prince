using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;




namespace FallenPrice
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ScriptAnimation : MonoBehaviour
    {

        [SerializeField] private int FrameRate;
        [SerializeField] private AnimationClip[] _clips;
        [SerializeField] UnityEvent<String> _onComplete;



        private SpriteRenderer _spriteRander;
        private float _nextFrameTime;
        private float _secendPerFrame;
        private int _currentFrame;
        private float _spriteUpdateTime;
        private bool _IsPlaying = true;
        private int _currentClip;



        private void Start()
        {
            _spriteRander = GetComponent<SpriteRenderer>();
            enabled = _IsPlaying;
            _secendPerFrame = 1f / FrameRate;
            AnimationStart();
        }
        private void OnBecameVisible()
        {
            enabled = _IsPlaying;
        }
        private void OnBecameInvisible()
        {
            enabled = false;
        }

        private void OnEnable()
        {
            
            _spriteUpdateTime = Time.time + _secendPerFrame;
       
        }
        public void SetClip(String ClipsName)
        {
            for (int i = 0; i < _clips.Length; i++)
            {
                if (_clips[i].Name == ClipsName)
                {
                    _currentClip = i;
                    AnimationStart();
                    return;
                }
               
            }
        }
        private void AnimationStart()
        {
            _nextFrameTime = Time.time * _secendPerFrame;
            _IsPlaying = true;
            _currentFrame = 0;
        }
        private void Update()
        {
            var Clip = _clips[_currentClip];
            if (_spriteUpdateTime > Time.time) return;

            if (_currentFrame >= Clip._Sprite.Length)
            {
                if (Clip.Loop)
                {
                    _currentFrame = 0;
                }
                else
                {
                    enabled = false;
                    Clip.OnComplete?.Invoke();
                    _onComplete?.Invoke(Clip.Name);
                    enabled = _IsPlaying = Clip.AllNextClip;

                    if (Clip.AllNextClip)
                    {
                        _currentFrame = 0;
                        _currentClip = (int)Mathf.Repeat(_currentClip + 1, _clips.Length);
                    }
                }
                return;
            }


            _spriteRander.sprite = Clip._Sprite[_currentFrame];
            _spriteUpdateTime += _secendPerFrame;
            _currentFrame++;
        }
        [Serializable]

        public class AnimationClip
        {
            [SerializeField] private string _name;
            [SerializeField] private Sprite[] _sprite;
            [SerializeField] private bool _loop;
            [SerializeField] UnityEvent _onComplete;
            [SerializeField] private bool _AllNextClip;

            public string Name => _name;
            public UnityEvent OnComplete => _onComplete;
            public Sprite[] _Sprite => _sprite;
            public bool Loop => _loop;

            public bool AllNextClip => _AllNextClip;
        }
    }
}


 