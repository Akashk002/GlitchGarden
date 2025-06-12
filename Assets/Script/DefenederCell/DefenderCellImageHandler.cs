using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DefenderCellImageHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private DefenderScriptable DefenderScriptable;
    private Image cellImage;
    private RectTransform rectTransform;
    private Vector2 originalAnchoredPosition;
    private Vector3 originalPosition;
    private bool cellActivate = true;
    private bool canAfford;

    // Start is called before the first frame update

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        cellImage = GetComponent<Image>();
    }
    private void Start()
    {
        originalPosition = rectTransform.localPosition;
        originalAnchoredPosition = rectTransform.anchoredPosition;
    }

    private void FixedUpdate()
    {
        if (CurrencyManager.Instance.CanAfford(DefenderScriptable.Cost))
        {
            cellImage.color = new Color(1, 1, 1, 1f);
            canAfford = true;
        }
        else
        {
            cellImage.color = new Color(1, 1, 1, 0.6f);
            canAfford = false;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!cellActivate) return;
        if (!canAfford) return;
        cellImage.color = new Color(1, 1, 1, 0.6f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!cellActivate) return;
        if (!canAfford) return;
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!cellActivate) return;
        if (!canAfford) return;
        bool defenderPlaced = GameService.Instance.EventService.OnPlaceDefender.InvokeEvent(DefenderScriptable.DefenderType, eventData.position);
        //bool defenderPlaced = GameService.Instance.DefenderService.CreateDefender(DefenderScriptable.DefenderType, eventData.position);

        if (defenderPlaced)
        {
            cellImage.color = new Color(1, 1, 1, .6f);
            StarImageFilling();
            cellActivate = false;
        }
        else
        {
            cellImage.color = new Color(1, 1, 1, 1f);
        }
        rectTransform.anchoredPosition = originalAnchoredPosition;
        rectTransform.localPosition = originalPosition;
    }

    private void StarImageFilling()
    {
        cellImage.fillAmount = 0;

        LeanTween.value(gameObject, 0f, 1f, DefenderScriptable.RecoverTime)
            .setEase(LeanTweenType.linear)
            .setOnUpdate((float value) =>
            {
                cellImage.fillAmount = value;
            })
            .setOnComplete(() =>
            {
                cellImage.color = new Color(1, 1, 1, 1f);
                cellActivate = true;
            });
    }


    internal void ConfigureCellImage(DefenderScriptable defenderScriptable)
    {
        cellImage.sprite = defenderScriptable.sprite;
        this.DefenderScriptable = defenderScriptable;
    }
}
