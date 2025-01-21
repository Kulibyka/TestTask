using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Image urlImage;
    [SerializeField] private Image resourcesImage;
    [SerializeField] private Button sceneButton;

    [SerializeField] private Slider progressBarUrl;
    [SerializeField] private Slider progressBarResources;
    [SerializeField] private Slider progressBarScene;
    // Start is called before the first frame update
    void Start()
    {
        sceneButton.interactable = false;
        RunBootstrapSequence().Forget();
    }

    private async UniTask RunBootstrapSequence()
    {
        await LoadImageFromUrl("https://img.freepik.com/free-photo/beautiful-kitten-with-colorful-clouds_23-2150752964.jpg?semt=ais_incoming");

        await LoadImageFromResources("dandadan");

        await LoadSceneAsync("S_Content_Overview");


    }

    private async UniTask LoadImageFromUrl(string url)
    {
        UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(url);
 
        var www = unityWebRequest.SendWebRequest();

        while (!www.isDone)
        {
            progressBarUrl.value = www.progress;
            await UniTask.Yield();
        }

        if (unityWebRequest.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(unityWebRequest);
            urlImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
            progressBarUrl.value = 1f;
        }
        else
        {
            Debug.Log("Failed to load image");
        }
    }


    private async UniTask LoadImageFromResources(string resource)
    {
        var resourceRequest = Resources.LoadAsync<Sprite>(resource);

        while (!resourceRequest.isDone)
        {
            progressBarResources.value = resourceRequest.progress; 
            await UniTask.Yield();
        }
        if (resourceRequest.asset is Sprite sprite)
        {
            resourcesImage.sprite = sprite;
            progressBarResources.value = 1f; 
        }
        else
        {
            Debug.Log("Failed to load image");
        }
    }

    private async UniTask LoadSceneAsync(string scene)
    {
        var sceneChange = SceneManager.LoadSceneAsync(scene);
        sceneChange.allowSceneActivation = false;

        while (sceneChange.progress < 0.9f)
        {
            progressBarScene.value = sceneChange.progress;
            await UniTask.Yield();
        }
        progressBarScene.value = 1f;
        sceneButton.interactable = true;
        sceneButton.onClick.AddListener(() => { 
            sceneChange.allowSceneActivation = true;
            sceneButton.interactable = false;
        });
    }
    
    /*private async UniTask LoadImageFromUrl(string url)
    {
        var unityWebRequestTexture = await UnityWebRequestTexture
            .GetTexture(url)
            .SendWebRequest();

        while (!unityWebRequestTexture.isDone) { 
            progressBarUrl.value = unityWebRequestTexture.downloadProgress * 100;
        }
        if (unityWebRequestTexture.isDone ) { 
        
        }
        Texture2D texture = ((DownloadHandlerTexture)unityWebRequestTexture.downloadHandler).texture;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
        urlImage.sprite = sprite;
    }*/
}