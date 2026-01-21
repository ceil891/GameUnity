# LAB THỰC HÀNH – CHƯƠNG 3: UNITY SCRIPTING

## Tổng quan
Dự án Unity này implement tất cả các lab trong chương 3, bao gồm:
- Component Lifecycle Debugger
- Vector Movement & Gizmos
- Quaternion Rotation
- Signed Angle (2D/Topdown)
- Observer Pattern (C# Event & UnityEvent)
- Mini Project kết hợp

## 🚀 Quick Start - Interactive Lab System

### Cách 1: Full Interactive Demo (Khuyến nghị)
1. Mở `SampleScene`
2. Tạo Empty GameObject → đặt tên `GameManager`
3. Attach `MiniProject/GameManager.cs`
4. **Play** → Giao diện Lab Selector xuất hiện!
5. Click vào từng button để test từng Lab riêng biệt

### Cách 2: Manual Setup từng Lab
1. Mở `SampleScene`
2. Tạo Empty GameObject → đặt tên `SceneSetup`
3. Attach `MiniProject/SceneSetup.cs`
4. Trong Inspector, assign prefabs hoặc để trống (tự tạo)

### 3. Scripts đã tạo (theo thư mục)
```
Assets/
├── Labs/
│   ├── Lab1_Lifecycle/
│   │   ├── LifecycleLogger.cs
│   │   └── LifecycleDemo.cs
│   │
│   ├── Lab2_VectorMovement/
│   │   └── TopDownMover.cs
│   │
│   ├── Lab3_QuaternionRotation/
│   │   └── TurretController.cs
│   │
│   ├── Lab4_SignedAngle/
│   │   └── TopdownSignedAngle.cs
│   │
│   ├── Lab5_Observer_CSharpEvent/
│   │   ├── PlayerHealth.cs
│   │   ├── HealthUI.cs
│   │   ├── HealthAudio.cs
│   │   └── GameOverManager.cs
│   │
│   ├── Lab6_Observer_UnityEvent/
│   │   └── PlayerHealthUnityEvent.cs
│
├── MiniProject/
│   ├── SceneSetup.cs
│   ├── GameManager.cs
│   ├── TurretDefenseController.cs
│   └── LabTester.cs
```

## 🎮 Interactive Lab System

### Cách sử dụng Lab Selector:
1. **Play game** → Giao diện Lab Selector xuất hiện bên trái
2. **Click button 1-6** để chọn Lab muốn test
3. **Xem instructions** ở panel bên phải
4. **Test tương tác** theo hướng dẫn
5. **Click "Reset/Clear Labs"** để reset

## 🎮 Controls cho từng Lab:

**Lab 1 (Lifecycle):**
- **I**: Instantiate object → Quan sát Awake/OnEnable/Start
- **D**: Destroy object → Quan sát OnDisable/OnDestroy
- **Ctrl+T**: Toggle active → Quan sát OnEnable/OnDisable

**Lab 2 (Vector Movement):**
- **WASD**: Di chuyển → Quan sát normalized movement
- Xem **Gizmos** trong Scene view

**Lab 3 (Quaternion Rotation):**
- Turret tự xoay theo player
- **T**: Toggle smooth/snap rotation

**Lab 4 (Signed Angle):**
- Di chuyển chuột → Player xoay theo
- Xem góc hiển thị trên UI

**Lab 5 (Observer Pattern C#):**
- **H**: Take damage → UI/Audio/GameOver phản ứng

**Lab 6 (Observer Pattern UnityEvent):**
- Check Inspector để xem UnityEvent bindings

---

## Chi tiết từng Lab

### Lab 1 – Component Lifecycle Debugger
**Scripts**: `Labs/Lab1_Lifecycle/LifecycleLogger.cs` + `Labs/Lab1_Lifecycle/LifecycleDemo.cs`

**Functions logged**: Awake, OnEnable, Start, Update, FixedUpdate, LateUpdate, OnDisable, OnDestroy

**Test**:
- Nhấn `I` để Instantiate object → Quan sát Awake/OnEnable/Start
- Nhấn `D` để Destroy object → Quan sát OnDisable/OnDestroy
- Nhấn `Ctrl+T` để Toggle active → Quan sát OnEnable/OnDisable

**Deliverable**: Ảnh/video Console log cho 3 trường hợp trên.

### Lab 2 – Vector Movement & Gizmos
**Script**: `Labs/Lab2_VectorMovement/TopDownMover.cs`

**Features**: WASD input, vector normalization, Rigidbody2D physics, Gizmos visualization

**Test**:
- Nhấn WASD để di chuyển → Quan sát movement
- Quan sát Gizmos (mũi tên xanh) hiển thị hướng di chuyển trong Scene view

**Normalize giải thích**:
- Vector thô khi W+D: (1,1) → độ dài √2 ≈ 1.41
- Vector normalized: (0.707, 0.707) → độ dài 1
- Kết quả: tốc độ chéo = tốc độ thẳng

**Deliverable**: Scene chạy + ảnh giải thích normalize.

### Lab 3 – Quaternion Rotation
**Script**: `Labs/Lab3_QuaternionRotation/TurretController.cs`

**Methods**: LookAt (direct), RotateTowards/Slerp (smooth)

**Test**:
- Turret xoay nhìn Player tự động
- Nhấn `T` để toggle giữa smooth (Slerp) và snap (LookAt)
- Nhấn `1` để toggle turret target on/off

**Deliverable**: Clip demo 2 chế độ xoay.

### Lab 4 – Signed Angle (2D/Topdown)
**Script**: `Labs/Lab4_SignedAngle/TopdownSignedAngle.cs`

**Features**: Vector2.SignedAngle, UI display, mouse/target tracking

**Test**:
- Di chuyển chuột → player xoay theo
- Nhấn `2` để toggle giữa mouse và target mode
- Quan sát góc hiển thị trên UI (độ)

**Deliverable**: Scene + ảnh UI góc.

### Lab 5 – Observer Pattern (C# Event)
**Scripts**: `Labs/Lab5_Observer_CSharpEvent/PlayerHealth.cs` (Subject), `HealthUI.cs`, `HealthAudio.cs`, `GameOverManager.cs` (Observers)

**Events**: OnHealthChanged, OnDeath

**Test**:
- Nhấn `H` → TakeDamage(10) → UI giảm, audio phát
- Nhấn `J` → Heal(10) → UI tăng
- Chết (health=0) → GameOver panel hiện

**Deliverable**: Video demo H key hoạt động.

### Lab 6 – Observer Pattern (UnityEvent)
**Script**: `Labs/Lab6_Observer_UnityEvent/PlayerHealthUnityEvent.cs`

**Features**: UnityEvent onHealthChanged, onDeath, Inspector binding

**Setup**: Thay `PlayerHealth.cs` bằng `PlayerHealthUnityEvent.cs`, drag components vào Inspector

**Deliverable**: Ảnh Inspector binding + demo.

---

## 📦 Features
- ✅ Auto scene setup - không cần manual configuration
- ✅ Tất cả scripts có comment giải thích
- ✅ UI hoàn chỉnh (Health bar, Angle display, Game Over)
- ✅ Gizmos hiển thị hướng di chuyển
- ✅ Console logging cho lifecycle
- ✅ Audio feedback (có thể add sound files)
- ✅ Responsive controls

## 🔧 Customization
- Sửa `SceneSetup.cs` để thay đổi vị trí, màu sắc, kích thước
- Thêm sound files vào `HealthAudio.cs` cho hit/death sounds
- Modify `TurretController.cs` để thay đổi tốc độ xoay
- Tùy chỉnh UI trong `SceneSetup.cs` SetupUI()

---

**Ready to test!** Mở Unity → Play → Enjoy all labs in one scene! 🎮