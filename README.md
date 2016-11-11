# ViveInput
HTC Vive Viveコントローラーの入力を簡略化

HTC ViveのViveコントローラーの入力が少し手間なのでstatic関数から呼べるようにしました。
動作にはSteamVR Pluginが必要です。https://www.assetstore.unity3d.com/jp/#!/content/32647
StermVR Pluginバージョン1.1.1にて作成しました。

______________________________________________________________________________________________________

使い方

	ViveInput.unitypackageをインポートしてください。

	このプログラムはSteamVR Plugin同様、GetTouchDown、GetTouch、GetTouchUp、GetPressDown、GetPress、GetPressUpの関数を用意しています。
	第一引数にController型、もしくはGameObject型をとります。
	この引数でどちらのコントローラーなのかを判別しています。
	GameObjectの場合、"Controller (left)"もしくは"Controller (right)"のオブジェクトを指定してください。
	第二引数にButtonMaskをとります。
	この引数でボタンの種類を判別しています。
	SteamVR_Controller.ButtonMask同様の名前でButtonMaskがあるのでそちらを利用してください。

	第一引数にController型を利用する場合

	        if (ViveInput.GetTouchDown(Controller.Right, ButtonMask.Trigger))
       		{
        		Debug.Log("右コントローラのトリガーを浅く引いた");
        	}

	第一引数にGameObject型を利用する場合(この場合"Controller (right)"にスクリプトをアサインしているものとします。)

		if(ViveInput.GetTouchDown(gameObject, ButtonMask.Trigger)){
			Debug.Log("右コントローラのトリガーを浅く引いた");
		}

ViveInput.cs

	また、トリガーの押し込み具合、タッチパットの触れている位置を取得する関数も用意しています。
	ともに第一引数にController型、もしくはGameObject型をとります。
	先程と同様、コントローラーの判別に使用しています。
	GameObjectの場合、"Controller (left)"もしくは"Controller (right)"のオブジェクトを指定してください。

	第一引数にController型を利用する場合

		float hoge = ViveInput.GetTriggerValue(Controller.Right);
		Vector2 fuga = ViveInput.GetTouchPos(Controller.Right);

	第一引数にGameObject型を利用する場合

		float hoge = ViveInput.GetTriggerValue(gameObject);
		Vector2 fuga = ViveInput.GetTouchPos(gameObject);

______________________________________________________________________________________________________

static 関数

	public static bool GetTouchDown(Controller controller, ButtonMask key);
		SteamVR_Controller.Device.GetTouchDown;の結果を取得します。
		Controllerで左右指定。ButtonMaskでキー指定。
	public static bool GetTouchDown(GameObject controller, ButtonMask key);
		SteamVR_Controller.Device.GetTouchDown;の結果を取得します。
		controllerにコントローラーのオブジェクトを指定。ButtonMaskでキー指定。
	public static bool GetTouch(Controller controller, ButtonMask key);
		SteamVR_Controller.Device.GetTouch;の結果を取得します。
		Controllerで左右指定。ButtonMaskでキー指定。
	public static bool GetTouch(GameObject controller, ButtonMask key);
		SteamVR_Controller.Device.GetTouch;の結果を取得します。
		controllerにコントローラーのオブジェクトを指定。ButtonMaskでキー指定。
	public static bool GetTouchUp(Controller controller, ButtonMask key);
		SteamVR_Controller.Device.GetTouchUp;の結果を取得します。
		Controllerで左右指定。ButtonMaskでキー指定。
	public static bool GetTouchUp(GameObject controller, ButtonMask key);
		SteamVR_Controller.Device.GetTouchUp;の結果を取得します。
		controllerにコントローラーのオブジェクトを指定。ButtonMaskでキー指定。

	public static bool GetPressDown(Controller controller, ButtonMask key);
		SteamVR_Controller.Device.GetPressDown;の結果を取得します。
		Controllerで左右指定。ButtonMaskでキー指定。
	public static bool GetPressDown(GameObject controller, ButtonMask key);
		SteamVR_Controller.Device.GetPressDown;の結果を取得します。
		controllerにコントローラーのオブジェクトを指定。ButtonMaskでキー指定。
	public static bool GetPress(Controller controller, ButtonMask key);
		SteamVR_Controller.Device.GetPress;の結果を取得します。
		Controllerで左右指定。ButtonMaskでキー指定。
	public static bool GetPress(GameObject controller, ButtonMask key);
		SteamVR_Controller.Device.GetPress;の結果を取得します。
		controllerにコントローラーのオブジェクトを指定。ButtonMaskでキー指定。
	public static bool GetPressUp(Controller controller, ButtonMask key);
		SteamVR_Controller.Device.GetPressUp;の結果を取得します。
		Controllerで左右指定。ButtonMaskでキー指定。
	public static bool GetPressUp(GameObject controller, ButtonMask key);
		SteamVR_Controller.Device.GetPressUp;の結果を取得。
		controllerにコントローラーのオブジェクトを指定。ButtonMaskでキー指定。

	public static float GetTriggerValue(Controller controller);
		SteamVR_Controller.Device.GetAxis(EVRButtonId.k_EButton_SteamVR_Trigger).x;の結果を取得します。
		Controllerで左右指定。
	public static float GetTriggerValue(GameObject controller);
		SteamVR_Controller.Device.GetAxis(EVRButtonId.k_EButton_SteamVR_Trigger).x;の結果を取得します。
		controllerにコントローラーのオブジェクトを指定。

	public static Vector2 GetTouchPos(Controller controller);
		SteamVR_Controller.Device.GetAxis;の結果を取得します。
		Controllerで左右指定。
	public static Vector2 GetTouchPos(Controller controller);
		SteamVR_Controller.Device.GetAxis;の結果を取得します。
		controllerにコントローラーのオブジェクトを指定。
