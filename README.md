# 菜单插件

gitee:https://gitee.com/kaiouyang-sn/DesktopMenu

github:[github](https://github.com/851039536/DesktopMenu)

## 功能实现

已实现功能:

- 自定义工具菜单
- 自定义桌面图标
- zip文件上传
- zip文件下载
- 自定义程序启动
- 网站导航

## 菜单注册

`RegAsm.exe` 是 .NET Framework 中的一个工具，用于将 .NET 程序集（通常是 DLL 或 EXE 文件）注册到 COM 互操作层，以便非 .NET 应用程序可以使用它们。`RegAsm.exe` 有 32 位和 64 位版本，取决于您想注册的程序集是 32 位还是 64 位。



1. 如果您的 `MechTE_ContextMenu.dll` 是 32 位的，那么您应该使用 32 位的 `RegAsm.exe`。同理，如果 `MechTE_ContextMenu.dll` 是 64 位的，那么您应该使用 64 位的 `RegAsm.exe`
2. 在 `debug` 路径下找到了一个名为 `注册.bat` 的批处理文件 , 使用管理员运行 , 显示成功注册即可

 ![image-20231130170332492](http://kai.snblogs.cn/typora/image-20231130170332492.png)

   3.在桌面中右键可查看到

 ![image-20231130170838233](http://kai.snblogs.cn/typora/image-20231130170838233.png)



## 自定义菜单

SW系统工具配置

 ![image-20231130171208432](http://kai.snblogs.cn/typora/image-20231130171208432.png)

以上图示

左边为固定选项(**如需更改名称,前往MechTE项目中更改生成**) , 右边位自定义功能区 

### 新增启动项

我们单击右边的配置按钮

```
dw.png,功能集合,SystemFunctionList
hfp.png,录音装置,EnterHfp
A2DP.png,播放装置,EnterA2DP
Config.png,配置,SystemConfig
de.png,卸载,unload
```

释义如下:

```
图片,菜单名,启动函数
dw.png,功能集合,SystemFunctionList
```

- 图片 : 默认在image文件中格式位xx.png

- 菜单名 : 写test就显示test

- 启动函数 : 如我配置EnterHfp , 那么我们在写功能时Program.args传入就是EnterHfp 

      ![image-20231130172014857](http://kai.snblogs.cn/typora/image-20231130172014857.png)

  

### 自定义桌面图标

把图片dw.png放在image文件中后配置如下即可

```
dw.png,功能集合,SystemFunctionList
```

 ![image-20231130172247886](http://kai.snblogs.cn/typora/image-20231130172247886.png)

## 快捷导航

规划中...

## 文件上传

### 七牛云

实现七牛云api文件上传

## 卸载

问题点: 程序执行卸载  , 会黑屏 , 需手动卸载一遍