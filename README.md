
> LCM is a set of libraries and tools for message passing and data marshalling, targeted at real-time systems where high-bandwidth and low latency are critical. It provides a publish/subscribe message passing model and automatic marshalling/unmarshalling code generation with bindings for applications in a variety of programming languages.

## LCM源码编译
- [lcm-proj/lcm](https://github.com/lcm-proj/lcm)
- LCM在Linux环境下的安装十分的简单，但是在windows环境中，由于众嗦周知的原因，需要配置各种环境，较为繁琐，可以参考下面这篇博客：[LCM通信包在Windows 64位环境下的编译](https://blog.csdn.net/weixinhum/article/details/81354061)

- 如果每次使用LCM都要从源码进行编译，显然这是一种非常愚蠢的做法，因此我已经把编译好的dll文件放在[我的GitHub](https://github.com/lhcstation/LCM-DLL)上面了，里面包含C++版本的dll和一个C#版本的dll，直接拿来用就可以了。

![](https://raw.githubusercontent.com/lhcstation/Picgo-imgs/main/img/fuckWINDOWS.jpg)

## Visual Studio配置
- 如果是从源码进行的编译，会在lcm根目录下生成build文件夹，里面是已经配置好的各种示例工程

- 如果不是从源码进行编译，直接使用预先编译好的dll，则可以参考GitHub仓库中`build`文件夹中VS的配置方式，主要使用`lcm-listener`、`lcm-sender`、`lcm-gen`这三个工程

![](https://raw.githubusercontent.com/lhcstation/Picgo-imgs/main/img/lcmConfig01.png)


![](https://raw.githubusercontent.com/lhcstation/Picgo-imgs/main/img/lcmConfig02.png)


![](https://raw.githubusercontent.com/lhcstation/Picgo-imgs/main/img/lcmConfig03.png)

## VISSIM-DriverModel.DLL
- 建议从VISSIM官方给出的DriverModel模板入手，进行开发；一个可以参考的例子是[lhcstation/LCM-DLL](https://github.com/lhcstation/LCM-DLL/tree/main/DriverModel_DLL)

- 需要定义数据模板，即在`lcm-gen`文件夹根目录下新建文件`example_t.lcm`，并配置数据类型，一个示例如下：

```c
package exlcm;
struct example_t
{
    int8_t velID;
    double time;
    double velFrontcoorX;
    double velFrontcoorY;
    double velEndcoorX;
    double velEndcoorY;
}
```

- 随后执行`lcm-gen -x example_t.lcm`，若使用VS，则添加控制台命令`-x example_t.lcm`，运行后会在当前文件夹生成一个`exlcm/example_t.hpp`文件

- 发送端VISSIM-dll提供一个可行的参考示例：[LCM-DLL/DriverModel_DLL/DriverModel.cpp](https://github.com/lhcstation/LCM-DLL/blob/main/DriverModel_DLL/DriverModel.cpp)

> **⚠** 请将[lhcstation/LCM-DLL](https://github.com/lhcstation/LCM-DLL/tree/main/CPP_dll)文件夹中所有dll文件放置到本机`C:\Windows\System32`文件夹下，在编译生成`DroverModel.dll`，否则VISSIM会提示如下错误：

![](https://raw.githubusercontent.com/lhcstation/Picgo-imgs/main/img/lcmERROR1.jpg)


## U3D接收端（基于C#）
- 首先需要编译C#版的`.dll`以供`.cs`调用，提供一个可用的dll：[LCM-DLL/Csharp_dll](https://github.com/lhcstation/LCM-DLL/tree/main/Csharp_dll)

- 将`.dll`放置在`Assets/Plugins/`内，并在需要调用的`.cs`脚本中引用`using LCM; using LCM.LCM;`，提供一个可用的参考[LCM-DLL/Csharp-listener/lcm-server/Program.cs](https://github.com/lhcstation/LCM-DLL/blob/main/Csharp-listener/lcm-server/Program.cs)

## 通信速度

![](https://raw.githubusercontent.com/lhcstation/Picgo-imgs/main/img/lcm-result.jpg)


#### enjoy it 😀