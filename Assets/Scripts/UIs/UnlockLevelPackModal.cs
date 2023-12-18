using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


using TMPro;
public class UnlockLevelPackModal : MonoBehaviour
{
    [SerializeField] private PlayerProgressData playerProgressData;

    [SerializeField] private GameObject purchaseConfirmationModal;
    [SerializeField] private GameObject afterPurchaseModal;
    [SerializeField] private TextMeshProUGUI afterPurchaseText;

    [Header("Caches")]
    [SerializeField] private ChooseLevelMenuManager chooseLevelMenuManager;
    [SerializeField] private LevelPack selectedLevelPack;
    [SerializeField] private LevelPackOptionUI selectedLevelPackOption;
    [SerializeField] private bool isHookingButton;
    //[SerializeField] private EventSystem eventSystem;

    /*
     * NOTE: 
     * Di sini saya menggunakan IPointerClickHandler untuk memudahkan saya mendapatkan akses LevelPackOptionUI
     * mana yang perlu di Unlock() setelah proses pembelian level pack berhasil
     */

    private void Start()
    {
        SubscribeEvents();

        purchaseConfirmationModal.SetActive(false);
        afterPurchaseModal.SetActive(false);

        ResetCaches();
    }

    private void Update()
    {
        if(isHookingButton)
        {
            HookSelectedLevelPackOption();
        }
    }

    private void HookSelectedLevelPackOption()
    {
        if (EventSystem.current == null) { return; }

        var currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
        if (currentSelectedGameObject == null) { return; }

        selectedLevelPackOption = currentSelectedGameObject.GetComponent<LevelPackOptionUI>();
        if (selectedLevelPackOption != null) 
        { 
            print("hooked a button!");
            isHookingButton = false;
        }
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

        string message;

        if(playerProgressData.data.coins < selectedLevelPack.GetPrice())
        {
            message = "Pembelian gagal. Anda tidak memiliki koin yang cukup";
        } else
        {
            chooseLevelMenuManager.PurchaseLevelPack(selectedLevelPack, selectedLevelPackOption);
            message = "Pembelian berhasil.";
        }

        ResetCaches();

        ShowAfterPurchaseModal(message);

    }

    public void ResetCaches()
    {
        selectedLevelPack = null;
        selectedLevelPackOption = null;

        isHookingButton = true;
    }

}
