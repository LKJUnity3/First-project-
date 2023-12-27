using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // �������� �ʴ� �÷����� ��� ���� null�� ���� �ֽ��ϴ�.

    void Awake()
    {
        // ���� �÷����� ���� ���� ID�� �����ɴϴ�.
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif


    }

    // ���� ���ֿ� �������� �ε��մϴ�.
    public void LoadAd()
    {
        // �߿�! �ʱ�ȭ �Ŀ��� �������� �ε��մϴ�(�� �������� �ʱ�ȭ�� �ٸ� ��ũ��Ʈ���� ó����).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // ������ ���������� �ε�Ǹ� ��ư�� �����ʸ� �߰��ϰ� Ȱ��ȭ�մϴ�.
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {

        }
    }

    // ������ ��ư�� Ŭ���� �� ������ �޼��带 �����մϴ�.
    public void ShowAd()
    {
        // �׷� ���� ������ ǥ���մϴ�.
        Advertisement.Show(_adUnitId, this);
    }

    // Show Listener�� OnUnityAdsShowComplete �ݹ� �޼��带 �����Ͽ� ������ ������ ������ �����մϴ�.
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            SceneManager.LoadScene("MainScene");

            // ������ �ݴϴ�.
        }
    }

    // Load �� Show ������ ���� �ݹ��� �����մϴ�.
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // ���� ���� ������ ����Ͽ� �� �ٸ� ������ �ε����� ���θ� �����մϴ�.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // ���� ���� ������ ����Ͽ� �� �ٸ� ������ �ε����� ���θ� �����մϴ�.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // ��ư �����ʸ� �����մϴ�.

    }
}