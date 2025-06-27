using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class mang : MonoBehaviour
{
    #region ����
    public GameObject gamePane1;
    public GameObject �Ի���;
    public GameObject dialogueBox;
    public TextMeshProUGUI speakerName;
    public TypewriterEffect typewriterEffect;


    public Image avatarImage;
    public AudioSource vocalAudio;
    public Image backgroundImage;
    public AudioSource backgroundMusic;
    public Image characterImage1;
    public Image characterImage2;


    public GameObject choicePane1;
    public Button choiceButton4;
    public Button choiceButton3;

    public Button choiceButton1;
    public Button choiceButton2;




    private readonly string storyPath = Constants.STORY_PATH;
    private readonly string defaultStoryFileName = Constants.DEFAULT_STORY_FILE_NAME;
    private readonly int defaultStartLine = Constants.DEFAULT_START_LINE;
    private readonly string excelFileExtension = Constants.EXCEL_FILE_EXTENSION;

    private string �����ļ�·��;//�����ļ�·��

    private string currentSpeakingContent;//��ǰ������

    private List<ExcelReader.ExcelData> storyData;
    private int currentLine;
    private string currentStoryFileName;
    private float currentTypingSpeed = Constants.DEFAULT_TYPING_SPEED;



    private bool isLoad = false;



    public static mang Instance { get; private set; }
    #endregion
    #region ��������
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);//���ٵ�ǰ��Ϸ����
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeSaveFilePath();//��ʼ�������ļ�·��


        Invoke("��ʼ��", 0.1f);

        //gamePane1.SetActive(false);//��ʼ����ʾ��Ϸ����
    }
    void ��ʼ��()
    {
        dialogueBox.SetActive(false);
        gamePane1.SetActive(false);
    }






    void Update()
    {
        //����������ϵͳ�Ƿ��ţ�����
        //��������
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {

            DisplayNextLine();


        }
    }
    #endregion
    #region ��ʼ��
    void InitializeSaveFilePath()
    {
        �����ļ�·�� = Path.Combine(Application.persistentDataPath, Constants.SAVE_FILE_PATH);
        if (!Directory.Exists(�����ļ�·��))
        {
            Directory.CreateDirectory(�����ļ�·��);//����Ŀ¼
        }
    }

    public void StartGame()
    {
        InitializeAndLoadStory(defaultStoryFileName, defaultStartLine);
    }
    void InitializeAndLoadStory(string fileName, int lineNumber)//
    {
        Initialize(lineNumber);//��ʼ�����ر�UI
        LoadStoryFromFile(fileName);//��ȡ�ļ���
        if (isLoad)//�Ƿ��ڻָ�״̬
        {
            �ָ�();
            isLoad = false;
        }
        DisplayNextLine();
    }
    void Initialize(int line)
    {
        currentLine = line;

        backgroundImage.gameObject.SetActive(false);
        backgroundMusic.gameObject.SetActive(false);

        avatarImage.gameObject.SetActive(false);
        vocalAudio.gameObject.SetActive(false);

        characterImage1.gameObject.SetActive(false);
        characterImage2.gameObject.SetActive(false);

        choicePane1.SetActive(false);
    }


    void LoadStoryFromFile(string fileName)
    {
        currentStoryFileName = fileName;
        var path = storyPath + fileName + excelFileExtension;
        storyData = ExcelReader.ReadExcel(path);//��ȡ�б�
        if (storyData == null || storyData.Count == 0)
        {
            Debug.LogError(Constants.NO_DATA_FOUND);
        }

    }
    #endregion
    #region չʾ
    void DisplayNextLine()
    {
        if (typewriterEffect.IsTyping())//����Ƿ����ڴ���
        {
            typewriterEffect.CompleteLine();//��������
        }
        else
        {
            DisplayThisLine();//��ʾ��ǰ������
        }
    }//�������
    void ��Ʒ�ƶ�()
    {
        var data = storyData[currentLine];
        if (data.speakerName == "PPP")
        {
            gamePane1.SetActive(false);
        }
        ������� obj = GameObject.Find(data.speakerName).GetComponent<�������>();


        if (NotNullNorEmpty(data.speakingContent))
        {
            //����ģ��
        }

        if (NotNullNorEmpty(data.avatarImageFileName))
        {
            //�ƶ���ʽ
        }

        if (NotNullNorEmpty(data.vocalAudioFileName))
        {
            //λ��
        }
        if (NotNullNorEmpty(data.backgroundImageFileName))
        {
            //ͼƬ������
        }

        currentLine++;
        ��Ʒ�ƶ�();
    }



    void DisplayThisLine()//��ʾ��һ��
    {
        var data = storyData[currentLine];//var���������ж�����
        if (data.speakerName == "XXX")//��Ʒ�ƶ�ģʽ
        {
            currentLine++;
            //ִ��һ����������Ƕ�ף�
            ��Ʒ�ƶ�();
            //�˳��Ի�
            gamePane1.SetActive(false);

        }
        else if (data.speakerName == "AAA")//ѡ��ģʽ
        {
            currentLine++;
            ShowChoices();

            return;//���治ִ����,���ǻ��м����������

        }
        else if (data.speakerName == "PPP")//����
        {
            gamePane1.SetActive(false);
            //�˳��Ի�
        }


        speakerName.text = data.speakerName;
        currentSpeakingContent = data.speakingContent;//�޸ĵ�ǰ������
        typewriterEffect.StartTyping(currentSpeakingContent, currentTypingSpeed);//��ʼ����


        if (NotNullNorEmpty(data.avatarImageFileName))
        {
            UpdateAvatarImage(data.avatarImageFileName);//����ͷ��
        }
        else
        {
            avatarImage.gameObject.SetActive(false);//����ͷ��
        }
        if (NotNullNorEmpty(data.vocalAudioFileName))
        {
            PlayVocalAudio(data.vocalAudioFileName);//��������
        }
        if (NotNullNorEmpty(data.backgroundImageFileName))
        {
            UpdateBackgroundImage(data.backgroundImageFileName);//���±���  ���
        }
        if (NotNullNorEmpty(data.backgroundMusicFileName))
        {
            PlayBackgroundMusic(data.backgroundMusicFileName);//���ű�������
        }



        //��ˮ



        //if (NotNullNorEmpty(data.character1Action))
        //{
        //    UpdateCharacterImage(data.character1Action, data.character1ImageFileName,//����
        //                         characterImage1,data.coordinateX1);//���½�ɫ1�Ͷ���
        //}
        //if (NotNullNorEmpty(data.character2Action))
        //{
        //    UpdateCharacterImage(data.character2Action, data.character2ImageFileName,
        //                         characterImage2,data.coordinateX2);//���½�ɫ2�Ͷ���
        //}
        currentLine++;//������һ  
    }






    void �ָ�()
    {
        var data = storyData[currentLine];
        if (NotNullNorEmpty(data.�ϴα���))
        {
            UpdateBackgroundImage(data.�ϴα���);
        }
        if (NotNullNorEmpty(data.�ϴ�����))
        {
            PlayBackgroundMusic(data.�ϴ�����);
        }
        //if(data.character1Action!= Constants.APPEAR_AT
        //    && NotNullNorEmpty(data.character1ImageFileName))
        //{
        //    UpdateCharacterImage(Constants.APPEAR_AT, data.character1ImageFileName,
        //                         characterImage1,data.�ϴ�λ��1);
        //}
        //if(data.character2Action!= Constants.APPEAR_AT
        //    && NotNullNorEmpty(data.character2ImageFileName))
        //{
        //    UpdateCharacterImage(Constants.APPEAR_AT, data.character2ImageFileName,
        //                         characterImage2,data.�ϴ�λ��2);
        //}
    }
    bool NotNullNorEmpty(string str)//�ж��Ƿ�Ϊ��
    {
        return !string.IsNullOrEmpty(str);
    }
    #endregion
    #region ѡ����
    void ShowChoices()//��ʾѡ����
    {
        var data = storyData[currentLine];
        choiceButton1.onClick.RemoveAllListeners();
        choiceButton2.onClick.RemoveAllListeners();
        choicePane1.SetActive(true);//��ʾѡ����
        //ר����������������



        choiceButton1.GetComponentInChildren<TextMeshProUGUI>().text = data.speakerName;//����ѡ��������
        choiceButton1.onClick.AddListener(() => ��ť��ֵ(data.speakingContent));//ѡ���Ҫ�ǵ÷��ضԻ��򣬶�������Ҫ��һ
        choiceButton2.GetComponentInChildren<TextMeshProUGUI>().text = data.avatarImageFileName;
        choiceButton2.onClick.AddListener(() => ��ť��ֵ(data.vocalAudioFileName));
        choiceButton3.GetComponentInChildren<TextMeshProUGUI>().text = data.backgroundImageFileName;
        choiceButton3.onClick.AddListener(() => ��ť��ֵ(data.character1Action));
        choiceButton4.GetComponentInChildren<TextMeshProUGUI>().text = data.coordinateX1;
        choiceButton4.onClick.AddListener(() => ��ť��ֵ(data.character2Action));
    }

    void ��ť��ֵ(string x)
    {
        if (NotNullNorEmpty(x))
        {
            int t = Convert.ToInt32(x);

            //��Ҽ������ֵ

            currentLine++;


            choicePane1.SetActive(false);
            �Ի���.SetActive(true);

        }


    }
    #endregion
    #region ��Ƶ ͼƬ ����
    void UpdateAvatarImage(string imageFileName)//����ͷ��
    {


        var imagePath = Constants.AVATAR_PATH + imageFileName;
        UpdateImage(imagePath, avatarImage);


    }

    void PlayVocalAudio(string audioFileName)//��������
    {
        string audioPath = Constants.VOCAL_PATH + audioFileName;
        PlayAudio(audioPath, vocalAudio, false);
    }

    void UpdateBackgroundImage(string imageFileName)//���±���
    {
        string imagePath = Constants.BACKGROUND_PATH + imageFileName;
        UpdateImage(imagePath, backgroundImage);
    }
    void PlayBackgroundMusic(string musicFileName)//���ű�������
    {
        string musicPath = Constants.MUSIC_PATH + musicFileName;
        PlayAudio(musicPath, backgroundMusic, true);
    }
    //void UpdateCharacterImage(string action, string imageFileName, Image characterImage,string x)
    //{
    //    //����actionִ�ж�Ӧ�Ķ��������
    //    if (action.StartsWith(Constants.APPEAR_AT))//����appearat(x,y)��������(x,y)��ʾ��ɫ����
    //    {
    //        string imagePath = Constants.CHARACTER_PATH + imageFileName;//��ɫ����·��
    //        if(NotNullNorEmpty(x))
    //        {
    //            UpdateImage(imagePath, characterImage);//��ʾ����
    //            var newPosition = new Vector2(float.Parse(x), characterImage.rectTransform.anchoredPosition.y);//��ɫ������λ��
    //            characterImage.rectTransform.anchoredPosition = newPosition;//����λ��
    //            characterImage.DOFade(1, (isLoad ? 0 : Constants.DURATION_TIME)).From(0);//����ɫ����0-1
    //        }
    //        else
    //        {
    //            Debug.LogError(Constants.COORDINATE_MISSING);
    //        }
    //    }
    //    else if (action == Constants.DISAPPEAR)//disappear�������ؽ�ɫ����
    //    {
    //        characterImage.DOFade(0,Constants.DURATION_TIME).OnComplete(() => characterImage.gameObject.SetActive(false));//������ɫ��Ȼ����Ϊ�ǻ״̬
    //    }
    //    else if (action.StartsWith(Constants.MOVE_TO))//����move to(x,y)�������ƶ���ɫ���浽(x,y)
    //    {
    //        if (NotNullNorEmpty(x))
    //        {
    //            characterImage.rectTransform.DOAnchorPosX(float.Parse(x), Constants.DURATION_TIME);//�ƶ���ɫ�����x��λ��
    //        }
    //        else
    //        {
    //            Debug.LogError(Constants.COORDINATE_MISSING);
    //        }


    //    }
    //}
    void UpdateImage(string imagePath, Image image)
    {
        Sprite sprite = Resources.Load<Sprite>(imagePath);
        if (sprite != null)
        {
            image.sprite = sprite;
            image.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError(Constants.IMAGE_LOAD_FAILED + imagePath);
        }
    }
    void PlayAudio(string audioPath, AudioSource audioSource, bool isLoop)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(audioPath);
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.gameObject.SetActive(true);
            audioSource.Play();
            audioSource.loop = isLoop;//�Ƿ�ѭ������
        }
        else
        {
            Debug.LogError(Constants.AUDIO_LOAD_FAILED + audioPath);
        }
    }
    #endregion
    #region ��ť  
    #region ��ȡ



    public void LoadGame(int Index)
    {
        //�򿪶Ի��򣬹ر�����
        //���ضԻ������ݣ���������
        isLoad = true;//�����Ҫ�ָ�����ֻ��Ҫ�Ķ�Ӧ���������˰�

        var lineNumber = Index - 1;
        InitializeAndLoadStory("���������Ӧ�ļ�·�������ݶ�Ӧ��Ʒ�����ж�", lineNumber);
        string savePath = Path.Combine(�����ļ�·��, Index + Constants.SAVE_FILE_EXTENSION);
    }
    #endregion
    #region ������ť
    public void ��ʾ()
    {
        gamePane1.SetActive(true);
    }
    #endregion
    #endregion
}
