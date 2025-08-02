using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour
{
    private CardData cardData;
    float cardSpeed = 5f;

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
            //card.transform.position = Vector2.MoveTowards(card.transform.position, Hand.instance.transform.position, speed * Time.deltaTime);

            transform.position = Vector2.Lerp(transform.position, targetPos, cardSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        //Hand.instance.DrawCard();
        //бесконечность
    }
    public IEnumerator WaitMethod()
    {
        yield return StartCoroutine(MoveCardTo(Hand.instance.transform.position));
        Hand.instance.DrawCard();
    }
}
