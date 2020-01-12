using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErikOverflow.YardDefender
{
    public class ScreenWipeController : MonoBehaviour
    {
        [SerializeField] SpriteRenderer portalOverlay = null;
        [SerializeField] LayerMask cullingMask = new LayerMask();
        [SerializeField] Material material = null;
        [SerializeField] float animationTime = 1f;

        Camera screenShotCamera;

        private void Awake()
        {
            screenShotCamera = Camera.main;
            EventManager.instance.OnLevelChanged += FreezeFrame;
        }

        public void FreezeFrame()
        {
            StartCoroutine(FreezeFrameAndScroll());
        }
        IEnumerator FreezeFrameAndScroll()
        {
            int pixelWidth = screenShotCamera.pixelWidth;
            int pixelHeight = screenShotCamera.pixelHeight;
            yield return new WaitForEndOfFrame();
            Texture2D screenShot;
            LayerMask origMask = screenShotCamera.cullingMask;
            screenShotCamera.cullingMask = cullingMask;
            RenderTexture rt = new RenderTexture(pixelWidth, pixelHeight, 20);
            screenShotCamera.targetTexture = rt;
            screenShot = new Texture2D(pixelWidth, pixelHeight, TextureFormat.RGB24, false);
            screenShotCamera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, pixelWidth, pixelHeight), 0, 0);
            screenShot.Apply();
            screenShotCamera.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);

            Sprite tempSprite = Sprite.Create(screenShot, new Rect(0, 0, pixelWidth, pixelHeight), new Vector2(0.5f,0.5f), (float)pixelHeight / (2 * screenShotCamera.orthographicSize));
            portalOverlay.sprite = tempSprite;
            screenShotCamera.cullingMask = origMask;
            //re enable 
            EventManager.instance.LevelStarted();
            float time = 0;
            while(time < animationTime)
            {
                time += Time.deltaTime;
                material.SetFloat("_ProgressAmount", time / animationTime);
                yield return null;
            }
            //portalOverlay.sprite = null;
        }
    }
}