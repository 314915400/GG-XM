using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VNmang : MonoBehaviour
{
    #region 变量
    public GameObject gamePane1;
    public GameObject 对话框;
    public TextMeshProUGUI speakerName;
    public TypewriterEffect typewriterEffect;



    public Sprite[] 图片数组; // 预设的图片数组
    public SpriteRenderer 图片渲染器;
    public Button 生长;
    private int 图片索引;




    

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
    
    private string currentSpeakingContent;//当前行内容

    private List<ExcelReader.ExcelData> storyData;
    private int currentLine;
    private float currentTypingSpeed = Constants.DEFAULT_TYPING_SPEED;

    
    

    public static VNmang Instance { get; private set;}
    #endregion
    #region 生命周期
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);//销毁当前游戏对象
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();

        Invoke("初始化",0.1f);
        
        //gamePane1.SetActive(false);//初始不显示游戏界面
    }

    void 初始化()
    {
        生长.onClick.AddListener(() => Shengzhang());
        //对话框.SetActive(false);
        //gamePane1.SetActive(false);
    }

    void Shengzhang()
    {
        图片渲染器.sprite = 图片数组[图片索引];
        图片索引++;
    }




    void Update()
    {
        //下面检测输入系统是否开着？不用
        //快速跳过
        if(!gamePane1.activeSelf && Input.GetMouseButtonDown(0) )
        {
            //创建预设体
            Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePosition.z = 0;
            

            Collider2D[] ab = Physics2D.OverlapCircleAll((Vector2)MousePosition, 0.5f);
            if (ab.Length> 0)
            {
                print(111);
                物体基类 wu = ab[0].GetComponent<物体基类>();
                if (wu.是否可点击)
                {
                    wu.互动(wu.当前状态);
                }
            }

        }




        if(对话框.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {

                DisplayNextLine();


            }
        }
        
    }
    #endregion
    #region 初始化
    
    
    public void StartGame()
    {
        InitializeAndLoadStory(defaultStoryFileName,defaultStartLine);
    }
    void InitializeAndLoadStory(string fileName,int lineNumber)//
    {

        gamePane1.SetActive(true);
        对话框.SetActive(true);



        Initialize(lineNumber);//初始化，关闭UI




        LoadStoryFromFile(fileName);//读取文件？
        //if(isLoad)//是否在恢复状态
        //{
        //    恢复();
        //    isLoad = false;
        //}
        DisplayNextLine();
    }
    void Initialize(int line)
    {
        currentLine =line;

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
        
        var path = storyPath + fileName + excelFileExtension;
        storyData = ExcelReader.ReadExcel(path);//获取列表
        if (storyData == null || storyData.Count == 0)
        {
            Debug.LogError(Constants.NO_DATA_FOUND);
        }
        
    }
    #endregion
    #region 展示
    void DisplayNextLine()
    {
        if (typewriterEffect.IsTyping())//检测是否正在打字
        {
            typewriterEffect.CompleteLine();//结束打字
        }
        else
        {
            DisplayThisLine();//显示当前行内容
        }
    }//快进跳过
    void 物品移动()
    {
        var data = storyData[currentLine];
        if (data.speakerName == "PPP")
        {
            gamePane1.SetActive(false);
        }
        else
        {
            物体基类 obj = GameObject.Find(data.speakerName).GetComponent<物体基类>();


            if (NotNullNorEmpty(data.speakingContent))
            {
               
                //状态修改
                obj.当前状态 = Convert.ToInt32(data.speakingContent);
            }

            if (NotNullNorEmpty(data.avatarImageFileName))
            {
                //玩家参数 = Convert.ToInt32(data.avatarImageFileName);
            }

            if (NotNullNorEmpty(data.vocalAudioFileName))
            {

                //应该直接调用一个函数来进行切换图片

                int i = Convert.ToInt32(data.vocalAudioFileName);
                切换图片(obj, i);

                
                
            }
            if (NotNullNorEmpty(data.backgroundImageFileName))
            {
                if(data.backgroundImageFileName == "Y")
                {
                    obj.是否可点击 = true;
                }
                else
                {
                    obj.是否可点击 = false;
                }
            }

            currentLine++;
            Invoke("物品移动",3.5f);
         
        }
        
    }
    public void 切换图片(物体基类 obj ,int 图片索引)
    {
        // 先淡出当前图片
        StartCoroutine(obj.FadeOut());
        // 等待淡出完成后再淡入新图片
        StartCoroutine(WaitForFadeOutAndFadeIn( obj,图片索引));
    }
    private IEnumerator WaitForFadeOutAndFadeIn(物体基类 obj, int 图片索引)
    {
        yield return new WaitForSeconds(obj.淡出时间);
        StartCoroutine(obj.FadeIn(图片索引));
    }



    void DisplayThisLine()//显示下一行
    {
        var data = storyData[currentLine];//var可以自行判断类型
        if (data.speakerName == "XXX")//物品移动模式
        {
            currentLine++;
            //执行一个函数（用嵌套）
            对话框.SetActive(false);
            物品移动();
            //退出对话
            

        }
        else if (data.speakerName == "AAA")//选项模式
        {
            currentLine++;
            对话框.SetActive(false);
            ShowChoices();

            return;//后面不执行了,可是还有检测鼠标的问题
            
        }
        else if (data.speakerName == "PPP")//结束
        {
            gamePane1.SetActive(false);
            //退出对话
        }


        speakerName.text = data.speakerName;
        currentSpeakingContent = data.speakingContent;//修改当前行内容
        typewriterEffect.StartTyping(currentSpeakingContent,currentTypingSpeed);//开始打字

       
        if (NotNullNorEmpty(data.avatarImageFileName))
        {
            UpdateAvatarImage(data.avatarImageFileName);//更新头像
        }
        else
        {
            avatarImage.gameObject.SetActive(false);//隐藏头像
        }
        if(NotNullNorEmpty(data.vocalAudioFileName))
        {
            PlayVocalAudio(data.vocalAudioFileName);//播放语音
        }
        if (NotNullNorEmpty(data.backgroundImageFileName))
        {
            UpdateBackgroundImage(data.backgroundImageFileName);//更新背景  叉掉
        }
        if (NotNullNorEmpty(data.backgroundMusicFileName))
        {
            PlayBackgroundMusic(data.backgroundMusicFileName);//播放背景音乐
        }



        //分水



        //if (NotNullNorEmpty(data.character1Action))
        //{
        //    UpdateCharacterImage(data.character1Action, data.character1ImageFileName,//擦掉
        //                         characterImage1,data.coordinateX1);//更新角色1和动作
        //}
        //if (NotNullNorEmpty(data.character2Action))
        //{
        //    UpdateCharacterImage(data.character2Action, data.character2ImageFileName,
        //                         characterImage2,data.coordinateX2);//更新角色2和动作
        //}
        currentLine++;//行数加一  
    }






    void 恢复()
    {
        var data = storyData[currentLine];
        if (NotNullNorEmpty(data.上次背景))
        {
            UpdateBackgroundImage(data.上次背景);
        }
        if(NotNullNorEmpty(data.上次音乐))
        {
            PlayBackgroundMusic(data.上次音乐);
        }
        //if(data.character1Action!= Constants.APPEAR_AT
        //    && NotNullNorEmpty(data.character1ImageFileName))
        //{
        //    UpdateCharacterImage(Constants.APPEAR_AT, data.character1ImageFileName,
        //                         characterImage1,data.上次位置1);
        //}
        //if(data.character2Action!= Constants.APPEAR_AT
        //    && NotNullNorEmpty(data.character2ImageFileName))
        //{
        //    UpdateCharacterImage(Constants.APPEAR_AT, data.character2ImageFileName,
        //                         characterImage2,data.上次位置2);
        //}
    }
    bool NotNullNorEmpty(string str)//判断是否为空
    {
        return !string.IsNullOrEmpty(str);
    }
    #endregion
    #region 选择器
    void ShowChoices()//显示选择器
    {
        var data = storyData[currentLine];
        choiceButton1.onClick.RemoveAllListeners();
        choiceButton2.onClick.RemoveAllListeners();
        choicePane1.SetActive(true);//显示选择器
        //专门整个函数？不行



        choiceButton1.GetComponentInChildren<TextMeshProUGUI>().text = data.speakerName;//更新选择器文字
        choiceButton1.onClick.AddListener(() => 按钮赋值(data.speakingContent));//选完后要记得返回对话框，而且行数要加一
        choiceButton2.GetComponentInChildren<TextMeshProUGUI>().text = data.avatarImageFileName;
        choiceButton2.onClick.AddListener(() => 按钮赋值(data.vocalAudioFileName));
        choiceButton3.GetComponentInChildren<TextMeshProUGUI>().text = data.backgroundImageFileName;
        choiceButton3.onClick.AddListener(() => 按钮赋值(data.backgroundMusicFileName));
        choiceButton4.GetComponentInChildren<TextMeshProUGUI>().text = data.character1Action;
        choiceButton4.onClick.AddListener( () => 按钮赋值(data.coordinateX1));
    }

    void 按钮赋值(string x )
    {
        if(NotNullNorEmpty(x))
        {
            int t = Convert.ToInt32(x);

            //玩家加上这个值

            currentLine++;


            choicePane1.SetActive(false);
            对话框.SetActive(true);
            
        }

       
    }
    #endregion
    #region 音频 图片 动作
    void UpdateAvatarImage(string imageFileName)//更新头像
    {
        
        
            var imagePath = Constants.AVATAR_PATH + imageFileName;
            UpdateImage(imagePath, avatarImage);
        
        
    }

    void PlayVocalAudio(string audioFileName)//播放音乐
    {
        string audioPath = Constants.VOCAL_PATH + audioFileName;
        PlayAudio(audioPath, vocalAudio, false);
    }

    void UpdateBackgroundImage(string imageFileName)//更新背景
    {
        string imagePath = Constants.BACKGROUND_PATH + imageFileName;
        UpdateImage(imagePath, backgroundImage);
    }
    void PlayBackgroundMusic(string musicFileName)//播放背景音乐
    {
        string musicPath = Constants.MUSIC_PATH+ musicFileName;
        PlayAudio(musicPath, backgroundMusic, true);
    }
    //void UpdateCharacterImage(string action, string imageFileName, Image characterImage,string x)
    //{
    //    //根据action执行对应的动画或操作
    //    if (action.StartsWith(Constants.APPEAR_AT))//解析appearat(x,y)动作并在(x,y)显示角色立绘
    //    {
    //        string imagePath = Constants.CHARACTER_PATH + imageFileName;//角色立绘路径
    //        if(NotNullNorEmpty(x))
    //        {
    //            UpdateImage(imagePath, characterImage);//显示立绘
    //            var newPosition = new Vector2(float.Parse(x), characterImage.rectTransform.anchoredPosition.y);//角色立绘新位置
    //            characterImage.rectTransform.anchoredPosition = newPosition;//更改位置
    //            characterImage.DOFade(1, (isLoad ? 0 : Constants.DURATION_TIME)).From(0);//将颜色渐变0-1
    //        }
    //        else
    //        {
    //            Debug.LogError(Constants.COORDINATE_MISSING);
    //        }
    //    }
    //    else if (action == Constants.DISAPPEAR)//disappear动作隐藏角色立绘
    //    {
    //        characterImage.DOFade(0,Constants.DURATION_TIME).OnComplete(() => characterImage.gameObject.SetActive(false));//渐隐角色，然后设为非活动状态
    //    }
    //    else if (action.StartsWith(Constants.MOVE_TO))//解析move to(x,y)动作并移动角色立绘到(x,y)
    //    {
    //        if (NotNullNorEmpty(x))
    //        {
    //            characterImage.rectTransform.DOAnchorPosX(float.Parse(x), Constants.DURATION_TIME);//移动角色组件的x轴位置
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
    void PlayAudio(string audioPath, AudioSource audioSource,bool isLoop)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(audioPath);
        if (audioClip != null)
        { 
            audioSource.clip = audioClip;
            audioSource.gameObject.SetActive(true);
            audioSource.Play();
            audioSource.loop = isLoop;//是否循环播放
        }
        else
        {
            Debug.LogError(Constants.AUDIO_LOAD_FAILED + audioPath);
        }
    }
    #endregion
    #region 按钮  
    #region 读取
    
    
    
    public void LoadGame(int Index)
    {
        //打开对话框，关闭输入
        //加载对话框内容，根据索引
        //isLoad = true;//真的需要恢复吗？我只需要改对应行数就行了吧
        print(2222);
        
        InitializeAndLoadStory(defaultStoryFileName, Index);
       
    }
    #endregion
    #region 其他按钮
    public void 显示()
    {
        gamePane1.SetActive(true);
    }
    #endregion
    #endregion
}
