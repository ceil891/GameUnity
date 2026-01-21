using UnityEngine;
using UnityEngine.UI;

public class LabSelector : MonoBehaviour
{
    public Button[] labButtons;
    public GameObject[] labPanels;
    public Text instructionText;

    private int currentLab = 0;
    private GameObject[] labObjects;

    void Start()
    {
        labObjects = new GameObject[6];

        // Setup button listeners
        for (int i = 0; i < labButtons.Length && i < 6; i++)
        {
            int labIndex = i;
            labButtons[i].onClick.AddListener(() => SelectLab(labIndex + 1));
        }

        // Show initial instructions
        UpdateInstructions();
    }

    void Update()
    {
        // Lab-specific controls
        HandleLabControls();
    }

    void SelectLab(int labNumber)
    {
        currentLab = labNumber;

        // Hide all panels
        foreach (var panel in labPanels)
        {
            if (panel != null) panel.SetActive(false);
        }

        // Show selected lab panel
        if (labNumber <= labPanels.Length && labPanels[labNumber - 1] != null)
        {
            labPanels[labNumber - 1].SetActive(true);
        }

        // Cleanup previous lab
        CleanupLab();

        // Setup new lab
        SetupLab(labNumber);

        UpdateInstructions();
    }

    void SetupLab(int labNumber)
    {
        switch (labNumber)
        {
            case 1:
                SetupLab1();
                break;
            case 2:
                SetupLab2();
                break;
            case 3:
                SetupLab3();
                break;
            case 4:
                SetupLab4();
                break;
            case 5:
                SetupLab5();
                break;
            case 6:
                SetupLab6();
                break;
        }
    }

    void CleanupLab()
    {
        // Destroy all lab objects
        for (int i = 0; i < labObjects.Length; i++)
        {
            if (labObjects[i] != null)
            {
                Destroy(labObjects[i]);
                labObjects[i] = null;
            }
        }
    }

