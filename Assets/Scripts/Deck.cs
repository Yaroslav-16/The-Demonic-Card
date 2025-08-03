using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEditor.Progress;

public class Deck : MonoBehaviour
{
    static public Deck instance;
    Transform spawnCardPos;

    Stack<CardData> cardInDeck = new Stack<CardData>();
    [SerializeField] CardData[] cards;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        FillingRandomCardData(10);
        spawnCardPos = Hand.instance.spawnCardPos;
    }

    public CardData ReturnTopCardData()
    {
        if (cardInDeck.Count > 0)
            return cardInDeck.Pop();
        else
            Debug.LogError("Стек пуст");
        return null;
    }

    public void FillingRandomCardData(int count)
    {
        cards = Resources.LoadAll<CardData>("CardData");
        for (int i = 1; i <= count; i++)
        {
            int index = Random.Range(0, cards.Length);
            cardInDeck.Push(cards[index]);
        }
    }
    private void OnMouseDown()
    {
        CardData data = ReturnTopCardData();
        var card = Instantiate(data.prefab, spawnCardPos);
        card.GetComponent<CardView>().Init(data);
        Hand.instance.cardsInHand.Add(card);
        //накидать событий а то с вызовыми траблы
        //сделать возможным вытягивание карты после того как предыдущая вытянутая карта переместилась в руку
        //и на руку можно забить с этого момента
        //заняться спелами на карты и ии для бота и геймдизайном
    }
}
