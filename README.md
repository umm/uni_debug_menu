# UniDebugMenu

* see also: https://github.com/baba-s/uni-debug-menu

## Requirement

* Unity 2018

## Install

```shell
yarn add github:umm/uni_debug_menu
```

## Usage
### Open Debug Scene
* 初期化Sceneの任意のGameObjectに `Assets/Scripts/InitializeDebugMenuBehaviour` をアタッチする
* BuildSettings に `Assets/Scenes/UniDebugMenuScene` シーンを追加する

### Custom Debug Scene
* `Assets/Scripts/UniDebugMenu/ContentsListCreator/*` にデバッグシーン内に表示する項目の設定が存在する
* `Assets/Scripts/UniDebugMenu/ContentsListCreator/TopListCreator` にて表示項目を指定する
