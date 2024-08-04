using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GuiManager : MonoBehaviour
    {
        public static GuiManager Instance;

        public Image hurtVignette;
        public TextMeshProUGUI bossNameText;

        private void Awake()
        {
            Instance ??= this;
        }

        public void FadeHurtVignette(float intensity)
        {
            hurtVignette.gameObject.SetActive(true);
            DOTween.Sequence()
                .Append(hurtVignette.DOFade(intensity, 0.05f))
                .AppendInterval(1.5f)
                .Append(hurtVignette.DOFade(0.0f, 0.5f))
                .SetEase(Ease.OutCubic);
        }

        public void ShowBossName(string bossName)
        {
            bossNameText.gameObject.SetActive(true);
            bossNameText.text = bossName;
            bossNameText.color = Color.white;
            DOTween.Sequence()
                .Append(bossNameText.DOFade(1.0f, 0.5f))
                .AppendInterval(2.0f)
                .Append(bossNameText.DOFade(0.0f, 0.5f));
        }
    }
}
