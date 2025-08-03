using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static Hand instance;
    public Transform spawnCardPos;

    public List<GameObject> cardsInHand;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        spawnCardPos = GameObject.Find("SpawnCardPos").GetComponent<Transform>();
    }

    public void SetPosCardsInHand()
    {
        float distanceBtwCards = 0.2f;
        float sizeOfCard = 1.2f;
        float handSize = cardsInHand.Count * (sizeOfCard + distanceBtwCards);
        float centerOffset = handSize / 2;
        float posY = cardsInHand[0].transform.position.y;

        // Располагаем карты симметрично относительно центра
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            // Рассчитываем позицию относительно центра
            float offsetFromCenter = (sizeOfCard + distanceBtwCards) * (i - cardsInHand.Count / 2f + 0.5f);
            float posX = spawnCardPos.position.x + offsetFromCenter;

            //cardsInHand[i].transform.position = new Vector2(posX, posY);
            StartCoroutine(cardsInHand[i].GetComponent<CardView>().MoveCardTo(new Vector2(posX, posY)));
        }
    }

}

