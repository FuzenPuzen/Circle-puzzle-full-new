using UnityEngine;
using UnityEngine.EventSystems;
using EventBus;

public class SwipeView : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private float swipeIncrementx = 1f; // Количество пройденных пикселей для увеличения переменной
    private Vector2 lastSwipePos;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentSwipePos = eventData.position;
        float swipeDeltaX = currentSwipePos.x - lastSwipePos.x;
        float swipeDeltaY = currentSwipePos.y - lastSwipePos.y;

        if (Mathf.Abs(swipeDeltaX) >= swipeIncrementx)
        {
            if(currentSwipePos.y <= Screen.height / 2)
                if (swipeDeltaX > 0)
                    EventBus<OnIncreaceX>.Raise();
                else
                    EventBus<OnDecreaceX>.Raise();
            else
                if (swipeDeltaX > 0)
                    EventBus<OnDecreaceX>.Raise();
                else
                    EventBus<OnIncreaceX>.Raise();

            lastSwipePos = currentSwipePos;
        }

        if (Mathf.Abs(swipeDeltaY) >= swipeIncrementx)
        {
            if (currentSwipePos.x >= Screen.width / 2)
                if (swipeDeltaY > 0)
                    EventBus<OnIncreaceX>.Raise();
                else
                    EventBus<OnDecreaceX>.Raise();
            else
                if (swipeDeltaY > 0)
                EventBus<OnDecreaceX>.Raise();
            else
                EventBus<OnIncreaceX>.Raise();

            lastSwipePos = currentSwipePos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EventBus<OnEndRotate>.Raise();
    }

}