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