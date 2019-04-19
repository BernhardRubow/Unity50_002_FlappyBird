using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace nvp.Prefabs.ParallaxScroller
{
    public class NvpParallaxScroller : MonoBehaviour
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        [Header("IMAGE LAYERS")]
        [SerializeField] private RawImage _layer1Image;
        [SerializeField] private RawImage _layer2Image;
        [SerializeField] private RawImage _layer3Image;
        [SerializeField] private RawImage _layer4Image;
        [SerializeField] private RawImage _layer5Image;


        [Header("IMAGE MOVEMENT")]
        [SerializeField] private float _speed = 10.0f;
        [SerializeField] private float _factorLayer1 = 0.8f;
        [SerializeField] private float _factorLayer2 = 0.35f;
        [SerializeField] private float _factorLayer3 = 0.2f;
        [SerializeField] private float _factorLayer4 = 0.25f;
        [SerializeField] private float _factorLayer5 = 0.05f;

        private Rect _uvRect;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            _uvRect = _layer1Image.uvRect;
            _uvRect.x += Time.deltaTime * _factorLayer1 * (_speed / 100);
            _layer1Image.uvRect = _uvRect;

            _uvRect = _layer2Image.uvRect;
            _uvRect.x += Time.deltaTime * _factorLayer2 * (_speed / 100);
            _layer2Image.uvRect = _uvRect;

            _uvRect = _layer3Image.uvRect;
            _uvRect.x += Time.deltaTime * _factorLayer3 * (_speed / 100);
            _layer3Image.uvRect = _uvRect;

            _uvRect = _layer4Image.uvRect;
            _uvRect.x += Time.deltaTime * _factorLayer4 * (_speed / 100);
            _layer4Image.uvRect = _uvRect;

            _uvRect = _layer5Image.uvRect;
            _uvRect.x += Time.deltaTime * _factorLayer5 * (_speed / 100);
            _layer5Image.uvRect = _uvRect;
        }
    }
}
