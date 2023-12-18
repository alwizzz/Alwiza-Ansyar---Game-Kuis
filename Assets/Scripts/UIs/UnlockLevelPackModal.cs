using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UnlockLevelPackModal : MonoBehaviour
{
    [SerializeField] private PlayerProgressData playerProgressData;

    [SerializeField] private GameObject purchaseConfirmationModal;
    [SerializeField] private GameObject afterPurchaseModal;
    [SerializeField] private TextMeshProUGUI afterPurchaseText;

    [Header("Caches")]
    [SerializeField] private LevelPack selectedLevelPack;

    private void Start()
    {
        SubscribeEvents();

        purchaseConfirmationModal.SetActive(false);
        afterPurchaseModal.SetActive(false);

        selectedLevelPack = null;
    }

    public void ShowPurchaseConfirmationModal()
    {
        purchaseConfirmationModal.SetActive(true);
        afterPurchaseModal.SetActive(false);
    }

    private void ShowAfterPurchaseModal(string message)
    {
        afterPurchaseText.text = message;

        purchaseConfirmationModal.SetActive(false);
        afterPurchaseModal.SetActive(true);
    }

    private void SubscribeEvents()
    {
        LevelPackOptionUI.OnClick += AttemptToPurchase;
    }
    private void UnsubscribeEvents()
    {
        LevelPackOptionUI.OnClick -= AttemptToPurchase;
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void AttemptToPurchase(LevelPack levelPack, bool isLocked)
    {
        if (!isLocked) { return; }

        selectedLevelPack = levelPack;
        ShowPurchaseConfirmationModal();
    }

    public void ConfirmPurchase()
    {
        if(selectedLevelPack == null)
        {
            print("ERROR");
            return; 
        }

        string message = "";

        if(playerProgressData.data.coins < selectedLevelPack.GetPrice())
        {
            message = "Pembelian gagal. Anda tidak memiliki koin yang cukup";
        } else
        {
            //TODO proses pembelian
            message = "Pembelian berhasil.";
        }

        selectedLevelPack = null;
        ShowAfterPurchaseModal(message);

    }

}
