using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour
{
    private CardData cardData;
    float cardSpeed = 10f;

    public void Init(CardData cardData)
    {
        this.cardData = cardData;
    }

    private void Start()
    {
        //StartCoroutine(MoveCardTo(Hand.instance.transform.position));
        StartCoroutine(WaitMethod());
    }

    public IEnumerator MoveCardTo(Vector2 targetPos)
    {
        while (Vector2.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector2.Lerp(transform.position, targetPos, cardSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
    }

    public IEnumerator WaitMethod()
    {
        yield return StartCoroutine(MoveCardTo(Hand.instance.transform.position));
        Hand.instance.SetPosCardsInHand();
        //при быстром вытягивании карт ломается рука.
    }
}
