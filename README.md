# 桌面菜单插件

gitee:https://gitee.com/kaiouyang-sn/DesktopMenu

github:[](https://github.com/851039536/DesktopMenu)

## 功能实现

已实现功能如下

- 自定义工具菜单
- 自定义桌面图标
- zip文件上传
- zip文件下载
- 自定义程序启动
- 开关桌面音频
- 网站快捷导航
- 快捷卸载
- 工具配置
- 系统配置



## 桌面功能注册

1. 如果MechTE_ContextMenu.dll生成32位 , RegAsm.exe就要使用32 , 64位同理, 在Debug目录中替换RegAsm
2. 在debug路径下找到注册.bat , 使用管理员运行 , 显示成功注册即可

 ![image-20231130170332492](http://kai.snblogs.cn/typora/image-20231130170332492.png)

在桌面中右键可查看到

 ![image-20231130170838233](http://kai.snblogs.cn/typora/image-20231130170838233.png)



## 自定义工具菜单

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



## zip上传下载



## 卸载