using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using Constans;
using OneByOne;
using UnityEngine.SceneManagement;

public static class WrapFile {

    public static BindType[] binds = new BindType[]
    {
        _GT(typeof(object)),
        _GT(typeof(System.String)),
        _GT(typeof(System.Enum)),   
        _GT(typeof(IEnumerator)),
        _GT(typeof(System.Delegate)),        
        _GT(typeof(Type)).SetBaseName("System.Object"),                                                     
        _GT(typeof(UnityEngine.Object)),
        //测试模板
        ////_GT(typeof(Dictionary<int,string>)).SetWrapName("DictInt2Str").SetLibName("DictInt2Str"),
        
        //custom    
        _GT(typeof(Util)),
        _GT(typeof(AppConst)),
		_GT(typeof(WWW)),
        _GT(typeof(LuaEnumType)),
        _GT(typeof(Debugger)),
        _GT(typeof(DelegateFactory)),
        _GT(typeof(TestLuaDelegate)),
        _GT(typeof(TestDelegateListener)),
        _GT(typeof(TestEventListener)),
        
        //unity                        
        _GT(typeof(Component)),
        _GT(typeof(Behaviour)),
        _GT(typeof(MonoBehaviour)),        
        _GT(typeof(GameObject)),
        _GT(typeof(Transform)),
        _GT(typeof(Space)),

        _GT(typeof(Camera)),   
        _GT(typeof(CameraClearFlags)),           
        _GT(typeof(Material)),
        _GT(typeof(Renderer)),        
        _GT(typeof(MeshRenderer)),
        _GT(typeof(SkinnedMeshRenderer)),
        _GT(typeof(Light)),
        _GT(typeof(LightType)),     
        _GT(typeof(ParticleEmitter)),
        _GT(typeof(ParticleRenderer)),
        _GT(typeof(ParticleAnimator)),        
                
        _GT(typeof(Physics)),
        _GT(typeof(Collider)),
        _GT(typeof(BoxCollider)),
        _GT(typeof(MeshCollider)),
        _GT(typeof(SphereCollider)),
        
        _GT(typeof(CharacterController)),

        _GT(typeof(Animation)),             
        _GT(typeof(AnimationClip)).SetBaseName("UnityEngine.Object"),
        _GT(typeof(TrackedReference)),
        _GT(typeof(AnimationState)),  
        _GT(typeof(QueueMode)),  
        _GT(typeof(PlayMode)),                  
        
        _GT(typeof(AudioClip)),
        _GT(typeof(AudioSource)),                
        
        _GT(typeof(Application)),
        _GT(typeof(SceneManager)),
        _GT(typeof(SceneLoader)),
        _GT(typeof(Input)),    
        _GT(typeof(TouchPhase)),            
        _GT(typeof(KeyCode)),             
        _GT(typeof(Screen)),
        _GT(typeof(Time)),
        _GT(typeof(RenderSettings)),
        _GT(typeof(SleepTimeout)),        

        _GT(typeof(AsyncOperation)).SetBaseName("System.Object"),
        _GT(typeof(AssetBundle)),   
        _GT(typeof(BlendWeights)),   
        _GT(typeof(QualitySettings)),          
        _GT(typeof(AnimationBlendMode)),    
        _GT(typeof(Texture)),
        _GT(typeof(RenderTexture)),
        _GT(typeof(ParticleSystem)),
        _GT(typeof(PlayerPrefs)),

        //自定义的注册脚本
        _GT(typeof(AssetInfo)),
        _GT(typeof(UIutils)),
        _GT(typeof(MapUtils)),
        _GT(typeof(TransUtils)),
        _GT(typeof(NetWorkScript)),
        _GT(typeof(ErrorModel)),
        _GT(typeof(ErrorManager)),
        _GT(typeof(EventDef)),
        _GT(typeof(GameData)),
        _GT(typeof(SkillButton)),
        _GT(typeof(PlayerBehaviourFacade)),
        _GT(typeof(FightUnitMgr)),
        _GT(typeof(MultipleTimeLengthButtonTrigger)),
        _GT(typeof(PlayerController)),
        _GT(typeof(TransformFinder)),
        _GT(typeof(SkillTipSingleton)),
        _GT(typeof(ResourceLoader)),
        _GT(typeof(SocketModel)),
        _GT(typeof(CameraMgr)),
        _GT(typeof(InputManager)),
        _GT(typeof(MusicManager)),
        _GT(typeof(AutomicInt)),

        //OneByOne
        _GT(typeof(Protocol)),
        _GT(typeof(LoginProtocol)),
        _GT(typeof(SelectProtocol)),
        _GT(typeof(MatchProtocol)),
        _GT(typeof(UserProtocol)),
        _GT(typeof(FightProtocol)),

        _GT(typeof(AccountDTO)),
        _GT(typeof(UserDTO)),
        _GT(typeof(SelectRoomDTO)),
        _GT(typeof(MoveDTO)),
        _GT(typeof(AttackDTO)),
        _GT(typeof(DamageDTO)),

        _GT(typeof(SelectModel)),
        _GT(typeof(FightPlayerModel)),
        _GT(typeof(FightBuildModel)),
        _GT(typeof(FightRoomModel)),
        _GT(typeof(FightSoldierModel)),
        _GT(typeof(FightSkill)),
        _GT(typeof(SkillTarget)),
        _GT(typeof(SkillType)),
        
        //UGUI
        _GT(typeof(Canvas)),
        _GT(typeof(RectTransform)),
        _GT(typeof(InputField)),
        _GT(typeof(Button)),
        _GT(typeof(Text)),
        _GT(typeof(Image)),
        _GT(typeof(RawImage)),
        _GT(typeof(Mask)),
        _GT(typeof(RectMask2D)),
        _GT(typeof(Toggle)),
        _GT(typeof(ToggleGroup)),
        _GT(typeof(Slider)),
        _GT(typeof(Scrollbar)),
        _GT(typeof(Dropdown)),
        _GT(typeof(ScrollRect)),
        _GT(typeof(Selectable)),
        _GT(typeof(Sprite)),


//------------------------------------------------------------------
        //ngui
        /*_GT(typeof(UICamera)),
        _GT(typeof(Localization)),
        _GT(typeof(NGUITools)),

        _GT(typeof(UIRect)),
        _GT(typeof(UIWidget)),        
        _GT(typeof(UIWidgetContainer)),     
        _GT(typeof(UILabel)),        
        _GT(typeof(UIToggle)),
        _GT(typeof(UIBasicSprite)),        
        _GT(typeof(UITexture)),
        _GT(typeof(UISprite)),           
        _GT(typeof(UIProgressBar)),
        _GT(typeof(UISlider)),
        _GT(typeof(UIGrid)),
        _GT(typeof(UIInput)),
        _GT(typeof(UIScrollView)),
        
        _GT(typeof(UITweener)),
        _GT(typeof(TweenWidth)),
        _GT(typeof(TweenRotation)),
        _GT(typeof(TweenPosition)),
        _GT(typeof(TweenScale)),
        _GT(typeof(UICenterOnChild)),    
        _GT(typeof(UIAtlas)),*/         
    };

    public static BindType _GT(Type t) {
        return new BindType(t);
    }
}