    void SetupLab1()
    {
        // Lab 1: Component Lifecycle Debugger
        GameObject lifecycleObj = new GameObject("LifecycleTestObject");
        lifecycleObj.AddComponent(typeof(LifecycleLogger));

        // Add sprite for visibility
        var spriteRenderer = lifecycleObj.AddComponent<SpriteRenderer>();
        Texture2D texture = new Texture2D(32, 32);
        Color[] colors = new Color[32 * 32];
        for (int i = 0; i < colors.Length; i++) colors[i] = Color.red;
        texture.SetPixels(colors);
        texture.Apply();
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f));
        spriteRenderer.sprite = sprite;

        labObjects[0] = lifecycleObj;
    }

    void SetupLab2()
    {
        // Lab 2: Vector Movement & Gizmos
        GameObject player = new GameObject("Player_Lab2");
        player.AddComponent<Rigidbody2D>().gravityScale = 0;
        player.AddComponent(typeof(TopDownMover));

        // Add sprite
        var spriteRenderer = player.AddComponent<SpriteRenderer>();
        Texture2D texture = new Texture2D(32, 32);
        Color[] colors = new Color[32 * 32];
        for (int i = 0; i < colors.Length; i++) colors[i] = Color.blue;
        texture.SetPixels(colors);
        texture.Apply();
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f));
        spriteRenderer.sprite = sprite;

        labObjects[1] = player;
    }

    void SetupLab3()
    {
        // Lab 3: Quaternion Rotation
        // Player
        GameObject player = new GameObject("Player_Lab3");
        var playerSprite = player.AddComponent<SpriteRenderer>();
        Texture2D playerTex = new Texture2D(32, 32);
        Color[] playerColors = new Color[32 * 32];
        for (int i = 0; i < playerColors.Length; i++) playerColors[i] = Color.blue;
        playerTex.SetPixels(playerColors);
        playerTex.Apply();
        Sprite playerSpriteObj = Sprite.Create(playerTex, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f));
        playerSprite.sprite = playerSpriteObj;
        player.transform.position = new Vector3(-2, 0, 0);

        // Turret
        GameObject turret = new GameObject("Turret_Lab3");
        var turretController = turret.AddComponent(typeof(TurretController)) as TurretController;
        turretController.target = player.transform;
        turretController.smooth = true; // Start with smooth mode

        var turretSprite = turret.AddComponent<SpriteRenderer>();
        Texture2D turretTex = new Texture2D(32, 32);
        Color[] turretColors = new Color[32 * 32];
        for (int i = 0; i < turretColors.Length; i++) turretColors[i] = Color.red;
        turretTex.SetPixels(turretColors);
        turretTex.Apply();
        Sprite turretSpriteObj = Sprite.Create(turretTex, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f));
        turretSprite.sprite = turretSpriteObj;

        labObjects[2] = player;
        labObjects[3] = turret;
    }

    void SetupLab4()
    {
        // Lab 4: Signed Angle
        GameObject player = new GameObject("Player_Lab4");
        player.AddComponent<Rigidbody2D>().gravityScale = 0;

        var angleScript = player.AddComponent(typeof(TopdownSignedAngle)) as TopdownSignedAngle;
        angleScript.useMouse = true;

        // Add sprite
        var spriteRenderer = player.AddComponent<SpriteRenderer>();
        Texture2D texture = new Texture2D(32, 32);
        Color[] colors = new Color[32 * 32];
        for (int i = 0; i < colors.Length; i++) colors[i] = Color.green;
        texture.SetPixels(colors);
        texture.Apply();
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f));
        spriteRenderer.sprite = sprite;

        // Create UI for angle display
        CreateAngleUI(angleScript);

        labObjects[4] = player;
    }

    void CreateAngleUI(TopdownSignedAngle angleScript)
    {
        // Create Canvas
        GameObject canvasGO = new GameObject("Canvas_Lab4");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Create Text
        GameObject textGO = new GameObject("AngleText");
        textGO.transform.SetParent(canvasGO.transform);
        Text angleText = textGO.AddComponent<Text>();
        angleText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        angleText.fontSize = 24;
        angleText.color = Color.black;
        angleText.alignment = TextAnchor.MiddleCenter;
        angleText.text = "Angle: 0°";

        RectTransform rectTransform = textGO.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(200, 50);
        rectTransform.anchoredPosition = new Vector2(0, 200);

        angleScript.angleText = angleText;
    }

    void SetupLab5()
    {
        // Lab 5: Observer Pattern (C# Events)
        GameObject player = new GameObject("Player_Lab5");
        var health = player.AddComponent(typeof(PlayerHealth)) as PlayerHealth;

        // Add sprite
        var spriteRenderer = player.AddComponent<SpriteRenderer>();
        Texture2D texture = new Texture2D(32, 32);
        Color[] colors = new Color[32 * 32];
        for (int i = 0; i < colors.Length; i++) colors[i] = Color.magenta;
        texture.SetPixels(colors);
        texture.Apply();
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f));
        spriteRenderer.sprite = sprite;

        // Create UI observers
        CreateHealthUI(health);

        labObjects[5] = player;
    }

    void CreateHealthUI(PlayerHealth playerHealth)
    {
        // Create Canvas
        GameObject canvasGO = new GameObject("Canvas_Lab5");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Create Health Slider
        GameObject sliderGO = new GameObject("HealthSlider");
        sliderGO.transform.SetParent(canvasGO.transform);
        Slider healthSlider = sliderGO.AddComponent<Slider>();
        healthSlider.minValue = 0;
        healthSlider.maxValue = 100;
        healthSlider.value = 100;

        // Background
        GameObject bgGO = new GameObject("Background");
        bgGO.transform.SetParent(sliderGO.transform);
        Image bgImage = bgGO.AddComponent<Image>();
        bgImage.color = Color.gray;
        RectTransform bgRect = bgGO.GetComponent<RectTransform>();
        bgRect.sizeDelta = new Vector2(200, 20);

        // Fill Area
        GameObject fillArea = new GameObject("Fill Area");
        fillArea.transform.SetParent(sliderGO.transform);

        GameObject fill = new GameObject("Fill");
        fill.transform.SetParent(fillArea.transform);
        Image fillImage = fill.AddComponent<Image>();
        fillImage.color = Color.green;
        RectTransform fillRect = fill.GetComponent<RectTransform>();
        fillRect.sizeDelta = new Vector2(200, 20);

        healthSlider.fillRect = fillRect;
        healthSlider.targetGraphic = fillImage;

        RectTransform sliderRect = sliderGO.GetComponent<RectTransform>();
        sliderRect.sizeDelta = new Vector2(200, 20);
        sliderRect.anchoredPosition = new Vector2(0, 150);

        // Create Health Text
        GameObject textGO = new GameObject("HealthText");
        textGO.transform.SetParent(canvasGO.transform);
        Text healthText = textGO.AddComponent<Text>();
        healthText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        healthText.fontSize = 18;
        healthText.color = Color.black;
        healthText.text = "100/100";
        RectTransform textRect = textGO.GetComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(200, 30);
        textRect.anchoredPosition = new Vector2(0, 120);

        // Create HealthUI observer
        GameObject uiObserver = new GameObject("HealthUI_Observer");
        var healthUI = uiObserver.AddComponent(typeof(HealthUI)) as HealthUI;
        healthUI.playerHealth = playerHealth;
        healthUI.healthSlider = healthSlider;
        healthUI.healthText = healthText;

        // Create GameOver observer
        GameObject gameOverObserver = new GameObject("GameOver_Observer");
        var gameOverManager = gameOverObserver.AddComponent(typeof(GameOverManager)) as GameOverManager;
        gameOverManager.playerHealth = playerHealth;

        // Create Game Over Panel
        GameObject gameOverPanel = new GameObject("GameOverPanel");
        gameOverPanel.transform.SetParent(canvasGO.transform);
        gameOverPanel.SetActive(false);

        Image panelImage = gameOverPanel.AddComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 0.8f);

        GameObject textPanelGO = new GameObject("GameOverText");
        textPanelGO.transform.SetParent(gameOverPanel.transform);
        Text gameOverText = textPanelGO.AddComponent<Text>();
        gameOverText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        gameOverText.fontSize = 36;
        gameOverText.color = Color.red;
        gameOverText.text = "GAME OVER - LAB 5";
        gameOverText.alignment = TextAnchor.MiddleCenter;

        RectTransform panelRect = gameOverPanel.GetComponent<RectTransform>();
        panelRect.sizeDelta = new Vector2(400, 200);
        panelRect.anchoredPosition = Vector2.zero;

        RectTransform textPanelRect = textPanelGO.GetComponent<RectTransform>();
        textPanelRect.sizeDelta = new Vector2(400, 50);
        textPanelRect.anchoredPosition = Vector2.zero;

        gameOverManager.gameOverUI = gameOverPanel;
    }

    void SetupLab6()
    {
        // Lab 6: Observer Pattern (UnityEvent)
        GameObject player = new GameObject("Player_Lab6");
        var health = player.AddComponent(typeof(PlayerHealthUnityEvent)) as PlayerHealthUnityEvent;

        // Add sprite
        var spriteRenderer = player.AddComponent<SpriteRenderer>();
        Texture2D texture = new Texture2D(32, 32);
        Color[] colors = new Color[32 * 32];
        for (int i = 0; i < colors.Length; i++) colors[i] = Color.cyan;
        texture.SetPixels(colors);
        texture.Apply();
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f));
        spriteRenderer.sprite = sprite;

        labObjects[6] = player;

        Debug.Log("Lab 6: Check Inspector for UnityEvent bindings!");
    }

    void HandleLabControls()
    {
        switch (currentLab)
        {
            case 1:
                // Lab 1 controls
                if (Input.GetKeyDown(KeyCode.I))
                {
                    if (labObjects[0] == null)
                    {
                        SetupLab1();
                    }
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (labObjects[0] != null)
                    {
                        Destroy(labObjects[0]);
                        labObjects[0] = null;
                    }
                }
                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.T))
                {
                    if (labObjects[0] != null)
                    {
                        labObjects[0].SetActive(!labObjects[0].activeSelf);
                    }
                }
                break;

            case 3:
                // Lab 3: Toggle smooth mode
                if (Input.GetKeyDown(KeyCode.T) && labObjects[3] != null)
                {
                    var turretController = labObjects[3].GetComponent<TurretController>();
                    if (turretController != null)
                    {
                        turretController.smooth = !turretController.smooth;
                        Debug.Log("Turret smooth mode: " + turretController.smooth);
                    }
                }
                break;

            case 5:
                // Lab 5: Take damage
                if (Input.GetKeyDown(KeyCode.H) && labObjects[5] != null)
                {
                    var health = labObjects[5].GetComponent<PlayerHealth>();
                    if (health != null)
                    {
                        health.TakeDamage(10);
                        Debug.Log("Took 10 damage. Health: " + health.currentHealth);
                    }
                }
                break;
        }
    }

    void UpdateInstructions()
    {
        string instructions = "Select a Lab to test:\n\n";

        switch (currentLab)
        {
            case 0:
                instructions += "Click buttons 1-6 to select Lab\n";
                instructions += "Each lab will setup its own demo scene";
                break;
            case 1:
                instructions += "Lab 1: Component Lifecycle Debugger\n";
                instructions += "I: Instantiate | D: Destroy | Ctrl+T: Toggle Active\n";
                instructions += "Watch Console for lifecycle logs!";
                break;
            case 2:
                instructions += "Lab 2: Vector Movement & Gizmos\n";
                instructions += "WASD: Move player | See gizmos in Scene view\n";
                instructions += "Notice normalized movement prevents faster diagonal speed";
                break;
            case 3:
                instructions += "Lab 3: Quaternion Rotation\n";
                instructions += "Turret follows player | T: Toggle smooth/snap\n";
                instructions += "Compare LookAt vs Slerp rotation";
                break;
            case 4:
                instructions += "Lab 4: Signed Angle (2D/Topdown)\n";
                instructions += "Move mouse to rotate player | See angle on UI\n";
                instructions += "SignedAngle provides correct rotation direction";
                break;
            case 5:
                instructions += "Lab 5: Observer Pattern (C# Events)\n";
                instructions += "H: Take damage | Watch UI/Audio/GameOver react\n";
                instructions += "Multiple observers respond to health changes";
                break;
            case 6:
                instructions += "Lab 6: Observer Pattern (UnityEvent)\n";
                instructions += "Check Inspector for UnityEvent bindings\n";
                instructions += "Visual event binding in Unity Editor";
                break;
        }

        if (instructionText != null)
        {
            instructionText.text = instructions;
        }
    }

    public void ResetLabs()
    {
        currentLab = 0;
        CleanupLab();

        foreach (var panel in labPanels)
        {
            if (panel != null) panel.SetActive(false);
        }

        UpdateInstructions();
    }
}