using FrameWork.Factories;
using FrameWork.Manager;
using FrameWork.Utils;

public class GameLaunch : UnitySingleton<GameLaunch>
{
    public override void Awake()
    {
        base.Awake();
        this.InitFramework();
        this.InitGameLogic();
    }

    #region 初期化

    /// <summary>
    /// アップデートチェック
    /// </summary>
    private void CheckHotUpdate()
    {
        //データ取得
        //ダウンロード情報
        //ローカルにダウンロード
    }

    /// <summary>
    /// フレームワークを初期化
    /// </summary>
    private void InitFramework()
    {
        this.gameObject.AddComponent<ResManager>();
        this.gameObject.AddComponent<UIManager>();
    }

    /// <summary>
    /// ゲームロジックに入る
    /// </summary>
    private void InitGameLogic()
    {
        this.gameObject.AddComponent<GameApp>();
        GameApp.Instance.InitGame();
    }

    #endregion
}