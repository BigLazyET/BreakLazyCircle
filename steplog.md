# 日志

## 20240623
1. 新建项目，拖入Sprites资源，并进行Sprites Editor编辑（可以自己手动编辑或者用自定义个菜单工具自动编辑：EditorHelper->SliceSprites）
2. 利用 Tile Palette进行构建当前场景地图，采用Rule Tile, Advanced Rule Tile工具，但是无法满足强行翻转绘制tile的功能，所以加入了CustomRuleTile的实现

## 20240628
1. 重新认识Rule Tile，CustomRule的实现标记成[Obsolete]，还是采用原生的功能
2. 创建各个图层的Tilemap，并设置Sorting Layers
3. 粗略的绘制地图
4. 创建一个MenuItem，用于切分sprites: EditHelper -> (New)SliceSprites
5. 问题：sprite的pivot设置影响从Palette中选择sprite进行绘制的时候，在所处的单元格是不是能紧贴的问题！
> Tips: 选择sprite绘制地图时，可以按键盘上的 [键 进行旋转sprite，按shift+[建可以镜像旋转，特别有用！！！

## 20240629
 1. 给Platforms加上刚体2D，Tilemap碰撞器2D(设置为Used By Composite)，Composite碰撞器2D
> Tips: Used By Composite -> tilemap所有的tile瓦片就被视作一个整体: 这样做可以带来
性能优化：

* TilemapCollider2D 会为每个单独的 Tile 创建一个碰撞体。这意味着如果你的 Tilemap 有大量的 Tile，物理引擎需要处理大量的小碰撞体，可能会导致性能问题。
* CompositeCollider2D 会将多个相邻的 Tile 碰撞体合并成一个或几个更大的碰撞体，从而减少物理引擎需要处理的碰撞体数量，提高性能。
简化碰撞体管理。
* 当使用 CompositeCollider2D 时，所有的 Tile 碰撞体会被合并成一个整体碰撞体，这使得碰撞体的管理更加简单。
这样做也可以避免一些由于 Tile 边界引起的复杂碰撞问题，使得物理引擎处理碰撞更为顺畅。
* 减少边缘效应：
如果不使用 CompositeCollider2D，每个 Tile 都有自己的碰撞体，物体在移动时可能会卡在 Tile 的边缘。
CompositeCollider2D 通过合并碰撞体，可以减少或消除这些边缘效应，使得物体在移动时更加平滑。

> Tips: 刚体2D 类型设置为Static：不受物理模拟影响

> Tips: 创建一个material, shader: Sprites/Default，勾选Tint; 将这个material拖到Platform tilemap的Tilemap Renderer的Material中
这个材料用来修复运行时，tilemap中各个tile直接的间隙的，特别有用！！！
2. 利用Input System来创建Player的Input Action，并设置好Action Map: Gameplay|UI，以及Control Scheme: Gamepad|Keyboard
3. 给用户加上Player Input组件，并将2创建的Input Action拖到组件的Actions属性中去
4. 创建PlayerInputHandler.cs来处理用户输入事件（具体看类的注释）
tips: 如何解决csharp代码在unity editor的inspector面板中 中文乱码的问题：大概率由于VS默认新建脚本编码为GB2312而不是UTF-8，解决方案：在vs项目根目录下新建.editorconfig文件，并配置（如下）后重新打开即可
```
# top-most EditorConfig file
root = true

# All files
[*]
charset = utf-8
```

## 20240701
1. 创建Animations和AnimationControllers，附带着重命名sprites，以更好的标记哪些sprite是用作哪些Animation的
> Animation窗口可以点击最后竖着的三个点，标记显示出Sample Rate，以用来调整采样率 
* 24 FPS：适用于电影级别的动画，通常用于电影和高质量动画。
* 30 FPS：游戏中常用的采样率，适用于大多数情况。
* 60 FPS：高帧率动画，适用于需要非常平滑的动画效果。
2. 导入已打包好了的unity package: behaviour-tree-editor
[Unity Behavior Tree](https://www.thekiwicoder.com/behaviour-tree)
> Assets -> Import Package -> Custom Package

## 20240707
行为树设计

## 20240708
CoreComponent

## 20240709
1. 编辑器模式下，默认情况不会调用Awake和Start方法的
> 可以给类添加[ExecuteInEditMode] attribute来确保Awake和Start方法在编辑器模式下也能被调用

<font color="red">这个解释了在OnDrawGizmosSelected和OnDrawGizmos方法里获取父组件为null的情形（因为一般获取父组件在Awake和Start方法中，而编辑器模式-场景模式下这两个方法不会被调用，所以父组件永远为null）</font>

2. Layer和Sorting Layer的区别
* Layer：用于物理交互、碰撞检测、摄像机渲染和光照管理
    * 碰撞检测：通过 Layer，你可以控制哪些对象可以相互碰撞。例如，可以设置玩家角色只与敌人和地形碰撞，而不与背景碰撞
    * 摄像机渲染：你可以设置摄像机只渲染特定 Layer 的对象。例如，可以创建一个 UI 层，只让 UI 摄像机渲染这个层
    * 光照和阴影：可以通过 Layer 控制哪些对象受到光照影响或投射阴影
* Sorting Layer：用于控制 2D 对象的渲染顺序，决定了哪些对象在渲染时显示在前面，哪些显示在后面

3. 场景中角色前面有一个闪电的标记
> 可以通过在场景视图的右上角，点击 General 菜单，调整3D Icons的配置来消除

4. 如何决定组件之间的依赖顺序
* 使用 Script Execution Order，选择 Edit > Project Settings > Script Execution Order
* 在 Awake 和 Start 方法中初始化
* 使用事件或委托

5. 脚本执行顺序
* 使用[DefaultExecutionOrder] attribute
* 创建一个自定义属性 ExecutionOrderAttribute，用于标记组件的执行顺序 